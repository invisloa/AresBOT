﻿using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MovePositions
{
    public interface IMoveAttackCollect
    {
		public IDoWhileMoving WhatToDoWhileMoving
        {
            get ;
        }

		public bool MoveAttackAndCollect();
    }
}
