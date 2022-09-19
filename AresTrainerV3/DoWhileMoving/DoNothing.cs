using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.DoWhileMoving
{
    public class DoNothing : IDoWhileMoving
    {
        public bool DoThisWhileMoving()
        {
            return false; // does nothing while moving
        }
    }
}
