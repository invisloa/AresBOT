using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Unstuck
{
    public static class StuckPositionValues
    {


        // CReator for making new Obstacles so it would be easier
        public static Tuple<int, int, int, int> ObstacleCreator(int Xpos, int Ypos, int XLength, int YLength)
        {
            return new Tuple<int, int, int, int>(Xpos, Ypos, Xpos+XLength, Ypos+YLength);
        }


        // list of obstacles
        public static Tuple<int, int, int, int>[] UWC1stFloorObstacles = new Tuple<int, int, int, int>[]
            {


            };

        public static Tuple<int, int, int, int>[] EmpireSacredStuckLockations = new Tuple<int, int, int, int>[]
            {


            };



        // UWC FIRST FLOOR create



    }
}
