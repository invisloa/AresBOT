namespace AresTrainerV3.MoveModels
{
    internal class MoveToPointNew : IMoveToPoint
    {
        static IRouteCalculator routeCalculator = new RouteCalculator();
        static ICheckRoute obstacleChecker = new ObstacleLineChecker();

        public void MoveToDestination(CoordsPoint endPosition, List<Obstacle> obstacles)
        {
            {
                bool isMainRoute = true;
                List<CoordsPoint> routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(Factory.getCurrentPosition, endPosition);

                while (routeCoordinates.Count != 0)
                {
                    int x = routeCoordinates[0].X;
                    int y = routeCoordinates[0].Y;

                    if (!obstacleChecker.CheckForObstacles(routeCoordinates.GetRange(0, Math.Min(4, routeCoordinates.Count)), obstacles))
                    {
                        Console.WriteLine("Moved to: " + x + "," + y);
						Factory.getCurrentPosition = new CoordsPoint(x, y); //////////////////////////////////////////////////////////////////// TO CHANGE GET CURRENT POSITION!!!!!!!!!!!!!!!

					}
					else
                    {
                        Console.WriteLine("Can't move to: " + x + "," + y + " Need an alternate route");
                        Console.WriteLine("WRITE AN ALTERNATE ROUTE METHOD!!!!!!!!!!!!!!!!!!");
						MoveToDestination(routeCalculator.CalculateAlternateEndPoint(Factory.getCurrentPosition,endPosition, obstacleChecker.IntersectedLine), obstacles);
					}

					routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(Factory.getCurrentPosition, endPosition);
                }
            }
        }
    }
}
