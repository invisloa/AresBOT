using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    public class BuyerPotionsHershalExp : BuyerPotions
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(100, true, 220, 5, ExpBotMovePositionsValues.mousePositionsForHershalBuying);
        }

    }
}
