using AresTrainerV3.Buyer;
using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.StorageRepot
{
    internal class StorageRepoter : BuyerPotions, IGoRepot
    {
        protected Tuple<int,int,int> SafeTeleportPlace()
        {
            if (ProgramHandle.GetCurrentMap == TeleportValues.BaldorTempleSecondFloor)
            {
                return TeleportValues.SafePosBaldorTemple2Floor;
            }
            else
                return null;
        }
        public void GoRepot()
        {
            ProgramHandle.TeleportToPositionTuple(SafeTeleportPlace());
            ProgramHandle.OpenStorageWindow();

        }

        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(120, false, 250, 5, ExpBotMovePositionsValues.mousePositionsForStorageBuying);

        }
    }
}
