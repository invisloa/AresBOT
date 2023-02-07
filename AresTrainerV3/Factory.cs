using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.HealBot.Repoter.Returner.kharon;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom.Hershal;
using AresTrainerV3.MoveRandom.Holina;
using AresTrainerV3.MoveRandom.Kharon;
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
	public class Factory
	{
		public static WhatToCollectEnums whatToCollect
		{
			get;
			set;
		}
		Thread blackScreenThread;
		protected static IStartExpBotThread _expBotToStart;
		public static MoverBotEnums whichBotThreadToStart
		{
			get;
			set;
		}
		static IGoRepot repoterCity
		{
			get;
			set;
		}

		static IGoBackExpAbstract _goBackExpPlace;

		static protected IStartExpBotThread ExpBotToStart
		{
			get
			{
				expPlaceRepoterBotToStartSetter();
				return _expBotToStart;
			}
		}

		public void expPlaceRepoterBotToStartSetter()
		{
			if (whichBotThreadToStart == MoverBotEnums.NoRepot)
			{
				repoterCity = new RepoterShutdown();
				_goBackExpPlace = new GoBackExpHolinaTeleport();
			}
			else if (whichBotThreadToStart == MoverBotEnums.SacredThieves)
			{

			}
			else if (whichBotThreadToStart == MoverBotEnums.HolinaGoblins)
			{
				repoterCity = new RepoterHolinaTeleport();
				_goBackExpPlace = new GoBackExpHolinaTeleport();
				_expBotToStart = new MoverHolinaGoblins() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };

			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpHershalLowLvl();
				_expBotToStart = new MoverHershalLowLvl() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalLeafMages)
			{
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpHershalTeleport();
				_expBotToStart = new MoverHershalLeafMages() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
			{
				repoterCity = new RepoterHershalLeafMages();
				_goBackExpPlace = new GoBackExpUWC();
				_expBotToStart = new MoverHershalUwc1stFloor() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonWolves)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpKharonWolves();
				_expBotToStart = new MoverKharonWolves() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.KharonBigWolves)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpKharonBigWolves();
				_expBotToStart = new MoverKharonBigWolves() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.Sloth1stFloor)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSloth1stFloor();
				_expBotToStart = new MoverSloth1stFloorEntrace() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothNoIcebergs)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothNoIcebergs();
				_expBotToStart = new MoverSloth1stFloorNoIceBergs() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothHorseFarm)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothHorseFarm();
				_expBotToStart = new SlothHorseFarm() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSlothNoIcebergs();
				_expBotToStart = new MoverSloth1stFloorAoe() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(Factory.whatToCollectSetter())) };
				if (blackScreenThread == null)
				{
					blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
					blackScreenThread.Start();
				}
			}
			else if (whichBotThreadToStart == MoverBotEnums.SlothAoe2Spot)
			{
				repoterCity = new RepoterKharonExp();
				_goBackExpPlace = new GoBackExpSloth1FloorAoe2Spot();
				_expBotToStart = new MoverSloth1stFloorAoe2Spot() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
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
