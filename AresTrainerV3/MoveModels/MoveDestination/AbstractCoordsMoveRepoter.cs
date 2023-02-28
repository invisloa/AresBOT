using AresTrainerV3.Unstuck;
using System.Collections.ObjectModel;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public abstract class AbstractCoordsMoveRepoter
	{
		protected int currentPointToMove = 0;
		protected IOneMoveToDestinationPosition moveToNextPos = Factory.CreateOneMoveToDestinationPosition;
		protected abstract IUnstuckerMover moveUnstucker { get; }
		protected abstract ReadOnlyCollection<CoordsPoint> moveDestinationsList { get; set; }
	}
}