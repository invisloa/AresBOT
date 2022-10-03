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
    public class MoveToPosKharonWolvesExp : MoveToPositionAbstract
    {


        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.KharonPlateau;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems
        {
            get
            {
                if (_attackAndCollectItems == null)
                {
                    _attackAndCollectItems = new DoScanAttackCollect(new PixelItemCollector(new CollectAllItems()));
                }
                return _attackAndCollectItems;
            }
        }
    }
}
