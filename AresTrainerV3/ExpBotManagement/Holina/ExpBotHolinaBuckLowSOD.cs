/*using AresTrainerV3.ExpBotManager;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ExpBotManagement.Holina
{
    internal class ExpBotHolinaBuckLowSOD : ExpBotManagerAbstract
    // last time stuck after scroll to city
    {

        MoveToPositionAbstract _MoveToPosPlace = new MoveToPosALL(TeleportValues.Hollina, new CollectSodJewelery());

        public override MoveToPositionAbstract MoveToPosPlace
        {
            get
            { return _MoveToPosPlace; }
        }

        *//*
                down max limit
                    1124179514
                    right max limit
                    1135812375,


                    right go to
                    1135440265


                    left go to
                    1133855562


                    left max
                    1133625506

                    DOWN GO TO 1124336732


                    up go to 
                    1125345069

                    up max
                    1125563371 


        telep 1135812375, 1124261475

        *//*
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
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Left, 1133855562, 1124179514, 1125563371, 1);
                        ExpBotClass.ExpBotLog += $"Up Ended current i {i}\n";
                    }
                    else if (i == 1)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Up, 1125345069, 1133625506, 1135440265, 1);
                        ExpBotClass.ExpBotLog += $"Right Ended current i {i}\n";
                    }
                    else if (i == 2)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Right, 1135440265, 1124179514, 1125563371, 1);
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";
                    }
                    else if (i == 3)
                    {
                        ExpBotClass.ExpBotLog += $"current i {i}\n";
                        MoveToPosPlace.MoveAttackCollect(DirectionsEnum.Down, 1124536732, 1133625506, 1135812375, 1);
                        ExpBotClass.ExpBotLog += $"Left Ended current i {i}\n";
                    }

                }
                howManyForLoops++;
                ExpBotClass.ExpBotLog += $"while end {howManyForLoops} \n";
            }
        }
    }
}
*/