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
                return StuckPositionValues.EmpireSacredObstacles;
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                return StuckPositionValues.UWC1stFloorObstacles;
            }
            /// ADD OTHER MAPS


            else return StuckPositionValues.EmpireSacredObstacles;
            

        }



        // CReator for making new Obstacles so it would be easier
        public static Tuple<int, int, int, int> ObstacleCreator(int XposStart, int YposStart, int XposEnd, int YposEnd)
        {
            return new Tuple<int, int, int, int>(XposStart, YposStart, XposEnd, YposEnd);
        }


        // list of obstacles

        // Empire Sacred Lands last cave
        public static Tuple<int, int, int, int>[] EmpireSacredLandsExpObstacles = new Tuple<int, int, int, int>[]
    {
                ObstacleCreator(1142063436, 1144631190, 1142157393, 1144743620),
                ObstacleCreator(1142292770, 1144713626, 1142445732, 1144856856),
                ObstacleCreator(1141823976, 1144860277, 1141962887, 1145083133)
        /*        go left limit 1141807769
            go up limit 1145602512
            go tight 1143144766
*/

    };




        // Uwc first floor
        public static Tuple<int, int, int, int>[] UWC1stFloorObstacles = new Tuple<int, int, int, int>[]
            {
                ObstacleCreator(1113168276, 1110655170, 1114290348, 1111837250)


            };

        public static Tuple<int, int, int, int>[] EmpireSacredObstacles = new Tuple<int, int, int, int>[]
            {
                ObstacleCreator(1117622968, 1147304172, 1120078719, 1147581659)
            };

        public static Tuple<int, int, int, int>[] EtanaObstacles = new Tuple<int, int, int, int>[]
            {
                ObstacleCreator(1131997533, 1132998859, 1132435568, 1133242851)
            };





    }
}
