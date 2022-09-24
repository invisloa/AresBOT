﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    internal class SkillSelectorSpearAlli : SkillSelector
    {
        public override void Rebuff()
        {
            if (ProgramHandle.getBuff1Informations == 0)
            {
                if (!AttackMob.AttackMob.isAttacking())
                {
                    KeyPresser.PressKey(4, 100, 100);
                    SkillAssign();
                    KeyPresser.PressKey(4, 100, 100);
                    SkillAssign();
                    KeyPresser.PressKey(4, 100, 100);
                    KeyPresser.PressKey(3, 100, 100);

                }
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