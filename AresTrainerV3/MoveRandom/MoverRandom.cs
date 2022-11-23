using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom
{
    public abstract class MoverRandom : ExpBotManagerAbstract, IMoveToPositon
    {
        int _lastMouseMovePosition = 0;
        int _lastPositionAfterBounce = 0;
        int _incrementalRandomizer = 0;
        bool tooLowDistance = false;
        Random randomizer = new Random();
        MoveRandomPositions positionsToMove = new MoveRandomPositions();
        protected abstract int moveOnlyOnMapX
        {
            get;
        }
        protected abstract Tuple<int, int, int, int> DirectionsLimts
        {
            get;
        }

        int moveClickSlower = 0;
        int howMuchToSlowClickMove = 2;
        int sideMoveCount = 10;

        public static bool AttackedOrCollected = false;

        public DoScanAttackCollect attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSod()));

        protected IUnstuckPosition unstuckPlace
        {
            get
            {
                return new UnstuckFromAnywhere();
            }
        }

        int MovePositionRandomizer(int i)
        {
            i = randomizer.Next(i - 2, i + 3); // not less then i-2 and not more then i+2
            if (i >= positionsToMove.MovePositionsArray.Length)  // transform if i> length of array
            {
                return i - positionsToMove.MovePositionsArray.Length;
            }
            else if (i < 0)
            {
                return positionsToMove.MovePositionsArray.Length + i; // +i because i is less then 0
            }
            else
            {
                return i;
            }
        }

        void MoveToPosition(int movePositionNr)
        {
                mouseClickToMove(movePositionNr);
        }
        void mouseClickToMove(int movePosNr)
        {
            Thread.Sleep(5);
            MouseOperations.SetCursorPosition(positionsToMove.MovePositionsArray[movePosNr].Item1, positionsToMove.MovePositionsArray[movePosNr].Item2);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(50);
        }

        void MoveToPosRandom()
        {
            if (ProgramHandle.isInCity != 1)
            {
                moveClickSlower++;

                if (moveClickSlower == howMuchToSlowClickMove)
                {
                    tooLowDistance = false;
                    moveClickSlower = 0;
                    if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        if (ExpBotManagerAbstract.isExpBotRunning)
                        {

                            if (!AttackedOrCollected)
                            {
                                if (ProgramHandle.isNowStandingOut())
                                {
                                    tooLowDistance = true;
                                    Debug.WriteLine("TOO LOW DISTANCE");
                                    int a = randomizer.Next(3);
                                    if (a == 0)
                                    {
                                        _lastMouseMovePosition -= 8;
                                    }
                                    else if (a == 1)
                                    {
                                        _lastMouseMovePosition -= 16;
                                    }
                                    else
                                    {
                                        _lastMouseMovePosition -= 24;
                                    }
                                }
                                _lastMouseMovePosition = MovePositionRandomizer(_lastMouseMovePosition);
                            }
                            else
                            {
                                _lastMouseMovePosition = MovePositionRandomizer(_lastMouseMovePosition);
                            }
                            MoveToPosition(_lastMouseMovePosition);
                            if (tooLowDistance)
                            {
                                Thread.Sleep(100);
                            }
                            AttackedOrCollected = false;
                        }
                    }
                    else
                    {
                        Thread.Sleep(5000);
                        if (ProgramHandle.GetCurrentMap != moveOnlyOnMapX)
                        {
                            ExpBotManagerAbstract.RequestStopExpBot();
                            HealBotAbstract.RequestStopHealBot();

                            System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                        }
                    }
                }
            }
        }
        void MoveToPosRandom(int i)
        {
            _lastMouseMovePosition =i;
            MoveToPosRandom();
        }
        void leftLimitBounce()
        {
            if (_lastMouseMovePosition > 16)
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(26, 31));
            }
            else
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(2, 7));
            }
        }
        void rightLimitBounce()
        {
            if (_lastMouseMovePosition > 24)
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(18, 23));
            }
            else
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(10, 15));
            }
        }
        void upLimitBounce()
        {
            if (_lastMouseMovePosition > 8)
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(18, 23));
            }
            else
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(26, 31));
            }
        }
        void downLimitBounce()
        {
            if (_lastMouseMovePosition > 24)
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(2, 7));
            }
            else
            {
                _lastMouseMovePosition = MovePositionRandomizer(randomizer.Next(10, 15));
            }
        }

        public override void RunAndExp()
        {
            ProgramHandle.SetCameraForExpBot();
            ExpBotManagerAbstract.RequestStartExpBot();


            // MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand);
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1 && shutDownOnRepot)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }
                this.MoveAttackCollect();
            }
        }

        public bool MoveAttackCollect()
        {
            while (ExpBotManagerAbstract.isExpBotRunning)
            {        //int maxLimitLeft, int maxUpLimit, int maxRightLimit, int maxDownLimit
                if (ProgramHandle.GetPositionX > DirectionsLimts.Item1 && ProgramHandle.GetPositionX < DirectionsLimts.Item3 && ProgramHandle.GetPositionY < DirectionsLimts.Item2 && ProgramHandle.GetPositionY > DirectionsLimts.Item4)
                {
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODDefault.DoThisWhileMoving()) ;
                    Debug.WriteLine("MainMoveClick");
                    MoveToPosRandom();
                }
                if (ProgramHandle.GetPositionX < DirectionsLimts.Item1)
                {
                    Debug.WriteLine("maxLimitLeft");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODDefault.DoThisWhileMoving());
                    leftLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionX < DirectionsLimts.Item1 && ExpBotManagerAbstract.isExpBotRunning)
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }
                }
                if (ProgramHandle.GetPositionX > DirectionsLimts.Item3)
                {
                    Debug.WriteLine("maxRightLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    // unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODDefault.DoThisWhileMoving());
                    rightLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionX > DirectionsLimts.Item3 && ExpBotManagerAbstract.isExpBotRunning)
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }

                }
                if (ProgramHandle.GetPositionY < DirectionsLimts.Item4)
                {
                    Debug.WriteLine("maxDownLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODDefault.DoThisWhileMoving());
                    downLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionY < DirectionsLimts.Item4 && ExpBotManagerAbstract.isExpBotRunning)
                        {
                            //AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }
                }
                if (ProgramHandle.GetPositionY > DirectionsLimts.Item2)
                {
                    Debug.WriteLine("maxUpLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODDefault.DoThisWhileMoving());
                    upLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if(ProgramHandle.GetPositionY > DirectionsLimts.Item2 && ExpBotManagerAbstract.isExpBotRunning )
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    } 
                 }
                return true;
            }
            return false;
        }
    }
}
