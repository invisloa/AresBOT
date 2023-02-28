namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.LineChecker
{
    public interface ICheckRoute
    {
        public Line IntersectedLine
        {
            get;
        }
        bool CheckForObstacles(List<CoordsPoint> routeCoordinates, List<Obstacle> obstacles);
    }
}
