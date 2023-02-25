using AresTrainerV3.HealBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    internal class SkillSelectorSpearAlli : SkillSelector
    {
        int BuffSpearMeditationEmp = PointersAndValues.BuffSpearMeditationAlli;
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
            while (HealBot.HealBotA.IsHealBotRunning == true)
            {
				checkForWhiteRed();

				if (ProgramHandle.isInCity != 1)
                {
					checkBuffAndClick(BuffSpearMeditationEmp, 4);
					checkBuffAndClick(expScroll, 5);
					checkIfAttackSkillIsSelected();
				}
				Thread.Sleep(5000);
            }

        }

        public override void SkillAssign()
        {
            if (ProgramHandle.isCurrentSkill() == 2)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearFirstAoESkill;
            }
            else if (ProgramHandle.isCurrentSkill() == 3)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearBuffMeditation;
            }
            else if (ProgramHandle.isCurrentSkill() == 4)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearBuffShout;
            }
            else if (ProgramHandle.isCurrentSkill() == 10)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearBuffBawlShout ;
            }
            else if (ProgramHandle.isCurrentSkill() == 11)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearBuffStoneBody;
            }
        }
    }

}
