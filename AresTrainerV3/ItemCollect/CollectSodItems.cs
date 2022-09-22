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
            if (ProgramHandle.getCurrentItemHighlightedType == 202 || ProgramHandle.getCurrentItemHighlightedType == 183 || ProgramHandle.getCurrentItemHighlightedType == 167)// stones jewelery)
            {
                 Thread.Sleep(50);

                if (ProgramHandle.getCurrentItemHighlightedType == 202 || ProgramHandle.getCurrentItemHighlightedType == 183 || ProgramHandle.getCurrentItemHighlightedType == 167)// stones jewelery)
                {
                    return CollectionClick();
                }
            }
            return false;
        }
    }
}
