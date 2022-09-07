using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal interface IMoveToPositon
    {
        public bool MoveToPosition( DirectionsEnum goDierction , int directionLimit, int sideUpOrRightLimit, int sideDownOrLeftLimit);
    }
}
