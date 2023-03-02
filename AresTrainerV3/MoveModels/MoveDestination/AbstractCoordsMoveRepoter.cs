using AresTrainerV3.Unstuck;
using System.Collections.ObjectModel;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public abstract class AbstractCoordsMoveRepoter
	{
		protected int currentPointToMove = 0;
		protected abstract IUnstuckerMover moveUnstucker { get; }
		protected IOneMoveToDestinationPosition moveToNextPos => Factory.CreateOneMoveToDestinationPosition;

		protected abstract ReadOnlyCollection<CoordsPoint> moveDestinationsList { get; set; }
	}
}