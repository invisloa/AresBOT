using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    internal class BuyerPotionsHershalSeller : BuyerPotions
    {
        public override void BuyPotions()
        {
            if (PointersAndValues.isNostalgia == true)
            {
                base.BuyPotionsAbstract(100, false, 100, 5, ExpBotMovePositionsValues.mousePositionsForHershalBuying);
            }
            else
            {
                base.BuyPotionsAbstract(100, false, 100, 5, ExpBotMovePositionsValues.mousePositionsForHershalBuyingEOA);
            }
        }

    }
}
