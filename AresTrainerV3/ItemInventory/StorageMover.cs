using AresTrainerV3.ItemCollect;
using AresTrainerV3.ItemInventory.Buyer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemInventory
{
	internal class ItemsStorageMoverHack : IItemsStorageMoverHack
	{
		IItemsOperationsGenerator itemOperations = Factory.ItemsOperationsGenerator();

		public void MoveItemsToStorage()
		{
			if (!isStorageFullCheck())
			{
				List<int> imtemsToOperate = itemOperations.ItemsToStorageMoveListGenerate();
				int itemsToMoveToStorageCount = imtemsToOperate.Count;
				if (itemsToMoveToStorageCount > 3 &&
					ProgramHandle.getCurrentWeight > AbstractWhatToCollect.MaxCollectWeight - 200) // - 200 is at least 1 item less then needed for repot
				{
					ProgramHandle.OpenStorageWindow();
					Thread.Sleep(200);
					MouseOperations.OpenInventoryTab1();
					Thread.Sleep(75);

					//  SELL ONLY FIRST ROW OF SECOND TAB  
					// for (int i = 12; i < ExpBotMovePositions.itemSellPositions.Length; i++) // START FROM 3 Row 1st Column - its 12
					foreach (int item in imtemsToOperate)
					{
						Debug.WriteLine($"move to Storage{item}");

						int itemToMove = item + 6; // START FROM 2 Row 1st column
						if (itemToMove >= 36 && ProgramHandle.isCurrentInventoryTabOppened == 0)
						{
							Thread.Sleep(150);
							MouseOperations.MoveAndLeftClickOperation(1235, 670, 100); // Open Inventory Tab 2
							Thread.Sleep(150);
						}
						MouseOperations.MoveAndRightClickOperation(ExpBotMovePositionsValues.itemSellPositions[itemToMove].Item1, ExpBotMovePositionsValues.itemSellPositions[itemToMove].Item2);
					}
					Thread.Sleep(50);
					KeyPresser.PressEscape();
					KeyPresser.PressEscape();
				}
			}
		}
		public bool isStorageFullCheck()
		{
			int invSlotValue = 0;
			for (int i = 95; i < 98; i++)
			{
				invSlotValue += ProgramHandle.ReadStorageItemsvalue(i);
			}
			if (invSlotValue > 2) // not =3 cause there can be potions etc.
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#region ItemMoveFromStorage

		public void moveItemsFromStorage()
		{
			KeyPresser.PressEscape();
			Thread.Sleep(200);
			ProgramHandle.OpenStorageWindow();
			Thread.Sleep(700);
			MouseOperations.OpenInventoryTab1();
			List<int> imtemsToOperate = itemOperations.ItemsFromStorageListGenerate();

			foreach (int item in imtemsToOperate)
			{
				if (ProgramHandle.isInventoryWindowStillOpen == 1 && ProgramHandle.getCurrentWeight < AbstractWhatToCollect.MaxCollectWeightNormalValue)
				{
					Debug.WriteLine($"move from Storage{item}");
					Thread.Sleep(1);
					MouseOperations.MoveAndRightClickOperation(ExpBotMovePositionsValues.itemMoveFromStoragePositions[item].Item1, ExpBotMovePositionsValues.itemMoveFromStoragePositions[item].Item2);
					Thread.Sleep(1);
				}
			}
		}
		#endregion

	}
}
