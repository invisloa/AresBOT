using AresTrainerV3.ExpBotManager;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.ItemInventory;
using AresTrainerV3.ItemInventory.Buyer;

namespace AresTrainerV3.HealBot.Repoter
{
	public abstract class RepotAbstract : IGoRepot
	{
		protected Random randomizer = new Random();
		ItemSeller Seller = new ItemSeller();

		protected int isCurrentCity
		{
			get { return ProgramHandle.GetCurrentMap; }
		}
		protected BuyerPotionsAbstract _buyerPotionsCity;
		protected int _repotCityVerification;
		public static bool IsScanRunning = false;
		protected void StopExpBot()
		{
			if (ExpBotManagerAbstract.isExpBotRunning)
			{
				ExpBotManagerAbstract.RequestStopExpBot();
			}
		}
		protected abstract BuyerPotionsAbstract BuyerPotionsCity
		{ get; }
		protected abstract int repotCityCheck
		{ get; }


		protected void MouseClickOpenShop()
		{
			Thread.Sleep(1000);
			MouseOperations.MoveAndLeftClickOperation(580, 565, 200);

		}
		protected void CheckIfNotRunning()
		{
			if (!ProgramHandle.isNowStandingCity())
			{
				Thread.Sleep(15000);
				KeyPresser.PressKey(6, 500, 1000);
			}
		}
		protected void teleportToCityAndStopExpBot()
		{
			StopExpBot();
			KeyPresser.PressKey(6, 100, 100);
			Thread.Sleep(1000);

			// scrollToCityIfNotInCity();
			press1IfLowHp();
			press2IfLowManna();
		}
		public bool press1IfLowHp()
		{
			if (ProgramHandle.getCurrentHp < HealBotAbstract.HpHealValue && ProgramHandle.getFirstInvSlotValue > PointersAndValues.InvPotCount(1))
			{
				KeyPresser.PressKey(1, 500, 500);
				return true;
			}
			return false;
		}
		public bool press2IfLowManna()
		{
			if (ProgramHandle.getCurrentManna < HealBotAbstract.MpRestoreValue && ProgramHandle.getSecondSlotValue > PointersAndValues.InvPotCount(1))
			{
				KeyPresser.PressKey(2, 500, 500);
				return true;
			}
			return false;
		}

		public virtual void GoRepot()
		{
			teleportToCityAndStopExpBot();
			if (isCurrentCity != repotCityCheck)
			{
				Thread.Sleep(1000);
			}
			// Set Weight limit back to the original state if player found changed it to not to collect items@
			AbstractWhatToCollect.MaxCollectWeight = AbstractWhatToCollect.MaxCollectWeightNormalValue;
			ProgramHandle.SetCameraForExpBot();
			if (isCurrentCity == repotCityCheck)
			{
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
				MoveToRepot();
				Thread.Sleep(100);
				//MouseClickOpenShop();
				if (Seller.IsCloseToShop())
				{
					Seller.SellItemsByMouseMove();

					BuyerPotionsCity.BuyPotions();
					Thread.Sleep(100);

					KeyPresser.PressEscape();
					Thread.Sleep(100);

				}
				else
				{
					Thread.Sleep(50000);
					this.GoRepot();
				}
			}
		}
		public void MoveToRepotWithPositions(Tuple<int, int>[] citySpecificPositions)
		{
			ProgramHandle.SetCameraForExpBot();
			Thread.Sleep(500);
			if (ProgramHandle.isNowStandingCity())
			{
				for (int i = 0; i < citySpecificPositions.Length; i++)
				{
					MouseOperations.MoveAndLeftClickOperation(citySpecificPositions[i].Item1, citySpecificPositions[i].Item2, 50);
					Thread.Sleep(1000);
					while (!ProgramHandle.isNowStandingCity())
					{
						Thread.Sleep(1);
					}
				}
			}
		}
		protected abstract void MoveToRepot();

	}
}
