﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AresTrainerV3.Buyer
{
    public abstract class BuyerPotions : IBuyerPotionsFromShop
    {
        public static int HpPotionsToBuy = 100;
        public static int MpPotionsToBuy = 100;
        public static int SpeedPotionsToBuy = 10;
        public static bool BuyMaxPotions = false;

        void ClickOkWhenBuying()
        {
            MouseOperations.MoveAndLeftClickOperation(560, 570, 300);
        }
        void BuyingHpPotionsMax()
        {
            MouseOperations.ClickFirstSlotInventoryLeft();
            Thread.Sleep(500);
            MouseOperations.ClickMaxPotionsToBuy();
            Thread.Sleep(500);
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

            for (int x = 3; x >0 ; x--)
            {
                if(numberOfPotionToBuy > x*100-1)
                {
                    KeyPresser.PressKey(x, 100, 100);
                    numberOfPotionToBuy -= x*100;
                }
            }
            for (int x = 9; x > 0; x--)
            {
                if (numberOfPotionToBuy > x * 10 - 1)
                {
                    midleNumberPressed = true;
                    KeyPresser.PressKey(x, 100, 100);
                    numberOfPotionToBuy -= x * 10;
                }
            }
            if (!midleNumberPressed)
            {
                KeyPresser.PressKey(0, 100, 100);
            }

            for (int x = 9; x > 0; x--)
            {
                if (numberOfPotionToBuy > x-1)
                {
                    lastNumberPressed = true;

                    KeyPresser.PressKey(x, 100, 100);
                    numberOfPotionToBuy -= x;
                }
            }
            if (!lastNumberPressed)
            {
                KeyPresser.PressKey(0, 100, 100);
            }

            ClickOkWhenBuying();

        }

        protected void BuyPotionsAbstract(int hpLimit, bool hpMaxBuy, int mannaLimit, int redWhiteLimit, Tuple<int, int>[] buyPotionsMouseMovePos)
        { 
            for (int i = 0; i < 4; i++)
            {
                
                Thread.Sleep(1000);
                if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.ItemCount1 + (mannaLimit - 1)) // Manna Potion
                {
                    // int howManyPotionsToBuy = PointersAndValues.ItemCount1 + (mannaLimit - 1) - ProgramHandle.getSecondSlotValue;
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 300);
                    MouseOperations.MoveAndLeftClickOperation(1295, 530, 800); //2slot inv

                    HowManyPotionsToBuy(PotionsToBuyCalculator(mannaLimit, ProgramHandle.getSecondSlotValue));
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < PointersAndValues.ItemCount1 + (redWhiteLimit - 1)) // Red Potions
                {
                   // int howManyPotionsToBuy = PointersAndValues.ItemCount1 + redWhiteLimit - ProgramHandle.getThirdSlotValue;

                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 300);
                    MouseOperations.MoveAndLeftClickOperation(1330, 530, 800); // 3 slot inv

                    HowManyPotionsToBuy(PotionsToBuyCalculator(redWhiteLimit, ProgramHandle.getThirdSlotValue));
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < PointersAndValues.ItemCount1 + (redWhiteLimit - 1)) // White Potions
                {
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 300);
                    MouseOperations.MoveAndLeftClickOperation(1365, 530, 800); // 4 slot inv

                    HowManyPotionsToBuy(PotionsToBuyCalculator(redWhiteLimit, ProgramHandle.getForthSlotValue));
                }
                else if (i == 3 && ProgramHandle.getFirstSlotValue < PointersAndValues.ItemCount1-1 + hpLimit)      // HP Potions 
                {

                    if (!hpMaxBuy)
                    {
                        MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 300);
                        MouseOperations.MoveAndLeftClickOperation(1260, 530, 300); // 1 slot inv

                        HowManyPotionsToBuy(PotionsToBuyCalculator(hpLimit, ProgramHandle.getFirstSlotValue));

                    }
                    else
                    {
                        MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 300);
                        HowManyPotionsToBuy(999);
                    }
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
