﻿using System;
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

            for (int i = 0; i < 2 + randomizer.Next(4); i++)
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
                Thread.Sleep(1000);
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon && ProgramHandle.GetPositionX < 1124331952 && ProgramHandle.GetPositionX > 1123556437)
                {
                        MouseOperations.MoveAndLeftClickOperation(960, 400, 50);
                        Thread.Sleep(500);
                }
            }
            Thread.Sleep(randomizer.Next(1000,5000));
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
