using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class MoveToPointRepoter : IMoveToPointRepoter
	{
		IMoveToPoint moveToPos = new MoveToPointPosition();
		ReadOnlyCollection<CoordsPoint> moveDestinations { get; set; }

		public MoveToPointRepoter()
		{
			if (ProgramHandle.GetCurrentMap == TeleportValues.Hollina)
			{
				this.moveDestinations = DestinationsCoordinator.RepotHoolina;
				 
			}
		}
		public MoveToPointRepoter(ReadOnlyCollection<CoordsPoint> movePositionsForTesting)
		{
			this.moveDestinations = movePositionsForTesting;
		}
		int currentPointToMove = 0;
		public bool MoveToRepotDestination()
		{
			ProgramHandle.SetCameraForExpBot();
			while (currentPointToMove < moveDestinations.Count)
			{
				if (moveToPos.MoveToDestination(moveDestinations[currentPointToMove]))
				{
					currentPointToMove++;
				}
			}
			return true;
		}

	}
}
