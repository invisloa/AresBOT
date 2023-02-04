using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.AttackMob
{
    public static class PixelMobAttack
    {
        static int moveMouseVector = 10;
        static Bitmap bitmap = new Bitmap(1340, 840);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);

/*        public static bool IsTooMuchPixels()
		{
			int pixelCount = 0;
            for (int x = 700; x < 1220; x++)
            {

                for (int y = 260; y < 780; y++)
                {
					if ((x < 934 || x > 987 || y < 495 || y > 550) && bitmap.GetPixel(x, y) == PointersAndValues.blackPixelColor)
                    {
                        pixelCount++;
                    }

				}
			}
            if (pixelCount > 20000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
*/
		public static bool AttackSkillMobWhenSelected()
        {
            if (ProgramHandle.isInCity != 1)
            {
                if (ExpBotManagerAbstract.isExpBotRunning == true)
                {

                    RepotAbstract.IsScanRunning = true;
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                        for (int x = 800; x < 1120; x++)
                        {
                            if (x < 934 || x > 987)
                            {
                                for (int y = 360; y < 680; y++)
                                {
                                    Color currentPixelColor = bitmap.GetPixel(x, y);
                                    if ((x < 934 || x > 987) && (y < 495 || y > 550) && currentPixelColor == PointersAndValues.blackPixelColor)
                                    {
                                        MouseOperations.SetCursorPosition(x, y);
                                        ProgramHandle.waitMouseInPos();

                                        if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                                        {
                                            //   Debug.WriteLine("1 attack for");

                                            RepotAbstract.IsScanRunning = false;
                                            GC.Collect();
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                }
                if (ExpBotManagerAbstract.isExpBotRunning == true)
                {
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
                                    ProgramHandle.waitMouseInPos();

                                    if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                                    {
                                        RepotAbstract.IsScanRunning = false;
                                        GC.Collect();
                                        return true;
                                    }
                                }
                            }

                        }
                }
            }
            RepotAbstract.IsScanRunning = false;
			GC.Collect();
            return false;
        }

    }

}
