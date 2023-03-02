using AresTrainerV3.MoveModels.MoveToPoint.DestinationsCoords;
using AresTrainerV3.Unstuck;
using System.Collections.ObjectModel;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class CoordsMoveOnly : AbstractCoordsMoveRepoter, IMoveToPoint
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
		public CoordsMoveOnly()
		{
			moveDestinationsList = DestinationsCoordinator.NoMoveCoords;
		}
		protected override IUnstuckerMover moveUnstucker { get => Factory.CreateUstuckerExp(); }
		protected override ReadOnlyCollection<CoordsPoint> moveDestinationsList { get; set; }

		public CoordsMoveOnly(ReadOnlyCollection<CoordsPoint> movePositions)
		{
			moveDestinationsList = movePositions;
		}
		public virtual bool MoveToDestination()
		{
			ProgramHandle.SetCameraForExpBot();
			int currentMap = ProgramHandle.GetCurrentMap;
			while (currentPointToMove < moveDestinationsList.Count )
			{
				if (currentMap == ProgramHandle.GetCurrentMap)
				{

					if (moveToNextPos.OneMoveToDestination(moveDestinationsList[currentPointToMove]))
					{
						currentPointToMove++;
					}
				}
				else
				{
					Thread.Sleep(5000); break;
				}
			}
			return true;
		}
	}
}