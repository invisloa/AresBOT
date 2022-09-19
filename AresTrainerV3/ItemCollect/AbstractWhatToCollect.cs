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
        public abstract bool ClickAndCollectWhatItem();

        protected bool CollectionClick()
        {
            Debug.WriteLine("Collect");

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            //make double LeftUp because somehow it didnt notice the click and bot bugged and stopped attacking
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            while (ExpBotClass.isNowRunningOut())
            {
                Thread.Sleep(500); // !!!!!!!!!!!!!! TODO IS RUNNING ANIMATION
            }
            return true;
        }

    }
}
