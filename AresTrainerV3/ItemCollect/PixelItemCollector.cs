using AresTrainerV3.AttackMob;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.ItemInventory;
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
        IWhatToCollect whatToCollect = new CollectSod();           // TEMPORARY TO DO TO CHANGE
		IWhatToCollect _whatToCollect { get { return whatToCollect; } set { whatToCollect = value; } }
        IWhatToCollect currentCollect;
		IWhatToCollect CollectIgnoringWeight = new CollectSod();

		int[] smallX = new int[2] { 850, 1170 };
		int[] smallY = new int[2] { 410, 730 };
		int[] bigX = new int[2] { 550, 1360 };
		int[] bigY = new int[2] { 290, 835 };
		int[] underCharX = new int[2] { 930, 980 };
		int[] underCharY = new int[2] { 500, 545 };
		Bitmap bitmap = new Bitmap(1370, 840);
		void BitmapCopyFromScreen()
        {
			Graphics graphics = Graphics.FromImage(bitmap as Image);
			graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
        }
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
        public PixelItemCollector(IWhatToCollect whatToCollect)
        {
            _whatToCollect = whatToCollect;
        }
        bool ScanAndCollect()
        {
            if (ProgramHandle.getCurrentWeight < AbstractWhatToCollect.MaxCollectWeight && ProgramHandle.isInCity != 1)
            {
                currentCollect = whatToCollect;
				return PixelScan();

			}
			else if (ProgramHandle.isInCity != 1)
            {
				currentCollect = CollectIgnoringWeight;
				return PixelScan();
            }
            return false;
       }
        public bool ScanClickAndCollectItem()
        {
            return ScanAndCollect();
        }

        bool PixelScan()
        {
            if (currentCollect == CollectIgnoringWeight || ProgramHandle.getCurrentWeight < AbstractWhatToCollect.MaxCollectWeight)
			{

				if (PixelScaner(smallX, smallY))
                {
                    return CollectSucces();
                }
                if (PixelScaner(bigX, bigY))
                {
                    return CollectSucces();
                }
            }
            return CollectFail();
        }
		public bool PixelScaner(int[] xSize, int[] ySize)
		{
			if (ExpBotManagerAbstract.isExpBotRunning == true)
			{
				RepotAbstract.IsScanRunning = true;
				BitmapCopyFromScreen();
				for (int x = xSize[0]; x < xSize[1]; x++)
				{
					for (int y = ySize[0]; y < ySize[1]; y++)
					{
						Color currentPixelColor = bitmap.GetPixel(x, y);
						if ((x < 934 || x > 979 || y < 500 || y > 538) && currentPixelColor == PointersAndValues.WhitePixelColor)
						{
							waitMouseAttackPointedMob(x, y);
							if (_whatToCollect.ClickAndCollectWhatItem())
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}
		public bool PixelScanUnderChar()
        {
            if (ExpBotManagerAbstract.isExpBotRunning == true)
            {
                if (currentCollect == CollectIgnoringWeight || ProgramHandle.getCurrentWeight < AbstractWhatToCollect.MaxCollectWeight)
                {
					ItemSeller.MoveItemsToStorage();
					if(PixelScaner(underCharX, underCharY))
                    {
                        return CollectSucces();
                    }
				}
			}
            return CollectFail();
        }
		public bool PixelSodWhileAttacking()
		{
			RepotAbstract.IsScanRunning = true;
            BitmapCopyFromScreen();
			if (ExpBotManagerAbstract.isExpBotRunning == true)
			{
				for (int x = 550; x < 1360; x++)
				{
					for (int y = 290; y < 835; y++)
					{
						Color currentPixelColor = bitmap.GetPixel(x, y);
						if ((x < 934 || x > 979 || y < 500 || y > 538) && currentPixelColor == PointersAndValues.WhitePixelColor)
						{
                            WaitMouseInPosition(x, y);
							if (CollectIgnoringWeight.ClickAndCollectWhatItem())
							{
                               return CollectSucces();
							}
						}
					}
				}
			}
            return CollectFail();
        }

        bool CollectSucces()
        {
			RepotAbstract.IsScanRunning = false;
			Debug.WriteLine("EndCollect");
			GC.Collect();
			return true;
		}
        bool CollectFail()
        {
			GC.Collect();
			RepotAbstract.IsScanRunning = false;
			return false;
		}
		void WaitMouseInPosition(int x, int y)
        {
			MouseOperations.SetCursorPosition(x, y);
			ProgramHandle.waitMouseInPosScanUnder();

		}
		void waitMouseAttackPointedMob(int x, int y)
		{
            WaitMouseInPosition(x, y);
			AttackWhenPointedOnMob();
		}

	}
}



// TO DO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
// small scan big scan using delegate as a method to run
