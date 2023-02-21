namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker
{
	public interface IObstacleRangeChecker
	{
		public Obstacle ObstacleIntersected
		{
			get;
			set;
		}

		bool CheckForObstacles(List<CoordsPoint> routeCoordinates);
	}
}