using AresTrainerV3.ExpBotManager;
using System.Diagnostics;

namespace AresTrainerV3.MoveModels.MovePlaceValidation
{
	internal class MovePlaceValidator : IMovePlaceValidator
	{
		private int moveOnlyOnMapX = 0;
		public MovePlaceValidator(int moveOnlyOnThisMap)
		{
			moveOnlyOnMapX = moveOnlyOnThisMap;
		}
		public bool ValidateMap()
		{
			if ( ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
			{
				return true;
			}
			else
			{
				Debug.WriteLine("ExpBot or Map OFFFFFF");
				return false;
			}
		}

	}
}
