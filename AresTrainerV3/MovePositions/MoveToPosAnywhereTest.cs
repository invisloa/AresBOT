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
        protected override IUnstuckPosition unstuckPlace
        {
            get
            {
                return new UnstuckerAnywhereTest();
            }
        }
        protected override int moveOnlyOnMapX
        {
            get
            {
                return ProgramHandle.GetCurrentMap;
            }

        }
    }
}
