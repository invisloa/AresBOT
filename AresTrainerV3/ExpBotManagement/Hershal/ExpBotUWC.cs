using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Hershal
{
    public class ExpBotUWC : ExpBotManagerAbstract
    {

        MoveUWC1CollectAll MoveUwcCollector = new MoveUWC1CollectAll();
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return MoveUwcCollector; }
        }


        public override void RunAndExp()
        {
            int howManyForLoops = 0;
            while (_isExpBotRunning)
            {
                ExpBotClass.ExpBotLog += $"Starting new While \n";

                for (int i = 0; i < 3; i++)
                {
                    ExpBotClass.ExpBotLog += $"starting new for \n";

                    Thread.Sleep(100);
                    if (i == 0)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, 1112000000, 1109794945 , 1111239992, 1);



                        // while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"goLeft Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, 1115828432, 1107997194, ProgramHandle.GetPositionX + 80000000, 1);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"goUp Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1128331398, ProgramHandle.GetPositionY - 800000, ProgramHandle.GetPositionY + 800000, 1);


                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"GoRight Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1110537017, ProgramHandle.GetPositionY - 800000, ProgramHandle.GetPositionY + 800000, 1);



                        //while (!goDown(965, 650, 1110537017, 1120835756, 1122982731, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"GoDown Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
    }
}




















