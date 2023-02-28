using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.MoveModels.MovePlaceValidation;
using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.LineChecker;
using AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.AlternateRoute;
using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute;
using System.Diagnostics;

namespace AresTrainerV3.MoveModels
{
    public class OneMoveToDestinationPosition : IOneMoveToDestinationPosition
    {
        IMouseMoveToPosition MoveToPosition = FactoryMoveToPoint.CreateMouseMoveToPosition();
        IRouteCalculator routeCalculator = FactoryMoveToPoint.CreateNewRouteCalculator();
        IObstacleRangeChecker obstacleRangeChecker = FactoryMoveToPoint.CreateNewRouteChecker();
        IMovePlaceValidator validateMap = FactoryMoveToPoint.CreateMovePlaceValidator();
        int howManyMovesForwardToCheck = 4;
		public bool OneMoveToDestination(CoordsPoint endPosition)
        {
            List<CoordsPoint> routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(endPosition);
                if (validateMap.ValidateMap())
                {
                    int moveVectorX = routeCoordinates[0].X - FactoryMoveToPoint.GetCurrentPositionX;
                    int moveVectorY = routeCoordinates[0].Y - FactoryMoveToPoint.GetCurrentPositionY;
                    if (Math.Abs(moveVectorX) <= endPosition.MoveAccuracy && Math.Abs(moveVectorY) <= endPosition.MoveAccuracy)
                    {
                        return true;
                    }

                    if (!obstacleRangeChecker.CheckForObstacles(routeCoordinates.GetRange(0, Math.Min(howManyMovesForwardToCheck, routeCoordinates.Count))))
                    {
                        MoveToPosition.MouseMove(moveVectorX, moveVectorY);
                    }
                    else
                    {
                        Debug.WriteLine("Can't move to: " + routeCoordinates[0].X + "," + routeCoordinates[0].Y + " Need an alternate route");
                        OneMoveToDestination(FindObstacleCorner.FindProperCorner(obstacleRangeChecker.ObstacleIntersected, endPosition));
                    }
                }
            return false;
        }

	}
}

