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
        public override void Rebuff()
        {
            while (HealBotAbstract.IsHealBotRunning == true)
            {
                if (ProgramHandle.isInCity != 1)
                {
                    UseRapidWhenLowSkillDelay();
                    UseRapidWhenLowSkillDelay();
                }
                Thread.Sleep(5000);

            }
        }
        void UseRapidWhenLowSkillDelay()
        {
            if (ProgramHandle.GetSkillDelay == PointersAndValues.castingSpeedDelayPlus2)
            {
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(3, 50, 50);

                Thread.Sleep(500);
                KeyPresser.PressKey(5, 50, 50);
                KeyPresser.PressKey(5, 50, 50);
                KeyPresser.PressKey(5, 50, 50);
                KeyPresser.PressKey(3, 10, 10);
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
