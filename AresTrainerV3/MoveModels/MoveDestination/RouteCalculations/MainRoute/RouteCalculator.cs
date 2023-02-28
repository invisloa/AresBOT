namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute
{
    public class RouteCalculator : IRouteCalculator
    {
        // TODO
        // IS IN OBSTACLE METHOD TO GET OUT OF OBSTACLE WHEN ALREADY IN IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        int obstacleMoveFactor = 4;
        bool isLineOnXAxis = false;
        int maxMoveDistance = 12;


		// move to the endpoint in a straight line 
		public List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint endPoint)
		{
			List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
			int startX = FactoryMoveToPoint.GetCurrentPositionX;
			int startY = FactoryMoveToPoint.GetCurrentPositionY;

			int xDiff = endPoint.X - startX;
			int yDiff = endPoint.Y - startY;
			int totalDistance = (int)Math.Sqrt(xDiff * xDiff + yDiff * yDiff);

			if (totalDistance == 0)
			{
				routeCoordinates.Add(new CoordsPoint(startX, startY));
			}
			else
			{
				int maxSteps = (int)Math.Ceiling((double)totalDistance / maxMoveDistance);
				double xIncrement = (double)xDiff / maxSteps;
				double yIncrement = (double)yDiff / maxSteps;

				double x = startX;
				double y = startY;

				for (int i = 0; i <= maxSteps; i++)
				{
					x += xIncrement;
					y += yIncrement;
					int roundedX = (int)Math.Round(x);
					int roundedY = (int)Math.Round(y);
					routeCoordinates.Add(new CoordsPoint(roundedX, roundedY));
				}
			}
			return routeCoordinates;
		}

		// if any line was interected set a new endpoint to go to (at the end of intersected line)
		public CoordsPoint CalculateAlternateEndPoint(CoordsPoint endPointOrigin, Line intersectedLine)

        {
            if (intersectedLine.P2.X - intersectedLine.P1.X != 0)
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


        // set the endpoint at the end of inersected line according to move direction
        CoordsPoint EndPointCorrection(int xDirection, int yDirection, Line intersectedLine)
        {
            CoordsPoint endPoint = new CoordsPoint(0, 0);
            if (isLineOnXAxis)
            {
                endPoint.X = xDirection < 0 ?
                Math.Min(intersectedLine.P1.X, intersectedLine.P2.X) - obstacleMoveFactor :
                Math.Max(intersectedLine.P1.X, intersectedLine.P2.X) + obstacleMoveFactor;
                endPoint.Y = yDirection < 0 ?
                Math.Min(intersectedLine.P1.Y, intersectedLine.P2.Y) + obstacleMoveFactor :
                Math.Max(intersectedLine.P1.Y, intersectedLine.P2.Y) - obstacleMoveFactor;
            }
            else
            {
                endPoint.X = xDirection < 0 ?
                Math.Min(intersectedLine.P1.X, intersectedLine.P2.X) + obstacleMoveFactor :
                Math.Max(intersectedLine.P1.X, intersectedLine.P2.X) - obstacleMoveFactor;
                endPoint.Y = yDirection < 0 ?
                Math.Min(intersectedLine.P1.Y, intersectedLine.P2.Y) - obstacleMoveFactor :
                Math.Max(intersectedLine.P1.Y, intersectedLine.P2.Y) + obstacleMoveFactor;
            }
            return endPoint;
        }
    }
}


/*    
 *    
 *    OLD Move not in line to the endpoint
 *    
 *    
 *    
 *    public List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint endPoint)
		{
			List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
			int x = FactoryMoveToPoint.GetCurrentPositionX;
			int y = FactoryMoveToPoint.GetCurrentPositionY;

			int xDiff = endPoint.X - x;
			int yDiff = endPoint.Y - y;
			if (xDiff == 0 && yDiff == 0)
			{
				routeCoordinates.Add(new CoordsPoint(x, y));
			}
			else
			{
				int xDirection = xDiff < 0 ? -1 : 1;
				int yDirection = yDiff < 0 ? -1 : 1;
				while (x != endPoint.X || y != endPoint.Y)
				{
					int move = Math.Min(maxMoveDistance, Math.Abs(endPoint.X - x));
					x += move * xDirection;

					move = Math.Min(maxMoveDistance, Math.Abs(endPoint.Y - y));
					y += move * yDirection;


					routeCoordinates.Add(new CoordsPoint(x, y));
					if (x == endPoint.X && y == endPoint.Y)
					{
						break;
					}
				}
			}
			return routeCoordinates;
		}
*/