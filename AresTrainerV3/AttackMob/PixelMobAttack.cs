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
		static bool wasMobSelected = false;
		static void WasMobSelected()
		{
			if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000 && ProgramHandle.isInCity != 1)
			{
				wasMobSelected = true;
			}
		}
		static void ScanAgainWhenMobFound()
		{
			if (wasMobSelected == true)
			{
				PixelMobAttack.AttackSkillMobWhenSelected();
			}
		}

		static public bool CheckSearchColor(Color currentPixelColor)
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
			wasMobSelected= false;
			if (ProgramHandle.isInCity != 1)
			{
				if (ExpBotManagerAbstract.isExpBotRunning)
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
								if ((x < 934 || x > 987) && (y < 495 || y > 550) && CheckSearchColor(currentPixelColor))
								{
									MouseOperations.SetCursorPosition(x, y);
									ProgramHandle.waitMouseInPos();
									WasMobSelected();
									if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
									{
										return endScanLoopSucces();
									}
								}
							}
						}
					}
					ScanAgainWhenMobFound();
				}
				if (ExpBotManagerAbstract.isExpBotRunning)
				{
					graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
					for (int x = 527; x < 1332; x++)
					{

						for (int y = 237; y < 835; y++)
						{
							Color currentPixelColor = bitmap.GetPixel(x, y);
							if ((x < 934 || x > 987 || y < 495 || y > 550) && CheckSearchColor(currentPixelColor))
							{
								MouseOperations.SetCursorPosition(x, y);
								ProgramHandle.waitMouseInPos();
								WasMobSelected();

								if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
								{
									return endScanLoopSucces();
								}
							}
						}

					}
					ScanAgainWhenMobFound();
				}
			}
			return endScanLoopFail();
		}
		static void endScanning()
		{
			wasMobSelected = false;
			RepotAbstract.IsScanRunning = false;
			GC.Collect();
		}
		static bool endScanLoopSucces()
		{
			endScanning();
			return true;
		}
		static bool endScanLoopFail()
		{
			endScanning();
			return false;
		}


	}

}
