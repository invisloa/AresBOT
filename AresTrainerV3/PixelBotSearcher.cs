using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    public class PixelBotSearcher
    {
        private static volatile bool _stopPixelAttack = false;
        public static bool isStopPixelAttack
        {
            get { return _stopPixelAttack; }
        }

        public static void RequestStopPixelAttack()
        {
            if (_stopPixelAttack)
                _stopPixelAttack = false;
            else
                _stopPixelAttack = true;
        }

        private static volatile bool _stopPixelItemDrop = false;
        public static bool isStopPixelItemDrop
        {
            get { return _stopPixelItemDrop; }
        }

        public static void RequestStopPixelPixelItemDrop()
        {
            if (_stopPixelItemDrop)
                _stopPixelItemDrop = false;
            else
                _stopPixelItemDrop = true;
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
                */
        public static void ScanAndAttack()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
           // bool isScanSuccessfull = false;                                                   TODO FIRST MAKE SCAN AND COLLECT WORKING
            Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
            // X and Y probbably set to start search only for LOA window
            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {

                    //MouseOperations.SetCursorPosition(x, y);

                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if (x < 938 || x > 976 || y < 502 || y > 540 && desiredPixelColor == currentPixelColor)

                    {
                        //    isScanSuccessfull = true;                                      TODO FIRST MAKE SCAN AND COLLECT WORKING
                            MouseOperations.SetCursorPosition(x, y);
                            ProgramHandle.AttackMobWhenSelected();
                    }
                }
            }
            GC.Collect();
        }

        public static void PixelOnlyScanAndAttack()
        {
            ProgramHandle.SetCameraForExpBot();
            if (!ProgramHandle.isStopHeal)
            {
                Form1.StartHealBotThreadKoHit();
            }


            while (_stopPixelAttack)
            {

                ScanAndAttack();
                GC.Collect();
            }
        }

        public static void ScanAndCollectItems()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
            // X and Y probbably set to start search only for LOA window
            for (int x = 527; x < 1360; x++)
            {

                for (int y = 237; y < 835; y++)
                {

                    //MouseOperations.SetCursorPosition(x, y);

                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    if ((x < 938 || x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)
                    {
                        MouseOperations.SetCursorPosition(x, y);
                            ProgramHandle.ClickAndCollectItem();
                        return;
                    }
                }
            }
            GC.Collect();
        }

    }
}

