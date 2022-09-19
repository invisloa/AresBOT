using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal class MoveHolinaCollectSod : MoveToPositionAbstract
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.Hollina;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems => new DoScanAttackCollect(new PixelItemCollector(1899, new CollectSodItems()));

    }
}
