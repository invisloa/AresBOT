using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel;

namespace AresTrainerV3.MoveModels
{
    public class MoveToPointNew : IMoveToPoint
    {
        IMouseToPosRemapper positionRammapper = FactoryMoveToPoint.CreateNewPosRemapper();
        IRouteCalculator routeCalculator = FactoryMoveToPoint.CreateNewRouteCalculator();
        ICheckRoute obstacleChecker = FactoryMoveToPoint.CreateNewRouteChecker();
        //IDoWhileMoving DoWhileMoving = Factory.


		public void MoveToDestination(CoordsPoint endPosition, List<Obstacle> obstacles)
        {
            {
                //bool isMainRoute = true;
                List<CoordsPoint> routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(endPosition);

                while (routeCoordinates.Count != 0)
                {
                    int moveVectorX = routeCoordinates[0].X - FactoryMoveToPoint.GetCurrentPositionX;
                    int moveVectorY = routeCoordinates[0].Y - FactoryMoveToPoint.GetCurrentPositionY;

                    if (!obstacleChecker.CheckForObstacles(routeCoordinates.GetRange(0, Math.Min(4, routeCoordinates.Count)), obstacles))
                    {
						CoordsPoint MousePositionToMove =  positionRammapper.RemapVectorToMousePos(moveVectorX, moveVectorY);
                        MouseOperations.MoveAndLeftClickOperation(MousePositionToMove.X, MousePositionToMove.Y);

					}
					else
                    {
                        Console.WriteLine("Can't move to: " + routeCoordinates[0].X + "," + routeCoordinates[0].Y + " Need an alternate route");
                        Console.WriteLine("WRITE AN ALTERNATE ROUTE METHOD!!!!!!!!!!!!!!!!!!");
						MoveToDestination(routeCalculator.CalculateAlternateEndPoint(endPosition, obstacleChecker.IntersectedLine), obstacles);
					}

					routeCoordinates = routeCalculator.CalculateMainRouteCoordinates(endPosition);
                }
            }
        }
    }
}
