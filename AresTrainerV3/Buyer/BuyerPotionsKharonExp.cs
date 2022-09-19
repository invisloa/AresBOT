using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    public class BuyerPotionsKharonExp : BuyerPotions
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(200, false, 200, 8, ExpBotMovePositionsValues.mousePositionsForKharonBuying);
        }


    }
}
