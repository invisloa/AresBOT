using AresTrainerV3.Buyer;
using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom.Hershal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterHershalLeafMages : RepotAbstract
    {
        protected override GoBackExpAbstract GoBackExpPlace
        {
            get
            {
                if (_goBackExpPlace == null)
                {
                    _goBackExpPlace = new GoBackExpHershalTeleport();
                }
                return _goBackExpPlace;
            }
        }

        protected override BuyerPotions BuyerPotionsCity
        {
            get
            {
                if (_buyerPotionsCity == null)
                {
                    _buyerPotionsCity = new BuyerPotionsHershalExp();
                }
                return _buyerPotionsCity;
            }
        }
        protected override int repotCityCheck
        {
            get
            {
                _repotCityVerification = TeleportValues.Hershal;
                return _repotCityVerification;
            }
        }
        protected override IStartExpBotThread ExpBotToStart
        {
            get
            {
                if (_expBotToStart == null)
                {
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    _expBotToStart = new MoverHershalLeafMages() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSellerCry()))};
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO CHANGE TEMPORARY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                }
                return _expBotToStart;
            }
        }

        protected override void MoveToRepot()
        {
            Thread.Sleep(500);
            CheckIfNotRunning();
            if (ProgramHandle.isNowStandingCity())
            {
                for (int i = 0; i < 20; i++)
                {
                    if (ProgramHandle.GetCurrentMap == TeleportValues.Hershal)
                    {
                        if (ProgramHandle.GetPositionX != 1142172652 && ProgramHandle.GetPositionY != 1141596108)
                        {
                            KeyPresser.PressKey(6, 500, 500);
                        }
                    }
                }
            }
            MoveToRepotWithPositions(ExpBotMovePositionsValues.HershalRepotMovePositions);
        }
    }
}
