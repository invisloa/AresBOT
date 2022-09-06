using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public class MoveToPosEmpireSacred : MoveToPosition, IMoveToPosition
    {
        public bool MoveToPosition(bool isMoveOnXAxis, bool isPosIcreasing, int directionLimit, int sideUpOrRightLimit, int sideDownOrLeftLimit)
        {
            return base.MoveToPosMouse(true, false, directionLimit, sideUpOrRightLimit, sideDownOrLeftLimit,new UnstackerEmpSacred() as IUnstuckPosition, TeleportValues.EmpireSacred);
        }
    }
}
