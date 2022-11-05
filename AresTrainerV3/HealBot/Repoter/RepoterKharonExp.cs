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
        protected override GoBackExpAbstract GoBackExpPlace
        {
            get
            {
                if(_goBackExpPlace == null)
                {
                    _goBackExpPlace = new GoBackExpKharonWolves();
                }
                return _goBackExpPlace;
            }
        }

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
            Thread.Sleep(500+ randomizer.Next(1,3000));
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                Thread.Sleep(200 + randomizer.Next(1, 1000));
                ProgramHandle.SetCameraLong();
                Thread.Sleep(100 + randomizer.Next(1, 1000));

                MouseOperations.MoveAndLeftClickOperation(1125, 253, 500);
                while (!ProgramHandle.isNowStandingCity())
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}

