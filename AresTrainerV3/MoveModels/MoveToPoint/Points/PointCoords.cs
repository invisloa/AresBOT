namespace AresTrainerV3.MoveModels
{
	public struct CoordsPoint : ICurrentPosition
	{
		public int X = 0;
		public int Y = 0;
		public CoordsPoint(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public CoordsPoint CurrentPosition { get { return new CoordsPoint(X, Y); } }
	}
	public class Line
	{
		public CoordsPoint P1 { get; set; }
		public CoordsPoint P2 { get; set; }

		public Line(CoordsPoint p1, CoordsPoint p2)
		{
			P1 = p1;
			P2 = p2;
		}

	}
	public struct Obstacle
	{
		public Obstacle(CoordsPoint topLeft, CoordsPoint bottomRight)
		{
			TopLeft = topLeft;
			BottomRight = bottomRight;
		}
		public CoordsPoint TopLeft;
		public CoordsPoint BottomRight;
	}

}
