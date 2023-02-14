using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.RangeChecker
{
    public interface IObstacleChecker
    {
        public Obstacle ObstacleIntersected
        {
            get;
        }
        bool CheckForObstacles(CoordsPoint routeCoordinate, List<Obstacle> obstacles);
    }
}
