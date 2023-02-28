using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.MoveModels.MoveRandom.Hershal;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.MovePositions;
using AresTrainerV3.Unstuck;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class CoordsMoveRunAndExp : CoordsMoveBase, IMoveAttackCollect, IStartExpBotThread
	{
		public IDoWhileMoving WhatToDoWhileMoving { get => Factory.CreateIDoWhileMovingAttack(); }

		public CoordsMoveRunAndExp()
		{
			MoveDestinationsAssigner();
		}
		public CoordsMoveRunAndExp(ReadOnlyCollection<CoordsPoint> movePositions)
		{
			moveDestinationsList = movePositions;
		}
		public void MoveAttackAndCollect()
		{
			while (ExpBotManagerAbstract.isExpBotRunning)
			{
				while (WhatToDoWhileMoving.DoThisWhileMoving()) ;
				moveUnstucker.CheckIfMoveIsStucked();

				if (moveToNextPos.OneMoveToDestination(moveDestinationsList[currentPointToMove]))
				{
					currentPointToMove++;
					if (currentPointToMove == moveDestinationsList.Count) { currentPointToMove = 0; }
				}
			}
		}

		public void StartExpBotThread()
		{
			ExpBotManagerAbstract.RequestStartExpBot();
			ProgramHandle.SetCameraForExpBot();
			Thread.Sleep(10);
			Thread ExpBotThread = new Thread(MoveAttackAndCollect);
			ExpBotThread.Start();
		}

		void MoveDestinationsAssigner()
		{
			if (Factory.WhichBotThreadToStart == MoverBotEnums.HolinaGoblins)
			{
				moveDestinationsList = DestinationsCoordinator.HolinaGoblins;
			}
			else if (Factory.WhichBotThreadToStart == MoverBotEnums.BucksLowLVL)
			{
				moveDestinationsList = DestinationsCoordinator.BuckLowLVL;
			}
			else if (Factory.WhichBotThreadToStart == MoverBotEnums.HershalLowLvl)
			{
				moveDestinationsList = DestinationsCoordinator.HershalLowLVLExp;
			}
		}
	}
}