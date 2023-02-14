using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel
{
	public class MouseToPosRemapper : IMouseToPosRemapper
	{
		CoordsPoint CharCenterPoint = new CoordsPoint(960, 522);
		// centerY +315 = currentPosY -12
		// centerY -315 = currentPosY +12
		// centerX -315 = currentPosX -12
		// centerX +315 = currentPosX +12
		public CoordsPoint RemapVectorToMousePos(int x, int y)
		{
			CoordsPoint MousePosition = CharCenterPoint;
			if (x == 1) { MousePosition.X += x * 27; }
			else { MousePosition.X += x * 25; }
			if (y == 1) { MousePosition.X += y * 27; }
			else { MousePosition.Y += -(y * 25); }
			return MousePosition;
		}


	}
}
