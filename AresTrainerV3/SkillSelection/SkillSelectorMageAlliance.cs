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
                checkIfAttackSkillIsSelected();
                if (ProgramHandle.isInCity != 1)
                {
                    UseRapidWhenLowSkillDelay();
                }
                Thread.Sleep(5000);

            }
        }
        void UseRapidWhenLowSkillDelay()
        {
            if (ProgramHandle.GetSkillDelay == PointersAndValues.castingSpeedDelayPlus1)
            {
                KeyPresser.PressKey(4, 100, 100);
                KeyPresser.PressKey(4, 100, 100);
                KeyPresser.PressKey(4, 100, 100);
                Thread.Sleep(500);
                KeyPresser.PressKey(5, 100, 100);
                KeyPresser.PressKey(5, 100, 100);
                KeyPresser.PressKey(5, 100, 100);
                Thread.Sleep(100);

                KeyPresser.PressKey(3, 100, 100);
                KeyPresser.PressKey(3, 100, 100);
                Thread.Sleep(500);
                KeyPresser.PressKey(3, 100, 100);
                Thread.Sleep(200);
                KeyPresser.PressKey(3, 100, 100);
                KeyPresser.PressKey(3, 100, 100);
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
