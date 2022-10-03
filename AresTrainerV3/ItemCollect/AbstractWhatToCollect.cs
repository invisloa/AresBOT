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
        protected const int SOD = -13799;
        protected const int jewelery = -19435;
        protected const int stones = -18452;
        protected abstract bool collectItemValues();
        public bool ClickAndCollectWhatItem()
        {
            if (collectItemValues())
            {
                Thread.Sleep(10);
                if (collectItemValues())
                {
                    return CollectionClick();
                }
            }
            return false;
        }

        protected bool CollectionClick()
        {
            Debug.WriteLine("Collect");

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            //make double LeftUp because somehow it didnt notice the click and bot bugged and stopped attacking
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            while (!ProgramHandle.isNowStandingOut())
            {
                Thread.Sleep(200); // !!!!!!!!!!!!!! TODO IS RUNNING ANIMATION
            }
            return true;
        }

    }
}
