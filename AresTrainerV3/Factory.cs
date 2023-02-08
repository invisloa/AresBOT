using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.HealBot.Repoter.Returner.kharon;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using AresTrainerV3.MoveRandom.Etana;
using AresTrainerV3.MoveRandom.Hershal;
using AresTrainerV3.MoveRandom.Holina;
using AresTrainerV3.MoveRandom.Kharon;
using AresTrainerV3.MoveRandom.SacredAlliance;
using AresTrainerV3.PixelScanNPC;
using AresTrainerV3.ShopSellAntiBug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3
{
	public static class Factory
	{
		public static WhatToCollectEnums whatToCollect;
		public static MoverBotEnums whichBotThreadToStart;
		public static ExpBotManagerAbstract ExpBotMoverToRun;
		public static IGoRepot RepoterCity;
		public static IGoBackExpAbstract GoBackExpPlace;
		static Thread blackScreenThread;
		public static IStartExpBotThread ExpBotToStart
		{
			get
			{
				expPlaceRepoterBotToStartSetter();
				return ExpBotMoverToRun;
			}
		}
		public static void SetExpBot()
		{
			expPlaceRepoterBotToStartSetter();
		}
		public static void expPlaceRepoterBotToStartSetter()
		{
			if (whichBotThreadToStart == MoverBotEnums.NoRepot)
			{
				RepoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.EtanaBuckerty)
			{
				ExpBotMoverToRun = new MoverEtanaBuckerty();
				RepoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.SacredGiko)
			{
				ExpBotMoverToRun = new MoverGiko();
				RepoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.SacredThievesSOD)
			{
				ExpBotMoverToRun = new MoverThievesSOD();
				RepoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.HolinaGoblins)
			{
				RepoterCity = new RepoterHolinaTeleport();
				GoBackExpPlace = new GoBackExpHolinaTeleport();
				ExpBotMoverToRun = new MoverHolinaGoblins() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpHershalLowLvl();
				ExpBotMoverToRun = new MoverHershalLowLvl() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLeafMages)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpHershalTeleport();
				ExpBotMoverToRun = new MoverHershalLeafMages() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpUWC();
				ExpBotMoverToRun = new MoverHershalUwc1stFloor() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonWolves)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpKharonWolves();
				ExpBotMoverToRun = new MoverKharonWolves() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonBigWolves)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpKharonBigWolves();
				ExpBotMoverToRun = new MoverKharonBigWolves() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.Sloth1stFloor)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSloth1stFloor();
				ExpBotMoverToRun = new MoverSloth1stFloorEntrace() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothNoIcebergs)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothNoIcebergs();
				ExpBotMoverToRun = new MoverSloth1stFloorNoIceBergs() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothHorseFarm)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothHorseFarm();
				ExpBotMoverToRun = new SlothHorseFarm() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothNoIcebergs();
				ExpBotMoverToRun = new MoverSloth1stFloorAoe() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe2Spot)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSloth1FloorAoe2Spot();
				ExpBotMoverToRun = new MoverSloth1stFloorAoe2Spot() { WhatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}

		}
		public static IFindNPC CreateFindNPC()
		{
			return new PixelScanForNpc();
		}
		public static IUnBugShop CreateUnbugShop()
		{
			return new ShopMoveUnbugger(); 
		}
		public static IActionToUnbug CreateUnbugActionClass()
		{
			return new MoveAwayFromShop();
		}
		public static IUnbugWhenCollecting CreateCollectItemUnbugger()
		{
			return new CollectAntibug();
		}
		public static AbstractWhatToCollect whatToCollectSetter()
		{
			if (whatToCollect == WhatToCollectEnums.Event)
			{
				return new CollectSodEvent();
			}
			else if (whatToCollect == WhatToCollectEnums.Stones)
			{
				return new CollectSodStones();
			}
			else if (whatToCollect == WhatToCollectEnums.Jewelery)
			{
				return new CollectSodJewelery();
			}
			else if (whatToCollect == WhatToCollectEnums.SellWeapons)
			{
				return new CollectSellerCry();
			}
			else if (whatToCollect == WhatToCollectEnums.SellAll)
			{
				return new CollectAllItems();
			}
			else
			{
				return new CollectSod();
			}
		}

	}
}
