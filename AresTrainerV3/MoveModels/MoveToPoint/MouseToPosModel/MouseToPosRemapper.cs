using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel
{
	public class MouseToPosRemapper : IMouseToPosRemapper
	{
		CoordsPoint CharCenterPoint = new CoordsPoint(960, 520);
		// centerY +315 = currentPosY -12
		// centerY -315 = currentPosY +12
		// centerX -315 = currentPosX -12
		// centerX +315 = currentPosX +12
		public CoordsPoint RemapVectorToMousePos(int x, int y)
		{
			CoordsPoint MousePosition = CharCenterPoint;
			MousePosition.X += x * 26;
			MousePosition.Y += y * 26;
			return MousePosition;
		}


	}
}
