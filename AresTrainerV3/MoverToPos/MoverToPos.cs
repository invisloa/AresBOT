using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoverToPos
{
    internal class MoverToPos
    {
        int currentPosX;
        int currentPosY;
        int destPosX;
        int destPosY;

        int DistanceX;
        int DistanceY;


        void CalculateDistance()
        {
            DistanceX = destPosX  - currentPosX;
            DistanceY = destPosY  - currentPosY;
        }

        void SetRoute()
        {
            // set main distance if goX>goY then goX else GoY is more important


            // if distance >0 go right
            // if < 0 go left
            // same for Y
            //

            // if distanceX/DistanceY <20% move (-3 - 3)
            // if distanceX/DistanceY <10% move (-3 - 3)
        }
    }
}
