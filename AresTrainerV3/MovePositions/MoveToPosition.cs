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

        const int moveBuffor = 99000000;  /// when it was lower bot was moving up and down all the time - around (10000)


        public bool MoveToPosition(bool isMoveOnXAxis,bool isPosIcreasing, int directionLimit, int sideDownOrLeftLimit, int sideUpOrRightLimit, int moveOnlyOnMapX)
        {
            if (isMoveOnXAxis)
            {
                if (isPosIcreasing)// GO RIGHT
                {

                }





                else // GO LEFT
                while (ProgramHandle.GetPositionX > directionLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                {
                    // TODO UNSTACKER IF SELECTION

                    if (ProgramHandle.GetPositionY < sideUpOrRightLimit  && ProgramHandle.GetPositionY > sideDownOrLeftLimit)
                    {
                        // ExpBotLog += $"goLeft \n";

                        ExpBotClass.MoveScanAndAttackAncCollect(new TupleMousePos().MoveLeft.Item1 + moveRandomizer, new TupleMousePos().MoveLeft. Item2 + moveRandomizer);
                    }
                    else if (ProgramHandle.GetPositionY > sideUpOrRightLimit)
                    {
                            // ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                            MoveToPosition(false,false,new TupleMousePos().sideMoveDownGoLeft, sideUpOrRightLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                        ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                        goUp(962 + moveRandomizer, 430 + moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
                    }

                }
                return true;
            }
            else
            {

            }

        }

    }
}
