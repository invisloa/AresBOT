using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.PixelScanOperations
{
    internal interface IClickableWhenPointed
    {
        bool CollectWhenPointed(bool collectAll,bool collectOnlySod);
    }
}
