using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public class PixelBotSearcher
    {
        private static volatile bool _stopPixel = false;

        public static void RequestStopPixel()
        {
            if (_stopPixel)
                _stopPixel = false;
            else
                _stopPixel = true;
        }

        static void ScanForPixels()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
            //
            //
            //
            // X and Y probbably set to start search only for LOA window
            //
            //
            //

            for (int x = 470; x < 1320; x++)
            {

                for (int y = 225; y < 830; y++)
                {

                        //MouseOperations.SetCursorPosition(x, y);

                        Color currentPixelColor = bitmap.GetPixel(x, y);

                        if (desiredPixelColor == currentPixelColor)
                        {
                            if (x < 900 || x > 925 || y < 497 || y > 521)
                            {

                                MouseOperations.SetCursorPosition(x, y);
                            }
                        }
                }
            }
            bitmap = null;
            graphics = null;
            Thread.Sleep(100);
            GC.Collect();

        }
        //888 935  486 530


    public static void SearchPixel()
        {
            while (_stopPixel)
            {

                if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
                {
                    ScanForPixels();
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.Etana)
                {
                    ScanForPixels();
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.AllianceSacredLand)
                {
                    ScanForPixels();
                }


                GC.Collect();
                }
        }
    }
}
