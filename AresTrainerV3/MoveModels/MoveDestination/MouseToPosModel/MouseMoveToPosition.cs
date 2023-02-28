using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel
{
	public class MouseMoveToPosition : IMouseMoveToPosition
	{
		IMouseToPosRemapper posRemapper = FactoryMoveToPoint.CreateNewPosRemapper();

		public void MouseMove(int moveVectorX, int moveVectorY)
		{
			CoordsPoint MousePositionToMove = posRemapper.RemapVectorToMousePos(moveVectorX, moveVectorY);
			MouseOperations.MoveAndLeftClickOperation(MousePositionToMove.X, MousePositionToMove.Y);
		}
	}
}
