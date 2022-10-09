using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public class PixelItemCollector : ICollectItems
    {
        public static int weightLimitCollect = 1900;

        IWhatToCollect _whatToCollect { get;}
        IWhatToCollect CollectIgnoringWeight = new CollectSodJewelery();

        public PixelItemCollector(IWhatToCollect whatToCollect)
        {
            _whatToCollect = whatToCollect;
        }
        bool ScanAndCollect()
        {
            if (ProgramHandle.getCurrentWeight < weightLimitCollect && ProgramHandle.isInCity != 1)
            {
                return PixelScan(_whatToCollect);
            }
            else if (ProgramHandle.isInCity != 1)
            {
                return PixelScan(CollectIgnoringWeight);
            }

            GC.Collect();
            RepotAbstract.IsScanRunning = false;
            return false;
        }

        public bool ClickAndCollectItem()
        {
            return ScanAndCollect();
        }

        bool PixelScan(IWhatToCollect whatToCollect)
        {
            Debug.WriteLine("Start PixelScan");

            RepotAbstract.IsScanRunning = true;
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
            for (int x = 800; x < 1120; x++)
            {
                for (int y = 360; y < 680; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 934 || x > 979 || y < 500 || y > 538) && desiredPixelColor == currentPixelColor)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            for (int z = -1; z < 2; z++)
                            {
                                MouseOperations.SetCursorPosition(x + 3*i, y + 3*z);
                                if (whatToCollect.ClickAndCollectWhatItem())
                                {
                                    RepotAbstract.IsScanRunning = false;
                                    Debug.WriteLine("EndCollect");
                                    GC.Collect();
                                    Debug.WriteLine("1 Pixel for");

                                    return true;
                                }
                            }
                        }

                    }
                }
            } 
            for (int x = 550; x < 1360; x++)
            {
                for (int y = 290; y < 835; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 934 || x > 979 || y < 500 || y > 538) && desiredPixelColor == currentPixelColor)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            for (int z = -1; z < 2; z++)
                            {
                                MouseOperations.SetCursorPosition(x + 2 * i, y + 2 * z);
                                if (whatToCollect.ClickAndCollectWhatItem())
                                {
                                    RepotAbstract.IsScanRunning = false;
                                    Debug.WriteLine("2 Pixel for");

                                    Debug.WriteLine("EndCollect");
                                    GC.Collect();
                                    return true;
                                }
                            }
                        }

                    }
                }
            }
            Debug.WriteLine("Pixel False");

            GC.Collect();
            RepotAbstract.IsScanRunning = false;
            return false;
        }
    }

}
