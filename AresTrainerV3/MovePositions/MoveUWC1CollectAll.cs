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
    public class MoveUWC1CollectAll : MoveToPositionAbstract
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.UWC1stFloor;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems => new DoScanAttackCollect(new PixelItemCollector(1770, new CollectAllItems()));

    }
}
