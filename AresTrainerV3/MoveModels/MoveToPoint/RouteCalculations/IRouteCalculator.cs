namespace AresTrainerV3.MoveModels
{
	public interface IRouteCalculator
	{
		List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint start, CoordsPoint end);
		public CoordsPoint CalculateAlternateEndPoint(CoordsPoint startPoint, CoordsPoint endPointOrigin, Line intersectedLine);

	}
}
