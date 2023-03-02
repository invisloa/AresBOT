using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.HealBot.Repoter.Returner.kharon;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.ItemInventory;
using AresTrainerV3.MoveModels;
using AresTrainerV3.MoveModels.MoveRandom.Etana;
using AresTrainerV3.MoveModels.MoveRandom.Hershal;
using AresTrainerV3.MoveModels.MoveRandom.Kharon;
using AresTrainerV3.MoveModels.MoveRandom.SacredAlliance;
using AresTrainerV3.MoveModels.MoveToPoint;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.PixelScanNPC;
using AresTrainerV3.ShopSellAntiBug;
using AresTrainerV3.Unstuck;
using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3
{
	public static class Factory
	{
		private static WhatToCollectEnums whatToCollect;
		private static MoverBotEnums whichBotThreadToStart;
		private static IStartExpBotThread expBotMoverToRun;
		private static IGoRepot repoterCity;
		private static IGoBackExpAbstract goBackExpPlace;
		static Thread blackScreenThread;
		internal static bool GoRepotFirst = true;
		internal static IOneMoveToDestinationPosition CreateOneMoveToDestinationPosition { get => new OneMoveToDestinationPosition(); }
		public static IStartExpBotThread ExpBotToStart { get => expBotMoverToRun; set => expBotMoverToRun = value; }
		public static IGoBackExpAbstract GoBackExpAbstract { get => GoBackExpPlace; set => GoBackExpPlace = value; }
		public static IGoRepot RepoterCity { get => repoterCity; set => repoterCity = value; }
		public static IGoBackExpAbstract GoBackExpPlace { get => goBackExpPlace; set => goBackExpPlace = value; }
		public static WhatToCollectEnums WhatToCollect { get => whatToCollect; set => whatToCollect = value; }
		public static MoverBotEnums WhichBotThreadToStart { get => whichBotThreadToStart; set => whichBotThreadToStart = value; }
		public static IWhatToCollect CreateSodCollector() => new CollectSod();
		public static IWhatToCollect CreateAllItemsCollector() => new CollectAllItems();
		public static IGoRepot CreateShutdownOnRepot() => new RepoterShutdown();
		public static IUnstuckerMover CreateUstuckerExp() => new UnstuckerMover();
		public static IGoRepot CreateRepoterHolinaTeleport() => new RepoterHolina();
		public static IGoRepot CreateRepoterHershal() => new RepoterHershal();
		public static IGoRepot CreateRepoterKharonExp() => new RepoterKharonExp();
		public static IFindNPC CreateFindNPC() => new PixelScanForNpc();
		public static IUnBugShop CreateUnbugShop() => new ShopMoveUnbugger();
		public static IActionToUnbug CreateUnbugActionClass() => new MoveAwayFromShop();
		public static IUnbugWhenCollecting CreateCollectItemUnbugger() => new CollectAntibug();
		public static IScanAndCollect CreateScanAndCollectMethod() => new PixelItemCollector(CreateWhatToCollect());
		public static IDoWhileMoving CreateIDoWhileMovingAttack() => new DoScanAttackCollect(CreateScanAndCollectMethod());
		public static IDoWhileMoving CreateIDoWhileMovingNothing() => new DoNothing();

		public static HealBotA HealbotToRun = new HealBotA();


		// TO CHANGE
		// TO CHANGE
		// TO CHANGE



		public static IStartExpBotThread CreateCoordsMover() => new CoordsMoveRunAndExp();
		// TO CHANGE
		// TO CHANGE
		// TO CHANGE
		// TO CHANGE
		// TO CHANGE




		public static void ExpPlaceRepoterBotToStartSetter()
		{
			if (WhichBotThreadToStart == MoverBotEnums.NoRepot)
			{
				RepoterCity = CreateShutdownOnRepot();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.EtanaBuckerty)
			{
				RepoterCity = CreateShutdownOnRepot();
				expBotMoverToRun = new MoverEtanaBuckerty();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SacredGiko)
			{
				RepoterCity = CreateShutdownOnRepot();
				expBotMoverToRun = new MoverGiko();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SacredThievesSOD)
			{
				RepoterCity = CreateShutdownOnRepot();
				expBotMoverToRun = new MoverThievesSOD();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.HolinaGoblins)
			{
				RepoterCity = CreateRepoterHolinaTeleport();
				GoBackExpPlace = new GoBackExpGoblinsTeleport();
				expBotMoverToRun = CreateCoordsMover();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.BucksLowLVL)
			{
				RepoterCity = CreateShutdownOnRepot();
				GoBackExpPlace = new GoBackExpGoblinsTeleport();
				expBotMoverToRun = CreateCoordsMover();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				RepoterCity = CreateRepoterHershal(); 
				GoBackExpPlace = new GoBackExpHershalLowLvl();
				expBotMoverToRun = CreateCoordsMover();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.HershalLeafMages)
			{
				RepoterCity = CreateRepoterHershal();
				GoBackExpPlace = new GoBackExpHershalTeleport();
				expBotMoverToRun = new MoverHershalLeafMages();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
			{
				RepoterCity = CreateRepoterHershal();
				GoBackExpPlace = new GoBackExpUWC();
				expBotMoverToRun = new MoverHershalUwc1stFloor();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.KharonWolves)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new CoordsGoBackExpWolves();
				expBotMoverToRun = CreateCoordsMover();
				/*if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}*/
			}
			else if (WhichBotThreadToStart == MoverBotEnums.KharonBigWolves)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpKharonBigWolves();
				expBotMoverToRun = new MoverKharonBigWolves();
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (WhichBotThreadToStart == MoverBotEnums.Sloth1stFloor)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpSloth1stFloor();
				expBotMoverToRun = new MoverSloth1stFloorEntrace();
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SlothNoIcebergs)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothNoIcebergs();
				expBotMoverToRun = new MoverSloth1stFloorNoIceBergs();
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SlothHorseFarm)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothHorseFarm();
				expBotMoverToRun = new SlothHorseFarm();
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SlothAoe)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpSlothNoIcebergs();
				expBotMoverToRun = new MoverSloth1stFloorAoe();
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (WhichBotThreadToStart == MoverBotEnums.SlothAoe2Spot)
			{
				RepoterCity = CreateRepoterKharonExp();
				GoBackExpPlace = new GoBackExpSloth1FloorAoe2Spot();
				expBotMoverToRun = new MoverSloth1stFloorAoe2Spot();
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}

		}

		public static AbstractWhatToCollect CreateWhatToCollect()
		{
			if (WhatToCollect == WhatToCollectEnums.Event)
			{
				return new CollectSodEvent();
			}
			else if (WhatToCollect == WhatToCollectEnums.Stones)
			{
				return new CollectSodStones();
			}
			else if (WhatToCollect == WhatToCollectEnums.Jewelery)
			{
				return new CollectSodJewelery();
			}
			else if (WhatToCollect == WhatToCollectEnums.SellWeapons)
			{
				return new CollectSellerCry();
			}
			else if (WhatToCollect == WhatToCollectEnums.SellAll)
			{
				return new CollectAllItems();
			}
			else
			{
				return new CollectSod();
			}
		}

		internal static IItemsOperationsGenerator ItemsOperationsGenerator() => new ItemsToOperateListGenerator();

		internal static IItemsStorageMoverHack CreateItemsStorageMoverHack() => new ItemsStorageMoverHack();

		internal static IMoveToPoint CreateMoveToRepot
		{
			get
			{
				return new CoordsMoveRepoter();
			}

		}

	}
}
