using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations;

namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker
{
	public class ObstacleRangeChecker : IObstacleRangeChecker
	{
		private readonly IObstacleChecker _obstacleChecker = FactoryMoveToPoint.CreateNewObstacleChecker();

		public Obstacle ObstacleIntersected { get; set; }

		public bool CheckForObstacles(List<CoordsPoint> routeCoordinates, List<Obstacle> obstacles)
		{
			int moveNumber = 0;
			CoordsPoint abstractCurrentPosPoint = FactoryMoveToPoint.GetCurrentCoordPointXY;

			while (moveNumber < routeCoordinates.Count)
			{
				if (_obstacleChecker.CheckForObstacles(routeCoordinates[moveNumber], obstacles))
				{
					ObstacleIntersected = _obstacleChecker.ObstacleIntersected;
					return true;
				}
				abstractCurrentPosPoint = routeCoordinates[moveNumber];
				moveNumber++;
			}
			return false;
		}
	}

}