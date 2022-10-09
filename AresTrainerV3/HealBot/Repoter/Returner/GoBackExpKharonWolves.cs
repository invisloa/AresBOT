using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
    public class GoBackExpKharonWolves : GoBackExpAbstract
    {

        IGoRepot _repoterCity = new RepoterKharonExp();
        void GoOutOfTheZagroda()
        {
            ProgramHandle.SetCameraLong();
            MouseOperations.MoveAndLeftClickOperation(1040 + randomizer.Next(100), 390, 200);
            ProgramHandle.SetCameraForExpBot();

            while (!ProgramHandle.isNowRunningOut())
            {
                Thread.Sleep(1);
            }

        }
        void PassTheStuckMountain()
        {
            ProgramHandle.SetCameraLong();
            MouseOperations.MoveAndLeftClickOperation(1040 + randomizer.Next(100), 390, 200);
            while (!ProgramHandle.isNowRunningOut())
            {
                Thread.Sleep(1);
            }
            ProgramHandle.SetCameraForExpBot();

            for (int i = 0; i < 2 + randomizer.Next(3); i++)
            {
                MouseOperations.MoveAndLeftClickOperation(1050 + randomizer.Next(300), 200 + randomizer.Next(100), 10);
                while (ProgramHandle.isNowRunningOut())
                {
                    ProgramHandle.isNowRunningOut();
                }


            }
            ProgramHandle.SetCameraForExpBot();

        }

        public override void GoBackExp()
        {
            MouseOperations.MoveAndLeftClickOperation(800+randomizer.Next(-20,20), 295+randomizer.Next(-40,100), 400);
            while (!ProgramHandle.isNowStandingCity())
            {
                Thread.Sleep(1);
            }
            for (int i = 0; i < 10; i++)
            {
                if(ProgramHandle.GetCurrentMap == TeleportValues.Kharon && ProgramHandle.GetPositionX < 1124331952 && ProgramHandle.GetPositionX > 1123556437)
                {
                        MouseOperations.MoveAndLeftClickOperation(960, 400, 10);
                        Thread.Sleep(500);
                }
            }
            Thread.Sleep(randomizer.Next(3000,15000));
            if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
            {
                GoOutOfTheZagroda();
                PassTheStuckMountain();
                ProgramHandle.SetCameraForExpBot();
                Debug.WriteLine("GoBackExp zakończone");
            }
            else if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
            {
                KeyPresser.PressKey(6, 100, 100);
                Thread.Sleep(1000);
                _repoterCity.GoRepot();
            }

        }
    }
}
