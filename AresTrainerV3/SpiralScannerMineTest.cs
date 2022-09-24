/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    internal class SpiralScannerMineTest
    {
        public IList<int> SpiralOrder()
        {
            int top = 500;
            int bottom = 540;
            int left = 940;
            int right = 980;
            int[,] matrix = new int[top, bottom];
            IList<int> list = new List<int>();
            int direction = 0;

            while (right >= left && bottom >= top)
            {
                if (direction == 0) // top
                {
                    for (int i = left; i <= right; i++) list.Add(matrix[top, i]);
                    top++;
                }
                else if (direction == 1) // right
                {
                    for (int i = top; i <= bottom; i++) list.Add(matrix[i, right]);
                    right--;
                }
                else if (direction == 2) // bottom
                {
                    for (int i = right; i >= left; i--) list.Add(matrix[bottom, i]);
                    bottom--;
                }
                else if (direction == 3) // left
                {
                    for (int i = bottom; i >= top; i--) list.Add(matrix[i, left]);
                    left++;
                }

                direction = (direction + 1) % 4;
            }

            return list;
        }








            for (int x = 527; x< 1360; x++)
            {

                for (int y = 237; y< 835; y++)
                {


                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x< 938 || x> 976 || y< 502 || y> 540) && desiredPixelColor == currentPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        GC.Collect();
                    }
}
            }
            GC.Collect();




    }
}
*/