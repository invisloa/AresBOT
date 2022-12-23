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

		public void BlessItem(int blessValue)
		{
			int sleepTime = 200;
			int i = 0;
			while ((blessValue > ProgramHandle.GetBless2RowValue) && ExpBotManagerAbstract.isExpBotRunning)
			{
				{
					ProgramHandle.SetCameraForExpBot();
					Thread.Sleep(sleepTime);
					//ProgramHandle.TeleportToPositionTuple(TeleportValues.PosBlessingItems);
					MouseOperations.SetCursorPosition(1300, 560);
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
					Thread.Sleep(sleepTime);
					MouseOperations.SetCursorPosition(915, 460);
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
					MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
					Thread.Sleep(sleepTime);
					MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
					Thread.Sleep(sleepTime);
				}
			}
		}


	}
}
