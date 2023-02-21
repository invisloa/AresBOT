using AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker
{
    public class ObstacleChecker : IObstacleChecker
    {

        Obstacle _obstacleIntersected = new Obstacle();
        public Obstacle ObstacleIntersected { get => _obstacleIntersected; }
        List<Obstacle> obstaclesList = FactoryMoveToPoint.AssignMapObstacles();
		private IRouteChunker _routeChunker
        {
            get
            {
                return FactoryMoveToPoint.CreateRouteChunker();
            }
        }
        public bool CheckForObstacles(CoordsPoint routeCoordinate)
        {
            List<CoordsPoint> chunkedMove = _routeChunker.ChunkRouteCoordinates(routeCoordinate);
            foreach (Obstacle obstacle in obstaclesList)
            {
                if (IsMovePointInObstacle(chunkedMove, obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsMovePointInObstacle(List<CoordsPoint> chunkedMove, Obstacle obstacle)
        {
            foreach (CoordsPoint point in chunkedMove)
            {
                if (point.X > obstacle.TopLeft.X && point.X < obstacle.BottomRight.X &&
                point.Y < obstacle.TopLeft.Y && point.Y > obstacle.BottomRight.Y)
                {
                    _obstacleIntersected = obstacle;
                    return true;
                }
            }
            return false;
        }
    }


}
