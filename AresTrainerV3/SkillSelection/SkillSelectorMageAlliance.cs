using AresTrainerV3.HealBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AresTrainerV3.SkillSelection
{
    internal class SkillSelectorMageAlliance : SkillSelector
    {
		int expScroll = 2489;
		int mageShield = 3417;
		int Rapid = 3416;
		int dontknowwhat = 1607; // ????? not sure this one
		int candle = 1605;

		public override void Rebuff()
        {
            while (HealBotAbstract.IsHealBotRunning == true)
            {
                checkForWhitePotBuff();

				if (ProgramHandle.isInCity != 1)
                {
					checkBuffAndClick(Rapid, 4);
					checkBuffAndClick(mageShield, 5);
					//checkBuffAndClick(expScroll, 7);
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




/*        public override void SkillAssign()
        {
            if (ProgramHandle.isCurrentSkill() == 2)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageFireSingleLast;
            }
            else if (ProgramHandle.isCurrentSkill() == 3)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageFireAOEleLast;
            }
            else if (ProgramHandle.isCurrentSkill() == 4)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageSupportBlastArmor;
            }
            else if (ProgramHandle.isCurrentSkill() == 6)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageSupportEnergyShield;
            }
            else if (ProgramHandle.isCurrentSkill() == 8)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageSupportFireBarrier;
            }
            else if (ProgramHandle.isCurrentSkill() == 9)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.mageSupportLightningBarrier;
            }
        }
*/



/*        void UseRapidWhenLowSkillDelay()
        {
            int clickDelayTime = 150;
            if (ProgramHandle.GetSkillDelay == PointersAndValues.castingSpeeDelaydZero)
            { 
                KeyPresser.PressKey(4, 2 * clickDelayTime);
                KeyPresser.PressKey(4, 2 * clickDelayTime);
                KeyPresser.PressKey(4, 2 * clickDelayTime);
                Thread.Sleep(500);
				KeyPresser.PressKey(7, clickDelayTime);
				KeyPresser.PressKey(7, clickDelayTime);
				KeyPresser.PressKey(7, clickDelayTime);
				Thread.Sleep(500);

				KeyPresser.PressKey(3, clickDelayTime);
                KeyPresser.PressKey(3, clickDelayTime);
                Thread.Sleep(500);
                KeyPresser.PressKey(3, clickDelayTime);
                KeyPresser.PressKey(3, clickDelayTime);
            }

        }
/*                    if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                    {
                        KeyPresser.PressKey(7, 100, 100);  // temporary exp scrolls

                        KeyPresser.PressKey(8, 100, 100);
                    }
*/

