using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    public class RepoterKharonExp : RepotAbstract
    {
        protected override BuyerPotions BuyerPotionsCity
        {
            get
            {
                if (_buyerPotionsCity == null)
                {
                    _buyerPotionsCity = new BuyerPotionsKharonExp();
                }
                return _buyerPotionsCity;
            }
        }
        protected override int repotCityCheck
        {
            get
            {
                _repotCityVerification = TeleportValues.Kharon;
                return _repotCityVerification;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(1000+ randomizer.Next(1,3000));
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                    Thread.Sleep(500);
                    ProgramHandle.SetCameraLong();
                    Thread.Sleep(500);
                if (ProgramHandle.GetPositionShortY == 17126)
                {
                    MouseOperations.MoveAndLeftClickOperation(1125, 253, 200);
                    Thread.Sleep(500);
                }
                else if(ProgramHandle.GetPositionShortY == 17142)
                {
                    MouseOperations.MoveAndLeftClickOperation(1126, 318, 200);
                    Thread.Sleep(500);

                }
                if (ProgramHandle.isNowStandingCity())
                {
                    MouseOperations.MoveAndLeftClickOperation(1125, 253, 200);
                    Thread.Sleep(500);

                }

                while (!ProgramHandle.isNowStandingCity())
                {
                    Thread.Sleep(50);
                }
            }
        }
    }
}

