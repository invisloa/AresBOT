using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    public abstract class SkillSelector : ISelectSkill
    {
        public static SkillSelector SelectPropperClass()
        {
            if (ProgramHandle.isCurrentClassSelected == 1)
            {
                return new SkillSelectorArcerEmp();
            }
            else if (ProgramHandle.isCurrentClassSelected == 2)
            {
                return new SkillSelectorMageAlliance();
            }
            else if (ProgramHandle.isCurrentClassSelected == 3)
            {
                return new SkillSelectorSpearAlli();
            }
            else
                return new SkillSelectorArcerAli();
        }
        public abstract void SkillAssign();
        public abstract void Rebuff();

    }
}
