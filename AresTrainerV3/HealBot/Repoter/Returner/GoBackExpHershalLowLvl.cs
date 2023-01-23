using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
	internal class GoBackExpHershalLowLvl : GoBackExpAbstract
	{
		public override void GoBackExp()
		{
			ProgramHandle.SetCameraForExpBot();
			ProgramHandle.TeleportToPositionTuple(TeleportValues.SpotExpHershalLowLvl);
			ProgramHandle.SetCameraForExpBot();
		}
	}
}
