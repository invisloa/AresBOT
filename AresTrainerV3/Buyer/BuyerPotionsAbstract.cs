using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using AresTrainerV3.ShopSellAntiBug;

namespace AresTrainerV3.Buyer
{
    public abstract class BuyerPotionsAbstract : IBuyerPotionsFromShop
    {
        public static bool BuyFromForm = false;
        public static int HpPotionsToBuy = 100;
        public static int MpPotionsToBuy = 100;
        public static int SpeedPotionsToBuy = 10;
        public static bool BuyMaxPotions = false;
        private static int _defaultMouseClickDelay = 150;
        private static int _defaultKeyClickDelay = 30;
        IUnBugShop ShopUnbugger = Factory.CreateUnbugShop();
        int howManyUnbugTriesCount = 0;

        void ClickOkWhenBuying()
        {
            KeyPresser.PressEnter(_defaultKeyClickDelay, _defaultKeyClickDelay);
            //MouseOperations.MoveAndLeftClickOperation(560, 570, _defaultMouseClickDelay);
        }
        void BuyingHpPotionsMax()
        {
            MouseOperations.ClickFirstSlotInventoryLeft();
            Thread.Sleep(_defaultMouseClickDelay);
            MouseOperations.ClickMaxPotionsToBuy();
            Thread.Sleep(_defaultMouseClickDelay);
            ClickOkWhenBuying();
        }

        void HowManyPotionsToBuy(int numberOfPotionToBuy)
        {
            if (numberOfPotionToBuy == 999)
            {
                BuyingHpPotionsMax();
                return;
            }

            bool midleNumberPressed = false;
            bool lastNumberPressed = false;

            for (int x = 9; x >0 ; x--)
            {
                if(numberOfPotionToBuy > x*100-1)
                {
                    KeyPresser.PressKey(x, _defaultKeyClickDelay, _defaultKeyClickDelay);
                    numberOfPotionToBuy -= x*100;
                }
            }
            for (int x = 9; x > 0; x--)
            {
                if (numberOfPotionToBuy > x * 10 - 1)
                {
                    midleNumberPressed = true;
                    KeyPresser.PressKey(x, _defaultKeyClickDelay, _defaultKeyClickDelay);
                    numberOfPotionToBuy -= x * 10;
                }
            }
            if (!midleNumberPressed)
            {
                KeyPresser.PressKey(0, _defaultKeyClickDelay, _defaultKeyClickDelay);
            }

            for (int x = 9; x > 0; x--)
            {
                if (numberOfPotionToBuy > x-1)
                {
                    lastNumberPressed = true;

                    KeyPresser.PressKey(x, _defaultKeyClickDelay, _defaultKeyClickDelay);
                    numberOfPotionToBuy -= x;
                }
            }
            if (!lastNumberPressed)
            {
                KeyPresser.PressKey(0, _defaultKeyClickDelay, _defaultKeyClickDelay);
            }
			ClickOkWhenBuying();

        }

        protected void BuyPotionsAbstract(int hpLimit, bool hpMaxBuy, int mannaLimit, int redWhiteLimit, Tuple<int, int>[] buyPotionsMouseMovePos)
        {
            
            for (int i = 0; i < 4; i++)
            {
                if (ProgramHandle.isShopWindowStillOpen == 1 ||
                    (buyPotionsMouseMovePos == ExpBotMovePositionsValues.mousePositionsForStorageBuying && ProgramHandle.isInventoryWindowStillOpen ==1))
                {
                    if (BuyFromForm)
                    {
                        hpLimit = HpPotionsToBuy;
                        mannaLimit = MpPotionsToBuy;
                        redWhiteLimit = SpeedPotionsToBuy;
                        hpMaxBuy = BuyMaxPotions;
                    }
                    Thread.Sleep(100);
                    if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.InvPotCount(mannaLimit)) // Manna Potion
                    {
                        MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, _defaultMouseClickDelay);
                        MouseOperations.MoveAndLeftClickOperation(1295, 530, _defaultMouseClickDelay); //2slot inv
                        HowManyPotionsToBuy(PotionsToBuyCalculator(mannaLimit, ProgramHandle.getSecondSlotValue));
                        Thread.Sleep(200);
                        if(ProgramHandle.getSecondSlotValue < PointersAndValues.InvPotCount(mannaLimit))
                        {
                            if(howManyUnbugTriesCount ==3)
                            {
                                throw new NotImplementedException();
                            }
							howManyUnbugTriesCount++;
							ShopUnbugger.UnBugShop();
							this.BuyPotions();
						}
                    }
                    else if (i == 1 && ProgramHandle.getRedPotSlotValue < PointersAndValues.InvPotCount(redWhiteLimit)) // Red Potions
                    {
                        if (ProgramHandle.isCurrentClassSelected != PointersAndValues.ClassSorcerer)
                        {
                            MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, _defaultMouseClickDelay);
                            MouseOperations.MoveAndLeftClickOperation(1330, 530, _defaultMouseClickDelay); // 3 slot inv
                            HowManyPotionsToBuy(PotionsToBuyCalculator(redWhiteLimit, ProgramHandle.getRedPotSlotValue));
                        }
                    }
                    else if (i == 2 && ProgramHandle.getWhitePotSlotValue < PointersAndValues.InvPotCount(redWhiteLimit)) // White Potions
                    {
                        MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, _defaultMouseClickDelay);
                        MouseOperations.MoveAndLeftClickOperation(1365, 530, _defaultMouseClickDelay); // 4 slot inv

                        HowManyPotionsToBuy(PotionsToBuyCalculator(redWhiteLimit, ProgramHandle.getWhitePotSlotValue));
                    }
                    else if (i == 3 && ProgramHandle.getFirstInvSlotValue < PointersAndValues.InvPotCount(hpLimit))      // HP Potions 
                    {

                        if (!hpMaxBuy)
                        {
                            MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, _defaultMouseClickDelay);
                            MouseOperations.MoveAndLeftClickOperation(1260, 530, _defaultMouseClickDelay); // 1 slot inv

                            HowManyPotionsToBuy(PotionsToBuyCalculator(hpLimit, ProgramHandle.getFirstInvSlotValue));
                        }
                        else
                        {
                            MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, _defaultMouseClickDelay);
                            HowManyPotionsToBuy(999);
                        }
                    }
                    howManyUnbugTriesCount = 0;
                }
            }
            KeyPresser.PressEscape();
            KeyPresser.PressEscape();
        }
        int PotionsToBuyCalculator(int howManyPotionsToBe, int HowManyPotionsThereIs)
        {
            int potionsToBuyCalculated;
            if (HowManyPotionsThereIs != 0)
            {
                potionsToBuyCalculated = PointersAndValues.ItemCount1-1 + howManyPotionsToBe - HowManyPotionsThereIs;
                return potionsToBuyCalculated;

            }
            else
            {
                return howManyPotionsToBe;

            }

        }
        public abstract void BuyPotions();
    }
}
