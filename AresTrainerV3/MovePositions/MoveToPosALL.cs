using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal class MoveToPosALL : MoveToPositionAbstract
    {
        int _whereToMoveOnly;

        int _collectFromWhatWeight;
        AbstractWhatToCollect _whatToCollect;
        public MoveToPosALL(int CityToMove, int collectFromWhatWeight, AbstractWhatToCollect whatToCollect)
        {
            _whereToMoveOnly = CityToMove;
            _collectFromWhatWeight = collectFromWhatWeight;
            _whatToCollect = whatToCollect;

        }
        protected override int moveOnlyOnMapX
        {
            get
            {
                return _whereToMoveOnly;
            }

        }

        protected override DoWhileMoving.IDoWhileMoving AttackAndCollectItems
        {
            get
            {
                if (_attackAndCollectItems == null)
                {
                    _attackAndCollectItems = new DoScanAttackCollect(new PixelItemCollector(_collectFromWhatWeight, _whatToCollect));
                }
                return _attackAndCollectItems;
            }
        }
    }
}