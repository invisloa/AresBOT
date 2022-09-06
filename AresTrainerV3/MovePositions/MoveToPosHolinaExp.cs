using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal class MoveToPosHolinaExp : MoveToPosition, IMoveToPosition
    {
        public bool MoveToPosition(bool isMoveOnXAxis, bool isPosIcreasing, int directionLimit, int sideUpOrRightLimit, int sideDownOrLeftLimit)
        {
            return base.MoveToPosMouse(true, false, directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit, new UnstackerHolina() as IUnstuckPosition, TeleportValues.Hollina);
        }
    }
}
