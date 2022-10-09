using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Buyer
{
    public class BuyerFromForm : BuyerPotions
    {
        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(HpPotionsToBuy, BuyMaxPotions, MpPotionsToBuy, SpeedPotionsToBuy, ExpBotMovePositionsValues.ShopBuyingPositionAssigner());
        }
    }
}