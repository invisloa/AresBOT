using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations
{
	internal interface IRouteChunker
	{
		List<CoordsPoint> ChunkRouteCoordinates(CoordsPoint endPoint);

	}
}
