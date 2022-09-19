using System;
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
                KeyPresser.PressKey(4, 50, 50);
                SkillAssign();
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(3, 50, 50);

            }
        }

        public override void SkillAssign()
        {
            if (ProgramHandle.isCurrentSkill() == 2)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.spearAllianceFireFury;
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
