using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.PositionCalculations
{
	internal class PositionRemapper
	{
		void calculatePosition()
		{
			int currentX = ProgramHandle.GetPositionX;
			int currentY = ProgramHandle.GetPositionY;

			currentX -= 983080867;
			currentX /= 34463;

			currentY -= 983080867;
			currentY /= 34463;



			CoordsPoint revampedPosition = new CoordsPoint();






		}


		/*			int minXValue = 983080867;

							zagroda	1117126656
						   rog mapy 1148143385
		zagroda - min 134045789
		rog - min	  165062518

		zagroda x i rog x (-min obydwa) = 31016729

		jeden punkt około 34463 lub 172484
		

		31 000 = 1 punkt
				int currentx = 1123017018;
				int twoSquaresx = 1123540726;

				int plus1Move = 500000;


		 *	
		 *	
		 *	
		 *	CoordsPoint MousePositionPoint = new CoordsPoint(0, 0);

				CoordsPoint characterCentrePoint = new CoordsPoint(960, 525);

		*/
	}
}
