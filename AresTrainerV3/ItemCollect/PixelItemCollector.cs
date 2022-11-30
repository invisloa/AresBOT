﻿using AresTrainerV3.AttackMob;
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
        void waitForAttackEnd()
        {
            while (ProgramHandle.isAttacking())
            {
                Thread.Sleep(50);
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
                waitForAttackEnd();
            }
            Thread.Sleep(50);
            if (ProgramHandle.isAttacking())
            {
                waitForAttackEnd();
            }
        }
        void AttackWhenPointedOnMob()
        {
            if (!AttackMobCollectSod.IsAttackingPixel)
            {
                if (ProgramHandle.isMobSelected != 0 && ProgramHandle.isMobSelected < 8300000)
                {
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                    Debug.WriteLine($"Mouse R Down");
                    Thread.Sleep(50);
                    if (ProgramHandle.isMouseClickedOnMob == 1)
                    {
                        waitForAttackEnd();
                        Debug.WriteLine($"Mouse Clicked On Mob==1");
                    }

                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    //   Thread.Sleep(100);
                    Debug.WriteLine($"Mouse R UP");

                }
            }

        }
        IWhatToCollect _whatToCollect { get; }
        IWhatToCollect CollectIgnoringWeight = new CollectSod();
        public PixelItemCollector(IWhatToCollect whatToCollect)
        {
            _whatToCollect = whatToCollect;
        }
        bool ScanAndCollect()
        {
            if (ProgramHandle.getCurrentWeight < PointersAndValues.MaxCollectWeight && ProgramHandle.isInCity != 1)
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
            //Debug.WriteLine("Start PixelScan");
            if(whatToCollect == CollectIgnoringWeight || ProgramHandle.getCurrentWeight < PointersAndValues.MaxCollectWeight)

            RepotAbstract.IsScanRunning = true;
           // Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Bitmap bitmap = new Bitmap(1360, 840);


            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
            for (int x = 850; x < 1170; x++)
            {
                for (int y = 410; y < 730; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 934 || x > 979 || y < 500 || y > 538) && desiredPixelColor == currentPixelColor)
                    {
                                MouseOperations.SetCursorPosition(x , y);
                                ProgramHandle.waitMouseInPos();
                                AttackWhenPointedOnMob();
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
           // graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            for (int x = 550; x < 1360; x++)
            {
                for (int y = 290; y < 835; y++)
                {
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if ((x < 934 || x > 979 || y < 500 || y > 538) && desiredPixelColor == currentPixelColor)
                    {
                        MouseOperations.SetCursorPosition(x, y);
                        ProgramHandle.waitMouseInPos();
                        AttackWhenPointedOnMob();

                        /*                                if (AttackMobCollectSod.CheckIfSelectedAndAttackSkill())
                                                        {
                                                            //   Debug.WriteLine("1 attack for");

                                                            RepotAbstract.IsScanRunning = false;
                                                            GC.Collect();
                                                            return true;
                                                        }
                        */
                        if (whatToCollect.ClickAndCollectWhatItem())
                        {
                            RepotAbstract.IsScanRunning = false;

                            Debug.WriteLine("EndCollect");
                            GC.Collect();
                            return true;
                        }
                    }
                }
            }
            //Debug.WriteLine("Pixel False");

            GC.Collect();
            RepotAbstract.IsScanRunning = false;
            return false;
        }
        public bool PixelScanUnderChar(IWhatToCollect whatToCollect)
        {
            if (whatToCollect == CollectIgnoringWeight && ProgramHandle.getCurrentWeight < PointersAndValues.MaxCollectWeight)
            {

                RepotAbstract.IsScanRunning = true;
                // sleep 1ms didnt work it took too long
                for (int x = 930; x < 980; x++)
                {
                    for (int y = 500; y < 545; y++)
                    {
                        /*                        for (int i = -1; i < 2; i++)
                                                {
                                                    for (int z = -1; z < 2; z++)
                                                    {
                                                        MouseOperations.SetCursorPosition(x + (2 * i), y + (2 * z));
                        */
                        MouseOperations.SetCursorPosition(x , y);
                        ProgramHandle.waitMouseInPosScanUnder();
                        AttackWhenPointedOnMob();

                        if (whatToCollect.ClickAndCollectWhatItem())
                                {
                                    RepotAbstract.IsScanRunning = false;
                                    Debug.WriteLine("Under Foot Scan PixelScanUnderChar");
                                    GC.Collect();
                                    return true;
                                }
/*                            }
                        }
*/                    }

                }
            }
            GC.Collect();
            RepotAbstract.IsScanRunning = false;
            return false;
        }

    }
}
