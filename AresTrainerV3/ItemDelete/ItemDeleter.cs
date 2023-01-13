﻿using AresTrainerV3.Buyer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemDelete
{
	// SOMETIMES HAPPENS AN INGAME BUG "COULD NOT FIND ITEM IN SLOT" 
	// FOR NOW NOT WORTH TO RUN THIS


	public class ItemDeleter : IDeleteItem
	{


		Func<int, bool> ItemsOperationDelegate;
		//public delegate bool ItemOperations(int addressNumber);

		public List<int> itemsToOperate = new List<int>();

		List<int> lowValueItems = new List<int>()
		{
			1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
			61,62,63,64,65,66,67,68,69,70,71,72,73,78,79,80,81,82,83,84,85,86,87,89,91,94,95,96,98,99,100,101,102,103,104,106,107,108,109,110,111,112,113,114,115,116,117,118,119,
			120,121,122,123,124,126,127,130,131,133,134,331,332,333,334,335,336,337,338,339,340,341,342,343,344,345,482,483,484,490,491,492,545,546,547,548,549,550,553,554,555,556,
			558,560,561,562,577,578,581,582,583,584,585,586,587,588,589,613,614,615,616,617,618,621,622,627,628,629,630,631,632,634,635,636,637,641,642,647,648,649,652,653,654,657,
			658,659,660,665,666,673,674,675,676,677,678,679,680,681,682,683,684,685,686,687,688,689,690,691,692,693,694,695,696,697,698,699,700,703,704,705,706,707,708,709,710,711,
			712,713,714,715,716,717,718,719,720,721,722,723,724,725,726,727,728,729,730,731,732,733,734,735,736,737,738,739,740,741,742,743,744,745,746,751,752,753,754,755,756,757,
			758,759,760,761,762,764,765,766,767,768,769,770,771,772,773,774,775,776,777,778,779,780,781,782,783,784,785,786,787,788,789,792,793,794,795,797,798,799,800,801,802,803,
			804,805,806,807,808,811,812,813,814,816,818,819,820,821,822,823,824,825,826,829,830,835,836,837,838,839,840,842,843,844,845,849,850,855,856,857,860,861,862,865,866,867,
			868,873,874,881,882,883,884,885,886,887,888,889,890,891,892,893,894,895,896,897,898,899,900,901,902,903,904,905,906,907,908,911,912,913,914,915,916,917,918,919,920,921,
			922,923,924,925,926,927,928,929,930,931,932,933,934,935,936,937,938,939,940,941,942,943,944,945,946,947,948,949,950,951,952,953,954,959,960,961,962,963,964,965,966,967,
			968,969,970,972,973,974,975,976,977,978,979,980,981,982,983,984,985,986,987,988,989,990,991,992,993,994,995,996,997,1000,1001,1002,1003,1005,1006,1007,1008,1009,1010,1011
			,1012,1013,1014,1015,1016,1019,1020,1021,1022,1024,1026,1027,1028,1029,1030,1031,1032,1033,1034,1037,1038,1043,1044,1045,1046,1047,1048,1050,1051,1052,1053,1057,1058,1063,
			1064,1065,1068,1069,1070,1073,1074,1075,1076,1081,1082,1089,1096,1097,1098,1099,1100,1101,1109,1110,1111,1112,1113,1114,1116,1117,1118,1120,1121,1122,1123,1149,1150,1151,
			1152,1153,1154,1156,1284,1285,1286,1287,1288,1289,1290,1291,1292,1293,1294,1295,1296,1297,1358,1359,1361,1371,1411,1412,1413,1417,1419,1423,1424,1425,1426,1428,1455,1456,
			1457,1461,1463,1467,1468,1469,1470,1472,1499,1500,1501,1505,1507,1511,1512,1513,1514,1516,1557,2115,2135,2149,2150,2151,2152,2961,3091,3092,3137,3296,3297,3343,3344,3345,
			3367,3368,3369,3373,3374,3376,3377,3385,3386,3387,3388,3390,3422,3423,3424,3826,3828,3829,3830,3881,3882,3883,3884,3886,3887,3889,3890,3891,3892,3894,3895,3897,3898,3899,
			3900,3902,3903,3905,3906,3907,3908,3910,3911,3913,3914,4068,4069,4070,4288,4289,4291,5385,8001,8002,8003,8004,8005,8006,8007,8008,8009,8010,8011,8012,8104,8106,8107,8108,
			8109,8110,8111,8112,8113,8114,8115,8116,9008,9019,9021,9023,9025,9026,9027,9028,9030,9208,9210,9214,9217,9218,20001,20002,20003,20004,20005,20006,20007,20008,20009,20010,
			20011,20012,20013,20014,20015,20016,20017,20018,20019,20020,20021,20022,20023,20024,20025,20026,20027,20030,20031,20032,20033,20034,20035,20036,20037,20038,20039,20040,
			20041,20042,20043,20044,20045,20046,20047,20048,20049,20050,20051,20052,20053,20054,20055,20056,20057,20058,20059,20060,20061,20062,20063,20064,20065,20066,20067,20068,20069,
			20070,20071,20072,20073,20078,20079,20080,20081,20082,20083,20084,20085,20086,20087,20088,20089,20095,20096,20097,20098,20099,20100,20103,20104,20105,20106,20111,20112,
			20113,20114,20115,20116,20119,20120,20125,20126,20127,20128,20129,20130,20132,20133,20134,20135,20139,20140,20145,20146,20147,20150,20151,20152,20155,20156,20157,20158,
			20163,20164,20171,20172,20173,20174,20175,20176,20177,20178,20179,20180,20181,20182,20183,20184,20185,20186,20187,20188,20189,20190,20191,20192,20193,20194,20195,20196,
			20197,20200,20201,20202,20203,20204,20205,20206,20207,20208,20209,20210,20211,20212,20213,20214,20215,20216,20217,20218,20219,20220,20221,20222,20223,20224,20225,20226,
			20227,20228,20229,20230,20231,20232,20233,20234,20235,20236,20237,20238,20239,20240,20241,20242,20243,20248,20249,20250,20251,20252,20253,20254,20255,20256,20257,20258,
			20259,20261,20262,20263,20264,20265,20266,20269,20270,20271,20272,20274,20275,20276,20277,20278,20279,20282,20283,20288,20289,20290,20291,20292,20293,20295,20296,20297,
			20298,20302,20303,20308,20309,20310,20313,20314,20315,20318,20319,20320,20321,20326,20327,20334,20335,20336,20337,20338,20339,20340,20341,20342,20343,20344,20345,20346,
			20347,20348,20349,20350,20351,20352,20353,20354,20355,20356,20357,20358,20359,20360,20363,20364,20365,20366,20367,20368,20369,20370,20371,20372,20373,20374,20375,20376,
			20377,20378,20379,20380,20381,20382,20383,20384,20385,20386,20387,20388,20389,20390,20391,20392,20393,20394,20395,20396,20397,20398,20399,20400,20401,20402,20403,20404,
			20405,20406,20411,20412,20413,20414,20415,20416,20417,20418,20419,20420,20421,20422,20424,20425,20426,20427,20428,20429,20432,20433,20434,20435,20437,20438,20439,20440,
			20441,20442,20445,20446,20451,20452,20453,20454,20455,20456,20458,20459,20460,20461,20465,20466,20471,20472,20473,20476,20477,20478,20481,20482,20483,20484,20489,20490
		};

		public void DeleteItem()
		{
			DeleteItemFromInventory();
		}

		void DeleteItemFromInventory()
		{
			ItemsToOperateListGenerate(isItemDeleteType);
			// MouseOperations.OpenInventoryTab1(); // TODO TEST IF ITS A MUST CAUSE IT TAKES TIME
			if (itemsToOperate.Count > 0)
			{
				ProgramHandle.OpenInventoryWindow();
				Thread.Sleep(800);
				foreach (var item in itemsToOperate)
				{

					if (ProgramHandle.isInventoryWindowStillOpen == 1)
					{
						Debug.WriteLine($"delete {item}");
						int deleteItemNumber = item + 6; // START FROM 2 Row 1st Column = 12
						if (deleteItemNumber >= 36 && ProgramHandle.isCurrentInventoryTabOppened() == 0)
						{
							Thread.Sleep(150);
							MouseOperations.MoveAndLeftClickOperation(1235, 670, 100); // Open Inventory Tab 2
							Thread.Sleep(150);
						}
						deleteOperationMouseMove(deleteItemNumber);
					}
					KeyPresser.PressEscape();
					Thread.Sleep(500);

				}
			}
		}

		void deleteOperationMouseMove(int deleteItemNumber)
		{
			int delaytime = 75;
			Thread.Sleep(delaytime);
			MouseOperations.OpenDeleteTab();
			Thread.Sleep(delaytime);
			Thread.Sleep(delaytime);
			if (ProgramHandle.isDeletelWindowOpen == 1)
			{
				MouseOperations.MoveAndLeftClickOperation(ExpBotMovePositionsValues.itemSellPositions[deleteItemNumber].Item1, ExpBotMovePositionsValues.itemSellPositions[deleteItemNumber].Item2, 50);
				Thread.Sleep(delaytime);
				MouseOperations.MoveItemToDeleteWindow();
				Thread.Sleep(delaytime);
				MouseOperations.MoveAndLeftClickOperation(1000, 770, 50);
				Thread.Sleep(delaytime);
				ItemSeller.MoveAndLeftClickToSellAll();
				Thread.Sleep(delaytime);
			}

		}


		public void ItemsToOperateListGenerate(Func<int,bool> funcDelegate)
		{

			itemsToOperate.Clear();
			for (int i = 0; i < 60; i++)
			{
				if (ProgramHandle.ReadInvItmsCount(i) != 0)
				{ 
					if (funcDelegate(i))
					{
						itemsToOperate.Add(i);
					}
				}
			}
		}
		public bool isItemDeleteType(int addressVector)
		{
			int itemType = ProgramHandle.ReadInventoryItemsType(addressVector);
			if(lowValueItems.Contains(itemType) && !ItemSeller.isItemHighValue(addressVector, Enums.EnumsList.InventoryType.Inventory))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
					
	}
}
