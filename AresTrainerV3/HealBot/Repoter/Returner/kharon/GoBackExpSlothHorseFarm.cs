﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner.kharon
{
    public class GoBackExpSlothHorseFarm : GoBackExpAbstractKharonTelep
	{


        IGoRepot _repoterCity = new RepoterKharonExp();
        public override void GoBackExp()
        {
            teleportToSloth1stExpBot();
        }

        bool teleportToSloth1stExpBot()
        {
            Thread.Sleep(1000);

            if (teleportToKharonPlateu())
            {
                if (teleportToSlothHorse())
                {
                    return true;
                }
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.KharonHorse)
            {
                ProgramHandle.TeleportToPositionTuple(TeleportValues.SlothHorseFarm);
                return true;
            }
            else
            {
                return false;
            }

        }
        bool teleportToSlothHorse()
        {

            for (int i = 0; i < 3; i++)
            {
                if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        Thread.Sleep(1000);
                        ProgramHandle.TeleportToPositionTuple(TeleportValues.SlothHorseEntrace);
                        Thread.Sleep(1000);
                        ProgramHandle.TeleportToPositionTuple(TeleportValues.SlothHorseEntrace);
                        ProgramHandle.SetCameraForExpBot();
                        for (int z = 0; z < 8; z++)
                        {

                            MouseOperations.MoveAndLeftClickOperation(890, 460, 150);
                            if (ProgramHandle.GetCurrentMap == TeleportValues.KharonHorse)
                            {
                                Thread.Sleep(1500);
                                ProgramHandle.TeleportToPositionTuple(TeleportValues.SlothHorseFarm);
                                ProgramHandle.SetCameraForExpBot();

                                return true;
                            }
                        }
                    }

                }
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.KharonHorse)
            {
                ProgramHandle.TeleportToPositionTuple(TeleportValues.SlothHorseFarm);
                ProgramHandle.SetCameraForExpBot();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
