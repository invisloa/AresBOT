﻿using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.ItemCollect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    public abstract class RepotAbstract :IGoRepot
    {
        protected int isCurrentCity = ProgramHandle.GetCurrentMap;

        protected GoBackExpAbstract _goBackExpPlace;
        protected BuyerPotions _buyerPotionsCity;
        protected int _repotCityVerification;
        protected IStartExpBotThread _expBotToStart;

        protected abstract GoBackExpAbstract GoBackExpPlace
        { get; }
        protected abstract IStartExpBotThread ExpBotToStart
        { get; }
        protected abstract BuyerPotions BuyerPotionsCity
        {get;}
        protected abstract int repotCityCheck
        {get;}

        protected void MouseClickOpenShop()
        {
            Thread.Sleep(1000);
            MouseOperations.MoveAndLeftClickOperation(580, 565, 200);

        }
        protected void CheckIfNotRunning()
        {
            if (ExpBotClass.isNowRunningCity())
            {
                Thread.Sleep(15000);
                KeyPresser.PressKey(6, 200, 200);
            }
        }
        public void GoRepot()
        {
            Thread.Sleep(5000);

            ProgramHandle.SetCameraForExpBot();

            if (isCurrentCity == repotCityCheck)
            {
                Thread.Sleep(1000);
                    MoveToRepot();
                Thread.Sleep(1000);

                //MouseClickOpenShop();
                ProgramHandle.OpenShopWindow();
                if (ProgramHandle.isShopWindowStillOpen() == 1)
                {
                    ItemSeller.SellItemsMouseMove();
                    BuyerPotionsCity.BuyPotions();
                }
                KeyPresser.PressEscape();
                GoBackExpPlace.GoBackExp();
                ExpBotToStart.StartExpBotThread();
            }


        }


        protected abstract void MoveToRepot();

    }
}
