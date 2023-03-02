using AresTrainerV3.ExpBotManager;
using AresTrainerV3.MoveModels.MovePlaceValidation;
using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.AlternateRoute;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute;
using System.Diagnostics;

namespace AresTrainerV3.MoveModels
{
	public class OneMoveToDestinationPosition : IOneMoveToDestinationPosition
	{
		IMouseMoveToPosition mouseClickerToMoveToPosition = FactoryMoveToPoint.CreateMouseMoveToPosition();
		IRouteCalculator routeCalculator = FactoryMoveToPoint.CreateNewRouteCalculator();
		IObstacleRangeChecker obstacleRangeChecker = FactoryMoveToPoint.CreateNewRouteChecker();
		IMovePlaceValidator validateMap;
		int howManyMovesForwardToCheck = 4;
		List<CoordsPoint> routeCoordinates;
		int MoveVectorX;
		int MoveVectorY;
		public OneMoveToDestinationPosition()
		{
			validateMap = FactoryMoveToPoint.CreateMovePlaceValidator();
		}
		public bool OneMoveToDestination(CoordsPoint endPosition)
		{
			if (validateMap.ValidateMap())
			{
				setRouteCalcValues(endPosition);

				if (Math.Abs(MoveVectorX) <= endPosition.MoveAccuracy && Math.Abs(MoveVectorY) <= endPosition.MoveAccuracy)
				{
					return true;
				}

				if (!obstacleRangeChecker.CheckForObstacles(routeCoordinates.GetRange(0, Math.Min(howManyMovesForwardToCheck, routeCoordinates.Count))))
				{
						mouseClickerToMoveToPosition.MouseMove(MoveVectorX, MoveVectorY);
				}
				else
				{
					Debug.WriteLine("Can't move to: " + routeCoordinates[0].X + "," + routeCoordinates[0].Y + " Need an alternate route");
					moveToEndPoint(FindObstacleCorner.FindProperCorner(obstacleRangeChecker.ObstacleIntersected, endPosition));  // TO SOLID
				}
			}
			return false;
		}
		void moveToEndPoint(CoordsPoint endPosition)
		{
			setRouteCalcValues(endPosition);
			while (!OneMoveToDestination(endPosition)) ;
		}
		void setRouteCalcValues(CoordsPoint endPosition)
		{
			routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(endPosition);
			MoveVectorX = routeCoordinates[0].X - FactoryMoveToPoint.GetCurrentPositionX;
			MoveVectorY = routeCoordinates[0].Y - FactoryMoveToPoint.GetCurrentPositionY;
		}
	}
}

