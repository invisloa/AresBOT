﻿using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public class MoveToPosAnywhereTest : MoveToPositionAbstract
    {

        protected override int moveOnlyOnMapX
        {
            get
            {
                return ProgramHandle.GetCurrentMap;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems
        {
            get
            {
                if (_attackAndCollectItems == null)
                {
                    _attackAndCollectItems = new DoScanAttackCollect(new PixelItemCollector(1550, new CollectAllItems()));
                }
                return _attackAndCollectItems;
            }
        }
    }

}

