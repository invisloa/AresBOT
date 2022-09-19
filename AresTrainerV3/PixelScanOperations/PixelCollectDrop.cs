/*using AresTrainerV3.Unstuck;
using AresTrainerV3.AttackMob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.PixelScanOperations
{
    public class PixelCollectDrop : IClickableWhenPointed
    {
        public bool ScanAndCollect(int collectFromWeight, bool collectAll, bool collectOnlySod, IUnstuckPosition checkIfNotStuck)
        {
             //if not running animation
            if (ExpBotClass.isNowStandingOut())
            {
                if (ProgramHandle.getCurrentWeight < collectFromWeight)
                {
                    checkIfNotStuck.UnstuckMove();
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
                            if ((x < 928 || x > 985 || y < 490 || y > 550) && desiredPixelColor == currentPixelColor)
                            {
                                Debug.WriteLine("pixel Collect");
                                for (int i = -5; i < 5; i++)
                                {
                                    for (int z = -5; z < 5; z++)
                                    {
                                        MouseOperations.SetCursorPosition(x + i, y + z);
                                        if (CollectWhenPointed(collectAll, collectOnlySod))
                                        {
                                            Debug.WriteLine("EndCollect");
                                            GC.Collect();
                                            return true;
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        void ClickMouseToCollect()
        {
            Debug.WriteLine("Collect Item");

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(30);
            //make double LeftUp because somehow it didnt notice the click and bot bugged and stopped attacking
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            while (!ExpBotClass.isNowStandingOut())
            {
                Thread.Sleep(50); // !!!!!!!!!!!!!! TODO IS RUNNING ANIMATION
            }

            Thread.Sleep(300);
        }

        public bool CollectWhenPointed(bool collectAll,bool collectOnlySod)
        {
            if (collectAll)
            {
                if (ProgramHandle.isCurrentItemHighlightedType() != 0)
                {
                    //for now its here but when number above will be sod then it has to be changed
                   // AttackMob.CheckIfSelectedAndAttackSkill();

                    Thread.Sleep(50);
                    if (ProgramHandle.isCurrentItemHighlightedType() != 0)
                    {
                        ClickMouseToCollect();
                        return true;
                    }
                }
                return false;
            }
            else if (collectOnlySod)
            {
                if (ProgramHandle.isCurrentItemHighlightedType() == 25)
                {
                    //for now its here but when number above will be sod then it has to be changed
                   // AttackMob.CheckIfSelectedAndAttackSkill();

                    Thread.Sleep(50);
                    if (ProgramHandle.isCurrentItemHighlightedType() == 25)
                    {
                        ClickMouseToCollect();
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }

        }
    }
}
*/