namespace AresTrainerV3.ItemInventory.Buyer
{
	internal class BuyerPotionSacredLandsAlliance : BuyerPotionsAbstract
	{
		public override void BuyPotions()
		{
			BuyPotionsAbstract(50, false, 250, 25, ExpBotMovePositionsValues.mousePositionsForSacredLandsBuying);
		}


	}
}
