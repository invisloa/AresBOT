using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
	public class CollectAntibug : IUnbugWhenCollecting
	{
		public int currentPositionX
		{
			get
			{
				return ProgramHandle.GetPositionX;
			}
		}
		public int currentPositionY
		{
			get
			{
				return ProgramHandle.GetPositionY;
			}
		}

		public void UnbugWhenCollecting(int beforeClickPosX)
		{
			if (beforeClickPosX == currentPositionX) 
			{
				MouseOperations.MoveAndLeftClickOperation(900, 600);// just some random position
			}
		}
	}
}
