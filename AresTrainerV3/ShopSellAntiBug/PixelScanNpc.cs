using AresTrainerV3.AttackMob;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.PixelScanNPC
{
	public class PixelScanForNpc : IFindNPC
	{
		int howManyScans = 5;

		bool isNPCTargeted()
		{
			if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		bool pixelScanForNPC()
		{
			Bitmap bitmap = new Bitmap(1340, 840);
			Graphics graphics = Graphics.FromImage(bitmap as Image);

			if (ProgramHandle.isInCity == 1)
			{
				graphics = Graphics.FromImage(bitmap as Image);
				graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
				for (int x = 527; x < 1338; x++)
				{
					for (int y = 260; y < 780; y++)
					{
						Color currentPixelColor = bitmap.GetPixel(x, y);
						if ((x < 934 || x > 987 || y < 495 || y > 550) && PixelMobAttack.CheckSearchColor(currentPixelColor))
						{
							MouseOperations.SetCursorPosition(x, y);
							ProgramHandle.waitMouseInPosScanUnder();
							Thread.Sleep(10);
							ProgramHandle.waitMouseInPosScanUnder();
							if (isNPCTargeted())
							{
								Thread.Sleep(10);
								if (isNPCTargeted())
								{
									Console.WriteLine($"NPC found right clicking");
									MouseOperations.MoveAndRightClickOperation(x, y);
									Thread.Sleep(50);
									MouseOperations.MoveAndRightClickOperation(x, y);
									Thread.Sleep(2000);
									GC.Collect();
									return true;
								}
							}
						}
					}
				}
			}
			GC.Collect();
			return false;
		}
		bool multiScan()
		{
			for (int i = 0; i < howManyScans; i++)
			{
				if (pixelScanForNPC())
				{
					return true;
				}
			}
			return false;
		}
		public bool FindNpc()
		{
			return multiScan();
		}
	}
}
