using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.AlternateRoute
{
    internal class AlternateRouteCalculator
	{
		public List<CoordsPoint> CalculateAlternateRouteCoordinates(CoordsPoint startPoint, Obstacle obstacle, CoordsPoint endPointOrigin)
		{
			List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();

			CoordsPoint newEndPoint = FindObstacleCorner.FindProperCorner(obstacle, endPointOrigin);

			int xDiff = newEndPoint.X - startPoint.X;
			int yDiff = newEndPoint.Y - startPoint.Y;
			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			int x = startPoint.X;
			int y = startPoint.Y;

			//int moveNumber = 1;
			while (x != newEndPoint.X || y != newEndPoint.Y)
			{
				int move = Math.Min(FactoryMoveToPoint.MaxMoveDistance, Math.Abs(newEndPoint.X - x));
				x += move * xDirection;
				move = Math.Min(FactoryMoveToPoint.MaxMoveDistance, Math.Abs(newEndPoint.Y - y));
				y += move * yDirection;
				routeCoordinates.Add(new CoordsPoint(x, y, 2));
				if (x == newEndPoint.X && y == newEndPoint.Y)
				{
					break;
				}
			}
			return routeCoordinates;
		}

	}
}
