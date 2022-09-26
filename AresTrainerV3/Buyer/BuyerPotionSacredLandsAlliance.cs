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
            base.BuyPotionsAbstract(200, false, 150, 20, ExpBotMovePositionsValues.mousePositionsForSacredLandsBuying);
        }


    }
}
