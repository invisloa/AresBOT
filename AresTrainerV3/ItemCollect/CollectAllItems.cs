using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public class CollectAllItems : AbstractWhatToCollect
    {
        public override bool ClickAndCollectWhatItem()
        {

            if (ProgramHandle.isItemHighlighted != 0)
            {
                Thread.Sleep(200);

                if (ProgramHandle.isItemHighlighted != 0)
                {
                    return CollectionClick();
                }
            }
            return false;
    }
}
}
