using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Sacred
{
    internal class ExpBotSacredNearGikoCave : ExpBotManagerAbstract
    {
        //             ProgramHandle.TeleportToPosition(1142406013, 1134435082, 0);





        MoveToPosSacredAlli _MoveToPosSacredAlli = new MoveToPosSacredAlli();
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _MoveToPosSacredAlli; }
        }


        public override void RunAndExpSquare()
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
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, 1142201685, 1132748429, 1133075278, true);



                        // while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {

                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1129224109, 1142020694, 1142201685, true);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1142307448, 1129224109, 1129980817, true);


                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
    }
}


