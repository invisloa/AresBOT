using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.LineChecker;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute;

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
		public static IMouseMoveToPosition CreateMouseMoveToPosition()
		{
			return new MouseMoveToPosition();
		}
		public static IRouteChunker CreateRouteChunker()
		{
			return new RouteChunker();
		}
		public static IMouseToPosRemapper CreateNewPosRemapper()
		{
			return new MouseToPosRemapper();
		}
		public static IRouteCalculator CreateNewRouteCalculator()
		{
			return new RouteCalculator();
		}
		public static IObstacleChecker CreateNewObstacleChecker()
		{
			return new ObstacleChecker();

		}
		public static IObstacleRangeChecker CreateNewRouteChecker()
		{
			return new ObstacleRangeChecker();

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
		public static int MaxMoveDistance = 4;

		
	}
}
