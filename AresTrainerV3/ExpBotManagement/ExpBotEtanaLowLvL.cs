using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement
{
    internal class ExpBotEtanaLowLvL : ExpBotManagerAbstract
    {

        MoveToPositionAbstract _moveToPosTest = new MoveToPosEtanaExp();
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _moveToPosTest; }
        }


        public override void RunAndExpSquare()
        {
            int howManyForLoops = 0;
            while (_isExpBotRunning)
            {
                ExpBotClass.ExpBotLog += $"Starting new While \n";

                for (int i = 0; i < 2; i++)
                {
                    ExpBotClass.ExpBotLog += $"starting new for \n";

                    Thread.Sleep(100);
                    if (i == 0)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1129758111, 1121100155, 1123148846, true);



                        // while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";

                    }

/*                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1123731931, 1133646625, 1135646625, true);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";

                    }
*/                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, 1135103167, 1121100155, 1123148846, true);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
    }
}
