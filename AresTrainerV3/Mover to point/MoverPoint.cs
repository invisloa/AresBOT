using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Mover_to_point
{
	public class MoverPoint
	{

		/// if you meet obstacle in next five moves make an alternate route to go around the obstacle and call yourself with a new direction point 









/*		    {
        static void Main(string[] args)
		{
			int startX = 0;
			int startY = 0;
			int endX = 10;
			int endY = 20;

			int moves = CalculateRoute(startX, startY, endX, endY);
			Console.WriteLine("The number of moves needed is: " + moves);
		}
*/
		static int CalculateRoute(int startX, int startY, int endX, int endY)
		{
			int xDiff = Math.Abs(endX - startX);
			int yDiff = Math.Abs(endY - startY);

			int moves = (xDiff + yDiff) / 12;
			int remainder = (xDiff + yDiff) % 12;

			if (remainder > 0 && remainder <= 4)
			{
				moves += 1;
			}
			else if (remainder > 4)
			{
				moves += 2;
			}

			return moves;
		}
	}
}
