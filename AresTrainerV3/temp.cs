﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3
{
    internal class temp
    {

        /*
                       public static bool ScanAndAttackNoDebug()
                {
                    Bitmap bitmap = getScreenBitmap();
                    Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
                    // X and Y  set to start search only for LOA window
                    for (int x = 527; x < 1360; x++)
                    {

                        for (int y = 237; y < 835; y++)
                        {


                            Color currentPixelColor = bitmap.GetPixel(x, y);
                            if ((x < 938 || x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)

                            {

                                MouseOperations.SetCursorPosition(x, y);
                                if (ProgramHandle.AttackMobWhenSelected())
                                {
                                    Debug.WriteLine("attack");
                                    GC.Collect();
                                    return true;

                                };
                            }
                        }
                    }
                    GC.Collect();
                    return false;
                }
                public static bool ScanAndAttackWithDebug()
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                    Color desiredPixelColor = ColorTranslator.FromHtml("#000000");
                    // X and Y  set to start search only for LOA window
                    for (int x = 527; x < 1360; x++)
                    {

                        for (int y = 237; y < 835; y++)
                        {

                            //MouseOperations.SetCursorPosition(x, y);

                            Color currentPixelColor = bitmap.GetPixel(x, y);
                            if ((x < 938 || x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)

                            {
                                Debug.WriteLine("pixel attack");

                                MouseOperations.SetCursorPosition(x, y);
                                if (ProgramHandle.AttackMobWhenSelected())
                                {
                                    Debug.WriteLine("EndAttack");

                                    GC.Collect();
                                    return true;

                                };
                            }
                        }
                    }
                    GC.Collect();
                    return false;
                }


                static bool ScanAndCollect()
                {
                    Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
                    for (int x = 527; x < 1360; x++)
                    {
                        for (int y = 237; y < 835; y++)
                        {
                            Color currentPixelColor = bitmap.GetPixel(x, y);
                            if ((x < 928 || x > 985 || y < 490 || y > 550) && desiredPixelColor == currentPixelColor)
                            {
                                Debug.WriteLine("pixel Collect");

                                MouseOperations.SetCursorPosition(x, y);
                                if (ExpBotClass.ClickAndCollectItem())
                                {
                                    Debug.WriteLine("EndCollect");

                                    GC.Collect();

                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                }


                public static void ScanAndAttackAndCollect()
                {
                    if (!ScanAndAttackNoDebug()) 
                    {
                        ScanAndCollect();
                    }
                    Debug.WriteLine("Check weight");
                    if (ProgramHandle.getCurrentWeight > 1800)
                    {
                        ProgramHandle.HealBotRepotKharonSell();
                    }

                    GC.Collect();
                }


                public static void PixelOnlyScanAndAttack()
                {
                    ProgramHandle.SetCameraForExpBot();
                    if (!ProgramHandle.isStopHeal)
                    {
                        Form1.StartHealBotThreadNormal();
                    }


                    while (_stopPixelAttack)
                    {

                        ScanAndAttackNoDebug();
                        GC.Collect();
                    }
                }

                public static void ScanAndCollectItemsStandAlone()
                {
                    Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics = Graphics.FromImage(bitmap as Image);
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                    Color desiredPixelColor = ColorTranslator.FromHtml("#FFFFFF");
                    // for (int x = 527; x < 1360; x++)  OLD VALUES 
                    for (int x = 700; x < 1200; x++)   // SEARCH RANGE WAS LOWERED
                    {

                       // for (int y = 237; y < 835; y++) OLD VALUES
                            for (int y = 335; y < 735; y++) // SEARCH RANGE WAS LOWERED
                        {

                                //MouseOperations.SetCursorPosition(x, y);

                                Color currentPixelColor = bitmap.GetPixel(x, y);

                            if ((x < 938 || x > 976 || y < 502 || y > 540) && desiredPixelColor == currentPixelColor)
                            {
                                MouseOperations.SetCursorPosition(x, y);
                                ExpBotClass.ClickAndCollectItem();
                                return;
                            }
                        }
                    }
                    GC.Collect();
                }
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


            }

        */
















    }
}