﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Windows.Input;
using System.Threading;
using System;

namespace AresTrainerV3
{
    public static class ExpBotClass
    {
        static InputSimulator inputSimulator = new InputSimulator();
        static int moveRandomizer
        {
            get
            {
                Random randomInt = new Random();

                return randomInt.Next(-75, 75);
            }
        }



        static volatile bool _isExpBotSell = false;

        public static bool isExpBotSell
        {
            get { return _isExpBotSell; }
        }

        public static void RequestisExpBotSell()
        {
            if (_isExpBotSell)
                _isExpBotSell = false;
            else
                _isExpBotSell = true;
        }


        /*        public static bool ExpBotRepot(Tuple<int, int>[] MainCityRepotPositions)
                {

                    ProgramHandle.SetCameraForExpBot();
                    MoveToPotionSuplier(MainCityRepotPositions);

                    return true;
                }

        *//*        static void MoveToPotionSuplier(Tuple<int, int>[] MainCityRepotPositions)
                {
                    foreach (var item in MainCityRepotPositions)
                    {
                        MouseOperations.SetCursorPosition(item.Item1, item.Item2);
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                        Thread.Sleep(100);
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    }
                }
        */
        /*        static void BuyFromSuplier(int whichCity)
                {
                    if(ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
                    {
                        BuyPotionsFromShop(whichCity);
                    }
                }
        */
        static volatile bool _stopMoveExpBot = false;

        public static string ExpBotLog;

        public static bool isStopMoveExpBot
        {
            get { return _stopMoveExpBot; }
        }
        public static void RequestStopMoveExpBot()
        {
            if (_stopMoveExpBot)
                _stopMoveExpBot = false;
            else
                _stopMoveExpBot = true;
        }

        public static void MoveAndLeftClickOperation(int xPos, int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(100);
        }

        static void OpenShop()
        {
            Thread.Sleep(1000);
            MoveAndLeftClickOperation(580, 565);

        }
        public static void BuyPotionsFromShopNormal(Tuple<int, int>[] whereAreYouBuyingPositions)
        {


            for (int i = 0; i < whereAreYouBuyingPositions.Length; i++)
            {
                Thread.Sleep(1000);
                if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.ItemCount1 + 50) // Manna Potion
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);

                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < PointersAndValues.ItemCount1 + 4) // Red Potions
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < PointersAndValues.ItemCount1 + 4) // White Potions
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 3 && ProgramHandle.getFirstSlotValue < PointersAndValues.ItemCount1 + 200)      // HP Potions 
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuyExp(i);
                }
            }

        }
        public static void BuyPotionsFromShopSellKharon(Tuple<int, int>[] whereAreYouBuyingPositions)
        {

            for (int i = 0; i < whereAreYouBuyingPositions.Length; i++)
            {
                Thread.Sleep(1000);
                if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.ItemCount1 + 20) // Manna Potion
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);

                    HowManyPotionsToBuySell(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < PointersAndValues.ItemCount1 + 1) // Red Potions
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuySell(i);
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < PointersAndValues.ItemCount1 + 1) // White Potions
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuySell(i);
                }
                else if (i == 3 && ProgramHandle.getFirstSlotValue < PointersAndValues.ItemCount1 + 20)      // HP Potions 
                {
                    MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    HowManyPotionsToBuySell(i);
                }
            }

        }
        static void ClickOkWhenBuying()
        {
            Thread.Sleep(300);
            MouseOperations.SetCursorPosition(560, 570);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);

        }


        static void HowManyPotionsToBuyExp(int numberOfPotionToBuy)
        {
            MouseOperations.SetCursorPosition(1295,530);  // Position for second slot item
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(500);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(1000);

            if (numberOfPotionToBuy == 0) // Manna Potion
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);

                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(500);

                ClickOkWhenBuying();
            }
            if (numberOfPotionToBuy == 1) //red potion
            {
                    inputSimulator.Keyboard.Sleep(500);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                    inputSimulator.Keyboard.Sleep(500);
                ClickOkWhenBuying();
            }
            else if (numberOfPotionToBuy == 2) // White Potion
            {
                inputSimulator.Keyboard.Sleep(1000);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(500);
                ClickOkWhenBuying();

            }
            else if (numberOfPotionToBuy == 3) // HP potion
            {
                BuyingHpPotions();
            }
        }
        static void HowManyPotionsToBuySell(int numberOfPotionToBuy)
        {
            MouseOperations.SetCursorPosition(1295, 530);  // Position for second slot item
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(500);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(1000);

            if (numberOfPotionToBuy == 0) // Manna Potion
            {
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(500);

                ClickOkWhenBuying();
            }
            if (numberOfPotionToBuy == 1) //red potion
            {
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(500);
                ClickOkWhenBuying();
            }
            else if (numberOfPotionToBuy == 2) // White Potion
            {
                inputSimulator.Keyboard.Sleep(1000);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(500);
                ClickOkWhenBuying();

            }
            else if (numberOfPotionToBuy == 3) // HP potion
            {
                inputSimulator.Keyboard.Sleep(1000);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(500);
                ClickOkWhenBuying();
            }
        }

        static void BuyingHpPotions()
        {
            MouseOperations.SetCursorPosition(1300, 550);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(300);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
            MouseOperations.SetCursorPosition(560, 520);
            Thread.Sleep(500);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
            ClickOkWhenBuying();
        }

        static void MoveToRepot(Tuple<int, int>[] citySpecificPositions)
        {
            Thread.Sleep(500);
            if (ProgramHandle.isWhatAnimationRunning != PointersAndValues.isRunningAnimationInCity)
            {
                for (int i = 0; i < citySpecificPositions.Length; i++)
                {
                    MoveAndLeftClickOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2);
                    while (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationInCity)
                    {
                        Thread.Sleep(2);
                    }
                }
            }

        }

        public static void Repot(int currentCity)
        {

            Thread.Sleep(1000);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(500);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(500);

            ProgramHandle.SetCameraForExpBot();

            if (currentCity == TeleportValues.Hershal)
            {
                MoveToRepot(ExpBotMovePositions.HershalRepotMovePositions);
                OpenShop();
                BuyPotionsFromShopNormal(ExpBotMovePositions.mousePositionsForHershalBuying);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(500);

            }
            
            if (currentCity == TeleportValues.Kharon)
            {

                MoveToRepot(ExpBotMovePositions.KharonRepotMovePositions);
                inputSimulator.Keyboard.Sleep(500);

                OpenShop();

                inputSimulator.Keyboard.Sleep(500);

                SellItems();

                inputSimulator.Keyboard.Sleep(500);
                BuyPotionsFromShopSellKharon(ExpBotMovePositions.mousePositionsForKharonBuying);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(500);

            }


        }
        public static void scrollToCity()
        {
            inputSimulator.Keyboard.Sleep(2000);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_6);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
            inputSimulator.Keyboard.Sleep(5000);
        }
        public static void ExpBotSellKharonGoBackToSpot()
        {
            scrollToCity();
            ProgramHandle.SetCameraForExpBot();
            while(ProgramHandle.GetCurrentMap != TeleportValues.KharonPlateau)
            {
                MoveAndLeftClickOperation(955, 160);
                Thread.Sleep(1000);
            }
            Thread.Sleep(10000);
            ProgramHandle.SetCameraForExpBot();
            PressF5ForTeleport();
            Thread.Sleep(2000);
        }
        static void PressF5ForTeleport()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F5);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.F5);
            inputSimulator.Keyboard.Sleep(500);
        }


        public static void WalkIntoUWC()
        {
            Thread.Sleep(500);
            PressF5ForTeleport();
            while (ProgramHandle.GetCurrentMap != TeleportValues.UWC1stFloor)
            {
                Thread.Sleep(500);
                MouseOperations.SetCursorPosition(1110, 380);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(1000);
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                Thread.Sleep(1000);
                ProgramHandle.SetCameraForExpBot();
                Thread.Sleep(100);
            }
        }

        static void MoveToPositionWhenNotAttacking( int x,int y)
        {
            if (ProgramHandle.isWhatAnimationRunning != PointersAndValues.isRunningAnimationOutside)
            {
                Thread.Sleep(5);
                MouseOperations.SetCursorPosition(x, y);
                Thread.Sleep(5);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(50);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(50);
            }
        }

        static void MoveScanAndAttack(int x,int y)
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimation)
            {
                moveToPosition(x, y);
            }
            // even was standing and moved make a scan;
            PixelBotSearcher.ScanAndAttack();

        }

        static void moveToPosition(int x, int y)
        {
            Thread.Sleep(5);
            MouseOperations.SetCursorPosition(x, y);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(50);
        }


        const int moveBuffor = 99000000;  /// when it was lower bot was moving up and down all the time - around (10000)

        public static bool goLeft(int x, int y, int leftLimit, int upLimit, int downLimit)
        {
                while (ProgramHandle.GetPositionX > leftLimit && _stopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                        MoveScanAndAttack(x+ moveRandomizer, y+ moveRandomizer);
                    ExpBotLog += $"goLeft \n";

                }
                else if (ProgramHandle.GetPositionY > upLimit)
                    {
                        goDown(900+ moveRandomizer, 640+ moveRandomizer, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);

                    ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    
                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                        goUp(962+ moveRandomizer, 430+ moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }

            }
                return true;

        }
        public static bool goRight(int x, int y, int rightLimit, int upLimit, int downLimit)
        {
                while (ProgramHandle.GetPositionX < rightLimit && _stopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                    MoveScanAndAttack(x+ moveRandomizer, y+ moveRandomizer);
                    ExpBotLog += $"goRight \n";

                    }
                    else if (ProgramHandle.GetPositionY > upLimit)
                    {
                            goDown(963+ moveRandomizer, 600+ moveRandomizer, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                        ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                            goUp(964+ moveRandomizer, 430+ moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                        ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                    }

                }
                return true;
        }
        public static bool goUp(int x, int y, int upLimit, int leftLimit,int rightLimit)
        {
                while (ProgramHandle.GetPositionY < upLimit && _stopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                    {
                    MoveScanAndAttack(x+ moveRandomizer, y+ moveRandomizer);
                    ExpBotLog += $"goUp \n";

                }
                else if (ProgramHandle.GetPositionX > rightLimit)
                    {
                        goLeft(800+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    ExpBotLog += $"goUp-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }
                else if (ProgramHandle.GetPositionX < leftLimit)
                    {
                        goRight(1100+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    ExpBotLog += $"goUp-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }

            }
                return true;
        }
        public static bool goDown(int x, int y, int upLimit, int leftLimit, int rightLimit)
        {
            while (ProgramHandle.GetPositionY > upLimit && _stopMoveExpBot)
            {
                if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                {
                    MoveScanAndAttack(x+ moveRandomizer, y+ moveRandomizer);
                    ExpBotLog += $"goDown currentY {ProgramHandle.GetPositionY} downLimit {upLimit} currentX {ProgramHandle.GetPositionX} \n";

                }
                else if (ProgramHandle.GetPositionX > rightLimit)
                {
                    goLeft(800+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor);
                    ExpBotLog += $"goDown-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }
                else if (ProgramHandle.GetPositionX < leftLimit)
                {
                    goRight(1100+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor);
                    ExpBotLog += $"goDown-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                }

            }
            return true;
        }


        public static void RunAndExpSquare()
        {
            int howManyForLoops = 0;
            while(_stopMoveExpBot)
            {
                ExpBotLog += $"Starting new While \n";

                for (int i = 0; i < 3; i++)
                {
                    ExpBotLog += $"starting new for \n";

                    Thread.Sleep(100);
                    if (i == 0)
                    {
                        ExpBotLog += $"current i {i}\n";
                        Thread.Sleep(100);

                        while (!goLeft(600, 520, 1110719243, 1111239992, 1109794945)) ;
                        ExpBotLog += $"goLeft Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);

                        while (!goUp(960, 300, 1114565081, 1107050535, ProgramHandle.GetPositionX + 80000000)) ;
                        ExpBotLog += $"goUp Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goRight(1250, 520, 1128331398, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000)) ;
                        ExpBotLog += $"GoRight Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goDown(965, 650, 1110537017, 1120835756, 1122982731)) ;
                        ExpBotLog += $"GoDown Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
        public static void TeleportSScroll()
        {
            Thread.Sleep(1000);
            MoveAndLeftClickOperation(920, 155);
            Thread.Sleep(1000);
        }


        static void MoveAndRightClickOperation(int xPos, int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(100);
        }
        static void MoveAndLeftClickToSellAll()
        {
            if (ProgramHandle.isSellWindowStillOpen == 1)
            {
                MouseOperations.SetCursorPosition(560, 570);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100);

            }
            if (ProgramHandle.isSellWindowStillOpen == 1)
            {
                MouseOperations.SetCursorPosition(560, 570);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(100);

            }
        }

        #region TrySellItems

        public static void SellItems()
        {
            TestArrayAdding.itemArrayPositionsInitialize();
            Thread.Sleep(500);
            MoveAndLeftClickOperation(1235, 570);
            Thread.Sleep(500);

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! SELL ONLY FIRST ROW OF SECOND TAB!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
           // for (int i = 12; i < ExpBotMovePositions.itemSellPositions.Length; i++) // START FROM 3 Row 1st Column - its 12
                for (int i = 12; i < 42; i++) // START FROM 3 Row 1st Column - its 12 and end on first row second tab
                {
                    if (i == 36)
                {
                    Thread.Sleep(300);

                    ExpBotClass.MoveAndLeftClickOperation(1235, 670); // Open Second Tab
                    Thread.Sleep(300);
                }
                MoveAndRightClickOperation(ExpBotMovePositions.itemSellPositions[i].Item1, ExpBotMovePositions.itemSellPositions[i].Item2);
                Thread.Sleep(100);
                MoveAndLeftClickToSellAll();


            }
        }



        #endregion


        #region Collecting Items


        public static bool ClickAndCollectItem()
        {
            Thread.Sleep(2);

            if (ProgramHandle.isItemHighlighted != 0)
            {

                if (ProgramHandle.isItemHighlighted != 0)
                {
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                    Thread.Sleep(100);
                    //make double LeftUp because somehow it didnt notice the click and bot bugged and stopped attacking
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    Thread.Sleep(5);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationOutside)
                    {
                        Thread.Sleep(500); // !!!!!!!!!!!!!! TODO IS RUNNING ANIMATION
                    }
                    Thread.Sleep(500); 
                    return true;
                }
            }
            return false;
        }

        #endregion


    }
}
