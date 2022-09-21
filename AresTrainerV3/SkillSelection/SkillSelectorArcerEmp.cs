using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    public class SkillSelectorArcerEmp : SkillSelector
    {
        public override void SkillAssign()
        {
            if (ProgramHandle.isCurrentSkill() == 2)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerEmpBlasting;
            }
            else if (ProgramHandle.isCurrentSkill() == 3)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerSpeedUpSkill;
            }
            else if (ProgramHandle.isCurrentSkill() == 4)
            {
                ProgramHandle.SkillToOverride = 40002;
            }
            else if (ProgramHandle.isCurrentSkill() == 12)
            {
                ProgramHandle.SkillToOverride = PointersAndValues.arcerEmpBlasting;
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
        public override void Rebuff()
        {
/*            if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedWhitePotValue)
            {
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(4, 50, 50);
                KeyPresser.PressKey(3, 50, 50);
            }
*/
        }

    }

}
