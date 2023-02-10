namespace AresTrainerV3.MoveModels
{
	internal class CheckIfNotInObstacle
	{
		public bool IsInObstacle(CoordsPoint startPosition, List<Obstacle> obstacles)
		{
			foreach (var obstacle in obstacles)
			{
				if (startPosition.X >= obstacle.TopLeft.X && startPosition.X <= obstacle.BottomRight.X &&
					startPosition.Y >= obstacle.TopLeft.Y && startPosition.Y <= obstacle.BottomRight.Y)
				{
					return true;
				}
			}
			return false;
		}
		public CoordsPoint ClosestObstaclePoint(List<Obstacle> obstacles)
		{
			CoordsPoint closestPoint = new CoordsPoint(0, 0);
			double closestDistance = double.MaxValue;

			foreach (var obstacle in obstacles)
			{
				CoordsPoint topLeft = obstacle.TopLeft;
				CoordsPoint bottomRight = obstacle.BottomRight;
				CoordsPoint[] obstaclePoints = new CoordsPoint[] { topLeft, new CoordsPoint(topLeft.X, bottomRight.Y), bottomRight, new CoordsPoint(bottomRight.X, topLeft.Y) };

				foreach (var obstaclePoint in obstaclePoints)
				{
					double distance = CalculateDistance(Factory.getCurrentPosition, obstaclePoint);
					if (distance < closestDistance)
					{
						closestDistance = distance;
						closestPoint = obstaclePoint;
					}
				}
			}
			return closestPoint;
		}
		private double CalculateDistance(CoordsPoint point1, CoordsPoint point2)
		{
			int deltaX = point2.X - point1.X;
			int deltaY = point2.Y - point1.Y;
			return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
		}
	}
}
