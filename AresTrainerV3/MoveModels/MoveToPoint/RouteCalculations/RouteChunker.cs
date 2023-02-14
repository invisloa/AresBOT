using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations
{
	public class RouteChunker : IRouteChunker
	{
		public List<CoordsPoint> ChunkRouteCoordinates(CoordsPoint endPoint)
		{
			List<CoordsPoint> chunkedRouteCoordinates = new List<CoordsPoint>();
			int currentPosX = FactoryMoveToPoint.GetCurrentPositionX;
			int currentPosY = FactoryMoveToPoint.GetCurrentPositionY;
			int xDiff = endPoint.X - currentPosX;
			int yDiff = endPoint.Y - currentPosY;

			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;
			int x = currentPosX;
			int y = currentPosY;

			while (x != endPoint.X || y != endPoint.Y)
			{
				int move = Math.Min(1, Math.Abs(endPoint.X - x));
				x += move * xDirection;

				move = Math.Min(1, Math.Abs(endPoint.Y - y));
				y += move * yDirection;


				chunkedRouteCoordinates.Add(new CoordsPoint(x, y));
				if (x == endPoint.X && y == endPoint.Y)
				{
					break;
				}
			}
			return chunkedRouteCoordinates;
		}
	}
}
