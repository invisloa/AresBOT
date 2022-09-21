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
        IWhatToCollect _whatToCollect { get;}
        IWhatToCollect _SodCollector = new CollectSodItems();

       int _weightLimit { get;}
        public PixelItemCollector(int weightLiftLimit, IWhatToCollect whatToCollect)
        {
            _weightLimit = weightLiftLimit;
            _whatToCollect = whatToCollect;
        }
        bool ScanAndCollect()
        {
            if (ProgramHandle.getCurrentWeight < _weightLimit && ProgramHandle.isInCity != 1)
            {
                PixelScan(_whatToCollect);
            }
            else if (ProgramHandle.isInCity != 1)
            {
                PixelScan(_SodCollector);
            }
            GC.Collect();
            HealBotAbstract.IsScanRunning = false;
            return false;
        }

        public bool ClickAndCollectItem()
        {
            return ScanAndCollect();
        }

        bool PixelScan(IWhatToCollect whatToCollect)
        {
            HealBotAbstract.IsScanRunning = true;
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");

            // Increased for collecting so it dont scan mob window top left
            for (int x = 550; x < 1360; x++)
            {
                for (int y = 290; y < 835; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 940 || x > 975 || y < 500 || y > 538) && desiredPixelColor == currentPixelColor)
                    {
                        Debug.WriteLine("pixel Collect");
                        for (int i = -1; i < 2; i++)
                        {
                            for (int z = -1; z < 2; z++)
                            {
                                MouseOperations.SetCursorPosition(x + i, y + z);
                                if (whatToCollect.ClickAndCollectWhatItem())
                                {
                                    HealBotAbstract.IsScanRunning = false;
                                    Debug.WriteLine("EndCollect");
                                    GC.Collect();
                                    return true;
                                }
                            }
                        }

                    }
                }
            }
            GC.Collect();
            HealBotAbstract.IsScanRunning = false;
            return false;
        }
    }

}
