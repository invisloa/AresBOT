using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class TeleportValues
    {
        public const int Etana = 35;
        public const int AllianceSacredLand = 2;


        public const int BaldorTempleFirstFloor = 4;
        public const int BaldorTempleSecondFloor = 32;
        public const int Hollina = 7;
        public const int EmpireSacred = 1;
        public const int Ogre1stFloor = 3;
        public const int Ogre2ndFloor = 30;
        public const int EasternMiningTunnel = 5;
        public const int Hershal = 17;
        public const int UWC1stFloor = 25;
        public const int UWC2ndFloor = 26;
        public const int UWC3rdFloor = 27;
        public const int UWC4rdFloor = 28;

        public const int Siros1stFloor = 58;
        public const int Siros2thFloor = 13;
        public const int Siros3thFloor = 14;
        public const int Siros4thFloor = 15;

        public const int COT1stFloor = 36;
        public const int COT2ndFloor = 37;
        public const int COT3rdFloor = 38;
        public const int COT4thFloor = 39;
        public const int COT5thFloor = 40;
        public const int COT6thfloor = 51;
        public const int COT7thloor = 52;
        public const int COT8thFloor = 53;
        public const int COT9thFloor = 54;


        public const int Kharon = 44;
        public const int KharonPlateau = 45;



        public static ValueTuple<int, int, int> PosCOT1stFloor = new ValueTuple<int, int, int>(1128417296, 1116105934, 0);
        public static ValueTuple<int, int, int> PosCOT2ndFloor = new ValueTuple<int, int, int>(1116794988, 1127562415, 0);
        public static ValueTuple<int, int, int> PosCOT3rdFloor = new ValueTuple<int, int, int>(1120975278, 1121030657, 0);
        public static ValueTuple<int, int, int> PosCOT4thFloor = new ValueTuple<int, int, int>(1112263688, 1129068496, 0);
        public static ValueTuple<int, int, int> PosCOT5thFloor = new ValueTuple<int, int, int>(1113779148, 1118233577, 0);
        public static ValueTuple<int, int, int> PosCOT6thFloor = new ValueTuple<int, int, int>(1105277565, 1127882124, 0);
        public static ValueTuple<int, int, int> PosCOT7thFloor = new ValueTuple<int, int, int>(1128401601, 1111832658, 0);
        public static ValueTuple<int, int, int> PosCOT8thFloor = new ValueTuple<int, int, int>(1126366899, 1124319439, 0);
        public static ValueTuple<int, int, int> PosCOT9thFloor = new ValueTuple<int, int, int>(1125556564, 1124629964, 0);

        public static ValueTuple<int, int, int> PosKoHitSearch = new ValueTuple<int, int, int>(1145550603,  1147449870, 1065554544);


        public static ValueTuple<int, int, int> PosSacredLandsOgre = new ValueTuple<int, int, int>(1145125639, 1127039556, 0);
        public static ValueTuple<int, int, int> PosBaldorTempleFirstFloor = new ValueTuple<int, int, int>(1135950304, 1131435506, 0);
        public static ValueTuple<int, int, int> PosBaldorTempleSecontloor = new ValueTuple<int, int, int>(1128864384, 1124166595, 0);


        public static ValueTuple<int, int, int> PosHollinaSiros = new ValueTuple<int, int, int>(1134911994, 1115018006, 1106469888);
        public static ValueTuple<int, int, int> PosHollinaTunnel = new ValueTuple<int, int, int>(1120233092, 1137152155, 1091370351);
        public static ValueTuple<int, int, int> PosSiros1stFloor = new ValueTuple<int, int, int>(1129909568, 1123683631, 1077936122);
        public static ValueTuple<int, int, int> PosSiros2thFloor = new ValueTuple<int, int, int>(1131430000, 1124022917, 1091567612);
        public static ValueTuple<int, int, int> PosSiros3thFloor = new ValueTuple<int, int, int>(1129977407, 1123787210, 1077936122);
        public static ValueTuple<int, int, int> PosSiros4thFloor = new ValueTuple<int, int, int>(1121854248, 1125928930, 1086346279);

        public static ValueTuple<int, int, int> PosEmpireSacred = new ValueTuple<int, int, int>(1146754742, 1142560515, 1092824576);
        public static ValueTuple<int, int, int> PosOgre1stFloor = new ValueTuple<int, int, int>(1135281824, 1125223858, 1076037106);
        public static ValueTuple<int, int, int> PosOgre2ndFloor = new ValueTuple<int, int, int>(1127275279, 1113300562, 0);

        public static ValueTuple<int, int, int> PosEasternMiningTunnelExit = new ValueTuple<int, int, int>(1105723392, 1125056512, 1076321776);
        public static ValueTuple<int, int, int> PosEasternMiningTunnelEntrace = new ValueTuple<int, int, int>(1129876799, 1105879974, 1076321776);

        public static ValueTuple<int, int, int> PosHershalUWC = new ValueTuple<int, int, int>(1131233933, 1146093959, 1091297280);
        public static ValueTuple<int, int, int> PosUWC1stFloor = new ValueTuple<int, int, int>(1129878944, 1124827221, 0);
        public static ValueTuple<int, int, int> PosUWC2ndFloor = new ValueTuple<int, int, int>(1139386835, 1132316057, 0);
        public static ValueTuple<int, int, int> PosUWC3rdFloor = new ValueTuple<int, int, int>(1137683001, 1132497408, 0);
        public static ValueTuple<int, int, int> PosUWC4rdFloor = new ValueTuple<int, int, int>(1113550000, 1132055267, 0);



        public static ValueTuple<int, int, int> KharonPlateuSellExp = new ValueTuple<int, int, int>(1134659696, 1141877335, 1084227584);
        public static ValueTuple<int, int, int> KharonPlateuSellExpHidden = new ValueTuple<int, int, int>(1115123685, 1146608269, 1089385337);
        
        public static ValueTuple<int, int, int> PosUWC4rdPlant = new ValueTuple<int, int, int>(1136310857, 1135108780, 1095210496);



        // IF X_CITY=ETANA
        // SET POSITION TO XYZ



    }
}
