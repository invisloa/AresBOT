using AresTrainerV3.ExpBotManager;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Hershal
{
    internal class ExpBotHershalSellLeafMages : ExpBotManagerAbstract
    {

        MoveToPositionAbstract _MoveToPosPlace = new MoveToPosALL(TeleportValues.Hershal,new CollectAllItems());
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _MoveToPosPlace; }
        }

        public override void RunAndExpSquare()
        {
            int howManyForLoops = 0;
            while (_isExpBotRunning)
            {
                ExpBotClass.ExpBotLog += $"Starting new While \n";

                for (int i = 0; i < 4; i++)
                {
                    ExpBotClass.ExpBotLog += $"starting new for \n";

                    Thread.Sleep(100);
                    if (i == 0)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, 1128494225, 1131207739, 1132673292, true);
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";
                    }

                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, 1132673292, 1127580850, 1132749901, true);
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";
                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1132749901, 1131207739, 1132991835, true);


                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1131662730, 1127580850, 1133161566, true);
                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, Teleport222222222Values.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";
            }
        }
    }
}


