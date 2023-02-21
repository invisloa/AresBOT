﻿using AresTrainerV3.MoveModels.MovePlaceValidation;
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
		public static int MaxMoveDistance = 4;
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

		public static CoordsPoint GetCurrentCoordPointXY
		{
			get
			{
				int x = ProgramHandle.GetCurrentPositionXMap;
				int y = ProgramHandle.GetCurrentPositionYMap;
				return new CoordsPoint(x, y);
			}
		}
		public static IMovePlaceValidator CreateMovePlaceValidator() => new MovePlaceValidator(1);
		public static IMouseMoveToPosition CreateMouseMoveToPosition() => new MouseMoveToPosition();
		public static IRouteChunker CreateRouteChunker() => new RouteChunker();
		public static IMouseToPosRemapper CreateNewPosRemapper() => new MouseToPosRemapper();
		public static IRouteCalculator CreateNewRouteCalculator() => new RouteCalculator();
		public static IObstacleChecker CreateNewObstacleChecker() => new ObstacleChecker();
		public static IObstacleRangeChecker CreateNewRouteChecker()=> new ObstacleRangeChecker();
		public static IMoveToPoint CreateNewMoveToPoint()=> new MoveToPointNew();

		
	}
}
