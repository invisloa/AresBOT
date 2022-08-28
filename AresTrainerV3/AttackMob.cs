using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class AttackMob
    {
        static bool isAttacking()
        {
            if (ProgramHandle.isMobBeingAttacked != -1 && ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationArcerAlliOut && ProgramHandle.isWhatAnimationRunning() != PointersAndValues.isStandingAnimationArcerEmpOut)
            { return true; }
            else
            { return false; }
        }
        static bool isMobTargeted()
        {
            if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000 && ProgramHandle.isInCity != 1)
            {
                return true;
            }
            else
                return false;
        }
        static void WaitForAttackEnd()
        {
            while (isAttacking())
            {
                Debug.WriteLine($"!isStandingAnimation");
                Thread.Sleep(100);
                ProgramHandle.isWhatAnimationRunning();
            }
            Thread.Sleep(30);
            if (isAttacking())
            {
                Debug.WriteLine($"!Checked 2 IS STANDING");

                WaitForAttackEnd();
            }

        }
        static void SkillAttack()
        {
            Debug.WriteLine($"Mouse R Down");
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(10);
            WaitForAttackEnd();
            //make double clickRightUp because somehow it didnt notice the click and bot bugged and stopped attacking
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Debug.WriteLine($"Mouse R UP");
        }



        public static bool CheckIfSelectedAndAttackSkill()
        {
            if (isMobTargeted())
            {
                SkillAttack();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

