using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManagement.Sacred;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.StorageRepot
{
    internal class StorageRepoter : BuyerPotions, IGoRepot, IGoBackExpAbstract
    {
        Tuple<int, int, int> startExpPosition;
        protected IStartExpBotThread _expBotToStart;
        protected IStartExpBotThread ExpBotToStart
        {
            get
            {
                if (_expBotToStart == null)
                {
                    _expBotToStart = new ExpBotSacredBaldor2floorStorageBuy();
                }
                return _expBotToStart;
            }
        }

        protected Tuple<int,int,int> SafeTeleportPlace()
        {
            if (ProgramHandle.GetCurrentMap == TeleportValues.BaldorTempleSecondFloor)
            {
                return TeleportValues.SafePosBaldorTemple2Floor;
            }
            else
                return null;
        }

        public override void BuyPotions()
        {
            base.BuyPotionsAbstract(200, false, 100, 5, ExpBotMovePositionsValues.mousePositionsForStorageBuying);

        }

        public void GoBackExp()
        {
            ProgramHandle.TeleportToPositionTuple(startExpPosition);
        }

        public void GoRepot()
        {
            if (ExpBotManagerAbstract.isExpBotRunning)
            {
                ExpBotManagerAbstract.RequestStopExpBot();
            }
            ProgramHandle.TeleportToPositionTuple(SafeTeleportPlace());
            Thread.Sleep(1000);
            if (ProgramHandle.GetCurrentMap == TeleportValues.BaldorTempleSecondFloor)
            { 
                ProgramHandle.OpenStorageWindow();
                BuyPotions();
                KeyPresser.PressEscape();
                GoBackExp();
                ExpBotToStart.StartExpBotThread();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}
