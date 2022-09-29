using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.AttackMob
{
    public static class PixelMobAttack
    {
        static Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);


        public static bool AttackSkillMobWhenSelected()
        {
            HealBotAbstract.IsScanRunning = true;
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            for (int x = 800; x < 1120; x++)
            {

                for (int y = 360; y < 680; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 || x > 976 || y < 502 || y > 540) && currentPixelColor == PointersAndValues.blackPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                        {
                            HealBotAbstract.IsScanRunning = false;
                            GC.Collect();
                            return true;
                        }
                    }
                }
            }
            for (int x = 700; x < 1220; x++)
            {

                for (int y = 260; y < 780; y++)
                {


                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 || x > 976 || y < 502 || y > 540) && currentPixelColor == PointersAndValues.blackPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                        {
                            HealBotAbstract.IsScanRunning = false;
                            GC.Collect();
                            return true;
                        }
                    }
                }
            }
            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {


                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 || x > 976 || y < 502 || y > 540) && currentPixelColor == PointersAndValues.blackPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                        {
                            HealBotAbstract.IsScanRunning = false;
                            GC.Collect();
                            return true;
                        }
                    }

                }
            }
            HealBotAbstract.IsScanRunning = false;
            GC.Collect();
            return false;

        }

    }

}
