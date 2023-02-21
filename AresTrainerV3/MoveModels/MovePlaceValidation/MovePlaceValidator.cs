using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (ProgramHandle.GetCurrentMap == moveOnlyOnMapX)
            {
                return true;
            }
            else
            {
                Thread.Sleep(1000000);
                return false;
            }
        }

    }
}
