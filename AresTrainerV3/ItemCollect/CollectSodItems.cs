using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public class CollectSodItems : AbstractWhatToCollect
    {
        bool collectItemValues()
        {
            if(PointersAndValues.isNostalgia == true)
            {
                if (ProgramHandle.getCurrentItemHighlightedType == 202 || ProgramHandle.getCurrentItemHighlightedType == 167)//  jewelery)
                    return true;
            }
            else 
            {
                if (ProgramHandle.getCurrentItemHighlightedType == 202 || ProgramHandle.getCurrentItemHighlightedType == 183 || ProgramHandle.getCurrentItemHighlightedType == 167)// stones jewelery)
                    return true;
            }
            return false;
        }
        public override bool ClickAndCollectWhatItem()
        {
            if (collectItemValues())
            {
                 Thread.Sleep(50);

                if (collectItemValues())
                {
                    return CollectionClick();
                }
            }
            return false;
        }
    }
}
