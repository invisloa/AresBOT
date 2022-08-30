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
            base.BuyPotionsAbstract(150, true, 190, 5, ExpBotMovePositions.mousePositionsForHershalBuying);
        }

    }
}
