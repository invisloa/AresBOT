using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManagement.Holina;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterHolinaTeleport : RepotAbstract
    {
        protected override GoBackExpAbstract GoBackExpPlace
        {
            get
            {
                if (_goBackExpPlace == null)
                {
                    _goBackExpPlace = new GoBackExpHolinaTeleport();
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
                    _buyerPotionsCity = new BuyerPotionHolinaExp();
                }
                return _buyerPotionsCity;
            }
        }
        protected override int repotCityCheck
        {
            get
            {
                _repotCityVerification = TeleportValues.Hollina;
                return _repotCityVerification;
            }
        }
        protected override IStartExpBotThread ExpBotToStart
        {
            get
            {
                if (_expBotToStart == null)
                {
                    _expBotToStart = new ExpBotHolinaSod();
                }
                return _expBotToStart;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(100);
            CheckIfNotRunning();
            ProgramHandle.SetCameraForExpBot();
            if (ProgramHandle.isNowStandingCity())
            {
                ProgramHandle.TeleportToPositionTuple(TeleportValues.ShopHolinaPos);

            }
        }
    }
}
