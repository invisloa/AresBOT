using AresTrainerV3.ExpBotManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom.Hershal
{
    internal class MoverHershalLeafMages : MoverRandom
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.Hershal;
            }

        }
        protected override Tuple<int, int, int, int> DirectionsLimts
        {
            get
            {
                return TeleportValues.moverRandomHershalLeafMages;
            }

        }

    }
}
