using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public abstract class MoveToPositionAbstract : IMoveToPositon
    {
        const int moveBuffor = 999900000;  /// when it was lower bot was moving up and down all the time - around (10000)
        int moveRandomizer
        {
            get
            {
                Random randomInt = new Random();
                return randomInt.Next(-75, 75);
            }
        }
        protected DoWhileMoving.IDoWhileMoving _attackAndCollectItems;
        protected abstract DoWhileMoving.IDoWhileMoving AttackAndCollectItems { get; }

        void MoveMouseClickNoCheckStanding(int x, int y)
        {
            mouseClickToMove(x, y);
            // Bot Moved only when standing now it moves just so even when not standing
/*            if (ExpBotClass.isNowStandingOut())
            {

                mouseClickToMove(x, y);

            }
*/        }
        static void mouseClickToMove(int x, int y)
        {
            Thread.Sleep(5);
            MouseOperations.SetCursorPosition(x, y);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(50);
        }




        //  Tuple<int, int> MouseClickDirection;

        bool isMoveOnXAxis { get; set; }
        bool isPosIncreasing { get; set; }
        protected IUnstuckPosition unstuckPlace
        {
            get
            {
                return new UnstuckFromAnywhere();
            }
        }
        protected abstract int moveOnlyOnMapX { get; }

        bool sideMove = false;



        bool MoveToPosMouse(int directionLimit, int sideDownOrLeftLimit, int  sideUpOrRightLimit, bool isMainDirection)
        {
            if (isMoveOnXAxis)   // moving left or right
            {
                if (isPosIncreasing)// GO RIGHT
                {
                    while (ProgramHandle.GetPositionX < directionLimit && ExpBotManagerAbstract.isExpBotRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionY < sideUpOrRightLimit && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                        {
                            while (AttackAndCollectItems.DoThisWhileMoving()) ;
                            if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                            {
                                if (isMainDirection)
                                { MoveMouseClickNoCheckStanding(TupleMousePos.MoveRight.Item1 + moveRandomizer, TupleMousePos.MoveRight.Item2 + moveRandomizer); }
                                else
                                { MoveMouseClickNoCheckStanding(TupleMousePos.SideMoveRight.Item1 + moveRandomizer, TupleMousePos.SideMoveRight.Item2 + moveRandomizer); }
                            }
                        }
                        else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Down, sideUpOrRightLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, false);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Up, sideUpOrRightLimit,  ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, false);
                        }
                    }
                    return true;

                }
                else // GO LEFT
                {
                    while (ProgramHandle.GetPositionX > directionLimit && ExpBotManagerAbstract.isExpBotRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();
                        if (ProgramHandle.GetPositionY < sideUpOrRightLimit && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goLeft \n";
                            while (AttackAndCollectItems.DoThisWhileMoving()) ;
                            if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                            {

                                if (isMainDirection)
                                { MoveMouseClickNoCheckStanding(TupleMousePos.MoveLeft.Item1 + moveRandomizer, TupleMousePos.MoveLeft.Item2 + moveRandomizer); }
                                else
                                { MoveMouseClickNoCheckStanding(TupleMousePos.SideMoveLeft.Item1 + moveRandomizer, TupleMousePos.SideMoveLeft.Item2 + moveRandomizer); }

                            }
                        }
                        else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Down, sideUpOrRightLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor,  false);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Up, sideUpOrRightLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, false);
                        }
                    }
                    return true;
                }
            }
            else   // move is not on x axis so it is on Y moving up or down
            {
                if (isPosIncreasing)// GO Up
                {
                    while (ProgramHandle.GetPositionY < directionLimit && ExpBotManagerAbstract.isExpBotRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionX < sideUpOrRightLimit && ProgramHandle.GetPositionX > sideDownOrLeftLimit)
                        {

                            // ExpBotLog += $"goRight \n";
                            while (AttackAndCollectItems.DoThisWhileMoving()) ;
                            if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                            {

                                if (isMainDirection)
                                { MoveMouseClickNoCheckStanding(TupleMousePos.MoveUp.Item1 + moveRandomizer, TupleMousePos.MoveUp.Item2 + moveRandomizer); }
                                else
                                { MoveMouseClickNoCheckStanding(TupleMousePos.SideMoveUp.Item1 + moveRandomizer, TupleMousePos.SideMoveUp.Item2 + moveRandomizer); }

                            }
                        }
                        else if (ProgramHandle.GetPositionX > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Left, sideUpOrRightLimit,  ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, false);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Right, sideDownOrLeftLimit,  ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, false);
                        }
                    }
                    return true;

                }

                else // GO Down
                {
                    while (ProgramHandle.GetPositionY > directionLimit && ExpBotManagerAbstract.isExpBotRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionX < sideUpOrRightLimit && ProgramHandle.GetPositionX > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight \n";
                            while (AttackAndCollectItems.DoThisWhileMoving()) ;
                            if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                            {

                                if (isMainDirection)
                                { MoveMouseClickNoCheckStanding(TupleMousePos.MoveDown.Item1 + moveRandomizer, TupleMousePos.MoveDown.Item2 + moveRandomizer); }
                                else
                                { MoveMouseClickNoCheckStanding(TupleMousePos.SideMoveDown.Item1 + moveRandomizer, TupleMousePos.SideMoveDown.Item2 + moveRandomizer); }
                            }
                        }
                        else if (ProgramHandle.GetPositionX > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Left, sideUpOrRightLimit,  ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, false);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveAttackCollect(DirectionsEnum.Right, sideUpOrRightLimit,  ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, false);
                        }
                    }
                    return true;
                }
            }

        }

        public bool MoveAttackCollect(DirectionsEnum goDierction, int directionLimit, int sideDownOrLeftLimit, int sideUpOrRightLimit , bool isMainDirection)
        {
            if (goDierction == DirectionsEnum.Left)
            {
                isMoveOnXAxis = true;
                isPosIncreasing = false;
                return MoveToPosMouse(directionLimit,  sideDownOrLeftLimit, sideUpOrRightLimit, isMainDirection);
            }
            else if (goDierction == DirectionsEnum.Right)
            {
                isMoveOnXAxis = true;
                isPosIncreasing = true;
                return MoveToPosMouse(directionLimit,  sideDownOrLeftLimit, sideUpOrRightLimit, isMainDirection);
            }
            else if (goDierction == DirectionsEnum.Up)
            {
                isMoveOnXAxis = false;
                isPosIncreasing = true;
                return MoveToPosMouse(directionLimit,  sideDownOrLeftLimit, sideUpOrRightLimit, isMainDirection);
            }
            else // (goDierction == DirectionsEnum.Down)
            {
                isMoveOnXAxis = false;
                isPosIncreasing = false;
                return MoveToPosMouse(directionLimit,  sideDownOrLeftLimit, sideUpOrRightLimit, isMainDirection);
            }
        }
    }
}






































/*public static bool goLeft(int x, int y, int leftLimit, int upLimit, int downLimit, int moveOnlyOnMapX)
{
    while (ProgramHandle.GetPositionX > leftLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
    {

        if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
        {
            ExpBotLog += $"goLeft \n";

            MoveScanAndAttackAncCollect(x + moveRandomizer, y + moveRandomizer);
        }
        if (ProgramHandle.GetPositionY > upLimit)
        {
            ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
            goDown(900 + moveRandomizer, 640 + moveRandomizer, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
        }
        if (ProgramHandle.GetPositionY < downLimit)
        {
            ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
            goUp(962 + moveRandomizer, 430 + moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
        }

    }
    return true;

}
*/