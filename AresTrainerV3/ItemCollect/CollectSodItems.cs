using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public class CollectSodItems : AbstractWhatToCollect
    {
        public override bool ClickAndCollectWhatItem()
        {
            if (ProgramHandle.getCurrentItemHighlightedType == 25)
            {
                Thread.Sleep(200);

                if (ProgramHandle.getCurrentItemHighlightedType == 25)
                {
                    return CollectionClick();
                }
            }
            return false;
        }
    }
}
