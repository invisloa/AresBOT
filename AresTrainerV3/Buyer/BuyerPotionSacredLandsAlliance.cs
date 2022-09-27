using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    internal class BuyerPotionSacredLandsAlliance : BuyerPotions
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(50, false, 250, 2553, ExpBotMovePositionsValues.mousePositionsForSacredLandsBuying);
        }


    }
}
