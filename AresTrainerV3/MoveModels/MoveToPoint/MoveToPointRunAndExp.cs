using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class MoveToPointRunAndExp : ExpBotManagerAbstract
	{
		IMoveToPoint moveToPos = new MoveToPointPosition();
		public override IDoWhileMoving WhatToDoWhileMoving { get =>Factory.CreateIDoWhileMovingAttack(); }
		ReadOnlyCollection<CoordsPoint> moveDestinations { get; set; }
		int currentPointToMove = 0;
		public MoveToPointRunAndExp(ReadOnlyCollection<CoordsPoint> MoveDestinations)
		{
			moveDestinations = MoveDestinations;
		}
		public override void RunAndExp()
		{
			ProgramHandle.SetCameraForExpBot();

			while (isExpBotRunning)
			{
				if (ProgramHandle.isInCity == 1 && shutDownOnRepot)
				{
					Process.Start("Shutdown", "-s -t 10");
				}
				MoveAttackAndCollect();
			}
		}
		public override bool MoveAttackAndCollect()
		{
			while (isExpBotRunning)
			{
				while (WhatToDoWhileMoving.DoThisWhileMoving()) ;

				if (moveToPos.MoveToDestination(moveDestinations[currentPointToMove]))
				{
					currentPointToMove++;
					if(currentPointToMove == moveDestinations.Count) { currentPointToMove= 0; }
				}
				return true;
			}
			return false;
		}

	}
}
