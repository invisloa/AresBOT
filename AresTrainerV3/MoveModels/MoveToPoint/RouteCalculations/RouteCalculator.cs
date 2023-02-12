namespace AresTrainerV3.MoveModels
{
	public class RouteCalculator : IRouteCalculator
	{
		// TODO
		// IS IN OBSTACLE METHOD TO GET OUT OF OBSTACLE WHEN ALREADY IN IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		int correctionValue = 3;
		bool isLineOnXAxis = false;


		public List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint endPoint)
		{
			List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
			int xDiff = endPoint.X - FactoryMoveToPoint.GetCurrentPositionX;
			int yDiff = endPoint.Y - FactoryMoveToPoint.GetCurrentPositionY;

			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			int x = FactoryMoveToPoint.GetCurrentPositionX;
			int y = FactoryMoveToPoint.GetCurrentPositionY;

			while (x != endPoint.X || y != endPoint.Y)
			{
				int move = Math.Min(12, Math.Abs(endPoint.X - x));
				x += move * xDirection;

				move = Math.Min(12, Math.Abs(endPoint.Y - y));
				y += move * yDirection;


				routeCoordinates.Add(new CoordsPoint(x, y));
				if (x == endPoint.X && y == endPoint.Y)
				{
					break;
				}
			}
			return routeCoordinates;
		}
		CoordsPoint EndPointCorrection(int xDirection, int yDirection, Line intersectedLine)
		{
			CoordsPoint endPoint = new CoordsPoint(0, 0);
			if (isLineOnXAxis)
			{
				endPoint.X = (xDirection < 0) ?
				Math.Min(intersectedLine.P1.X, intersectedLine.P2.X) - correctionValue :
				Math.Max(intersectedLine.P1.X, intersectedLine.P2.X) + correctionValue;
				endPoint.Y = (yDirection < 0) ?
				Math.Min(intersectedLine.P1.Y, intersectedLine.P2.Y) + correctionValue :
				Math.Max(intersectedLine.P1.Y, intersectedLine.P2.Y) - correctionValue;
			}
			else
			{
				endPoint.X = (xDirection < 0) ?
				Math.Min(intersectedLine.P1.X, intersectedLine.P2.X) + correctionValue :
				Math.Max(intersectedLine.P1.X, intersectedLine.P2.X) - correctionValue;
				endPoint.Y = (yDirection < 0) ?
				Math.Min(intersectedLine.P1.Y, intersectedLine.P2.Y) - correctionValue :
				Math.Max(intersectedLine.P1.Y, intersectedLine.P2.Y) + correctionValue;
			}
			return endPoint;
		}
		public CoordsPoint CalculateAlternateEndPoint(CoordsPoint endPointOrigin, Line intersectedLine)
		{
			if ((intersectedLine.P2.X - intersectedLine.P1.X) != 0)
			{
				isLineOnXAxis = true;
			}
			else
			{
				isLineOnXAxis = false;
			}

			int xDiff = endPointOrigin.X - FactoryMoveToPoint.GetCurrentPositionX;
			int yDiff = endPointOrigin.Y - FactoryMoveToPoint.GetCurrentPositionY;

			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			return EndPointCorrection(xDirection, yDirection, intersectedLine);
		}

		public List<CoordsPoint> CalculateAlternateRouteCoordinates(CoordsPoint startPoint, Line intersectedLine)
		{
			bool isLineOnXAxis = false;
			List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
			if ((intersectedLine.P2.X - intersectedLine.P1.X) != 0)
			{
				isLineOnXAxis = true;
			}
			int xDiff1 = intersectedLine.P1.X - startPoint.X;
			int yDiff1 = intersectedLine.P1.Y - startPoint.Y;

			int xDiff2 = intersectedLine.P2.X - startPoint.X;
			int yDiff2 = intersectedLine.P2.Y - startPoint.Y;

			CoordsPoint endPoint;

			if (Math.Abs(xDiff1) + Math.Abs(yDiff1) < Math.Abs(xDiff2) + Math.Abs(yDiff2))
			{
				endPoint = intersectedLine.P1;
			}
			else
			{
				endPoint = intersectedLine.P2;
			}

			int xDiff = endPoint.X - startPoint.X;
			int yDiff = endPoint.Y - startPoint.Y;
			if (isLineOnXAxis) { xDiff = xDiff < 0 ? xDiff - 3 : xDiff + 3; }
			else { yDiff = yDiff < 0 ? yDiff - 3 : yDiff + 3; }
			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			int x = startPoint.X;
			int y = startPoint.Y;

			//int moveNumber = 1;
			while (x != endPoint.X || y != endPoint.Y)
			{
				int move = Math.Min(12, Math.Abs(endPoint.X - x));
				x += move * xDirection;

				move = Math.Min(12, Math.Abs(endPoint.Y - y));
				y += move * yDirection;


				routeCoordinates.Add(new CoordsPoint(x, y));
				if (x == endPoint.X && y == endPoint.Y)
				{
					break;
				}
			}
			return routeCoordinates;
		}

	}


}