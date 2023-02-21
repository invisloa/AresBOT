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
			if (x == 1 || x == -1) { MousePosition.X += x * 26; }
			else { MousePosition.X += x * 21; }
			if (y == 1 || y == -1) { MousePosition.X += y * 26; }
			else { MousePosition.Y += -(y * 21); }
			return MousePosition;
		}


	}
}
