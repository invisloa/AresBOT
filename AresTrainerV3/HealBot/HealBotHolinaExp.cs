using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot
{
    public class HealBotHolinaExp : HealBotAbstract
    {

        protected override IGoRepot RepoterCity
        {
            get
            {
                if (_repoterCity == null)
                { _repoterCity = new RepoterHolinaTeleport(); }
                return _repoterCity;
            }
        }
    }
}

