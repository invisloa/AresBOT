using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.SkillSelection
{
    public abstract class SkillSelector : ISelectSkill
    {
        protected int firstBuff, secondBuff, thirdBuff, fourthBuff;
		protected int expScroll = 2489;

		public static SkillSelector SelectPropperClass()
        {
            if (ProgramHandle.isCurrentClassSelected == 1)
            {
                return new SkillSelectorArcerAli();
            }
            else if (ProgramHandle.isCurrentClassSelected == 2)
            {
                return new SkillSelectorMageAlliance();
            }
            else if (ProgramHandle.isCurrentClassSelected == 3)
            {
                return new SkillSelectorSpearAlli();
            }
            else
                return new SkillSelectorKnightAlli();
        }
		bool buffIsNotActive(int buffValue)
		{
			foreach (var item in ProgramHandle.getBuffInformations)
			{
				if (buffValue == item)
				{ return false; }
			}
			return true;
		}
		protected void checkForWhitePotBuff()
		{
			if (buffIsNotActive(1697))
			{
				KeyPresser.PressKey(8, 75, 75);
			}
		}
		protected void checkForWhiteRed()
		{
			if (buffIsNotActive(1697))
			{
				KeyPresser.PressKey(7, 75, 75);
				KeyPresser.PressKey(8, 75, 75);
			}
		}
		protected void checkBuffAndClick(int buffValue, int buffPressKey)
		{
			if (buffIsNotActive(buffValue))
			{
				KeyPresser.PressKey(buffPressKey, 75, 75);
				KeyPresser.PressKey(buffPressKey, 75, 75);
				KeyPresser.PressKey(buffPressKey, 75, 75);
			}
		}

		protected void checkIfAttackSkillIsSelected()
        {
            if (ProgramHandle.isCurrentSkill() != 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ProgramHandle.isCurrentSkill() != 2)
                    {
                        KeyPresser.PressKey(3, 50, 50);
                        Thread.Sleep(2000);
                    }

                }
            }

        }
        public abstract void SkillAssign();
        public abstract void Rebuff();
        public void StartRebuffThread()
        {
                Thread SkillSelectorThread = new Thread(Rebuff);
                SkillSelectorThread.Start();
        }


    }
}
