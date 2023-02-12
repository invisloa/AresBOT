using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;

namespace AresTrainerV3.MoveModels
{
	static class FactoryMoveToPoint
	{
		public static CoordsPoint GetCurrentCoordPointXY
		{
			get
			{
				int x = ProgramHandle.GetCurrentPositionXMap;
				int y = ProgramHandle.GetCurrentPositionYMap;
				return new CoordsPoint(x, y);
			}
		}
		public static IMouseToPosRemapper CreateNewPosRemapper()
		{
			return new MouseToPosRemapper();
		}
		public static IRouteCalculator CreateNewRouteCalculator()
		{
			return new RouteCalculator();
		}
		public static ICheckRoute CreateNewRouteChecker()
		{
			return new ObstacleLineChecker();
		}
		public static int GetCurrentPositionX
		{
			get
			{
				return ProgramHandle.GetCurrentPositionXMap;
			}
		}
		public static int GetCurrentPositionY
		{
			get
			{
				return ProgramHandle.GetCurrentPositionYMap;
			}
		}
		static CoordsPoint currentPositionTests = new CoordsPoint(0,0);
		public static CoordsPoint getCurrentPosition
		{
			get
			{
				return currentPositionTests;
			}

			set
			{
				currentPositionTests = value;
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
