using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public abstract class MoveToPosition
    {
        int moveRandomizer
        {
            get
            {
                Random randomInt = new Random();
                return randomInt.Next(-75, 75);
            }
        }
        bool _isMoveToPositon = false;
        public bool isMoveToPosition
        {
            get { return _isMoveToPositon; }
        }
        public void RequestStopMoveBot()
        {
            if (_isMoveToPositon)
                _isMoveToPositon = false;
            else
                _isMoveToPositon = true;
        }

        const int moveBuffor = 99000000;  /// when it was lower bot was moving up and down all the time - around (10000)

        protected virtual bool MoveToPosMouse(bool isMoveOnXAxis,bool isPosIcreasing, int directionLimit,  int sideUpOrRightLimit, int sideDownOrLeftLimit,IUnstuckPosition unstuckPlace, int moveOnlyOnMapX)
        {
            if (isMoveOnXAxis)   // moving left or right
            {
                if (isPosIcreasing)// GO RIGHT
                {
                    while (ProgramHandle.GetPositionX < directionLimit && isMoveToPosition && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                    {
                        unstuckPlace.UnstuckMove();

                        if (ProgramHandle.GetPositionY < sideUpOrRightLimit && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight \n";
                            ExpBotClass.MoveScanAndAttackAncCollect(new TupleMousePos().MoveRight.Item1 + moveRandomizer, new TupleMousePos().MoveRight.Item2 + moveRandomizer);
                        }
                        else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                        {
                            // ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosMouse(false, false, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosMouse(false, true, sideDownOrLeftLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                    }
                    return true;

                }
                else // GO LEFT
                {
                    while (ProgramHandle.GetPositionX > directionLimit &&isMoveToPosition && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
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
                            MoveToPosMouse(false, false, sideUpOrRightLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                        else if (ProgramHandle.GetPositionY < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosMouse(false, true, sideDownOrLeftLimit, ProgramHandle.GetPositionX + moveBuffor, ProgramHandle.GetPositionX - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                    }
                    return true;
                }
            }
            else   // move is not on x axis so it is on Y moving up or down
            {
                if (isPosIcreasing)// GO Up
                {
                    while (ProgramHandle.GetPositionY < directionLimit && isMoveToPosition && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
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
                            MoveToPosMouse(true, false, sideUpOrRightLimit, ProgramHandle.GetPositionY + moveBuffor, ProgramHandle.GetPositionY - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosMouse(true, true, sideDownOrLeftLimit, ProgramHandle.GetPositionY + moveBuffor, ProgramHandle.GetPositionY - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                    }
                    return true;

                }

                else // GO Down
                {
                    while (ProgramHandle.GetPositionY > directionLimit && isMoveToPosition && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
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
                            MoveToPosMouse(true, false, sideUpOrRightLimit, ProgramHandle.GetPositionY + moveBuffor, ProgramHandle.GetPositionY - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                        else if (ProgramHandle.GetPositionX < sideDownOrLeftLimit)
                        {
                            // ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosMouse(true, true, sideDownOrLeftLimit, ProgramHandle.GetPositionY + moveBuffor, ProgramHandle.GetPositionY - moveBuffor, unstuckPlace, moveOnlyOnMapX);
                        }
                    }
                    return true;
                }
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