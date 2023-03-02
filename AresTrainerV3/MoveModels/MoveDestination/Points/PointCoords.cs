namespace AresTrainerV3.MoveModels
{
	public struct CoordsPoint
	{
		private int x = 0;
		private int y = 0;
		int moveAccuracy = 5;
		public CoordsPoint(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
		public CoordsPoint(int x, int y, int moveAccuracy)
		{
			this.X = x;
			this.Y = y;
			this.MoveAccuracy = moveAccuracy;
		}
		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }
		public int MoveAccuracy { get => moveAccuracy; set => moveAccuracy = value; }
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
