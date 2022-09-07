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
        const int moveBuffor = 99000000;  /// when it was lower bot was moving up and down all the time - around (10000)
        int moveRandomizer
        {
            get
            {
                Random randomInt = new Random();
                return randomInt.Next(-75, 75);
            }
        }

        bool _isMoveToPositonRunning = false;
        public bool isMoveToPositionRunning
        {
            get { return _isMoveToPositonRunning; }
        }
        Tuple<int, int> MouseClickDirection;

        bool isMoveOnXAxis { get; set; }
        bool isPosIncreasing { get; set; }
        protected abstract IUnstuckPosition unstuckPlace { get; }
        protected abstract int moveOnlyOnMapX { get; }

        public void RequestStopMoveToPosition()
        {
            if (_isMoveToPositonRunning)
                _isMoveToPositonRunning = false;
            else
                _isMoveToPositonRunning = true;
        }

        bool MoveToPosMouse(int directionLimit,  int sideUpOrRightLimit, int sideDownOrLeftLimit)
        {
            if (isMoveOnXAxis)   // moving left or right
            {
                if (isPosIncreasing)// GO RIGHT
                {
                    while (ProgramHandle.GetPositionX < directionLimit && isMoveToPositionRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionY < sideUpOrRightLimit && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                        {
                            MouseClickDirection = TupleMousePos.MoveRight;
                            // ExpBotLog += $"goRight \n";
                            ExpBotClass.MoveScanAndAttackAncCollect(MouseClickDirection.Item1 + moveRandomizer, MouseClickDirection.Item2 + moveRandomizer);
                        }
                        else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Down, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Up, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                    }
                    return true;

                }
                else // GO LEFT
                {
                    while (ProgramHandle.GetPositionX > directionLimit && isMoveToPositionRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();
                        if (ProgramHandle.GetPositionY < sideUpOrRightLimit && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goLeft \n";
                            ExpBotClass.MoveScanAndAttackAncCollect(new TupleMousePos().MoveLeft.Item1 + moveRandomizer, new TupleMousePos().MoveLeft.Item2 + moveRandomizer);
                        }
                        else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Down, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Up, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                    }
                    return true;
                }
            }
            else   // move is not on x axis so it is on Y moving up or down
            {
                if (isPosIncreasing)// GO Up
                {
                    while (ProgramHandle.GetPositionY < directionLimit && isMoveToPositionRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionX < sideUpOrRightLimit && ProgramHandle.GetPositionX > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight \n";
                            ExpBotClass.MoveScanAndAttackAncCollect(new TupleMousePos().MoveUp.Item1 + moveRandomizer, new TupleMousePos().MoveUp.Item2 + moveRandomizer);
                        }
                        else if (ProgramHandle.GetPositionX > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Left, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Right, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                    }
                    return true;

                }

                else // GO Down
                {
                    while (ProgramHandle.GetPositionY > directionLimit && isMoveToPositionRunning && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionX < sideUpOrRightLimit && ProgramHandle.GetPositionX > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight \n";
                            ExpBotClass.MoveScanAndAttackAncCollect(new TupleMousePos().MoveDown.Item1 + moveRandomizer, new TupleMousePos().MoveDown.Item2 + moveRandomizer);
                        }
                        else if (ProgramHandle.GetPositionX > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Left, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(DirectionsEnum.Right, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor);
                        }
                    }
                    return true;
                }
            }

        }

        public bool MoveToPosition(DirectionsEnum goDierction, int directionLimit, int sideUpOrRightLimit, int sideDownOrLeftLimit)
        {
            if (goDierction == DirectionsEnum.Left)
            {
                isMoveOnXAxis = true;
                isPosIncreasing = false;
                return MoveToPosMouse(directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit);
            }
            else if (goDierction == DirectionsEnum.Right)
            {
                isMoveOnXAxis = true;
                isPosIncreasing = true;
                return MoveToPosMouse(directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit);
            }
            else if (goDierction == DirectionsEnum.Up)
            {
                isMoveOnXAxis = false;
                isPosIncreasing = true;
                return MoveToPosMouse(directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit);
            }
            else // (goDierction == DirectionsEnum.Down)
            {
                isMoveOnXAxis = false;
                isPosIncreasing = false;
                return MoveToPosMouse(directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit);
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