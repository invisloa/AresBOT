using AresTrainerV3.ItemInventory.Buyer;

namespace AresTrainerV3.HealBot.Repoter
{
	internal class RepoterSacredAlliance : RepotAbstract
	{
		protected override BuyerPotionsAbstract BuyerPotionsCity
		{
			get
			{
				if (_buyerPotionsCity == null)
				{
					_buyerPotionsCity = new BuyerFromForm();
				}
				return _buyerPotionsCity;
			}
		}
		protected override int repotCityCheck
		{
			get
			{
				_repotCityVerification = TeleportValues.AllianceSacredLand;
				return _repotCityVerification;
			}
		}

		protected override void MoveToRepot()
		{
			Thread.Sleep(10);
			CheckIfNotRunning();
			if (ProgramHandle.isNowStandingCity())
			{
				ProgramHandle.TeleportToPositionTuple(TeleportValues.SacredlandsAlliShop);

			}
		}
	}
}

