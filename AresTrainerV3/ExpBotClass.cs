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

        public static bool ExpBotRepot(Tuple<int, int>[] MainCityRepotPositions)
        {

            ProgramHandle.SetCameraForExpBot();
            MoveToPotionSuplier(MainCityRepotPositions);

            return true;
        }

        static void MoveToPotionSuplier(Tuple<int, int>[] MainCityRepotPositions)
        {
            foreach (var item in MainCityRepotPositions)
            {
                MouseOperations.SetCursorPosition(item.Item1, item.Item2);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            }
        }

/*        static void BuyFromSuplier(int whichCity)
        {
            if(ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
            {
                BuyPotionsFromShop(whichCity);
            }
        }
*/
        
        static void MoveMouseForBuyingOperation(int xPos,int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(100);
        }
        static void MoveAndLeftCliokOperation(int xPos, int yPos)
        {
            MouseOperations.SetCursorPosition(xPos, yPos);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(100);
        }

        static void BuyPotionsFromShop(Tuple<int,int> [] whereAreYouBuyingPositions)
        {

            Thread.Sleep(1000);
            MoveAndLeftCliokOperation(577, 551);

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
                else if (i == 2 && ProgramHandle.getSecondSlotValue < 16777255)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
                else if (i == 3)
                {
                    MoveMouseForBuyingOperation(whereAreYouBuyingPositions[i].Item1, whereAreYouBuyingPositions[i].Item2);
                    BuyingPotions(i); }
            }

        }

        public static Tuple<int, int>[] mousePositionsForHershalBuying = new Tuple<int, int>[]
        {
            new Tuple<int, int>(945, 415),  //white pot
            new Tuple<int, int>(947, 451),  //red pot
            new Tuple<int, int>(945, 375),  //mana pot
            new Tuple<int, int>(947, 215)   //hp yarrow pot
        };
        public static Tuple<int, int>[] HershalMovePositions = new Tuple<int, int>[]
{
            new Tuple<int, int>(433, 464),  
            new Tuple<int, int>(438, 678),  
            new Tuple<int, int>(569, 791),
            new Tuple<int, int>(800, 747),
};

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
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
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
            MouseOperations.SetCursorPosition(520, 500);
            Thread.Sleep(500);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
            MouseOperations.SetCursorPosition(518, 554);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
        }

        static void MoveToRepot(Tuple<int, int>[] citySpecificPositions)
        {
            Thread.Sleep(500);
            if (ProgramHandle.isStillRunningValue != 2)
            {
                for (int i = 0; i < citySpecificPositions.Length; i++)
                {
                    MoveAndLeftCliokOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2);
                    while (ProgramHandle.isStillRunningValue == 2)
                    {
                        Thread.Sleep(2);
                    }
                }
            }

        }
        static void SetWindowInPropperPosition()
        {
            ProgramHandle.SetNostalgiaMainWindow();

            Thread.Sleep(1000);
            MouseOperations.SetCursorPosition(1, 1);
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(1000);
            MouseOperations.SetCursorPosition(400, 120);
            Thread.Sleep(1000);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            MouseOperations.SetCursorPosition(500, 200);
            Thread.Sleep(1000);

        }
        public static void Repot(int currentCity)
        {
            SetWindowInPropperPosition();

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
                MoveToRepot(HershalMovePositions);
                BuyPotionsFromShop(mousePositionsForHershalBuying);
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

        static void BotUWC1stFloor()
        {
            if (ProgramHandle.isStillRunningValue == 0 && ProgramHandle.isMobBeingAttacked !=-1 )
            Thread.Sleep(50);
            MouseOperations.SetCursorPosition(600, 505);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(50);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(50);

        }

        static void GoExp(int currentCity)
        {
            SetWindowInPropperPosition();

            if (currentCity == TeleportValues.Hershal)
            {
                PressF5ForTeleport();
            }
            WalkIntoUWC();



        }

    }
}
