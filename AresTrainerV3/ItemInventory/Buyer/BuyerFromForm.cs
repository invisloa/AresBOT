using AresTrainerV3.ItemInventory.Buyer;

namespace AresTrainerV3.ItemInventory.Buyer
{
	public class BuyerFromForm : BuyerPotionsAbstract
	{
		public override void BuyPotions()
		{
			BuyPotionsAbstract(HpPotionsToBuy, BuyMaxPotions, MpPotionsToBuy, SpeedPotionsToBuy, ExpBotMovePositionsValues.ShopBuyingPositionAssigner());
		}
	}
}