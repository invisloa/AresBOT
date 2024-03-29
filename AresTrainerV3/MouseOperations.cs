﻿using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace AresTrainerV3
{
	public class MouseOperations
	{
		[Flags]
		public enum MouseEventFlags
		{
			LeftDown = 0x00000002,
			LeftUp = 0x00000004,
			MiddleDown = 0x00000020,
			MiddleUp = 0x00000040,
			Move = 0x00000001,
			Absolute = 0x00008000,
			RightDown = 0x00000008,
			RightUp = 0x00000010
		}
		private bool IsRightMouseButtonPressed()
		{
			return (Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right;
		}

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetCursorPos(out MousePoint lpMousePoint);

		[DllImport("user32.dll")]
		private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);



		public static void SetCursorPosition(int x, int y)
		{
			SetCursorPos(x, y);
		}
		public static void MoveAndRightClickOperation(int xPos, int yPos)
		{
			int sleepTime = 100;
			Thread.Sleep(10);
			MouseOperations.SetCursorPosition(xPos, yPos);
			if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right)	// Right mouse button is pressed
			{
				Thread.Sleep(sleepTime);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);

			}
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
			Thread.Sleep(sleepTime);
		}

		public static void SetCursorPosition(MousePoint point)
		{
			SetCursorPos(point.X, point.Y);
		}


		public static MousePoint GetCursorPosition()
		{
			MousePoint currentMousePoint;
			var gotPoint = GetCursorPos(out currentMousePoint);
			if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
			return currentMousePoint;
		}

		public static void MouseEvent(MouseEventFlags value)
		{
			MousePoint position = GetCursorPosition();

			mouse_event
				((int)value,
				 position.X,
				 position.Y,
				 0,
				 0)
				;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct MousePoint
		{
			public int X;
			public int Y;

			public MousePoint(int x, int y)
			{
				X = x;
				Y = y;
			}
		}
		public static void OpenInventoryTab1()
		{
			if (ProgramHandle.isCurrentInventoryTabOppened != 0 && ProgramHandle.isShopWindowStillOpen ==1)
			{
				Thread.Sleep(200);
				if (ProgramHandle.isCurrentInventoryTabOppened != 0 && ProgramHandle.isShopWindowStillOpen == 1)
				{
					Thread.Sleep(15);
					MoveAndLeftClickOperation(1235, 570, 100);
					Thread.Sleep(15);
					for (int i = 0; i < 4; i++)
					{
						if (ProgramHandle.isCurrentInventoryTabOppened != 0)
						{
							Thread.Sleep(15);
							MoveAndLeftClickOperation(1235, 570, 100);
							Thread.Sleep(15);
						}
					}
				}
			}
		}
		public static void OpenInventoryTab2()
		{
			if (ProgramHandle.isShopWindowStillOpen == 1)
			{
				Thread.Sleep(15);
				MouseOperations.MoveAndLeftClickOperation(1235, 670, 100); // Open Inventory Tab 2
				Thread.Sleep(15);
				if (ProgramHandle.isCurrentInventoryTabOppened != 1)
				{
					OpenInventoryTab2();
				}
			}
		}
		public static void OpenDeleteTab()
		{
			MoveAndLeftClickOperation(1415, 765, 50);
		}
		public static void MoveItemToDeleteWindow()
		{
			MoveAndLeftClickOperation(1080, 200, 50);
		}

		public static void MoveAndLeftClickOperation(int xPos, int yPos)
		{
			int delay = 77;
			MouseOperations.SetCursorPosition(xPos, yPos);
			Thread.Sleep(delay);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(delay);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(delay);
		}


		public static void MoveAndLeftClickOperation(int xPos, int yPos, int delay)
		{
			MouseOperations.SetCursorPosition(xPos, yPos);
			Thread.Sleep(delay);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(delay);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(delay);
		}

		public static void ClickMaxPotionsToBuy()
		{
			MouseOperations.MoveAndLeftClickOperation(570, 520, 400);
		}
		public static void ClickFirstSlotInventoryLeft()
		{
			MouseOperations.MoveAndLeftClickOperation(1265, 550, 400);
		}



	}
}
