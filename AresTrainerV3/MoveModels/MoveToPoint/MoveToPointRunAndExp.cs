using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint
{
	public class MoveToPointRunAndExp : ExpBotManagerAbstract
	{
		MoveToPointPosition moveToPos = new MoveToPointPosition();
		public override IDoWhileMoving WhatToDoWhileMoving { get =>Factory.CreateIDoWhileMovingAttack(); }

		public override bool MoveAttackAndCollect()
		{
			throw new NotImplementedException();
		}

		public override void RunAndExp()
		{
			throw new NotImplementedException();
		}
	}
}
