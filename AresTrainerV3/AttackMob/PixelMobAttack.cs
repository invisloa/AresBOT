using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.AttackMob
{
    public static class PixelMobAttack
    {
        static Bitmap bitmap = new Bitmap(1340, 840);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);


        public static bool AttackSkillMobWhenSelected()
        {
            //Debug.WriteLine("Start AttackScan");
            if (ProgramHandle.isInCity != 1)
            {
                RepotAbstract.IsScanRunning = true;
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                for (int x = 800; x < 1120; x++)
                {

                    for (int y = 360; y < 680; y++)
                    {
                        Color currentPixelColor = bitmap.GetPixel(x, y);
                        if ((x < 934 || x > 987 || y < 495 || y > 550) && currentPixelColor == PointersAndValues.blackPixelColor)

                        {
                              MouseOperations.SetCursorPosition(x+ 20, y);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                                //   Debug.WriteLine("1 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                              MouseOperations.SetCursorPosition(x- 20, y);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                                //  Debug.WriteLine("1 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                            MouseOperations.SetCursorPosition(x, y + 20);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                                //  Debug.WriteLine("1 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                              MouseOperations.SetCursorPosition(x, y- 20);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                                //  Debug.WriteLine("1 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                        }
                    }
                }
                graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                for (int x = 700; x < 1220; x++)
                {

                    for (int y = 260; y < 780; y++)
                    {


                        Color currentPixelColor = bitmap.GetPixel(x, y);
                        if ((x < 934 || x > 987 || y < 495 || y > 550) && currentPixelColor == PointersAndValues.blackPixelColor)

                        {
                            MouseOperations.SetCursorPosition(x, y);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                                // Debug.WriteLine("2 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                        }
                    }
                }
                graphics = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                for (int x = 527; x < 1332; x++)
                {

                    for (int y = 237; y < 835; y++)
                    {


                        Color currentPixelColor = bitmap.GetPixel(x, y);
                        if ((x < 934 || x > 987 || y < 495 || y > 550) && currentPixelColor == PointersAndValues.blackPixelColor)
                        {
                            MouseOperations.SetCursorPosition(x, y);
                            ProgramHandle.waitMouseInPosAttack();

                            if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                            {
                               // Debug.WriteLine("3 attack for");

                                RepotAbstract.IsScanRunning = false;
                                GC.Collect();
                                return true;
                            }
                        }
                    }

                }
            }
           // Debug.WriteLine("attack false");

            RepotAbstract.IsScanRunning = false;
            GC.Collect();
            return false;

        }

    }

}
