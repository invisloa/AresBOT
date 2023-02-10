namespace AresTrainerV3.MoveModels
{
	static class Factory
	{
		static CoordsPoint currentPosition = new CoordsPoint(0,0);
		public static CoordsPoint getCurrentPosition
		{
			get
			{
				return currentPosition;
			}

			set
			{
				currentPosition = value;
			}
		}
		public static ICheckRoute CreateRouteChecker()
		{
			return new ObstacleLineChecker();
		}
		public static IRouteCalculator CreateRouteCalculator()
		{
			return new RouteCalculator();
		}
		public static IMoveToPoint CreateNewMoveToPoint()
		{
			return new MoveToPointNew();
		}

		
	}
}
