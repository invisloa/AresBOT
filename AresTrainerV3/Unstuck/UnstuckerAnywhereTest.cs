using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Unstuck
{
    public class UnstuckerAnywhereTest : Unstacker
    {
        public override bool UnstuckMove()
        {
            return base.UnstuckMoveBase(StuckPositionValues.AnywhereTestObstacles);
        }

    }
}
