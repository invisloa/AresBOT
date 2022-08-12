using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    internal class temp
    {

/*
        public static void ScanAndAttackAndCollect()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            bool isScanSuccessfull = false;

            Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
            // X and Y  set to start search only for LOA window
            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {

                    //MouseOperations.SetCursorPosition(x, y);

                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 
x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)

                    {
                        isScanSuccessfull = true;                                   //   TODO FIRST MAKE SCAN AND COLLECT WORKING
                        MouseOperations.SetCursorPosition(x, y);
                        if (ProgramHandle.AttackMobWhenSelected())
                        {
                            return;
                        };
                    }
                }
            }
            if (!isScanSuccessfull && ProgramHandle.getCurrentWeight < 1800) // TOCHANGE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
                for (int x = 700; x < 1200; x++)   // SEARCH RANGE WAS LOWERED
                {
                    for (int y = 335; y < 735; y++) // SEARCH RANGE WAS LOWERED
                    {
                        Color currentPixelColor = bitmap.GetPixel(x, y);
                        if ((x < 928 || x > 985 || y < 490 || y > 550) && desiredPixelColor == currentPixelColor)
                        {
                            MouseOperations.SetCursorPosition(x, y);
                            if (ExpBotClass.ClickAndCollectItem())
                            {
                                return;
                            }
                        }
                    }
                }
            }
            if (ProgramHandle.getCurrentWeight > 1800)
            {
                ProgramHandle.HealBotRepotKharonSell();
            }
            GC.Collect();
        }


*/
















    }
}
