using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords
{
	public static class DestinationsCoordinator
	{
		public static readonly ReadOnlyCollection<CoordsPoint> NoMoveCoords = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(500, 500, 1000)
		});

		public static readonly ReadOnlyCollection<CoordsPoint> HolinaGoblins = new ReadOnlyCollection<CoordsPoint>(new[]
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

		public static readonly ReadOnlyCollection<CoordsPoint> BuckLowLVL = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(202, 138),
		new CoordsPoint(193, 110),
		new CoordsPoint(172, 83, 3),
		new CoordsPoint(157, 76),
		new CoordsPoint(130, 69),
		new CoordsPoint(110, 78),
		new CoordsPoint(99, 100),
		new CoordsPoint(103, 118),
		new CoordsPoint(135, 135),
		new CoordsPoint(177, 150),
		new CoordsPoint(195, 142)
		});

		public static readonly ReadOnlyCollection<CoordsPoint> RepotHoolina = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(222, 396, 1),
		new CoordsPoint(234, 389, 1),
		new CoordsPoint(260, 389, 3),
		new CoordsPoint(267, 397, 2),
		new CoordsPoint(267, 414, 1),
		});

		public static readonly ReadOnlyCollection<CoordsPoint> HershalRepot = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(575, 560, 4),
		new CoordsPoint(580, 560, 4),
		new CoordsPoint(556, 553, 5),
		new CoordsPoint(536, 536, 2),
		});
		public static readonly ReadOnlyCollection<CoordsPoint> HershalLowLVLExp = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(430, 620, 8),
		new CoordsPoint(386, 520, 8),
		new CoordsPoint(381, 459, 8),
		new CoordsPoint(260, 490, 8),
		new CoordsPoint(355, 610, 8),
		new CoordsPoint(260, 490, 8),
		new CoordsPoint(260, 490, 8),
		});

		public static readonly ReadOnlyCollection<CoordsPoint> GoBackExpHershalOutsideCity = new ReadOnlyCollection<CoordsPoint>(new[]
		{
		new CoordsPoint(529, 555, 2),
		new CoordsPoint(518, 564, 4),
		new CoordsPoint(510, 584, 2),
		new CoordsPoint(505, 600, 6),
		new CoordsPoint(470,605,6)
		});
	}
}