﻿/*using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Kharon
{
    public class ExpBotKharonWolvesExp : ExpBotManagerAbstract
    {

        MoveToPosKharonWolvesExp _moveToPosKharonWolvesExp = new MoveToPosKharonWolvesExp();
        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _moveToPosKharonWolvesExp; }
        }
        Tuple<int, int, int, int> go1way = new Tuple<int, int, int, int>(1126867063, 1121156757, 1129999999, 1);
        Tuple<int, int, int, int> go2way = new Tuple<int, int, int, int>(1128169347, 1126867063, 1128062330, 1);
        Tuple<int, int, int, int> go3way = new Tuple<int, int, int, int>(1122739996, 1126867063, 1128062330, 1);


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
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, go1way);



                        // while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, go2way);

                        // while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";

                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, go3way);


                        //while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*//*, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
    }
}


*//**/