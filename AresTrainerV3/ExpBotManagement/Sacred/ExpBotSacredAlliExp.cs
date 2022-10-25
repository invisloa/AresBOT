using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Sacred
{
    internal class ExpBotSacredAlliExp : ExpBotManagerAbstract
    {
        //             ProgramHandle.TeleportToPosition(1121665964, 1147452062 , 0);

        MoveToPosSacredAlli _MoveToPosSacredAlli = new MoveToPosSacredAlli();
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _MoveToPosSacredAlli; }
        }


        public override void RunAndExp()
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
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, 1147452062, 1121665964, 1123628996, 1);



                        // while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {

                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1125345630, 1147377517, 1147599453, 1);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1146955261, 1125345630, 1126722127, 1);


                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, 1123628996, 1146687360, 1146955261, 1);


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


