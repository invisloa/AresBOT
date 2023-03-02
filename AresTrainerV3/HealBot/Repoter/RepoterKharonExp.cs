using AresTrainerV3.ItemInventory.Buyer;
using AresTrainerV3.PixelScanNPC;

namespace AresTrainerV3.HealBot.Repoter
{
	public class RepoterKharonExp : RepotAbstract
	{
		protected override BuyerPotionsAbstract BuyerPotionsCity
		{
			get
			{
				if (_buyerPotionsCity == null)
				{
					_buyerPotionsCity = new BuyerPotionsKharonExp();
				}
				return _buyerPotionsCity;
			}
		}
		protected override int repotCityCheck
		{
			get
			{
				_repotCityVerification = TeleportValues.Kharon;
				return _repotCityVerification;
			}
		}

		protected override void MoveToRepot()
		{
			if (ProgramHandle.isNowStandingCity())
			{
				if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
				{
					moverToPointRepoter.MoveToDestination();
					ProgramHandle.ZoomCameraForNpcScan();
					IFindNPC npcFinder = Factory.CreateFindNPC();
					if (npcFinder.FindNpc())
					{
						ProgramHandle.SetCameraForExpBot();
					}
					else
					{
						throw new NotImplementedException();
					}




					/*		OLD REPOT PIXEL MOVE
					 *		
					 *		if (ProgramHandle.isNowStandingCity())
								{
									Thread.Sleep(500);
									ProgramHandle.SetCameraLong();
									Thread.Sleep(500);
									if (ProgramHandle.GetPositionShortY == 17126)
									{
										MouseOperations.MoveAndLeftClickOperation(1113 + randomizer.Next(5), 267 + randomizer.Next(5), 200);
										Thread.Sleep(500);
									}
									else if (ProgramHandle.GetPositionShortY == 17142)
									{
										MouseOperations.MoveAndLeftClickOperation(1126, 318, 200);
										Thread.Sleep(500);
									}
									while (!ProgramHandle.isNowStandingCity())
									{
										Thread.Sleep(50);
									}
					*/
				}
			}
		}

	}
}

