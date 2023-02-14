namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute
{
    public class RouteCalculator : IRouteCalculator
    {
        // TODO
        // IS IN OBSTACLE METHOD TO GET OUT OF OBSTACLE WHEN ALREADY IN IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        int obstacleMoveFactor = 4;
        bool isLineOnXAxis = false;
        int maxMoveDistance = 12;
        public List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint endPoint)
        {
            List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
            int x = FactoryMoveToPoint.GetCurrentPositionX;
            int y = FactoryMoveToPoint.GetCurrentPositionY;

            int xDiff = endPoint.X - x;
            int yDiff = endPoint.Y - y;

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
            return routeCoordinates;
        }

        public List<CoordsPoint> CalculateAlternateRouteCoordinates(CoordsPoint startPoint, Line intersectedLine)
        {
            bool isLineOnXAxis = false;
            List<CoordsPoint> routeCoordinates = new List<CoordsPoint>();
            if (intersectedLine.P2.X - intersectedLine.P1.X != 0)
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
            int xDirection = xDiff < 0 ? -1 : 1;
            int yDirection = yDiff < 0 ? -1 : 1;

            int x = startPoint.X;
            int y = startPoint.Y;

            //int moveNumber = 1;
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
            return routeCoordinates;
        }
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