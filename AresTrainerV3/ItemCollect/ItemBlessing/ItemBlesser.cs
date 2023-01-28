using AresTrainerV3.ExpBotManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect.ItemBlessing
{
	public class ItemBlesser
	{
		int sleepTime = 200;
		int posSlotFirstSod = 1300;
		int posSlotSecontSod = 1330;
		int posSlotThirdSod = 1360;
		int secondItemBlessValue { get { return ProgramHandle.GetBless2RowValue; } }

		public void BlessItem(int blessValue)
		{
		ExpBotManagerAbstract.RequestStartExpBot();
			ProgramHandle.SetGameAsMainWindow();
			Thread.Sleep(sleepTime*3);
			int i = 0;
			while ((secondItemBlessValue < blessValue) && ExpBotManagerAbstract.isExpBotRunning)
			{
				if (ProgramHandle.ReadInvItmsCount(0) == 0)
				{
					BuyDestructedItem();
				}
				if (blessValue == 6)
				{
					blessItemTo4();
					blessItem4To6();
				}

				if (blessValue ==7)
				{
					blessItemTo4();
					blessItem4To5();
					blessItem5To7();
					blessItem6To7();
				}
				else
				{
					BlessItemMouseMoves(posSlotFirstSod);
				}
			}
		}

		void blessItemTo4()
		{
			while ((secondItemBlessValue < 4) && ExpBotManagerAbstract.isExpBotRunning)
			{
				BlessItemMouseMoves(posSlotFirstSod);
			}
		}
		void blessItem4To5()
		{
			if (secondItemBlessValue == 4)
			{
				BlessItemMouseMoves(posSlotSecontSod);
			}
		}
		void blessItem4To6()
		{
			if (secondItemBlessValue == 4)
			{
				BlessItemMouseMoves(posSlotSecontSod);
			}
		}
		void blessItem5To7()
		{
			if (secondItemBlessValue == 5)
			{
				BlessItemMouseMoves(posSlotThirdSod);
			}
		}
		void blessItem6To7()
		{
			if (secondItemBlessValue == 6)
			{
				BlessItemMouseMoves(posSlotFirstSod);
			}
		}


		void BuyDestructedItem()
		{
			ProgramHandle.SetCameraForExpBot();
			Thread.Sleep(sleepTime*2);
			MouseOperations.SetCursorPosition(915, 460);
			Thread.Sleep(sleepTime*2);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
			Thread.Sleep(sleepTime * 2);
			MouseOperations.SetCursorPosition(570, 570);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(sleepTime);

		}
		void BlessItemMouseMoves(int sodsPosition)
		{
			ProgramHandle.SetCameraForExpBot();
			Thread.Sleep(sleepTime);
			//ProgramHandle.TeleportToPositionTuple(TeleportValues.PosBlessingItems);
			MouseOperations.SetCursorPosition(sodsPosition, 560);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
			Thread.Sleep(sleepTime);
			MouseOperations.SetCursorPosition(570, 570);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(sleepTime);
			MouseOperations.SetCursorPosition(1260, 560);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
		}


	}
}
