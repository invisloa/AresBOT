using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Unstuck
{
    public abstract class Unstacker : IUnstuckPosition
    {
        Tuple<int, int, int, int>[] StuckLockationAssigner()
        {
            if (ProgramHandle.GetCurrentMap == TeleportValues.EmpireSacred)
            {
                return StuckPositionValues.EmpireSacredStuckLockations;
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                return StuckPositionValues.UWC1stFloorObstacles;
            }


            /// ADD OTHER MAPS


            else return null;
        }


        protected bool isInStuckPosition()
        {
            Tuple<int, int, int, int>[] stuckLockations = StuckLockationAssigner();
            foreach (var stuckLockat in stuckLockations)
            {
                if (ProgramHandle.GetCurrentPositionX() > stuckLockat.Item1 && ProgramHandle.GetCurrentPositionX() < stuckLockat.Item3 && ProgramHandle.GetCurrentPositionY() > stuckLockat.Item2 && ProgramHandle.GetCurrentPositionY() < stuckLockat.Item4)
                {
                    return true;
                }
            }
            return false;
        }

        void MoveFromPosition()
        {

        }

        protected bool UnstuckMoveAbstract()
        {
            if(isInStuckPosition)
            {

            }


            return false
        }

        public abstract bool UnstuckMove();
    }
}
