namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.LineChecker
{

    public class ObstacleLineChecker : ICheckRoute
    {
        int howManyMovesForwardToCheck = 3;
        public Line colissionLine = new Line(new CoordsPoint(0, 0), new CoordsPoint(0, 0));

        ICurrentPosition currentPositionInterface = FactoryMoveToPoint.GetCurrentCoordPointXY;

        public Line IntersectedLine { get => colissionLine; }

        public bool IntersectsWith(CoordsPoint startPoint, CoordsPoint destinationPoint, Obstacle obstacle)
        {
            colissionLine = new Line(new CoordsPoint(0, 0), new CoordsPoint(0, 0));
            List<Line> lines = new List<Line>()
            {
                new Line(new CoordsPoint(obstacle.TopLeft.X, obstacle.TopLeft.Y), new CoordsPoint(obstacle.BottomRight.X, obstacle.TopLeft.Y)),
                new Line(new CoordsPoint(obstacle.BottomRight.X, obstacle.TopLeft.Y), new CoordsPoint(obstacle.BottomRight.X, obstacle.BottomRight.Y)),
                new Line(new CoordsPoint(obstacle.BottomRight.X, obstacle.BottomRight.Y), new CoordsPoint(obstacle.TopLeft.X, obstacle.BottomRight.Y)),
                new Line(new CoordsPoint(obstacle.TopLeft.X, obstacle.BottomRight.Y), new CoordsPoint(obstacle.TopLeft.X, obstacle.TopLeft.Y))
            };
            Line moveLine = new Line(startPoint, destinationPoint);

            foreach (var obstacleLine in lines)
            {
                int denominator = (obstacleLine.P2.Y - obstacleLine.P1.Y) * (moveLine.P2.X - moveLine.P1.X) - (obstacleLine.P2.X - obstacleLine.P1.X) * (moveLine.P2.Y - moveLine.P1.Y);
                int numerator1 = (obstacleLine.P2.X - obstacleLine.P1.X) * (moveLine.P1.Y - obstacleLine.P1.Y) - (obstacleLine.P2.Y - obstacleLine.P1.Y) * (moveLine.P1.X - obstacleLine.P1.X);
                int numerator2 = (moveLine.P2.X - moveLine.P1.X) * (moveLine.P1.Y - obstacleLine.P1.Y) - (moveLine.P2.Y - moveLine.P1.Y) * (moveLine.P1.X - obstacleLine.P1.X);

                // If the lines are coincident, there is no intersection
                if (denominator == 0)
                {
                    continue;
                }

                double r = (double)numerator1 / denominator;
                double s = (double)numerator2 / denominator;

                if (r >= 0 && r <= 1 && s >= 0 && s <= 1)
                {
                    colissionLine = obstacleLine;
                    return true;
                }
            }
            return false;
        }
        public bool IsObstacleInOneMove(CoordsPoint start, CoordsPoint end, List<Obstacle> obstacles)
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (IntersectsWith(start, end, obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckForObstacles(List<CoordsPoint> routeCoordinates, List<Obstacle> obstacles)
        {
            {
                int moveNumber = 0;
                CoordsPoint abstractCurrentPosPoint = FactoryMoveToPoint.GetCurrentCoordPointXY;
                while (moveNumber < routeCoordinates.Count && moveNumber <= howManyMovesForwardToCheck)
                {
                    if (IsObstacleInOneMove(abstractCurrentPosPoint, routeCoordinates[moveNumber], obstacles))
                    {
                        return true;
                    }
                    abstractCurrentPosPoint = routeCoordinates[moveNumber];
                    moveNumber++;
                }
                return false;
            }
        }
    }
}
