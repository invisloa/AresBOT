using AresTrainerV3.HealBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
	internal class SkillSelectorKnightAlli : SkillSelector
	{
		int expScroll = 2489;
		int dontknowwhat = 1607; // ????? not sure this one
		int candle = 1605;

		public override void Rebuff()
		{
			while (HealBot.HealBotA.IsHealBotRunning == true)
			{
				checkForWhiteRed();

				if (ProgramHandle.isInCity != 1)
				{
					//checkBuffAndClick(expScroll, 5);
					checkIfAttackSkillIsSelected();
				}
				Thread.Sleep(10000);
			}

		}
		public override void SkillAssign()
		{
			// currently no Hacking;
		}



	}
}
