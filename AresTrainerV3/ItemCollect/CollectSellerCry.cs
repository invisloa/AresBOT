using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.ItemCollect
{
    internal class CollectSellerCry : AbstractWhatToCollect
    {
        protected override bool collectItemValues()
        {
            if (ProgramHandle.getCurrentItemHighlightedType == SOD || ProgramHandle.getCurrentItemHighlightedType == jewelery ||
                ProgramHandle.getCurrentItemHighlightedType == cryBow || ProgramHandle.getCurrentItemHighlightedType == cryOrb ||
                ProgramHandle.getCurrentItemHighlightedType == cryPhasor || ProgramHandle.getCurrentItemHighlightedType == crySword
                || ProgramHandle.getCurrentItemHighlightedType == cryStaff || ProgramHandle.getCurrentItemHighlightedType == stones)
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