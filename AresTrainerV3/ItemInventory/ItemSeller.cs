using AresTrainerV3.ItemCollect;
using AresTrainerV3.ItemInventory.Buyer;
using AresTrainerV3.ShopSellAntiBug;
using System.Diagnostics;
using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3.ItemInventory
{
	public class ItemSeller
	{
		IUnBugShop ShopUnbugger = Factory.CreateUnbugShop();
		int howManyTries = 0;
		IItemsOperationsGenerator itemOperations = Factory.ItemsOperationsGenerator();

		public void SellItemsByMouseMove()
		{
			AssignWeight();
			if (IsCloseToShop())
			{
				ProgramHandle.OpenShopWindow();
				int firstSellListCount = itemOperations.ItemsForSaleListGenerate().Count;
				List<int> imtemsToOperate = itemOperations.ItemsForSaleListGenerate();
				int bugVerifier = 0;
				Thread.Sleep(700);
				MouseOperations.OpenInventoryTab1();
				foreach (var item in imtemsToOperate)
				{
					if (ProgramHandle.isShopWindowStillOpen == 1)
					{
						Debug.WriteLine($"sell item {item}");

						int sellItemNumber = item + 6; // START FROM 2 Row 1st Column = 12
						if (sellItemNumber >= 36 && ProgramHandle.isCurrentInventoryTabOppened == 0)
						{
							MouseOperations.OpenInventoryTab2();
						}
						MouseOperations.MoveAndRightClickOperation(ExpBotMovePositionsValues.itemSellPositions[sellItemNumber].Item1, ExpBotMovePositionsValues.itemSellPositions[sellItemNumber].Item2);
						MouseConfirmSelling();
						bugVerifier++;
					}
					if (bugVerifier == 3 && imtemsToOperate.Count == itemOperations.ItemsForSaleListGenerate().Count)
					{
						howManyTries++;
						if (howManyTries == 5)
						{
							throw new NotImplementedException();
							//System.Diagnostics.Process.Start("Shutdown", "-s -t 30");
						}
						ShopTooFarAntiBug();
						Thread.Sleep(200);
						SellItemsByMouseMove();
					}
				}
				howManyTries = 0;
				Thread.Sleep(50);
				if (itemOperations.ItemsForSaleListGenerate().Count != 0 && firstSellListCount != itemOperations.ItemsForSaleListGenerate().Count)
				{
					Debug.WriteLine($"items for sale left {imtemsToOperate.Count}");
					SellItemsByMouseMove();
				}
				if (itemOperations.ItemsFromStorageListGenerate().Count != 0 && ProgramHandle.isShopWindowStillOpen == 1 && ProgramHandle.getCurrentWeight < AbstractWhatToCollect.MaxCollectWeightNormalValue)
				{
					KeyPresser.PressEscape();
					moveItemsFromStorage();
					KeyPresser.PressEscape();
					KeyPresser.PressEscape();
					Thread.Sleep(500);
					SellItemsByMouseMove();                //XXXXXXXXXXXXXX Mouse
				}
			}
		}

		void ShopTooFarAntiBug()
		{
			if (IsCloseToShop())
			{
				KeyPresser.PressEscape();
				ShopUnbugger.UnBugShop();
			}
		}

		public bool IsCloseToShop()
		{
			if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
			{
				if (ProgramHandle.GetPositionX > 1141175465 && ProgramHandle.GetPositionX < 1141336640
					&& ProgramHandle.GetPositionY > 1141133820 && ProgramHandle.GetPositionY < 1141308147)
				{ return true; }
				else
				{ return false; }
			}
			else if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
			{
				if (ProgramHandle.GetPositionX > 1125115858 && ProgramHandle.GetPositionX < 1125782038
					&& ProgramHandle.GetPositionY > 1125170820 && ProgramHandle.GetPositionY < 1125701048)
				{ return true; }
				else
				{ return false; }
			}
			return true;
		}
		public static void MouseConfirmSelling()
		{
			Debug.WriteLine("Check if selll window is open");
			Thread.Sleep(50);
			if (ProgramHandle.isSellWindowStillOpen == 1)
			{
				LeftClickOnConfirmSell("normal item sell");
			}

			Debug.WriteLine("Check if high value");
			Thread.Sleep(100);
			if (ProgramHandle.isSellWindowStillOpen == 1)
			{
				Thread.Sleep(10);
				LeftClickOnConfirmSell("high value item click once more");
				Thread.Sleep(50);
			}
		}
		public static void SellItemEnterConfirmation()
		{
			KeyPresser.PressEnter(10, 10);
		}
		#region OldSellItems
		public void AssignWeight()
		{
			AbstractWhatToCollect.MaxCollectWeight = ProgramHandle.getMaxWeight - 150;
			AbstractWhatToCollect.MaxCollectWeightNormalValue = ProgramHandle.getMaxWeight - 150;
		}
		static void LeftClickOnConfirmSell(string debugMessage)
		{
			int sleepTime = 35;
			if((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
			{
				Thread.Sleep(sleepTime);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			}
			Debug.WriteLine(debugMessage);
			MouseOperations.SetCursorPosition(560, 570);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Thread.Sleep(sleepTime);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Thread.Sleep(sleepTime);
		}

		//public void SellItemsByMouseMove(Action SellConfirmationDelegate)

		#endregion

	}
}





/*        public static void NewSellItems()
		{
*//*            Thread.Sleep(500);
			ExpBotClass.MoveAndLeftClickOperation(1235, 570);
*//*    
			Thread.Sleep(500);
			ItemsForSaleListGenerate();
			ProgramHandle.OpenShopWindow();
			Thread.Sleep(1000);


			foreach (var item in itemsForSaleList)
			{
				Thread.Sleep(200);

				ProgramHandle.SetItemForSaleSelected(item);
				Thread.Sleep(200);
				ProgramHandle.OpenSellConfirmationUI();


				Thread.Sleep(200);
				MoveAndLeftClickToSellAll();
				Thread.Sleep(200);



			}
		}
*/
