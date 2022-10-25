using AresTrainerV3.Buyer;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter.Returner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
    internal class RepoterOnlyHealbot : IGoRepot
    {


        public void GoRepot()
        {
            Console.WriteLine("noRepotInThis");
            KeyPresser.PressKey(6, 200, 200);
            KeyPresser.PressKey(6, 200, 200);
            HealBotAbstract.RequestStopHealBot();   
            ExpBotManagerAbstract.RequestStopExpBot();

        }

        /*        protected override GoBackExpAbstract GoBackExpPlace
                {
                    get
                    {
                        if (_goBackExpPlace == null)
                        {
                            _goBackExpPlace = new GoBackOnlyHealbot();
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
                            _buyerPotionsCity = new BuyerPotionsKharonExp();
                        }
                        return _buyerPotionsCity;
                    }
                }


                protected override int repotCity
                {
                    get
                    {
                        if (_repotCityVerification == null)
                        {
                            _repotCityVerification = TeleportValues.Kharon;
                        }
                        return _repotCityVerification;
                    }
                }

                GoBackExpAbstract _GoBackExpPlace = new GoBackOnlyHealbot();
                protected override GoBackExpAbstract GoBackExpPlace
                {
                    get { return _GoBackExpPlace; }
                }

                protected override BuyerPotions BuyerPotionsCity => throw new NotImplementedException();

                protected override int repotCity => throw new NotImplementedException();






                protected override void GoBackToExpSpot()
                {

                }

                protected override void MoveToRepot()
                {

                }

                protected override void RestartExpBot()
                {

                }
        */
    }
}
