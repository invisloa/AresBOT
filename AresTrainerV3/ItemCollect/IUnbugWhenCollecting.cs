using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
	public interface IUnbugWhenCollecting
	{
		void UnbugWhenCollecting(int beforeClickPosX);
	}
}
