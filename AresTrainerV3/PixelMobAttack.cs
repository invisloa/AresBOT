using AresTrainerV3.Unstuck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class PixelMobAttack
    {
        static Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);


        public static bool AttackSkillMobWhenSelected()
        {
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {


                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 || x > 976 || y < 502 || y > 540) &&  currentPixelColor == PointersAndValues.blackPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        if (AttackMob.CheckIfSelectedAndAttackSkill())
                        {
                          GC.Collect();
                          return true;
                        }
                    }

                }
            }
            GC.Collect();
            return false;

        }

    }

}
