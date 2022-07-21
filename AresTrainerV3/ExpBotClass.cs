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

namespace AresTrainerV3
{
    public static class ExpBotClass
    {
        static InputSimulator inputSimulator = new InputSimulator();

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

        public static string PositionLog;

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

        static void MoveMouseForBuyingOperation(int xPos,int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(100);
        }
        static void MoveAndLeftClickOperation(int xPos, int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(100);
        }

        public static void BuyPotionsFromShop(Tuple<int,int> [] whereAreYouBuyingPositions)
        {

            Thread.Sleep(1000);
            MoveAndLeftClickOperation(580, 565);

            for (int i = 0; i < whereAreYouBuyingPositions.Length; i++)
            {
                Thread.Sleep(1000);
                if(i==0 && ProgramHandle.getSecondSlotValue < 16777285) // Manna Potion
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);

                    BuyingPotions(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < 16777223) // Red Potions
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i);
                }
                else if (i == 2 && ProgramHandle.getForthSlotValue < 16777223) // White Potions
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
                else if (i == 3)      // HP Potions
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
            }

        }


        static void BuyingPotions(int numberOfPotionToBuy)
        {
            MouseOperations.SetCursorPosition(1295,530);
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(500);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(1000);

            if (numberOfPotionToBuy == 0) // Manna Potion
            {
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(500);

                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                inputSimulator.Keyboard.Sleep(500);


            }
            if (numberOfPotionToBuy == 1) //red potion
            {
                    inputSimulator.Keyboard.Sleep(500);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                    inputSimulator.Keyboard.Sleep(500);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    inputSimulator.Keyboard.Sleep(500);
            }
            else if (numberOfPotionToBuy == 2) // White Potion
            {
                inputSimulator.Keyboard.Sleep(1000);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                inputSimulator.Keyboard.Sleep(500);

            }
            else if (numberOfPotionToBuy == 3) // HP potion
            {
                BuyingHpPotions();
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
            MouseOperations.SetCursorPosition(560, 570);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
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
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(500);

            ProgramHandle.SetCameraForExpBot();

            if (currentCity == TeleportValues.Hershal)
            {
                MoveToRepot(ExpBotMovePositions.HershalMovePositions);
                BuyPotionsFromShop(ExpBotMovePositions.mousePositionsForHershalBuying);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
                inputSimulator.Keyboard.Sleep(500);

            }

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



        static void MoveAndAttack(int currentMap)
        {
            currentMap = ProgramHandle.GetCurrentMap;

            if(currentMap== TeleportValues.UWC1stFloor)
            {


            }
        }


        const int moveBuffor = 99000000;  /// when it was lower bot was moving up and down all the time - around (10000)

        public static bool goLeft(int x, int y, int leftLimit, int upLimit, int downLimit)
        {
                while (ProgramHandle.GetPositionX > leftLimit && _stopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                        MoveScanAndAttack(x, y);
                    PositionLog += $"goLeft \n";

                }
                else if (ProgramHandle.GetPositionY > upLimit)
                    {
                        goDown(961, 600, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);

                    PositionLog += $"goLeft-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    
                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                        goUp(962, 430, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    PositionLog += $"goLeft-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

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
                    MoveScanAndAttack(x, y);
                    PositionLog += $"goRight \n";

                    }
                    else if (ProgramHandle.GetPositionY > upLimit)
                    {
                            goDown(963, 600, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                        PositionLog += $"goRight-goDown currentY {ProgramHandle.GetPositionY} UpLimit {upLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                            goUp(964, 430, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                        PositionLog += $"goRight-goUp currentY {ProgramHandle.GetPositionY} downLimit {downLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";
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
                    MoveScanAndAttack(x, y);
                    PositionLog += $"goUp \n";

                }
                else if (ProgramHandle.GetPositionX > rightLimit)
                    {
                        goLeft(800, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    PositionLog += $"goUp-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }
                else if (ProgramHandle.GetPositionX < leftLimit)
                    {
                        goRight(1100, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    PositionLog += $"goUp-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

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
                    MoveScanAndAttack(x, y);
                    PositionLog += $"goDown currentY {ProgramHandle.GetPositionY} downLimit {upLimit} currentX {ProgramHandle.GetPositionX} \n";

                }
                else if (ProgramHandle.GetPositionX > rightLimit)
                {
                    goLeft(800, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor);
                    PositionLog += $"goDown-goLeft currentX {ProgramHandle.GetPositionX} rightLimit {rightLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }
                else if (ProgramHandle.GetPositionX < leftLimit)
                {
                    goRight(1100, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor);
                    PositionLog += $"goDown-goRight currentX {ProgramHandle.GetPositionX} leftLimit {leftLimit} current x {ProgramHandle.GetPositionX}, current y {ProgramHandle.GetPositionY} \n";

                }

            }
            return true;
        }


        public static void RunAndExpSquare()
        {
            int howManyForLoops = 0;
            while(_stopMoveExpBot)
            {
                PositionLog += $"Starting new While \n";

                for (int i = 0; i < 3; i++)
                {
                    PositionLog += $"starting new for \n";

                    Thread.Sleep(100);
                    if (i == 0)
                    {
                        PositionLog += $"current i {i}\n";
                        Thread.Sleep(100);

                        while (!goLeft(600, 520, 1109300565, 1111239992, 1109794945)) ;
                        PositionLog += $"goLeft Ended current i {i}\n";

                    }

                    else if (i == 1)
                    {
                        PositionLog += $"current i {i}\n";

                        Thread.Sleep(100);

                        while (!goUp(960, 300, 1114565081, 1107050535, ProgramHandle.GetPositionX + 800000)) ;
                        PositionLog += $"goUp Ended current i {i}\n";

                    }
                    else if (i == 2)
                    {
                        PositionLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goRight(1250, 520, 1122188392, ProgramHandle.GetPositionY + 800000, ProgramHandle.GetPositionY - 800000)) ;
                        PositionLog += $"GoRight Ended current i {i}\n";

                    }
                    else if (i == 3)
                    {
                        PositionLog += $"current i {i}\n";

                        Thread.Sleep(100);
                    while (!goDown(965, 650, 1110537017, 1120835756, 1122982731)) ;
                        PositionLog += $"GoDown Ended current i {i}\n";

                    }

                }
                howManyForLoops++;
                PositionLog += $"while end {howManyForLoops} \n";

            }
        }
    }
}
