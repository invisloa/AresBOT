using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
    public abstract class GoBackExpAbstract : IGoBackExpAbstract
    {
        protected Random randomizer = new Random();
        public abstract void GoBackExp();
    }
}
