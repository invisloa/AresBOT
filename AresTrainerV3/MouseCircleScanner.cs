using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class MouseCircleScanner
    {
        public static Tuple<int, int>[] GenerateCirclePoints(int numberOfCircles, int pointsInACircle, int startingRadius, int radiusIncrementation, int centerX, int centerY)
        {
            double numberOfTupples = 0;
            double pointsToCountTupples = pointsInACircle;
            for (int i = 0; i < numberOfCircles; i++)
            {
                numberOfTupples += pointsToCountTupples;
                pointsToCountTupples = (int)(pointsToCountTupples *1);
            }
            Tuple<int, int>[] tuplePoints = new Tuple<int, int>[(int)numberOfTupples];
            int currentPoint = 0;
            for (int ix = 0; ix < numberOfCircles; ix++)
            {
                double slice = 2 * Math.PI / pointsInACircle;

                for (int i = 0; i < pointsInACircle; i++)
                {
                    double angle = slice * i;
                    int newX = (int)(centerX + startingRadius * Math.Cos(angle));
                    int newY = (int)(centerY + startingRadius * Math.Sin(angle));

                    tuplePoints[currentPoint] = new Tuple<int, int>(newX, newY);
                    currentPoint++;
                }
                pointsInACircle = (int)(pointsInACircle *1);
                startingRadius += radiusIncrementation;


            }
            return tuplePoints;
        }

        public static Tuple<int, int>[] GenerateLinearPoints(int startingX,int startingY, int lengthX, int heightY, int distanceBetweenPoints)
        {
            int numberOfTuples = lengthX * heightY;
            int currentPoint = 0;
            int currentIterationY = startingY;
            Tuple<int, int>[] tuplePoints = new Tuple<int, int>[numberOfTuples];
            for (int i = 0; i < lengthX; i++)
            {
                tuplePoints[currentPoint] = new Tuple<int, int>(startingX, startingY);
                currentPoint++;
                currentIterationY = startingY;
                for (int y = 1; y < heightY; y++)
                {
                    tuplePoints[currentPoint] = new Tuple<int, int>(startingX, currentIterationY + 1);
                    currentPoint++;
                    currentIterationY += distanceBetweenPoints;
                }
                startingX += distanceBetweenPoints;
            }
            return tuplePoints;
        }



        /*        static Tuple<int, int>[] GenerateMultipleCirclePoints(int numberOfCircles, int pointsInACircle, int startingRadius, int centerX, int centerY)
                {
                    Tuple<int, int>[] tuplePoints = new Tuple<int, int>[pointsInACircle * numberOfCircles *2];

                    for (int i = 0; i < numberOfCircles; i++)
                    {
                        tuplePoints = GenerateCirclePoints(pointsInACircle, startingRadius, centerX, centerY);
                        pointsInACircle *= (int)2;
                        startingRadius += 10;
                    }
                    ret

                }
        */





        /*        

                public static void DrawMultipleCircles(int numberOfCircles, int howManyPoints, int radius, int ceterX, int CenterY,int mobSelected)
                {
                    for (int i = 0; i < numberOfCircles; i++)
                    {
                        if (mobSelected == 0)
                        {
                            DrawCirclePoints(howManyPoints, radius, ceterX, CenterY,mobSelected);
                            howManyPoints *= (int)1.5;
                            radius += 10;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
        */
    }
}
