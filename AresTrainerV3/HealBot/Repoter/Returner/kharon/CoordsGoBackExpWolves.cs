using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.MoveModels.MoveToPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner.kharon
{
	internal class CoordsGoBackExpWolves : GoBackExpAbstract
	{
		public override void GoBackExp()
		{
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			CoordsMoveOnly mover = new CoordsMoveOnly(DestinationsCoordinator.GoBackExpKharonOutsideCity);
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST
			// TEST TEST TEST

			mover.MoveToDestination();
			int routeRandomizer = randomizer.Next(2);
			if (routeRandomizer == 0)
			{
				mover = new CoordsMoveOnly(DestinationsCoordinator.GoBackExpKharonOutOfZagroda);
			}
			else
			{
				mover = new CoordsMoveOnly(DestinationsCoordinator.GoBackExpKharonOutOfZagroda2);
			}
			mover.MoveToDestination();

		}
	}
}
