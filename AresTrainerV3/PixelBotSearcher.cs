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
        public static bool isStopPixel
        {
            get { return _stopPixel; }
        }

        public static void RequestStopPixel()
        {
            if (_stopPixel)
                _stopPixel = false;
            else
                _stopPixel = true;
        }

/*        static void ScanForPixels()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
            // X and Y probbably set to start search only for LOA window
            for (int x = 487; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {

                    //MouseOperations.SetCursorPosition(x, y);

                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    if (desiredPixelColor == currentPixelColor)
                    {
                        if (x < 938 || x > 976 || y < 502 || y > 540)
                        {

                            MouseOperations.SetCursorPosition(x, y);
                            ProgramHandle.AttackMobWhenSelected();
                        }
                    }
                }
            }
        }
*/        public static void ScanAndAttack()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
            // X and Y probbably set to start search only for LOA window
            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {

                    //MouseOperations.SetCursorPosition(x, y);

                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    if (desiredPixelColor == currentPixelColor)
                    {
                        if (x < 938 || x > 976 || y < 502 || y > 540)
                        {
                            MouseOperations.SetCursorPosition(x, y);
                             ProgramHandle.AttackMobWhenSelected();
                        }
                    }
                }
            }
            GC.Collect();
        }

        public static void SearchPixel()
        {
            while (_stopPixel)
            { 
                if (ProgramHandle.GetCurrentMap == TeleportValues.UWC1stFloor)
                {
                    ScanAndAttack();
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.Etana)
                {
                    ScanAndAttack();
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.AllianceSacredLand)
                {
                    ScanAndAttack();
                }
                GC.Collect();
            }
        }
    }
}

