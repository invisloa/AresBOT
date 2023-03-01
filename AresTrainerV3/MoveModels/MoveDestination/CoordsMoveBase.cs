using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.Unstuck;
using System.Collections.ObjectModel;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class CoordsMoveBase : AbstractCoordsMoveRepoter, IMoveToPoint
	{

		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		/// <summary>
		/// TO DO MOVE USTACKER
		/// </summary>
		public CoordsMoveBase()
		{
			moveDestinationsList = DestinationsCoordinator.NoMoveCoords;
		}
		protected override IUnstuckerMover moveUnstucker { get => Factory.CreateUstuckerExp(); }
		protected override ReadOnlyCollection<CoordsPoint> moveDestinationsList { get; set; }

		public CoordsMoveBase(ReadOnlyCollection<CoordsPoint> movePositions)
		{
			moveDestinationsList = movePositions;
		}
		public virtual bool MoveToDestination()
		{
			ProgramHandle.SetCameraForExpBot();
			while (currentPointToMove < moveDestinationsList.Count)
			{
				if (moveToNextPos.OneMoveToDestination(moveDestinationsList[currentPointToMove]))
				{
					currentPointToMove++;
				}
			}
			return true;
		}
	}
}