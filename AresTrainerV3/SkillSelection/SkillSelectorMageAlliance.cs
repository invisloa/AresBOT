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
        int buff1value = PointersAndValues.BuffMageShieldAlli;
        int buff2value = -1;  
        int buff3value = -1;

        bool buffIsNotActive(int buffValue)
        {

            if (buffValue == firstBuff || buffValue == secondBuff || buffValue == thirdBuff || buffValue == fourthBuff)
            {
                return false;
            }

            return true;
        }
        public override void Rebuff()
        {
            while (HealBotAbstract.IsHealBotRunning == true)
            {
				/*                if (ProgramHandle.isInCity != 1)
								{
									firstBuff = ProgramHandle.getBuff1Informations.Item1;
									secondBuff = ProgramHandle.getBuff1Informations.Item2;
									thirdBuff = ProgramHandle.getBuff1Informations.Item3;
									fourthBuff = ProgramHandle.getBuff1Informations.Item4;

									UseRapidWhenLowSkillDelay();
									if (buffIsNotActive(buff1value))
									{
										KeyPresser.PressKey(5, 50, 50);
										KeyPresser.PressKey(5, 50, 50);
										KeyPresser.PressKey(5, 50, 50);
									}
									checkIfAttackSkillIsSelected();
									if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
									{
										KeyPresser.PressKey(7, 100, 100);  // temporary exp scrolls

										KeyPresser.PressKey(8, 100, 100);
									}

								}
				*/
				KeyPresser.PressKey(5, 50, 50);
				Thread.Sleep(60000);
            }
             
        }
        void UseRapidWhenLowSkillDelay()
        {
            int clickDelayTime = 150;
            if (ProgramHandle.GetSkillDelay == PointersAndValues.castingSpeedDelayPlus2)
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

        public override void SkillAssign()
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

    }
}
