using AresTrainerV3.ItemCollect;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.AttackMob
{
    public static class AttackMobCollectSod
    {
        static void WaitForAttackEnd()
        {

            Thread.Sleep(50);
            IWhatToCollect _SodCollector = new CollectSod(); // WHAT TO COLLECT WHEN ATTACKING 
            PixelItemCollector pixelSodCollect = new PixelItemCollector(_SodCollector);

            UnstuckFromAnywhere anywhereUnstucker = new UnstuckFromAnywhere();
            // check if not attacking in stuck position

            anywhereUnstucker.UnstuckMove();

            Thread.Sleep(50);

            while (ProgramHandle.isAttacking())
            {
                pixelSodCollect.ClickAndCollectItem();
                Debug.WriteLine($"is not StandingAnimation");
                Thread.Sleep(100);
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
                Debug.WriteLine($"!Checked 2 IS STANDING");
                WaitForAttackEnd();
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
                Debug.WriteLine($"!Checked 3 IS STANDING");
                WaitForAttackEnd();
            }

        }

        static bool isMobTargeted()
        { 
            if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isInCity != 1)
            {
                 if (ProgramHandle.isMobSelected > 8300000)
                     {
                     PixelItemCollector.weightLimitCollect = 3000;
                     Debug.WriteLine($"Player Found");
                     return false;
                     }
                Debug.WriteLine($"MOB found ");
                return true;
            }
            else
                return false;
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

