using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Windows.Input;
using System.Threading;
using System;
using AresTrainerV3.Buyer;
using AresTrainerV3.Unstuck;

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
        public static volatile bool _stopMoveExpBot = false;

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


        static void MouseClickOpenShop()
        {
            Thread.Sleep(1000);
            MouseOperations.MoveAndLeftClickOperation(580, 565,200);

        }
        public static bool isNowRunningCity()
        {
            if (ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationArcerEmpCity
                || ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationArcerAlliCity
                || ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationSorcAlliCity
                || ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationSorcEmpCityF
                || ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationSpearAlliCity
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isNowRunningOut()
        {
            if (ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isRunningAnimationArcALLIOutside ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isRunningAnimationArcEMPOutside ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isRunningAnimationSpearALLIOutside ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isRunningAnimationSorcAlliStaffOutside ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isRunningAnimationSorcAlliOrbOutside                
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isNowStandingOut()
        {
            if (ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerEmpOut ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerAlliOut ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcAlliOutStaff ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcAlliOutOrb ||
                ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSpearAlliOut
                )
            {            
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isNowStandingCity()
        {
            if (ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerEmpCity 
                || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerAlliCity 
                || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcAlliCity 
                || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcEmpCityF)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void BuyPotionsFromShopNormalEXP(Tuple<int, int>[] buyPotionsMouseMovePos)
        {


            for (int i = 0; i < buyPotionsMouseMovePos.Length; i++)
            {
                Thread.Sleep(1000);
                if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.ItemCount1 + 99) // Manna Potion
                {
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 150);

                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < PointersAndValues.ItemCount1 + 3) // Red Potions
                {
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 150);
                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < PointersAndValues.ItemCount1 + 3) // White Potions
                {
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 150);
                    HowManyPotionsToBuyExp(i);
                }
                else if (i == 3 && ProgramHandle.getFirstSlotValue < PointersAndValues.ItemCount1 + 120)      // HP Potions 
                {
                    MouseOperations.MoveAndLeftClickOperation(buyPotionsMouseMovePos[i].Item1, buyPotionsMouseMovePos[i].Item2, 150);
                    HowManyPotionsToBuyExp(i);
                }
            }

        }
        public static void BuyPotionsFromShopSell(Tuple<int, int>[] whereAreYouBuyingPositions)
        {

            for (int i = 0; i < whereAreYouBuyingPositions.Length; i++)
            {
                Thread.Sleep(1000);
                if (i == 0 && ProgramHandle.getSecondSlotValue < PointersAndValues.ItemCount1 + 20) // Manna Potion
                {
                    MouseOperations.MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2,200);

                    HowManyPotionsToBuySell(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < PointersAndValues.ItemCount1 + 4) // Red Potions
                {
                    MouseOperations.MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2, 200);
                    HowManyPotionsToBuySell(i);
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < PointersAndValues.ItemCount1 + 4) // White Potions
                {
                    MouseOperations.MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2, 200);
                    HowManyPotionsToBuySell(i);
                }
                else if (i == 3 && ProgramHandle.getFirstSlotValue < PointersAndValues.ItemCount1 + 30)      // HP Potions 
                {
                    MouseOperations.MoveAndLeftClickOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2, 200);
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
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);

                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
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
                BuyingHpPotionsMax();
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
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_3);
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

        static void BuyingHpPotionsMax()
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

        public static void MoveToRepot(Tuple<int, int>[] citySpecificPositions)
        {
            Thread.Sleep(500);
            if (!isNowRunningCity())
            {
                for (int i = 0; i < citySpecificPositions.Length; i++)
                {
                        MouseOperations.MoveAndLeftClickOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2, 10);
                        Thread.Sleep(1000);
                        while (!isNowStandingCity())
                        {
                        Thread.Sleep(1);
                        }
                }
            }
        }

        public static void Repot(int currentCity)
        {

            Thread.Sleep(1000);

            ProgramHandle.SetCameraForExpBot();

            if (currentCity == TeleportValues.Hershal)
            {
                MoveToRepot(ExpBotMovePositionsValues.HershalRepotMovePositions);
                MouseClickOpenShop();

                if (ProgramHandle.isShopWindowStillOpen() == 1)
                {
                    ItemSeller.SellItemsMouseMove();

                    BuyerPotionsHershalExp buyerPotionsHershalExp = new BuyerPotionsHershalExp();
                    buyerPotionsHershalExp.BuyPotions();

                   // BuyPotionsFromShopNormalEXP(ExpBotMovePositions.mousePositionsForHershalBuying);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
                    inputSimulator.Keyboard.Sleep(500);
                }
            }
            
            if (currentCity == TeleportValues.Kharon)
            {

                MoveToRepot(ExpBotMovePositionsValues.KharonRepotMovePositions);
                inputSimulator.Keyboard.Sleep(500);

                MouseClickOpenShop();

                inputSimulator.Keyboard.Sleep(500);

                ItemSeller.SellItemsMouseMove();

                inputSimulator.Keyboard.Sleep(500);
                BuyPotionsFromShopSell(ExpBotMovePositionsValues.mousePositionsForKharonBuying);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(500);

            }


        }
        public static void scrollToCity()
        {
            inputSimulator.Keyboard.Sleep(500);
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
                MouseOperations.MoveAndLeftClickOperation(955, 160, 200);
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
            ProgramHandle.SetCameraForExpBot();
            Thread.Sleep(500);
            if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
            {
                PressF5ForTeleport();
                ProgramHandle.SetCameraForExpBot();
                for (int i = 0; i < 70; i++)
                {

                    if (ProgramHandle.GetCurrentMap != TeleportValues.UWC1stFloor)
                    {
                        Thread.Sleep(50);
                        MouseOperations.SetCursorPosition(1110+i, 380+i);
                        Thread.Sleep(50);
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                        Thread.Sleep(50);
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                        Thread.Sleep(50);
                    }
                }
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                Thread.Sleep(1000);
                ProgramHandle.SetCameraForExpBot();
                Thread.Sleep(100);
            }
/*            else
            {
                ProgramHandle.HealBotTeleportRepotGoUWC();
            }
*/     
        }

        static void MoveToPositionWhenNotAttacking( int x,int y)
        {
            Thread.Sleep(50);

            if (ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isRunningAnimationArcALLIOutside && ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isRunningAnimationArcEMPOutside)
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
/*
        static void MoveScanAndAttack(int x, int y)
        {
            if (isNowStandingOut())
            {
                moveToPosition(x, y);
            }

            PixelMobAttack.AttackSkillMobWhenSelected();
        }
*/       public static void MoveIfStandingOut(int x,int y)
        {

            if (isNowStandingOut())
            {

                moveToPosition(x, y);

            }

            /*            if (!PixelMobAttack.AttackSkillMobWhenSelected())
                        {
                            ScanAndCollectClickLeftOnhighlightedForNow();
                        }

            */
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

        public static bool goLeft(int x, int y, int leftLimit, int upLimit, int downLimit, int moveOnlyOnMapX)
        {
                while (ProgramHandle.GetPositionX > leftLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                {

                if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                    ExpBotLog += $"goLeft \n";

                    MoveIfStandingOut(x+ moveRandomizer, y+ moveRandomizer);
                    }
                    if (ProgramHandle.GetPositionY > upLimit)
                    {
                    ExpBotLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                    goDown(900+ moveRandomizer, 640+ moveRandomizer, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
                    }
                    if (ProgramHandle.GetPositionY < downLimit)
                    {
                    ExpBotLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
                    goUp(962+ moveRandomizer, 430+ moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
                    }

                }
                return true;

        }
        public static bool goRight(int x, int y, int rightLimit, int upLimit, int downLimit, int moveOnlyOnMapX)
        {
                while (ProgramHandle.GetPositionX < rightLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                {

                if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                    ExpBotLog += $"goRight \n";

                    MoveIfStandingOut(x+ moveRandomizer, y+ moveRandomizer);

                    }
                    if (ProgramHandle.GetPositionY > upLimit)
                {
                    ExpBotLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    goDown(963+ moveRandomizer, 600+ moveRandomizer, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);

                    }
                    if (ProgramHandle.GetPositionY < downLimit)
                {
                    ExpBotLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    goUp(964+ moveRandomizer, 430+ moveRandomizer, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor, moveOnlyOnMapX);
                    }

                }
                return true;
        }
        public static bool goUp(int x, int y, int upLimit, int leftLimit,int rightLimit, int moveOnlyOnMapX)
        {
                while (ProgramHandle.GetPositionY < upLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
                {

                if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                        {
                        ExpBotLog += $"goUp \n";

                        MoveIfStandingOut(x+ moveRandomizer, y+ moveRandomizer);

                        }
                    if (ProgramHandle.GetPositionX > rightLimit)
                        {
                            ExpBotLog += $"goUp-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                            goLeft(800+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, moveOnlyOnMapX);

                        }
                    if (ProgramHandle.GetPositionX < leftLimit)
                        {
                        ExpBotLog += $"goUp-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                        goRight(1100+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, moveOnlyOnMapX);

                        }

                }
                return true;
        }
        public static bool goDown(int x, int y, int upLimit, int leftLimit, int rightLimit, int moveOnlyOnMapX)
        {
            while (ProgramHandle.GetPositionY > upLimit && _stopMoveExpBot && ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
            {

                if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                {
                    ExpBotLog += $"goDown currentY xyz{ProgramHandle.GetPositionY} downLimit {upLimit} currentX {ProgramHandle.GetPositionX} \n";

                    MoveIfStandingOut(x+ moveRandomizer, y+ moveRandomizer);

                }
                if (ProgramHandle.GetPositionX > rightLimit)
                {
                    ExpBotLog += $"goDown-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    goLeft(800+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, moveOnlyOnMapX);

                }
                if (ProgramHandle.GetPositionX < leftLimit)
                {
                    ExpBotLog += $"goDown-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    goRight(1100+ moveRandomizer, 520+ moveRandomizer, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor, moveOnlyOnMapX);
                }

            }
            return true;
        }


        public static void RunAndExpSquareUWC()
        {
            int howManyForLoops = 0;
            while(_stopMoveExpBot )
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

                        while (!goLeft(600, 520, 1112000000, 1111239992, 1109794945,TeleportValues.UWC1stFloor)) ;
                        ExpBotLog += $"goLeft Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);

                        while (!goUp(960, 300, 1115828432, 1107050535, ProgramHandle.GetPositionX + 80000000, TeleportValues.UWC1stFloor)) ;
                        ExpBotLog += $"goUp Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goRight(1250, 520, 1120884234 /*1128331398  old go full right*/, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.UWC1stFloor)) ;
                        ExpBotLog += $"GoRight Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goDown(965, 650, 1110537017, 1120835756, 1122982731, TeleportValues.UWC1stFloor)) ;
                        ExpBotLog += $"GoDown Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                ExpBotLog += $"while end {howManyForLoops} \n";

            }
        }
        public static void RunAndExpSquareSacred()
        {
            int howManyForLoops = 0;
            while (_stopMoveExpBot)
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

                        while (!goLeft(600, 520, 1121245593, 1146928281, 1145928281, TeleportValues.AllianceSacredLand)) ;
                        ExpBotLog += $"goLeft Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);

                        while (!goUp(960, 300, 1146075590, 1120772620, ProgramHandle.GetPositionX + 80000000, TeleportValues.AllianceSacredLand)) ;
                        ExpBotLog += $"goUp Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                        while (!goRight(1250, 520, 1125340770, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000, TeleportValues.AllianceSacredLand)) ;
                        ExpBotLog += $"GoRight Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        ExpBotLog += $"current i {i}\n";

                        Thread.Sleep(100);
                        while (!goDown(965, 650, 1110537017, 1120835756, 1122982731, TeleportValues.AllianceSacredLand)) ;
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
            MouseOperations.MoveAndLeftClickOperation(920, 155, 200);
            Thread.Sleep(1000);
        }


        public static void MoveAndRightClickOperation(int xPos, int yPos)
        {
            Thread.Sleep(50);
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(50);
        }





    }
}
