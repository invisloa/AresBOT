using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManagement.Hershal;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot
{

    internal class HealBotUWC : HealBotAbstract
    {

        protected override IGoRepot RepoterCity
        {
            get
            {
                if (_repoterCity == null)
                { _repoterCity = new RepotUWC(); }
                return _repoterCity;
            }
        }
    }
}
