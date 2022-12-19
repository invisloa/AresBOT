using AresTrainerV3.Buyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterShutdown : RepotAbstract
	{
		protected override BuyerPotions BuyerPotionsCity
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
				_repotCityVerification = TeleportValues.Kharon;
				return _repotCityVerification;
			}
		}

		protected override void MoveToRepot()
		{
			System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
		}
	}
}
