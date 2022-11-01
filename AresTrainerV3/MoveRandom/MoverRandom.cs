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
    public class MoverRandom : IMoveToPositon
    {
        int _lastMouseMovePosition = 0;
        int _lastPositionAfterBounce = 0;
        int _incrementalRandomizer = 0;
        Random randomizer = new Random();
        MoveRandomPositions positionsToMove = new MoveRandomPositions();
        int _moveOnlyOnMapX = 999;
        int moveClickSlower = 0;
        int howMuchToSlowClickMove = 3;
        int sideMoveCount = 50;

        int _posBeforeMoveX = 0;
        int _posBeforeMoveY = 0;
        public static bool AttackedOrCollected = false;

        DoScanAttackCollect attackAndCollectSODAndEvent = new DoScanAttackCollect(new PixelItemCollector(new CollectSod()));

        int MoveOnlyOnMapX
        {
            get
            {
                return _moveOnlyOnMapX;
            }
            set
            {
                _moveOnlyOnMapX = value;
            }
        }
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

        public MoverRandom(int mapNumber)
        {
            MoveOnlyOnMapX = mapNumber;
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
            moveClickSlower++;

            if (moveClickSlower == howMuchToSlowClickMove)
            {
                moveClickSlower =0;
                if (ProgramHandle.GetCurrentMap == MoveOnlyOnMapX)
                {
                    if (!AttackedOrCollected)
                    {
                        if (ProgramHandle.isNowStandingOut())
                        {
                            Debug.WriteLine("!!!!!!!!!!!!!!!!!!! TOO LOW DISTANCE!!!!!!!!!!!!!!!!!!");
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
                    AttackedOrCollected = false;
                }
                else
                {
                    ExpBotManagerAbstract.RequestStopExpBot();
                    HealBotAbstract.RequestStopHealBot();
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


        public bool MoveAttackCollect(DirectionsEnum nothing, int maxLimitLeft, int maxUpLimit, int maxRightLimit, int maxDownLimit)
        {
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.GetPositionX > maxLimitLeft && ProgramHandle.GetPositionX < maxRightLimit && ProgramHandle.GetPositionY < maxUpLimit && ProgramHandle.GetPositionY > maxDownLimit)
                {
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODAndEvent.DoThisWhileMoving()) ;
                    Debug.WriteLine("MainMoveClick");
                    MoveToPosRandom();
                }
                if (ProgramHandle.GetPositionX < maxLimitLeft)
                {
                    Debug.WriteLine("maxLimitLeft");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                    leftLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionX < maxLimitLeft && ExpBotManagerAbstract.isExpBotRunning)
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }
                }
                /*                else if (ProgramHandle.GetPositionX < maxLimitLeft + closeToLimit)
                                {
                                    Debug.WriteLine("closeToLimit Left");
                                    AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                                    unstuckPlace.UnstuckMove();
                                    // while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                                    leftLimitBounce();
                                    MoveToPosRandom();

                                }
                */
                if (ProgramHandle.GetPositionX > maxRightLimit)
                {
                    Debug.WriteLine("maxRightLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    // unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                    rightLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionX > maxRightLimit && ExpBotManagerAbstract.isExpBotRunning)
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }

                }
                /*                else if (ProgramHandle.GetPositionX > maxRightLimit - closeToLimit)
                                {
                                    Debug.WriteLine("closeToLimit Right");
                                    AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                                    unstuckPlace.UnstuckMove();
                                    // while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                                    rightLimitBounce();
                                    MoveToPosRandom();
                                }
                */
                if (ProgramHandle.GetPositionY < maxDownLimit)
                {
                    Debug.WriteLine("maxDownLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                    downLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if (ProgramHandle.GetPositionY < maxDownLimit && ExpBotManagerAbstract.isExpBotRunning)
                        {
                            //AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    }
                }
/*                else if (ProgramHandle.GetPositionY < maxDownLimit + closeToLimit)
                {
                    Debug.WriteLine("closeToLimit Down");
                    AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    unstuckPlace.UnstuckMove();
                    // while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                    downLimitBounce();
                    MoveToPosRandom();
                }
*/                if (ProgramHandle.GetPositionY > maxUpLimit)
                {
                    Debug.WriteLine("maxUpLimit");
                    // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                    //unstuckPlace.UnstuckMove();
                    while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                    upLimitBounce();
                    _lastPositionAfterBounce = _lastMouseMovePosition;

                    for (int i = 0; i < sideMoveCount; i++)
                    {
                        if(ProgramHandle.GetPositionY > maxUpLimit && ExpBotManagerAbstract.isExpBotRunning )
                        {
                           // AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                            MoveToPosRandom(_lastPositionAfterBounce);
                        }
                    } 
                 }
                /*                else if (ProgramHandle.GetPositionY > maxUpLimit - closeToLimit)
                                {
                                    Debug.WriteLine("closeToLimit Up");
                                    AttackedOrCollected = true; // set true to not run distance check cause this runs without scanner and runs too fast
                                    unstuckPlace.UnstuckMove();
                                    // while (attackAndCollectSODAndEvent.DoThisWhileMoving());
                                    upLimitBounce();
                                    MoveToPosRandom();
                                }
                */
                return true;
            }
            return false;
        }
    }
}
