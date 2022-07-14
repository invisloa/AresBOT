using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class MouseCircleScanner
    {
        static Tuple<int, int>[] GenerateCirclePoints(int points, int radius, int centerX, int centerY)
        {
            Tuple<int, int>[] tuplePoints = new Tuple<int, int>[points];
            int currentPoint = 0;
            double slice = 2 * Math.PI / points;
            for (int i = 0; i < points; i++)
            {
                double angle = slice * i;
                int newX = (int)(centerX + radius * Math.Cos(angle));
                int newY = (int)(centerY + radius * Math.Sin(angle));

                tuplePoints[currentPoint] = new Tuple<int, int>(newX, newY);
                currentPoint++;
            }
            return tuplePoints;
        }

        static void DrawCirclePoints(int points, int radius, int centerX, int centerY)
        {
            Tuple<int, int>[] searchPoints = GenerateCirclePoints(points, radius, centerX, centerY);
            foreach (Tuple<int, int> point in searchPoints)
            {
                MouseOperations.SetCursorPosition(point.Item1, point.Item2);
                Thread.Sleep(5);
            }
        }

        public static void DrawMultipleCircles(int numberOfCircles, int howManyPoints, int radius, int ceterX, int CenterY)
        {
            int currentCircle = 1;
            for (int i = 0; i < numberOfCircles; i++)
            {
                DrawCirclePoints(howManyPoints, radius, ceterX, CenterY);
                currentCircle++;
                howManyPoints *= (int)1.5;
                radius += 10;
            }

        }
    }
}
