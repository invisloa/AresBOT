using AresTrainerV3.Buyer;
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
            if (!ProgramHandle.isNowRunningCity())
            {
                Thread.Sleep(15000);
                KeyPresser.PressKey(6, 200, 200);
            }
        }
        public void GoRepot()
        {
            Thread.Sleep(2000);
            // Set Weight limit back to the original state if player found changed it to not to collect items@
            PixelItemCollector.weightLimitCollect = 1900;
            Thread.Sleep(2000);
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
        public void MoveToRepotWithPositions(Tuple<int, int>[] citySpecificPositions)
        {
            ProgramHandle.SetCameraForExpBot();
            Thread.Sleep(500);
            if (!ProgramHandle.isNowRunningCity())
            {
                for (int i = 0; i < citySpecificPositions.Length; i++)
                {
                    MouseOperations.MoveAndLeftClickOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2, 10);
                    Thread.Sleep(1000);
                    while (!ProgramHandle.isNowStandingCity())
                    {
                        Thread.Sleep(1);
                    }
                }
            }
        }


        protected abstract void MoveToRepot();

    }
}
