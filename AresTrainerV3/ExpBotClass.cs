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
        private static volatile bool _stopMoveExpBot = false;
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
                if(i==0 && ProgramHandle.getForthSlotValue < 16777221)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);

                    BuyingPotions(i);
                }
                else if (i == 1 && ProgramHandle.getThirdSlotValue < 16777221)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i);
                }
                else if (i == 2 && ProgramHandle.getSecondSlotValue < 16777275)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
                else if (i == 3)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
            }

        }


        static void BuyingPotions(int numberOfPotionToBuy)
        {
            MouseOperations.SetCursorPosition(1300,550);
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(500);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(1000);

            if (numberOfPotionToBuy == 0) // white potion
            {
                    inputSimulator.Keyboard.Sleep(1000);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
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
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                    inputSimulator.Keyboard.Sleep(500);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    inputSimulator.Keyboard.Sleep(200);
                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    inputSimulator.Keyboard.Sleep(500);
            }
            else if (numberOfPotionToBuy == 2) // manna potion
            {
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
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
            if (ProgramHandle.isWhatAnimationRunning != PointersAndValues.isRunningAnimation)
            {
                for (int i = 0; i < citySpecificPositions.Length; i++)
                {
                    MoveAndLeftClickOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2);
                    while (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimation)
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
            }

        }

        static void PressF5ForTeleport()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F5);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.F5);
            inputSimulator.Keyboard.Sleep(500);
        }

        static void WalkIntoUWC()
        {
            while(ProgramHandle.GetCurrentMap != TeleportValues.UWC1stFloor)
            {
                Thread.Sleep(500);
                MouseOperations.SetCursorPosition(1000, 400);
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
            if (ProgramHandle.isWhatAnimationRunning != PointersAndValues.isRunningAnimation)
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

        static void MoveAndScan(int x,int y)
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimation)
            {
                moveToPosition(x,y);
            }
            else if( ScanAndAttack)

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

        static void GoExp(int currentCity)
        {

            if (currentCity == TeleportValues.Hershal)
            {
                PressF5ForTeleport();
                WalkIntoUWC();
            }



        }

        const int moveBuffor = 99000000;

        public static bool goLeft(int x, int y, int leftLimit, int upLimit, int downLimit)
        {
                while (ProgramHandle.GetPositionX > leftLimit && isStopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                        MoveToPositionWhenNotAttacking(x, y);
                    }
                    else if (ProgramHandle.GetPositionY > upLimit)
                    {
                        goDown(960, 600, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                        goUp(960, 430, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    }

                }
                return true;

        }
        public static bool goRight(int x, int y, int rightLimit, int upLimit, int downLimit)
        {
                while (ProgramHandle.GetPositionX < rightLimit && isStopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionY < upLimit && ProgramHandle.GetPositionY > downLimit)
                    {
                        MoveToPositionWhenNotAttacking(x, y);
                    }
                    else if (ProgramHandle.GetPositionY > upLimit)
                    {
                        goDown(960, 600, upLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    }
                    else if (ProgramHandle.GetPositionY < downLimit)
                    {
                        goUp(960, 430, downLimit, ProgramHandle.GetPositionX - moveBuffor, ProgramHandle.GetPositionX + moveBuffor);
                    }

                }
                return true;
        }
        public static bool goUp(int x, int y, int upLimit, int leftLimit,int rightLimit)
        {
                while (ProgramHandle.GetPositionY < upLimit && isStopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                    {
                        MoveToPositionWhenNotAttacking(x, y);
                    }
                    else if (ProgramHandle.GetPositionX > rightLimit)
                    {
                        goLeft(800, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    }
                    else if (ProgramHandle.GetPositionX < leftLimit)
                    {
                        goRight(1100, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    }

                }
                return true;
        }
        public static bool goDown(int x, int y, int downLimit, int leftLimit, int rightLimit)
        {
                while (ProgramHandle.GetPositionY > downLimit && isStopMoveExpBot)
                {
                    if (ProgramHandle.GetPositionX > leftLimit && ProgramHandle.GetPositionX < rightLimit)
                    {
                        MoveToPositionWhenNotAttacking(x, y);
                    }
                    else if (ProgramHandle.GetPositionX > rightLimit)
                    {
                        goLeft(800, 520, rightLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    }
                    else if (ProgramHandle.GetPositionX < leftLimit)
                    {
                        goRight(1100, 520, leftLimit, ProgramHandle.GetPositionY - moveBuffor, ProgramHandle.GetPositionY + moveBuffor );
                    }

                }
                return true;
        }
    }
}
