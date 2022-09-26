using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    internal class BuyerPotionHolinaExp : BuyerPotions
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(100, true, 150, 10, ExpBotMovePositionsValues.mousePositionsForHershalBuying);
        }

    }
}
