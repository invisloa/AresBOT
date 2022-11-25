using AresTrainerV3.Buyer;
using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom.Hershal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterHershalLeafMages : RepotAbstract
    {
        protected override BuyerPotions BuyerPotionsCity
        {
            get
            {
                if (_buyerPotionsCity == null)
                {
                    _buyerPotionsCity = new BuyerPotionsHershalExp();
                }
                return _buyerPotionsCity;
            }
        }
        protected override int repotCityCheck
        {
            get
            {
                _repotCityVerification = TeleportValues.Hershal;
                return _repotCityVerification;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(500);
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (ProgramHandle.GetPositionX != 1142172652 && ProgramHandle.GetPositionY != 1141596108 && ProgramHandle.GetPositionX != 1139294473 && ProgramHandle.GetPositionY != 1140809096 && ProgramHandle.GetPositionX != 1142170812 && ProgramHandle.GetPositionY != 1141596291)
                        {
                            KeyPresser.PressKey(6, 200, 200);
                        }
                    }

                    if (ProgramHandle.GetPositionX == 1142172652 && ProgramHandle.GetPositionY == 1141596108 || ProgramHandle.GetPositionX == 1142170812 && ProgramHandle.GetPositionY == 1141596291)
                        {
                            MoveToRepotWithPositions(ExpBotMovePositionsValues.HershalRepotMovePositions);
                        }
                    else if (ProgramHandle.GetPositionX == 1139294473 && ProgramHandle.GetPositionY == 1140809096)
                    {
                        MoveToRepotWithPositions(ExpBotMovePositionsValues.HershalRepotMovePositions2);
                    }

                }
            }
        }
    }
}