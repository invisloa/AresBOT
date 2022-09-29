using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal class MoveToPosSacredAlli : MoveToPositionAbstract
    {


        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.AllianceSacredLand;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems
        {
            get
            {
                if (_attackAndCollectItems == null)
                {
                    _attackAndCollectItems = new DoScanAttackCollect(new PixelItemCollector(1990, new CollectSodStonesJewleryItems()));
                }
                return _attackAndCollectItems;
            }
        }
    }
}
