using AresTrainerV3.MoveModels.MoveToPoint;
using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
	internal class GoBackExpHershalLowLvl : GoBackExpAbstract
	{
		public override void GoBackExp()
		{
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			CoordsMoveBase mover = new CoordsMoveBase(DestinationsCoordinator.GoBackExpHershalOutsideCity);
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST

			mover.MoveToDestination();
		}
	}
}
