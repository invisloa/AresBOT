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

		public static IStartExpBotThread _expBotToStart;
		public static IGoRepot repoterCity;
		public static IGoBackExpAbstract _goBackExpPlace;
		static Thread blackScreenThread;

		public static IStartExpBotThread ExpBotToStart
		{
			get
			{
				expPlaceRepoterBotToStartSetter();
				return _expBotToStart;
			}
		}
		public static void SetCollectItems()
		{
			switch (whatToCollect)
			{
				case Enums.EnumsList.WhatToCollectEnums.Event:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSodEvent()));
					break;
				case Enums.EnumsList.WhatToCollectEnums.Stones:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSodStones()));
					break;
				case Enums.EnumsList.WhatToCollectEnums.Jewelery:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSodJewelery()));
					break;
				case Enums.EnumsList.WhatToCollectEnums.StonesAndJewelery:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSodStonesJewleryItems()));
					break;
				case Enums.EnumsList.WhatToCollectEnums.SellWeapons:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectSellerCry()));
					break;
				case Enums.EnumsList.WhatToCollectEnums.SellAll:
					ExpBotMoverToRun.whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(new CollectAllItems()));
					break;
				default:
					break;
			}
		}
		public static void expPlaceRepoterBotToStartSetter()
		{
			if (whichBotThreadToStart == MoverBotEnums.NoRepot)
			{
				repoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.EtanaBuckerty)
			{
				ExpBotMoverToRun = new MoverEtanaBuckerty();
				repoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.SacredGiko)
			{
				ExpBotMoverToRun = new MoverGiko();
				repoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.SacredThievesSOD)
			{
				ExpBotMoverToRun = new MoverThievesSOD();
				repoterCity = new RepoterShutdown();
			}
			else if (whichBotThreadToStart == MoverBotEnums.HolinaGoblins)
			{
				ExpBotMoverToRun = new MoverHolinaGoblins();
				repoterCity = new RepoterHolinaTeleport();
				_goBackExpPlace = new GoBackExpHolinaTeleport();
				_expBotToStart = new MoverHolinaGoblins() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				ExpBotMoverToRun = new MoverHershalLowLvl();
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpHershalLowLvl();
				_expBotToStart = new MoverHershalLowLvl() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLeafMages)
			{
				ExpBotMoverToRun = new MoverHershalLeafMages();
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpHershalTeleport();
				_expBotToStart = new MoverHershalLeafMages() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
			{
				ExpBotMoverToRun = new MoverHershalUwc1stFloor();
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpUWC();
				_expBotToStart = new MoverHershalUwc1stFloor() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonWolves)
			{
				ExpBotMoverToRun = new MoverKharonWolves();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpKharonWolves();
				_expBotToStart = new MoverKharonWolves() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonBigWolves)
			{
				ExpBotMoverToRun = new MoverKharonBigWolves();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpKharonBigWolves();
				_expBotToStart = new MoverKharonBigWolves() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.Sloth1stFloor)
			{
				ExpBotMoverToRun = new MoverSloth1stFloorEntrace();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSloth1stFloor();
				_expBotToStart = new MoverSloth1stFloorEntrace() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothNoIcebergs)
			{
				ExpBotMoverToRun = new MoverSloth1stFloorNoIceBergs();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothNoIcebergs();
				_expBotToStart = new MoverSloth1stFloorNoIceBergs() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothHorseFarm)
			{
				ExpBotMoverToRun = new SlothHorseFarm();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothHorseFarm();
				_expBotToStart = new SlothHorseFarm() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe)
			{
				ExpBotMoverToRun = new MoverSloth1stFloorAoe();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothNoIcebergs();
				_expBotToStart = new MoverSloth1stFloorAoe() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe2Spot)
			{
				ExpBotMoverToRun = new MoverSloth1stFloorAoe2Spot();
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSloth1FloorAoe2Spot();
				_expBotToStart = new MoverSloth1stFloorAoe2Spot() { whatToCollectWhileMoving = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
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
