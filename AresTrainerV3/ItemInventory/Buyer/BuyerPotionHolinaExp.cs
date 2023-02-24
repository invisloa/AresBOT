using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AresTrainerV3.ItemInventory.Buyer;



namespace AresTrainerV3.ItemInventory.Buyer
{
    internal class BuyerPotionHolinaExp : BuyerPotionsAbstract
    {
        public override void BuyPotions()
        {
            BuyPotionsAbstract(120, true, 80, 10, ExpBotMovePositionsValues.mousePositionsForHolinaBuying);
        }

    }
}
