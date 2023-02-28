using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
    internal class GoBackExpUWC : GoBackExpAbstract
    {
        public override void GoBackExp()
        {
            OLD_ExpBotClass.WalkIntoUWC();
        }

    }
}
