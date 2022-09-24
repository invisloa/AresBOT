﻿using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManagement.Kharon;
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
        protected override IStartExpBotThread ExpBotToStart
        {
            get
            {
                if (_expBotToStart == null)
                {
                    _expBotToStart = new ExpBotKharonWolvesExp();
                }
                return _expBotToStart;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(1000);
            CheckIfNotRunning();
            if (ExpBotClass.isNowStandingCity())
            {
                Thread.Sleep(10000);
                ProgramHandle.SetCameraLong();
                Thread.Sleep(1000);
                ProgramHandle.SetCameraLong();
                Thread.Sleep(1000);

                MouseOperations.MoveAndLeftClickOperation(1125, 253, 500);
                while (!ExpBotClass.isNowStandingCity())
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}
