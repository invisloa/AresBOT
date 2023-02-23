using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords
{
	public struct DestinationsCoordinator
	{
		public DestinationsCoordinator()
		{
			HolinaGoblins = new ReadOnlyCollection<CoordsPoint>(new[]
			{
			new CoordsPoint(180, 250),
			new CoordsPoint(200, 310),
			new CoordsPoint(260, 290),
			new CoordsPoint(300, 260),
			new CoordsPoint(360, 240),
			new CoordsPoint(300, 215),
			new CoordsPoint(260, 235),
			new CoordsPoint(245, 240)
		});

			BuckLowLVL = new ReadOnlyCollection<CoordsPoint>(new[]
			{
			new CoordsPoint(202, 138),
			new CoordsPoint(193, 110),
			new CoordsPoint(171, 85),
			new CoordsPoint(157, 76),
			new CoordsPoint(130, 69),
			new CoordsPoint(110, 78),
			new CoordsPoint(99, 100),
			new CoordsPoint(103, 118),
			new CoordsPoint(135, 135),
			new CoordsPoint(177, 150),
			new CoordsPoint(195, 142)
		});
		}

		public ReadOnlyCollection<CoordsPoint> HolinaGoblins { get; }
		public ReadOnlyCollection<CoordsPoint> BuckLowLVL { get; }
	}
}
