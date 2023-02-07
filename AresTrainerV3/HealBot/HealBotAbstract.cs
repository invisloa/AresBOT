using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.HealBot.Repoter.Returner.kharon;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom.Hershal;
using AresTrainerV3.MoveRandom.Holina;
using AresTrainerV3.MoveRandom.Kharon;
using AresTrainerV3.SkillSelection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3.HealBot
{
    public abstract class HealBotAbstract
    {
		public static bool SelfSetHealValue = false;
        public static bool SellItems = false;
        protected static bool _isHealBotRunning = false;
        public static bool IsHealBotRunning
        {
            get { return _isHealBotRunning; }
        }
        protected static int hpHealValue = 0;
        protected static int MannaRestoreValue = 0;
        protected int myCurrentHp { get { return ProgramHandle.getCurrentHp; } }
        protected int myCurrentManna { get { return ProgramHandle.getCurrentManna; } }
        protected void StopExpBot()
        {
            if (ExpBotManagerAbstract.isExpBotRunning)
            {
                ExpBotManagerAbstract.RequestStopExpBot();
            }
        }
        public static int HpHealValue
        {
            get
            {return hpHealValue; }
            set
            { hpHealValue = value; }
        }
        public static int MpRestoreValue
        {
            get
            { return MannaRestoreValue; }
            set
            { MannaRestoreValue = value; }
        }
        public void setHealbotValues()
        {
            setHealValue();
            setMannaRestoreValue();
        }
        void setHealValue()
        {
            if (myCurrentHp < 100)
            {
                hpHealValue = 30;
            }

            else if (myCurrentHp < 120)
            {
                hpHealValue = 40;
            }
            else if (myCurrentHp < 150)
            {
                hpHealValue = 60;
            }
            else if (myCurrentHp < 200)
            {
                hpHealValue = 120;
            }
            else if (myCurrentHp < 250)
            {
                hpHealValue = 130;
            }
            else if (myCurrentHp < 300)
            {
                hpHealValue = 150;
            }
            else if (myCurrentHp < 350)
            {
                hpHealValue = 180;
            }
            else if (myCurrentHp < 400)
            {
                hpHealValue = 200;
            }
            else if (myCurrentHp < 500)
            {
                hpHealValue = 300;
            }
            else if (myCurrentHp < 600)
            {
                hpHealValue = 340;
            }
			else if (myCurrentHp < 650)
			{
				hpHealValue = 400;
			}
			else if (myCurrentHp < 850)
			{
				hpHealValue = 550;
			}
			else if (myCurrentHp < 1050)
			{
				hpHealValue = 700;
			}
			else if (myCurrentHp < 1250)
			{
				hpHealValue = 900;
			}
			else
			{
                hpHealValue = myCurrentHp - 500;
            }
        }
        void setMannaRestoreValue()
        {
            if (myCurrentManna < 20)
            {
                MannaRestoreValue = 6;
            }

            else if (myCurrentManna < 30)
            {
                MannaRestoreValue = 8;
            }

            else if (myCurrentManna < 50)
            {
                MannaRestoreValue = 15;
            }
            else if (myCurrentManna < 80)
            {
                MannaRestoreValue = 21;
            }

            else if (myCurrentManna < 100)
            {
                MannaRestoreValue = 30;
            }

            else if (myCurrentManna < 200)
            {
                MannaRestoreValue = 40;
            }
            else if (myCurrentManna < 300)
            {
                MannaRestoreValue = 80;

            }
			else if (myCurrentManna < 400)
			{
				MannaRestoreValue = 90;
			}
			else if (myCurrentManna < 500)
			{
				MannaRestoreValue = 100;
			}
			else if (myCurrentManna < 600)
			{
				MannaRestoreValue = 150;
			}
			else
			{
                MannaRestoreValue = 200;
            }
        }

        public static void RequestStartStopHealBot()
        {
            if (_isHealBotRunning)
                _isHealBotRunning = false;
            else
                _isHealBotRunning = true;
        }
        protected void StartHealBot()
        {
            ProgramHandle.SetGameAsMainWindow();
            expPlaceRepoterBotToStartSetter();
            RequestStartStopHealBot();

            SkillSelector ClassRebuffer = SkillSelector.SelectPropperClass();
            ClassRebuffer.StartRebuffThread();

            if (SelfSetHealValue)
            {
                setHealValue();
                setMannaRestoreValue();
            }
            while (_isHealBotRunning)
            {
                if (myCurrentHp < hpHealValue && myCurrentHp != 0)
                {
                    HealKeyPress();
                }
                else if (myCurrentHp == 0)
                {
                    StopExpBot();
                    Thread.Sleep(60000);
                    RepotAndStartExpBot();
                }
                if (myCurrentManna < MannaRestoreValue)
                {
                    MannaKeyPress();
                }
                if (SellItems == true && ProgramHandle.getCurrentWeight > AbstractWhatToCollect.MaxCollectWeight && ProgramHandle.isInCity !=1)
                {
                    // try to make storage repot and items move
                    RepotAndStartExpBot();
                }

            }
            return;

        }
        
        public void StartHealBotThread()
        {
            Thread HealbotThread = new Thread(StartHealBot);
            HealbotThread.Start();
        }

        protected void HealKeyPress()
        {
            if (ProgramHandle.getFirstInvSlotValue > PointersAndValues.InvPotCount(7))
            {
                KeyPresser.PressKey(1, 50, 50);
            }
            else
            {
                RepotAndStartExpBot();
            }

        }
        public void RepotAndStartExpBot()
        {
            if (repoterCity == null)
            {
                expPlaceRepoterBotToStartSetter();
                Factory.whatToCollectSetter();
            }
            repoterCity.GoRepot();
            _goBackExpPlace.GoBackExp();
            ExpBotToStart.StartExpBotThread();
        }

        protected void MannaKeyPress()
        {
            {
                if (ProgramHandle.getSecondSlotValue > PointersAndValues.InvPotCount(3)) // if less then 5 use key 6 which is teleport
                {
                    KeyPresser.PressKey(2, 100, 150);
                }
                else
                {
                    RepotAndStartExpBot();
                }
            }

        }
    }
}
