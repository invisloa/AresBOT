using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class KeyPresser
    {
        static InputSimulator inputSimulator = new InputSimulator();

        public static void PressEnter(int startDelay, int endDelay)
        {
			inputSimulator.Keyboard.Sleep(startDelay);
			inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN);
			inputSimulator.Keyboard.Sleep(startDelay);
			inputSimulator.Keyboard.KeyUp(VirtualKeyCode.RETURN);
			inputSimulator.Keyboard.Sleep(endDelay);
		}

		public static void PressKey(int keyNumber,int startDelay,int endDelay)
        {
            if (keyNumber == 0)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                inputSimulator.Keyboard.Sleep(endDelay);
            }
            if (keyNumber == 1)
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 2)
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 3)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 4)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_4);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_4);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_4);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 5)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 6)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(endDelay);


            }
            if (keyNumber == 7)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                inputSimulator.Keyboard.Sleep(endDelay);


            }
            if (keyNumber == 8)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                inputSimulator.Keyboard.Sleep(endDelay);

            }
            if (keyNumber == 9)
            {
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_9);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_9);
                inputSimulator.Keyboard.Sleep(startDelay);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_9);
                inputSimulator.Keyboard.Sleep(endDelay);
            }
        }

        public static void PressEscape()
        {
            Thread.Sleep(50);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
            Thread.Sleep(50);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
            Thread.Sleep(50);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.ESCAPE);
            Thread.Sleep(50);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.ESCAPE);
            Thread.Sleep(50);
        }
    }
}
