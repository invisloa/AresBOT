using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public interface IMoveToPositon
    {
        public bool MoveAttackCollect( DirectionsEnum goDierction , int maxLimitOrLeft, int sideDownLeftOrUp, int  sideUpRightOrRight, int mainDirOrDown);
    }
}
