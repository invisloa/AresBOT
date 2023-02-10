using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemInventory.Buyer
{
	internal class BuyerPotionsStorage : BuyerPotionsAbstract
	{
		public override void BuyPotions()
		{
			base.BuyPotionsAbstract(80, false, 40, 4, ExpBotMovePositionsValues.mousePositionsForStorageBuying);
		}


	}
}
