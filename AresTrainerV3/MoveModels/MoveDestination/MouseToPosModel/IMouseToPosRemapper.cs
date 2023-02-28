namespace AresTrainerV3.MoveModels.MoveToPoint.MouseToPosModel
{
	public interface IMouseToPosRemapper
	{
		CoordsPoint RemapVectorToMousePos(int x, int y);
	}
}