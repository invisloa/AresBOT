﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    internal class SkillSelectorArcerAli : SkillSelector
    {
        public override void SkillAssign()
        {
            if (ProgramHandle.isCurrentSkill() == 2)
            {
                ProgramHandle.SkillToOverride = 40002;
            }
            else if (ProgramHandle.isCurrentSkill() == 3)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerAlliLastSingle;
            }
            else if (ProgramHandle.isCurrentSkill() == 4)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerSpeedUpSkill;
            }
            else if (ProgramHandle.isCurrentSkill() == 10)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerEmpBlasting;
            }
        }
        public override void Rebuff()
        {
        }
    }
}
