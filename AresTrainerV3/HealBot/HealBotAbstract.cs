using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.SkillSelection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot
{
    public abstract class HealBotAbstract
    {
        public static bool IsScanRunning = false;
        protected static bool _isHealBotRunning = false;
        protected IGoRepot _repoterCity;
        public static bool IsHealBotRunning
        {
            get { return _isHealBotRunning; }
        }
        protected int hpHealValue = 0;
        protected int MannaRestoreValue = 0;
        protected int myCurrentHp { get { return ProgramHandle.getCurrentHp; } }
        protected int myCurrentManna { get { return ProgramHandle.getCurrentManna; } }
        abstract protected IGoRepot RepoterCity
        {
            get;
        }

        void setHealValue()
        {
            if (myCurrentHp < 200)
            {
                hpHealValue = 100;
            }
            else if (myCurrentHp < 400 && myCurrentHp > 200)
            {
                hpHealValue = 200;

            }
            else
            {
                hpHealValue = myCurrentHp - 340;
            }
        }
        void setMannaRestoreValue()
        {            
            if (myCurrentManna < 100)
            {
                MannaRestoreValue = 30;
            }

            else if (myCurrentManna < 200)
            {
                MannaRestoreValue = 40;
            }
            else if (myCurrentManna < 400 && myCurrentHp > 200)
            {
                MannaRestoreValue = 80;

            }
            else if (myCurrentManna < 600 && myCurrentHp > 400)
            {
                MannaRestoreValue = 90;

            }
            else
            {
                MannaRestoreValue = 100;
            }
        }
        public static void RequestStopHealBot()
        {
            if (_isHealBotRunning)
                _isHealBotRunning = false;
            else
                _isHealBotRunning = true;
        }
        protected void StopExpBot()
        {
            if (ExpBotManagerAbstract.isExpBotRunning)
            {
                ExpBotManagerAbstract.RequestStartStopExpBot();
            }
        }
        protected bool isNowStandingCity()
        {
            if (ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerEmpCity || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationArcerAlliCity || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcAlliCity || ProgramHandle.isWhatAnimationRunning() == PointersAndValues.isStandingAnimationSorcEmpCityF)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool press1IfLowHp()
        {
            if (myCurrentHp < hpHealValue && myCurrentHp != 0)
            {
                KeyPresser.PressKey(1, 500, 500);
                return true;
            }
            return false;
        }
        protected bool press2IfLowManna()
        {
            if (myCurrentManna < MannaRestoreValue)
            {
                KeyPresser.PressKey(2, 500, 500);
                return true;
            }
            return false;

        }
/*        protected void scrollToCityIfNotInCity()
        {
            if (ProgramHandle.isWhatAnimationRunning != isNowStandingCity)
            {
                KeyPresser.PressKey(6, 500, 500);
                Debug.WriteLine("Not in city use scroll");
            }
        }
*/
        protected void teleportToCityAndStopExpBot()
        {
            StopExpBot();
            KeyPresser.PressKey(6, 100, 100);
            Thread.Sleep(1000);
            while (IsScanRunning)
            {
                Thread.Sleep(20);
            }

                // scrollToCityIfNotInCity();
                while (press1IfLowHp()) ;
            while (press2IfLowManna()) ;
        }
        protected void StartHealBot()
        {
            ProgramHandle.SetForegroundWindow(ProgramHandle.FindWindow(null, ProgramHandle.foregroundWindowName));
            if (!IsHealBotRunning)
            {
                RequestStopHealBot();
            }
            setHealValue();
            setMannaRestoreValue();

            while (_isHealBotRunning)
            {
                if (myCurrentHp < hpHealValue && myCurrentHp != 0)
                {
                    HealKeyPress();
                }
                else if (myCurrentHp == 0)
                {
                    StopExpBot();

                    Thread.Sleep(300000);
                    RepoterCity.GoRepot();
                    // HealBotTeleportRepotGoUWC();  // GO EXP IN UWC
                }
                if (myCurrentManna < MannaRestoreValue)
                {
                    MannaKeyPress();
                }
                WhiteRedPotionKeyPress();
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
            if (ProgramHandle.getFirstSlotValue > PointersAndValues.ItemCount1 + 8) // if less then 5 use key 6 which is teleport
                {
                KeyPresser.PressKey(1, 100, 100);
                }
            else
                {
                teleportToCityAndStopExpBot();
                RepoterCity.GoRepot();
                }

        }


        protected void MannaKeyPress()
        {
            {
                if (ProgramHandle.getSecondSlotValue > PointersAndValues.ItemCount1 + 5) // if less then 5 use key 6 which is teleport
                {
                    KeyPresser.PressKey(2, 100, 100);
                }
                else
                {
                    teleportToCityAndStopExpBot();

                    RepoterCity.GoRepot();
                }
            }

        }

        protected void WhiteRedPotionKeyPress()
        {

            // TO DO GET CURRENT CLASS AND SET PROPPER POTION USE
            if (ProgramHandle.isCurrentClassSelected == 1)
            {
                if (ProgramHandle.getCurrentAttackSpeed == PointersAndValues.attackSpeedKishValueBow)
                {
                    KeyPresser.PressKey(8, 100, 100);
                    // for now using with red potion later to change for a sorcerer
                    KeyPresser.PressKey(7, 100, 100);
                }
            }
            if (ProgramHandle.isCurrentClassSelected == 2)
            {
                if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                {
                    KeyPresser.PressKey(8, 100, 100);
                }
            }

            else if (ProgramHandle.isCurrentClassSelected == 3)
            {
                if (ProgramHandle.getCurrentAttackSpeed < PointersAndValues.attackSpeedKishValueBow)
                {
                    KeyPresser.PressKey(8, 100, 100);
                    // for now using with red potion later to change for a sorcerer
                    KeyPresser.PressKey(7, 100, 100);
                }
            }
        }


    }
}
