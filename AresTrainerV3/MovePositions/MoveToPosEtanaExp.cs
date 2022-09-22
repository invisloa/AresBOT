﻿using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal class MoveToPosEtanaExp : MoveToPositionAbstract
    {


        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.Etana;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems
        {
            get
            {
                if (_attackAndCollectItems == null)
                {
                    _attackAndCollectItems = new DoScanAttackCollect(new PixelItemCollector(1600, new CollectSodItems()));
                }
                return _attackAndCollectItems;
            }
        }
    }
}
