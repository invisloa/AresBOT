using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    public class CollectAllItems : AbstractWhatToCollect
    {
        protected override bool collectItemValues()
        {
            if (ProgramHandle.getCurrentItemHighlightedType != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
