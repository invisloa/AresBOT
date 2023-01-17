using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    internal class BuyerPotionHolinaExp : BuyerPotionsAbstract
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(120, false, 200, 30, ExpBotMovePositionsValues.mousePositionsForHolinaBuying);
        }

    }
}
