using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveRandom.Holina
{
    internal class MoverHolinaGoblins : MoverRandom
    {
        protected override int moveOnlyOnMapX
        {
            get
            {
                return TeleportValues.Hollina;
            }

        }
        protected override Tuple<int, int, int, int> DirectionsLimts
        {
            get
            {
                return TeleportValues.moverRandomHolinaGoblins;
            }

        }

    }
}
