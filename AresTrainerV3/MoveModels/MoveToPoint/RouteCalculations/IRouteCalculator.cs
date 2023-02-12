namespace AresTrainerV3.MoveModels
{
	public interface IRouteCalculator
	{
		List<CoordsPoint> CalculateMainRouteCoordinates(CoordsPoint end);
		public CoordsPoint CalculateAlternateEndPoint(CoordsPoint endPointOrigin, Line intersectedLine);

	}
}
