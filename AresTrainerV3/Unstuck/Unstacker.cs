using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AresTrainerV3.Unstuck
{
    public abstract class Unstacker : IUnstuckPosition
    {
        Random random = new Random();

        Tuple<int, int>[] tempUnstuckMousePositions = new Tuple<int, int>[]
        {
            
            new Tuple<int, int>(955+100,515+100),
            new Tuple<int, int>(955+100,515-100),
            new Tuple<int, int>(955-100,515+100),
            new Tuple<int, int>(955-100,515-100)
        };
        bool isInStuckPosition(Tuple<int, int, int, int>[] stuckLockations)
        {
            foreach (var stuckLockat in stuckLockations)
            {
                if (ProgramHandle.GetCurrentPositionX > stuckLockat.Item1 && ProgramHandle.GetCurrentPositionX < stuckLockat.Item3 && ProgramHandle.GetCurrentPositionY > stuckLockat.Item2 && ProgramHandle.GetCurrentPositionY < stuckLockat.Item4)
                {
                    return true;
                }
            }
            return false;
        }

        void MouseClickFromPosition()
        {
            if (ExpBotClass.isNowStandingOut())
            {
                int movefromPositionRandomizer = random.Next(tempUnstuckMousePositions.Length);
                MouseOperations.MoveAndLeftClickOperation(tempUnstuckMousePositions[movefromPositionRandomizer].Item1, tempUnstuckMousePositions[movefromPositionRandomizer].Item2, 15);
            }
        }

        protected bool UnstuckMoveBase(Tuple<int, int, int, int>[] stuckLockations)
        {
            Debug.WriteLine("Check if is in stuck lockation");
            while (isInStuckPosition(stuckLockations))
            {
                Debug.WriteLine("stuck lockation WHILE");
                MouseClickFromPosition();
            }
            Debug.WriteLine($"Not Stuck");

            return false;
        }

        public abstract bool UnstuckMove();
    }
}
