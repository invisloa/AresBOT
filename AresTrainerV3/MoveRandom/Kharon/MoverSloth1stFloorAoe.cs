using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom.Kharon
{
    internal class MoverSloth1stFloorAoe : MoverRandom
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.SlothFloor1;
            }

        }
        protected override Tuple<int, int, int, int> DirectionsLimts
        {
            get
            {
                return TeleportValues.moverRandomSloth1stFloorAoe;
            }

        }
		protected override void upLimitBounce()
		{
			_lastMouseMovePosition = MovePositionRandomizer(8);
		}

		
	}
}
