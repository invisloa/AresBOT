using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot
{
    internal class HealBotSacredAlli : HealBotAbstract
    {

        protected override IGoRepot RepoterCity
        {
            get
            {
                if (_repoterCity == null)
                { _repoterCity = new RepoterSacredAlliance(); }
                return _repoterCity;
            }
        }
    }
}

