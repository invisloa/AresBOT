﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    internal interface IMoveToPosition
    {
        bool MoveToPosition(bool isMoveOnXAxis, bool isPosIcreasing, int directionLimit, int sideUpOrRightLimit, int sideDownOrLeftLimit);
    }
}
