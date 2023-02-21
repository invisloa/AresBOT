using AresTrainerV3.ItemInventory.Buyer;

namespace AresTrainerV3.HealBot.Repoter
{
	internal class RepoterShutdown : RepotAbstract
	{
		protected override BuyerPotionsAbstract BuyerPotionsCity
		{
			get
			{
				if (_buyerPotionsCity == null)
				{
					_buyerPotionsCity = new BuyerPotionsKharonExp();
				}
				return _buyerPotionsCity;
			}
		}
		protected override int repotCityCheck
		{
			get
			{
				_repotCityVerification = ProgramHandle.GetCurrentMap;
				return _repotCityVerification;
			}
		}

		protected override void MoveToRepot()
		{
			//System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
		}
	}
}
