namespace AresTrainerV3.MoveModels
{
	public interface ICheckRoute
	{
		public Line IntersectedLine
		{
			get;
		}
		bool CheckForObstacles(List<CoordsPoint> routeCoordinates, List<Obstacle> obstacles);
	}
}
