using AresTrainerV3.PixelScanNPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ShopSellAntiBug
{
	public class ShopMoveUnbugger : IUnBugShop
	{
		IActionToUnbug unbugAction = Factory.CreateUnbugActionClass();
		IFindNPC npcFinder = Factory.CreateFindNPC();
		public void UnBugShop()
		{
			ProgramHandle.SetCameraForExpBot();
			unbugAction.ActionToUnBugShop();
			npcFinder.FindNpc();
		}
	}
}
