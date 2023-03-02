using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class CoordsMoveRepoter : CoordsMoveOnly
	{

		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		public CoordsMoveRepoter()
		{
			if (ProgramHandle.GetCurrentMap == TeleportValues.Hollina)
			{
				this.moveDestinationsList = DestinationsCoordinator.RepotHoolina;
			}
			if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
			{
				this.moveDestinationsList = DestinationsCoordinator.RepotHershal;
			}
			if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
			{
				this.moveDestinationsList = DestinationsCoordinator.RepotKharon;
			}
		}



	}
}
