﻿using AresTrainerV3.ItemCollect;
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
        public static bool IsAttackingPixel = false;
        static int attackUnstackCounter = 0;
        static void WaitForAttackEnd()
        {
            void checkIfIsNowAttackingAnimation()
            {
                Thread.Sleep(100);
                if (ProgramHandle.isAttacking())
                {
                    WaitForAttackEnd();
                }
            }
            Thread.Sleep(500);
            IWhatToCollect _SodCollector = new CollectSod(); // WHAT TO COLLECT WHEN ATTACKING 
            PixelItemCollector pixelSodCollect = new PixelItemCollector(_SodCollector);

            UnstuckFromAnywhere anywhereUnstucker = new UnstuckFromAnywhere();
            // check if not attacking in stuck position
           // anywhereUnstucker.UnstuckMove();

            while (ProgramHandle.isAttacking())
            {
                attackUnstackCounter++;
                pixelSodCollect.ClickAndCollectItem();
                //Debug.WriteLine($"is not StandingAnimation");
                Thread.Sleep(100);
                Debug.WriteLine(attackUnstackCounter);
                if (attackUnstackCounter == 60)
                {
                    anywhereUnstucker.AttackUnstacker();
                }
            }
            checkIfIsNowAttackingAnimation();
            checkIfIsNowAttackingAnimation();
            checkIfIsNowAttackingAnimation();
        }

        static bool isMobTargeted()
        { 
            if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000 && ProgramHandle.isInCity != 1)
            {
                return true;
            }
            else if (ProgramHandle.isMobSelected > 8300000)
            {
                PointersAndValues.MaxCollectWeight = 1;
                Debug.WriteLine($"Player Found");
                return false;
            }
            else
                return false;
        }
        static bool SkillAttack()
        {
            if (ProgramHandle.isMobSelected != 0)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                Debug.WriteLine($"Mouse R Down");
                Thread.Sleep(300);
                if (ProgramHandle.isMouseClickedOnMob == 1)
                {
                    IsAttackingPixel = true;

                    attackUnstackCounter = 0;

                    Debug.WriteLine($"Mouse Clicked On Mob==1");
                    MoverRandom.AttackedOrCollected = true;

                    WaitForAttackEnd();
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    Debug.WriteLine($"Mouse R UP");
                    IsAttackingPixel = false;
                    return true;


                }
                else
                {
                    Debug.WriteLine($"Mouse not Clicked On Mob");
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    Debug.WriteLine($"Mouse R UP");
                    IsAttackingPixel = false;
                    return false;
                }
            }
            return false;
        }
        public static bool CheckIfSelectedAndAttackSkill()
        {
            if (isMobTargeted())
            {
                if (SkillAttack())
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
    }

}

