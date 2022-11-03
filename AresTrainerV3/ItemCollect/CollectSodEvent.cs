using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    internal class CollectSodEvent : AbstractWhatToCollect
    {
        protected override bool collectItemValues()
        {
            if (ProgramHandle.getCurrentItemHighlightedType == SOD || ProgramHandle.getCurrentItemHighlightedType == EventItems)
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