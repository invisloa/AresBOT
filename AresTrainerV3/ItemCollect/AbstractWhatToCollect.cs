using AresTrainerV3.MoveRandom;
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
        public static int MaxCollectWeight = 1500;

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
            if (collectItemValues())
            {
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
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MoverRandom.AttackedOrCollected = true;
            Debug.WriteLine("Collect"+ ProgramHandle.getCurrentItemHighlightedType);
            Thread.Sleep(500);

            //make double LeftUp because somehow it didnt notice the click and bot bugged and stopped attacking
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(500);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            while (!ProgramHandle.isNowStandingOut())
            {
                Debug.WriteLine("collecting while");
            Thread.Sleep(200); // !!!!!!!!!!!!!! TODO IS RUNNING ANIMATION
            }
            Thread.Sleep(50);
            PixelItemCollector underCharPostScanner = new PixelItemCollector(this);
            underCharPostScanner.PixelScanUnderChar(this);
        }

    }
}
