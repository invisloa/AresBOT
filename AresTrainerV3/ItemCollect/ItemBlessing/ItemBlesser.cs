using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect.ItemBlessing
{
	public class ItemBlesser
	{
		int blessMaxValue = 0;
		public ItemBlesser(int blessLimit) 
		{
			blessMaxValue = blessLimit;	
		}

		public void BlessItem()
		{
			while (blessMaxValue < ProgramHandle.ReadBless2RowValue())
			{
				MouseOperations.SetCursorPosition(1300, 560);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
				Thread.Sleep(50);
				MouseOperations.SetCursorPosition(570, 570);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
				Thread.Sleep(50);
				MouseOperations.SetCursorPosition(1260, 560);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
				Thread.Sleep(50);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			}
		}


	}
}
