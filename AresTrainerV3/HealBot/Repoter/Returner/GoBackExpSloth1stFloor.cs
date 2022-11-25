using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
    internal class GoBackExpSloth1stFloor : GoBackExpAbstract
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
                if (teleportToSloth1stFloor())
                {
                    return true;
                }
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.SlothFloor1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool teleportToSloth1stFloor()
        {

            for (int i = 0; i < 3; i++)
            {
                if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        Thread.Sleep(1000);
                        ProgramHandle.TeleportToPositionTuple(TeleportValues.KharonPlateuSlothEntraceTuple);
                        Thread.Sleep(1000);
                        ProgramHandle.TeleportToPositionTuple(TeleportValues.KharonPlateuSlothEntraceTuple);
                        if (ProgramHandle.GetPositionX == 1148190218)
                        {
                            ProgramHandle.SetCameraForExpBot();
                            for (int z = 0; z < 8; z++)
                            {

                                MouseOperations.MoveAndLeftClickOperation(1060, 520, 150);
                                if (ProgramHandle.GetCurrentMap == TeleportValues.SlothFloor1)
                                {
                                    Thread.Sleep(1500);
                                    ProgramHandle.SetCameraForExpBot();
                                    MouseOperations.MoveAndLeftClickOperation(960 + randomizer.Next(200), 700 + randomizer.Next(60), 150);

                                    return true;
                                }
                            }
                        }
                    }

                }

            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.SlothFloor1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        bool teleportToKharonPlateu()
        {
            ProgramHandle.SetCameraForExpBot();
            for (int i = 0; i < 500; i++)
            {
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
                {
                    Thread.Sleep(10);
                    ProgramHandle.TeleportToPositionTuple(TeleportValues.KharonTeleportOutside);
                }
                else if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
                {
                    return true;
                }
            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
            {
                MouseOperations.MoveAndLeftClickOperation(930, 150, 100);
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
                {
                    ProgramHandle.SetCameraForExpBot();
                    MouseOperations.MoveAndLeftClickOperation(930, 460, 100);
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
                {
                    ProgramHandle.SetCameraForExpBot();
                    MouseOperations.MoveAndLeftClickOperation(930, 150, 100);
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.Kharon)
                {
                    ProgramHandle.SetCameraForExpBot();
                    MouseOperations.MoveAndLeftClickOperation(930, 460, 100);
                }
                if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
                {
                    return true;
                }

            }
            if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
