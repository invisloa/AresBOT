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
            int i = 1;
            ProgramHandle.SetCameraForExpBot();
            ProgramHandle.SetCameraLong();
            ProgramHandle.SetCameraLong();
            MouseOperations.MoveAndLeftClickOperation(1040 + randomizer.Next(100), 390, 200);
            ProgramHandle.SetCameraForExpBot();

/*            while (ProgramHandle.isNowStandingCity())
            {
                i++;
                Thread.Sleep(1);
                if(i >5000)
                {
                    Debug.WriteLine("go repot stuck zagroda");
                    RepoterKharonExp repotWhenStuck = new RepoterKharonExp();
                    repotWhenStuck.GoRepot();
                }
            }
*/        }
        void PassTheStuckMountain()
        {
            ProgramHandle.SetCameraLong();
            MouseOperations.MoveAndLeftClickOperation(1040 + randomizer.Next(100), 390, 200);
            while (!ProgramHandle.isNowRunningOut())
            {
                Thread.Sleep(1);
            }
            ProgramHandle.SetCameraForExpBot();

            for (int i = 0; i < 15 + randomizer.Next(10); i++)
            {
                MouseOperations.MoveAndLeftClickOperation(1050 + randomizer.Next(300), 200 + randomizer.Next(200), 10);
                while (ProgramHandle.isNowRunningOut())
                {
                    ProgramHandle.isNowRunningOut();
                }
            }
            ProgramHandle.SetCameraForExpBot();
            if (ProgramHandle.isInCity == 1)
            {
                Thread.Sleep(10000);
                Form1.HealbotToRun.RepotAndStartExpBot();

            }

        }

        public override void GoBackExp()
        {
            MouseOperations.MoveAndLeftClickOperation(800+randomizer.Next(-20,20), 295+randomizer.Next(-40,100), 150);
            while (!ProgramHandle.isNowStandingCity())
            {
                Thread.Sleep(1);
            }
            for (int i = 0; i < 10; i++)
            {
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon && ProgramHandle.GetPositionX < 1124331952 && ProgramHandle.GetPositionX > 1123556437)
                {
                        MouseOperations.MoveAndLeftClickOperation(960, 400, 50);
                        Thread.Sleep(2000);
                }
            }
            Thread.Sleep(randomizer.Next(2000,5000));
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
                Thread.Sleep(50000);
                _repoterCity.GoRepot();
            }

        }
    }
}
