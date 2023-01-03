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
        int buff1value = PointersAndValues.BuffSpearMeditationEmp;
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
                if (ProgramHandle.isInCity != 1)
                {
                    firstBuff = ProgramHandle.getBuff1Informations.Item1;
                    secondBuff = ProgramHandle.getBuff1Informations.Item2;
                    thirdBuff = ProgramHandle.getBuff1Informations.Item3;
                    fourthBuff = ProgramHandle.getBuff1Informations.Item4;

                     
                    if (buffIsNotActive(buff1value))
                    {
						KeyPresser.PressKey(4, 50, 50);
						KeyPresser.PressKey(4, 50, 50);
						KeyPresser.PressKey(4, 50, 50);
						KeyPresser.PressKey(5, 50, 50);
						KeyPresser.PressKey(5, 50, 50);
						KeyPresser.PressKey(5, 50, 50);
						KeyPresser.PressKey(5, 50, 50);
					}
					if (buffIsNotActive(buff2value))
                    {
                    }
                    if (buffIsNotActive(buff2value))
                    {
                    }
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
