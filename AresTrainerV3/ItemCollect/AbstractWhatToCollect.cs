﻿using AresTrainerV3.MoveModels.MoveRandom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public abstract class AbstractWhatToCollect : IWhatToCollect
    {
        IUnbugWhenCollecting ItemCollectUnbuger = Factory.CreateCollectItemUnbugger();


		public static int MaxCollectWeight;
        public static int MaxCollectWeightNormalValue;
        protected const int SOD = -13799;
        protected const int EventItems = 32627;
        protected const int jewelery = -19435;
        protected const int stones = -18452;

        //cry items
        protected const int cryBow = -25143;
        protected const int cryOrb= 25403;
        protected const int cryPhasor= 19725;
        protected const int crySword = 21230;
        protected const int cryStaff = 25403;

        //hecatomb items
        protected const int hecatombGloves = -9855;
        protected const int hecatombHat = -14515;
        protected const int hecatombArmor = 6657;
        protected const int hecatombBoots = 3810;

        protected abstract bool collectItemValues();
        public bool ClickAndCollectWhatItem()
        {
			if (ProgramHandle.getCurrentItemHighlightedType == SOD)
            {
				CollectionClick();
			}

			if (collectItemValues())
            {
                Thread.Sleep(1);
                Thread.Sleep(1);
                Thread.Sleep(1);
				Thread.Sleep(1);
				Thread.Sleep(1);
				Thread.Sleep(1);
				if (collectItemValues())
                {
                    CollectionClick();
                    return true;
                }
            }
            return false;
        }
        protected void CollectionClick()
        {
            int positionBeforeClick = ProgramHandle.GetPositionShortX;
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MoverRandom.AttackedOrCollected = true;
            Debug.WriteLine("Collect"+ ProgramHandle.getCurrentItemHighlightedType);
            Thread.Sleep(50);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            while (!ProgramHandle.isNowStandingOut() && !ProgramHandle.isNowStandingCity())
            {
                Debug.WriteLine("collecting while");
                Thread.Sleep(10);
            }
            ItemCollectUnbuger.UnbugWhenCollecting(positionBeforeClick);
			PixelItemCollector underCharPostScanner = new PixelItemCollector(this);
			underCharPostScanner.PixelScanUnderChar();
        }

    }
}
