﻿using System;
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
		public const int HolinaBuckSlavePit = 34;

		public const int EmpireSacred = 1;
        public const int Ogre1stFloor = 3;
        public const int Ogre2ndFloor = 30;
		public const int EasternMiningTunnel = 5;
		public const int AllianceMiningTunnel = 6;
		public const int Hershal = 17;
        public const int UWC1stFloor = 25;
        public const int UWC2ndFloor = 26;
        public const int UWC3rdFloor = 27;
        public const int UWC4rdFloor = 28;
		
		public const int Siros1stFloor = 58;
        public const int Siros2thFloor = 13;
        public const int Siros3thFloor = 14;
        public const int Siros4thFloor = 15;

        public const int SirosBasement1stFloor = 16;
        public const int SirosBasement2ndFloor = 62;



        public const int COT1stFloor = 36;
        public const int COT2ndFloor = 37;
        public const int COT3rdFloor = 38;
        public const int COT4thFloor = 39;
        public const int COT5thFloor = 40;
        public const int COT6thfloor = 51;
        public const int COT7thloor = 52;
        public const int COT8thFloor = 53;
        public const int COT9thFloor = 54;
        public const int COT10thFloor = 55;
        public const int COT11thFloor = 56;
        public const int COT12thFloor = 57;
        public const int COT13thFloor = 58;

        public const int GMLand = 46;


        public const int Kharon = 44;
        public const int KharonPlateau = 45;
        public const int SlothFloor1 = 48;
        public const int SlothFloor2 = 49;
        public const int KharonHorse = 50;



        public static ValueTuple<int, int, int> PosCOT1stFloor = new ValueTuple<int, int, int>( 1116105934, 1128417296, 0);
        public static ValueTuple<int, int, int> PosCOT2ndFloor = new ValueTuple<int, int, int>( 1127562415, 1116794988, 0);
        public static ValueTuple<int, int, int> PosCOT3rdFloor = new ValueTuple<int, int, int>( 1121030657, 1120975278, 0);
        public static ValueTuple<int, int, int> PosCOT4thFloor = new ValueTuple<int, int, int>( 1129068496, 1112263688, 0);
        public static ValueTuple<int, int, int> PosCOT5thFloor = new ValueTuple<int, int, int>( 1118233577, 1113779148, 0);
        public static ValueTuple<int, int, int> PosCOT6thFloor = new ValueTuple<int, int, int>( 1127882124, 1105277565, 0);
        public static ValueTuple<int, int, int> PosCOT7thFloor = new ValueTuple<int, int, int>( 1111832658, 1128401601, 0);
        public static ValueTuple<int, int, int> PosCOT8thFloor = new ValueTuple<int, int, int>( 1124319439, 1126366899, 0);
        public static ValueTuple<int, int, int> PosCOT9thFloor = new ValueTuple<int, int, int>( 1124629964, 1125556564, 0);
        public static ValueTuple<int, int, int> PosCOT10thFloor = new ValueTuple<int, int, int>( 1126961583, 1129183176, 0);
        public static ValueTuple<int, int, int> PosCOT11thFloor = new ValueTuple<int, int, int>( 1120762492, 1106655977, 0);
		public static ValueTuple<int, int, int> PosCOT12thFloor = new ValueTuple<int, int, int>(1128207766, 1108614369, 0);
		public static ValueTuple<int, int, int> PosCOT13thFloor = new ValueTuple<int, int, int>(1126117801, 1119453651, 0);

		public static ValueTuple<int, int, int> PosKoHitSearch = new ValueTuple<int, int, int>(  1147449870, 1145550603, 1065554544);


        public static Tuple<int, int, int> PosSacredLandsOgre = new Tuple<int, int, int>(1127039556, 1145125639, 0);
        public static ValueTuple<int, int, int> PosSacredLandsExpBot = new ValueTuple<int, int, int>(1143323406, 1145180323, 1091659175);



        public static ValueTuple<int, int, int> PosBaldorTempleFirstFloor = new ValueTuple<int, int, int>( 1131435506, 1135950304, 0);
        public static ValueTuple<int, int, int> PosBaldorTempleSecontloor = new ValueTuple<int, int, int>( 1124166595, 1128864384, 0);


        public static ValueTuple<int, int, int> PosHollinaSiros = new ValueTuple<int, int, int>( 1115018006, 1134911994, 1106469888);
        public static ValueTuple<int, int, int> PosHollinaTunnel = new ValueTuple<int, int, int>( 1137152155, 1120233092, 1091370351);
        public static ValueTuple<int, int, int> PosSiros1stFloor = new ValueTuple<int, int, int>( 1123683631, 1129909568, 1077936122);
        public static ValueTuple<int, int, int> PosSiros2thFloorTo3rd = new ValueTuple<int, int, int>(1124022917, 1131430000, 1091567612);
        public static ValueTuple<int, int, int> PosSiros2thFloorToBasement = new ValueTuple<int, int, int>(1103884700, 1128356476, 0);
        public static ValueTuple<int, int, int> PosSiros3thFloor = new ValueTuple<int, int, int>( 1123787210, 1129977407, 1077936122);
        public static ValueTuple<int, int, int> PosSiros4thFloor = new ValueTuple<int, int, int>(1125928930, 1121854248, 1086346279);
        public static ValueTuple<int, int, int> PosSiros1stBasementFloor = new ValueTuple<int, int, int>(1121378362, 1129807456, 0);
		public static Tuple<int, int, int> PosSiros1stBasementFloorEXPSpot = new Tuple<int, int, int>(1103884700, 1128356476, 0);

		public static ValueTuple<int, int, int> PosSiros2ndBasementFloor = new ValueTuple<int, int, int>(1124062914, 1131328071, 0);


        public static ValueTuple<int, int, int> PosEmpireSacred = new ValueTuple<int, int, int>( 1142560515, 1146754742, 1092824576);
        public static ValueTuple<int, int, int> PosOgre1stFloor = new ValueTuple<int, int, int>( 1125223858, 1135281824, 1076037106);
        public static ValueTuple<int, int, int> PosOgre2ndFloor = new ValueTuple<int, int, int>( 1113300562, 1127275279, 0);

		public static ValueTuple<int, int, int> PosEasternMiningTunnelExit = new ValueTuple<int, int, int>(1125056512, 1105723392, 1076321776);
		public static ValueTuple<int, int, int> PosAllianceTunnelToHolina = new ValueTuple<int, int, int>(1128924953, 1107228744, 1076321776);
        public static ValueTuple<int, int, int> PosEasternMiningTunnelEntrace = new ValueTuple<int, int, int>(1129876799,  1105879974, 1076321776);

        public static ValueTuple<int, int, int> PosHershalUWC = new ValueTuple<int, int, int>( 1146093959, 1131233933, 1091297280);
        public static ValueTuple<int, int, int> PosUWC1stFloor = new ValueTuple<int, int, int>( 1124827221, 1129878944, 0);
        public static ValueTuple<int, int, int> PosUWC2ndFloor = new ValueTuple<int, int, int>( 1132316057, 1139386835, 0);
        public static ValueTuple<int, int, int> PosUWC3rdFloor = new ValueTuple<int, int, int>( 1132497408, 1137683001, 0);
        public static ValueTuple<int, int, int> PosUWC4rdFloor = new ValueTuple<int, int, int>( 1132055267, 1113550000, 0);
        public static ValueTuple<int, int, int> PosUWC4rdPlant = new ValueTuple<int, int, int>(1136310857, 1135108780, 1095210496);


        public static ValueTuple<int, int, int> PosKharonPlateuSlothEntrace = new ValueTuple<int, int, int>(1148190218, 1148523002, 1097859072);
        public static ValueTuple<int, int, int> PosKharonPlateuGardionEntrace = new ValueTuple<int, int, int>(1108850452, 1148542857, 1121408142);
        public static ValueTuple<int, int, int> PosKharonPlateuTigersAoe = new ValueTuple<int, int, int>(1146933217, 1137434216, 1121408142);
        public static ValueTuple<int, int, int> PosSlothFloor1 = new ValueTuple<int, int, int>(1136295936, 1118437376, 1097859072);
        public static ValueTuple<int, int, int> MiniPosSlothFloor1BossBulgar1 = new ValueTuple<int, int, int>(1129762520, 1134509410, 1101089181);
        public static ValueTuple<int, int, int> MiniPosSlothFloor1BossBulgar2 = new ValueTuple<int, int, int>(1132962719, 1131670265, 1102053376);
        public static ValueTuple<int, int, int> MiniPosSlothFloor1BossBulgar3 = new ValueTuple<int, int, int>(1134395149, 1135955773, 1097859072);
        public static ValueTuple<int, int, int> MiniPosSlothFloor1BossBulgar4 = new ValueTuple<int, int, int>(1128810480, 1136200217, 1097859072);
        public static ValueTuple<int, int, int> PosSlothFloor2 = new ValueTuple<int, int, int>(1134407858, 1138126219, 1097859072);
        public static ValueTuple<int, int, int> MiniPosSlothFloor2IceCube = new ValueTuple<int, int, int>(1133097017, 1135058534, 1107017794);
        public static ValueTuple<int, int, int> MiniPosSlothFloor2IceCubeMiddle = new ValueTuple<int, int, int>(1133621892, 1132091306, 0);
        public static ValueTuple<int, int, int> KharonHorseBulglarAoe = new ValueTuple<int, int, int>(1135172319, 1137007029, 0);
		public static Tuple<int, int, int> PosSlothFloorAoe2 = new Tuple<int, int, int>(1132689809, 1130929285, 1102053376);



		public static Tuple<int, int, int> KharoncCityTeleported = new Tuple<int, int, int>(1124073472, 1122369536, 1106067456);

        public static Tuple<int, int, int> KharoncCityWalkedToTeleportShort = new Tuple<int, int, int>(17152, 17142, 16874);

        public static Tuple<int, int, int> KharonTeleportOutside = new Tuple<int, int, int>(1124052940, 1128515351, 1128115351);
        public static Tuple<int, int, int> KharonPlateuSlothEntraceTuple = new Tuple<int, int, int>(1148190218, 1148523002, 1097859072);
        public static Tuple<int, int, int> PosSlothFloor1NoIceBergs = new Tuple<int, int, int>(1118699559, 1127194625, 1102142445);

		public static Tuple<int, int, int> MiniSacredLandsImpCave = new Tuple<int, int, int>(1129967491, 1142341254, 0);
        public static Tuple<int, int, int> MiniHershalTurtle = new Tuple<int, int, int>(1144459024, 1142613273, 1065554544);

        public static Tuple<int, int, int> ShopHolinaPos = new Tuple<int, int, int>(1132844553, 1137813749, 1107654016);
		public static Tuple<int, int, int> HolinaGoblinsExp = new Tuple<int, int, int>(1128817291, 1130720477, 1090921371);
		public static Tuple<int, int, int> HolinaBucksLowLVLExp = new Tuple<int, int, int>(1128942799, 1124862966, 1068878517);

        public static Tuple<int, int, int> SacredlandsAlliExp = new Tuple<int, int, int>(1121665964, 1147452062, 0);
        public static Tuple<int, int, int> SacredlandsAlliShop = new Tuple<int, int, int>(1145707559, 1128361148, 0);

        public static Tuple<int, int, int> SpotExpHershalMagicExp = new Tuple<int, int, int>(1133131594, 1131227739, 1092867852);
		public static Tuple<int, int, int> HershalUWCEntrace = new Tuple<int, int, int>(1146093959, 1131233933, 1091297280);
		public static Tuple<int, int, int> SlothHorseEntrace = new Tuple<int, int, int>(1108850452, 1148542857, 1121408142);
		public static Tuple<int, int, int> SpotExpHershalLowLvl = new Tuple<int, int, int>(1130301265, 1141035437, 0);

		public static Tuple<int, int, int> PosBlessingItems = new Tuple<int, int, int>(1130682429, 1127279816, 1091408142);

		public static Tuple<int, int, int> SlothHorseFarm = new Tuple<int, int, int>(1124351779, 1133088682, 1091297280);
		public static Tuple<int, int, int, int> moverRandomEtanaBuckys = new Tuple<int, int, int, int>(1120531098, 1134986919, 1125090368, 1128186402);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomSacredGiko = new Tuple<int, int, int, int>(1141048739, 1132575491, 1142147534, 1128382486);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomThievesUnder = new Tuple<int, int, int, int>(1120295809, 1144140242, 1126285252, 1143094754);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomthievesUp = new Tuple<int, int, int, int>(1121716968, 1147515844, 1125986132, 1146748268);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomHolinaGoblins = new Tuple<int, int, int, int>(1128280657, 1134028880, 1131887172, 1131920903);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomBuckertyRightCorner = new Tuple<int, int, int, int>(1121223072, 1135761772, 1122790408, 1135379212);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomHolinaBuckSlave = new Tuple<int, int, int, int>(1124199974, 1124762662, 1125517200, 1123145422);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomHershalLowLvl = new Tuple<int, int, int, int>(1130311265, 1141435437, 1134827717, 1137807344);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomHershalLeafMages = new Tuple<int, int, int, int>(1127987620, 1133037274, 1133101347, 1131251099);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomHershalElves = new Tuple<int, int, int, int>(1142410400, 1129543726, 1142958167, 1127990620);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomUWC1stFloor = new Tuple<int, int, int, int>(1110493212, 1116984574, 1122140674, 1110027219);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomKharonWolves = new Tuple<int, int, int, int>(1120173211, 1130046682, 1129089075, 1126879685);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomKharonBigWolves = new Tuple<int, int, int, int>(1142123962, 1141073814, 1143779967, 1135031921);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomSloth1stFloor = new Tuple<int, int, int, int>(1124434047, 1137975177, 1125905268, 1137659923);  //Left,Up,Right,Down
        public static Tuple<int, int, int, int> moverRandomSloth1stFloorNoIcebergs = new Tuple<int, int, int, int>(1117317700, 1137975177, 1122940064, 1133700146);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomSloth1stFloorAoe = new Tuple<int, int, int, int>(1118582503, 1126938769, 1120949079, 1126052185);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomSloth1stFloorAoe2 = new Tuple<int, int, int, int>(1132145205, 1131272846, 1132899859, 1129831150);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomSlothHorseFarm = new Tuple<int, int, int, int>(1124917651, 1133298023, 1124351779, 1133088682);  //Left,Up,Right,Down
		public static Tuple<int, int, int, int> moverRandomSacredAlliThievesSod = new Tuple<int, int, int, int>(1136646890, 1142866316, 1138333998, 1141837440);  //Left,Up,Right,Down

		// left 1136646890
		// up 1142866316 1138333998
		// right 1138522128
		// down 1141837440

		//1128942799
		//1124862966
/*		//1068878517










*/	}
}

