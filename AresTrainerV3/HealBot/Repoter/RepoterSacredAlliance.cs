using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterSacredAlliance : RepotAbstract
    {
        protected override GoBackExpAbstract GoBackExpPlace
        {
            get
            {
                if (_goBackExpPlace == null)
                {
                    _goBackExpPlace = new GoBackExpSacredAlliTeleport();
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
                    _buyerPotionsCity = new BuyerFromForm();
                }
                return _buyerPotionsCity;
            }
        }
        protected override int repotCityCheck
        {
            get
            {
                _repotCityVerification = TeleportValues.AllianceSacredLand;
                return _repotCityVerification;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(10);
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                ProgramHandle.TeleportToPositionTuple(TeleportValues.SacredlandsAlliShop);

            }
        }
    }
}

