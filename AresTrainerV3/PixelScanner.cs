using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public static class PixelScanner
    {
        static Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        static Graphics graphics = Graphics.FromImage(bitmap as Image);


        public static void ScanPixelsAndSetMouse(Color desiredPixelColor)
        {
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {


                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 938 || x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)

                    {
                        MouseOperations.SetCursorPosition(x, y);
                        GC.Collect();
                    }
                }
            }
            GC.Collect();

        }

    }
}

