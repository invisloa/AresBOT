using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom;
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
            Thread.Sleep(200);

            int i = 0;
            IWhatToCollect _SodCollector = new CollectSod(); // WHAT TO COLLECT WHEN ATTACKING 
            PixelItemCollector pixelSodCollect = new PixelItemCollector(_SodCollector);

            UnstuckFromAnywhere anywhereUnstucker = new UnstuckFromAnywhere();
            // check if not attacking in stuck position
            anywhereUnstucker.UnstuckMove();

            while (ProgramHandle.isAttacking())
            {
                i++;
                pixelSodCollect.ClickAndCollectItem();
                //Debug.WriteLine($"is not StandingAnimation");
                Thread.Sleep(100);
                Debug.WriteLine(i);
                if (i== 30)
                {
                    anywhereUnstucker.AttackUnstacker();
                }
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
               // Debug.WriteLine($"!Checked 2 IS STANDING");
                WaitForAttackEnd();
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
               // Debug.WriteLine($"!Checked 3 IS STANDING");
                WaitForAttackEnd();
            }

        }

        static bool isMobTargeted()
        { 
            if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000 && ProgramHandle.isInCity != 1)
            {
                return true;
            }
            else if (ProgramHandle.isMobSelected > 8300000)
            {
                AbstractWhatToCollect.MaxCollectWeight = 1;
                Debug.WriteLine($"Player Found");
                return false;
            }
            else
                return false;
        }
        static void SkillAttack()
        {
            if (ProgramHandle.isMobSelected != 0)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                MoverRandom.AttackedOrCollected = true;
                Debug.WriteLine($"Mouse R Down");
                Thread.Sleep(100);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                if (ProgramHandle.isMouseClickedOnMob == 1)
                {
                    WaitForAttackEnd();
                    //make double clickRightUp because somehow it didnt notice the click and bot bugged and stopped attacking
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    //   Thread.Sleep(100);
                }
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                //   Thread.Sleep(100);
                Debug.WriteLine($"Mouse R UP");
            }
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

