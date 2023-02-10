using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemInventory.Buyer
{
    public class BuyerPotionsKharonExp : BuyerPotionsAbstract
    {
        public override void BuyPotions()
        {
            BuyPotionsAbstract(60, false, 40, 4, ExpBotMovePositionsValues.mousePositionsForKharonBuying);
        }


    }
}
