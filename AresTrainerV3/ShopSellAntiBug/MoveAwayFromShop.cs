using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ShopSellAntiBug
{
	public class MoveAwayFromShop : IActionToUnbug
	{
		protected Random randomizer = new Random();

		public void ActionToUnBugShop()
		{
			Thread.Sleep(100);
			Console.WriteLine("move away from shop");
			KeyPresser.PressEscape();
			Thread.Sleep(200);
			MouseOperations.MoveAndLeftClickOperation(750 + randomizer.Next(100), 400 + randomizer.Next(250), 200);
			Thread.Sleep(100);
			while (!ProgramHandle.isNowStandingCity())
			{
				Thread.Sleep(1);
			}
			if (randomizer.Next(4) == 0)
			{
				MouseOperations.MoveAndLeftClickOperation(910 + randomizer.Next(100), 570 + randomizer.Next(100), 200);
			}
			if (randomizer.Next(4) == 0)
			{
				MouseOperations.MoveAndLeftClickOperation(1000 + randomizer.Next(50), 460 + randomizer.Next(100), 200);
			}
		}
	}
}
