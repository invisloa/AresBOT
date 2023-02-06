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
		static int redDifference = 32;

		static Bitmap bitmap = new Bitmap(1340, 840);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);
        static bool checkSearchColor(Color currentPixelColor)
        {
			if (currentPixelColor.G == 0 && currentPixelColor.B == 0 &&
				currentPixelColor.R < 130 && currentPixelColor.R > 20)
            {
                return true;
            }
            else return false;
		}
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
                                    if ((x < 934 || x > 987) && (y < 495 || y > 550) && checkSearchColor(currentPixelColor))

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
                     graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                        for (int x = 527; x < 1332; x++)
                        {

                            for (int y = 237; y < 835; y++)
                            {
                                Color currentPixelColor = bitmap.GetPixel(x, y);
                                if ((x < 934 || x > 987 || y < 495 || y > 550) && checkSearchColor(currentPixelColor))
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
