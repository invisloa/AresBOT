using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.RouteCalculations.AlternateRoute
{
	internal class FindObstacleCorner
	{

		const int obstacleOffset = 5;

		public static CoordsPoint FindProperCorner(Obstacle obstacle, CoordsPoint endPointOrigin)
		{
			CoordsPoint topLeft = new CoordsPoint(obstacle.TopLeft.X,obstacle.TopLeft.Y,2);
			CoordsPoint bottomRight = new CoordsPoint(obstacle.BottomRight.X, obstacle.BottomRight.Y,2);
			CoordsPoint topRight = new CoordsPoint(bottomRight.X, topLeft.Y,2);
			CoordsPoint bottomLeft = new CoordsPoint(topLeft.X, bottomRight.Y,2);
			CoordsPoint currentPosition = FactoryMoveToPoint.GetCurrentCoordPointXY;

			int xDiff = endPointOrigin.X - currentPosition.X;
			int yDiff = endPointOrigin.Y - currentPosition.Y;
			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			if (xDirection == 1 && yDirection == 1)
			{
				// go up and right
				if (currentPosition.Y < bottomRight.Y)
				{
					if (currentPosition.X < bottomLeft.X)
					{
						topLeft.Y += obstacleOffset;
						return topLeft;
					}
					else
					{
						bottomRight.X += obstacleOffset;
						return bottomRight;
					}
				}
				else
				{
					topLeft.Y += obstacleOffset;
					return topLeft;
				}
			}
			else if (xDirection == -1 && yDirection == 1)
			{
				// go up and left
				if (currentPosition.Y < bottomLeft.Y)
				{
					if (currentPosition.X > bottomRight.X)
					{
						topRight.Y += obstacleOffset;
						return topRight;
					}
					else
					{
						bottomLeft.X -= obstacleOffset;
						return bottomLeft;
					}
				}
				else
				{
					topRight.Y += obstacleOffset;
					return topRight;
				}
			}

			else if (xDirection == 1 && yDirection == -1)
			{
				// go down and right
				if (currentPosition.Y > topLeft.Y)
				{
					if (currentPosition.X < topLeft.X)
					{
						bottomLeft.Y -= obstacleOffset;
						return bottomLeft;
					}
					else
					{
						topRight.X += obstacleOffset;
						return topRight;
					}
				}
				else
				{
					bottomLeft.Y -= obstacleOffset;
					return bottomLeft;
				}

			}
			else
			{
				// go down and left
				if (currentPosition.Y > topRight.Y)
				{
					if (currentPosition.X > topRight.X)
					{
						bottomRight.Y -= obstacleOffset;
						return bottomRight;
					}
					else
					{
						topLeft.X -= obstacleOffset;
						return topLeft;
					}
				}
				else
				{
					bottomRight.Y -= obstacleOffset;
					return bottomRight;
				}
			}
		}
	}
}
