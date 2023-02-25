using AresTrainerV3.MoveModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.Unstuck
{
	public class UnstuckerMover : IUnstuckerMover
	{
		int minMoveForUnstuck = 4;
		int stuckedMovesLimit = 5;
		int howManyTimesStucked = 0;

		CoordsPoint currentPosition { get => FactoryMoveToPoint.GetCurrentCoordPointXY; }
		CoordsPoint firstPosition = FactoryMoveToPoint.GetCurrentCoordPointXY;

		bool CheckIfMoved()
		{
			int movedByValue = Math.Abs(currentPosition.X - firstPosition.X) + Math.Abs(currentPosition.Y - firstPosition.Y);
			return movedByValue >= minMoveForUnstuck;
		}

		public void CheckIfMoveIsStucked()
		{
			Debug.WriteLine($"{howManyTimesStucked} !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! {firstPosition}");
			if (CheckIfMoved())
			{
				firstPosition = FactoryMoveToPoint.GetCurrentCoordPointXY;
				howManyTimesStucked = 0;
			}
			else
			{
				howManyTimesStucked++;
				if (howManyTimesStucked == stuckedMovesLimit)
				{
					Factory.HealbotToRun.RepotAndStartExpBot();
				}
			}
		}
	}
}
