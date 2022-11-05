﻿using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepotUWC : RepotAbstract
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
            Thread.Sleep(1000);
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                for (int i = 0; i < 20; i++)
                {
                    if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
                    {
                        if (ProgramHandle.GetPositionX != 1142172652 && ProgramHandle.GetPositionY != 1141596108)
                        {
                            KeyPresser.PressKey(6, 1000, 1000);
                        }
                    }
                }
            }
            MoveToRepotWithPositions(ExpBotMovePositionsValues.HershalRepotMovePositions);
        }
    }
}