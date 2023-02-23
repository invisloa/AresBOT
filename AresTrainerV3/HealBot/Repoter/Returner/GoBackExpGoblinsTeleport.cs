using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter.Returner
{
    internal class GoBackExpGoblinsTeleport : GoBackExpAbstract
    {
        public override void GoBackExp()
        {
            ProgramHandle.SetCameraForExpBot();
            if (Factory.WhichBotThreadToStart == Enums.EnumsList.MoverBotEnums.HolinaGoblins)
            {
                ProgramHandle.TeleportToPositionTuple(TeleportValues.HolinaGoblinsExp);
            }
			else if (Factory.WhichBotThreadToStart == Enums.EnumsList.MoverBotEnums.BucksLowLVL)
			{
				ProgramHandle.TeleportToPositionTuple(TeleportValues.HolinaBucksLowLVLExp);
			}
			ProgramHandle.SetCameraForExpBot();

        }
    }
}
