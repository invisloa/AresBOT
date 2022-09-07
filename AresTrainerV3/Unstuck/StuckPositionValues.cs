using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Unstuck
{
    public static class StuckPositionValues
    {
        public static Tuple<int, int, int, int>[] StuckLockationAssigner()
        {
            if (ProgramHandle.GetCurrentMap == TeleportValues.EmpireSacred)
            {
                return StuckPositionValues.EmpireSacredLandsExpObstacles;
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                return StuckPositionValues.UWC1stFloorObstacles;
            }
            /// ADD OTHER MAPS


            else return StuckPositionValues.EmpireSacredLandsExpObstacles;
            

        }



        // CReator for making new Obstacles so it would be easier
        public static Tuple<int, int, int, int> ObstacleCreator(int XposStart, int YposStart, int XposEnd, int YposEnd)
        {
            return new Tuple<int, int, int, int>(XposStart, YposStart, XposEnd, YposEnd);
        }


        // list of obstacles

        // ANYWHERE TEST OBSTACLES
        public static Tuple<int, int, int, int>[] AnywhereTestObstacles = new Tuple<int, int, int, int>[]
{
                ObstacleCreator(1, 1, 1, 1),
};


        // Empire Sacred Lands near last cave enterace 
        public static Tuple<int, int, int, int>[] EmpireSacredLandsExpObstacles = new Tuple<int, int, int, int>[]
    {
                ObstacleCreator(1142063436, 1144631190, 1142157393, 1144743620),
                ObstacleCreator(1142292770, 1144713626, 1142445732, 1144856856),
                ObstacleCreator(1141823976, 1144860277, 1141962887, 1145083133)
    };

        // Holina Goblins exp 
        public static Tuple<int, int, int, int>[] HolinaGoblinsExpObstacles = new Tuple<int, int, int, int>[]
    {
                ObstacleCreator(1142063436, 1144631190, 1142157393, 1144743620),
                ObstacleCreator(1142292770, 1144713626, 1142445732, 1144856856),
                ObstacleCreator(1141823976, 1144860277, 1141962887, 1145083133)
    };




        // Uwc first floor
        public static Tuple<int, int, int, int>[] UWC1stFloorObstacles = new Tuple<int, int, int, int>[]
            {
                ObstacleCreator(1113168276, 1110655170, 1114290348, 1111837250)


            };
        // Etana For testing
        public static Tuple<int, int, int, int>[] EtanaObstacles = new Tuple<int, int, int, int>[]
            {
                ObstacleCreator(1113168276, 1110655170, 1114290348, 1111837250)


            };






    }
}
