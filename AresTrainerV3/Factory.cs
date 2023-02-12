using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.HealBot.Repoter.Returner.kharon;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveModels.MoveRandom.Etana;
using AresTrainerV3.MoveModels.MoveRandom.Hershal;
using AresTrainerV3.MoveModels.MoveRandom.Holina;
using AresTrainerV3.MoveModels.MoveRandom.Kharon;
using AresTrainerV3.MoveModels.MoveRandom.SacredAlliance;
using AresTrainerV3.PixelScanNPC;
using AresTrainerV3.ShopSellAntiBug;
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

		public static IWhatToCollect CreateSodCollector()
		{
			return new CollectSod();
		}
		public static IWhatToCollect CreateAllItemsCollector()
		{
			return new CollectAllItems();
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
				ExpBotMoverToRun = new MoverHolinaGoblins() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpHershalLowLvl();
				ExpBotMoverToRun = new MoverHershalLowLvl() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLeafMages)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpHershalTeleport();
				ExpBotMoverToRun = new MoverHershalLeafMages() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
			{
				RepoterCity = new RepoterHershalLeafMages();
				GoBackExpPlace = new GoBackExpUWC();
				ExpBotMoverToRun = new MoverHershalUwc1stFloor() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonWolves)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpKharonWolves();
				ExpBotMoverToRun = new MoverKharonWolves() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
				ExpBotMoverToRun = new MoverKharonBigWolves() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
				ExpBotMoverToRun = new MoverSloth1stFloorEntrace() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothNoIcebergs)
			{
				RepoterCity = new RepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothNoIcebergs();
				ExpBotMoverToRun = new MoverSloth1stFloorNoIceBergs() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
				ExpBotMoverToRun = new SlothHorseFarm() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
				ExpBotMoverToRun = new MoverSloth1stFloorAoe() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
				ExpBotMoverToRun = new MoverSloth1stFloorAoe2Spot() { WhatToDoWhileMoving = new DoScanAttackCollect(new PixelItemCollector(CreateWhatToCollect())) };
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
		public static AbstractWhatToCollect CreateWhatToCollect()
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
