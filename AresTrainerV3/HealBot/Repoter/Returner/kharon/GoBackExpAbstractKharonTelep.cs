using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
	public abstract  class GoBackExpAbstractKharonTelep : GoBackExpAbstract
	{
		protected virtual bool teleportToKharonPlateu()
		{
			ProgramHandle.SetCameraForExpBot();
			for (int i = 0; i < 500; i++)
			{
				if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
				{
					Thread.Sleep(10);
					ProgramHandle.TeleportToPositionTuple(TeleportValues.KharonTeleportOutside);
				}
				else if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
				{
					return true;
				}
			}
			if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
			{
				MouseOperations.MoveAndLeftClickOperation(930, 150, 100);
				if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
				{
					ProgramHandle.SetCameraForExpBot();
					MouseOperations.MoveAndLeftClickOperation(930, 460, 100);
				}
				if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
				{
					ProgramHandle.SetCameraForExpBot();
					MouseOperations.MoveAndLeftClickOperation(930, 150, 100);
				}
				if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
				{
					ProgramHandle.SetCameraForExpBot();
					MouseOperations.MoveAndLeftClickOperation(930, 460, 100);
				}
				if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
				{
					return true;
				}

			}
			if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
