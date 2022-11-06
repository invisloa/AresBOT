﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom.SacredAlliance
{
    internal class MoverGiko : MoverRandom
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.AllianceSacredLand;
            }

        }
        protected override Tuple<int, int, int, int> DirectionsLimts
        {
            get
            {
                return TeleportValues.moverRandomSacredGiko;
            }

        }

    }
}
