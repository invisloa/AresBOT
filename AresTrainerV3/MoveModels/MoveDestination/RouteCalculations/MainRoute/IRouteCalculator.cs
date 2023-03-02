namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.MainRoute
{
    public interface IRouteCalculator
    {
        List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint end);
        public CoordsPoint CalculateAlternateLineEndPoint(CoordsPoint endPointOrigin, Line intersectedLine);

    }
}
