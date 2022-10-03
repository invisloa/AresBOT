﻿using AresTrainerV3.HealBot.Repoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot
{
    internal class HealBotHershalExp : HealBotAbstract
    {

        protected override IGoRepot RepoterCity
        {
            get
            {
                if (_repoterCity == null)
                { _repoterCity = new RepoterHershalExp(); }
                return _repoterCity;
            }
        }
    }
}
