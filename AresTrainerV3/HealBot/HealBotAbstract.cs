﻿using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.HealBot.Repoter.Returner;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MoveRandom.Hershal;
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
        IGoRepot _repoterCity;
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
        IGoRepot repoterCity
        {
            get;
            set;
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
                hpHealValue = 380;
            }
            else
            {
                hpHealValue = myCurrentHp - 300;
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
        protected void StartHealBot()
        {
            SkillSelector ClassRebuffer = SkillSelector.SelectPropperClass();
            ProgramHandle.SetGameAsMainWindow();
            ClassRebuffer.StartRebuffThread();
            expPlaceToStartSetter();

            RequestStopHealBot();
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
                    Thread.Sleep(300000);
                    RepotAndStartExpBot();
                }
                if (myCurrentManna < MannaRestoreValue)
                {
                    MannaKeyPress();
                }
                WhiteRedPotionKeyPress();
                if (SellItems == true && ProgramHandle.getCurrentWeight > PointersAndValues.MaxCollectWeight)
                {
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
            if (ProgramHandle.getFirstSlotValue > PointersAndValues.ItemCount1 + 5) // if less then 5 use key 6 which is teleport
                {
                KeyPresser.PressKey(1, 100, 150);
            }
            else
                {
                RepotAndStartExpBot();
            }

        }
        public void RepotAndStartExpBot()
        {
            expPlaceToStartSetter();
            whatToCollectSetter();
            repoterCity.GoRepot();
            _goBackExpPlace.GoBackExp();
            ExpBotToStart.StartExpBotThread();

        }

        protected void MannaKeyPress()
        {
            {
                if (ProgramHandle.getSecondSlotValue > PointersAndValues.ItemCount1 + 2) // if less then 5 use key 6 which is teleport
                {
                    KeyPresser.PressKey(2, 100, 150);
                    /*                    if (SellItems == true && ProgramHandle.getCurrentWeight > PointersAndValues.MaxCollectWeight)
                                        {
                                        RepotAndStartExpBot();
                                        }
                    */
                }
                else
                {
                    RepotAndStartExpBot();
                }
            }

        }

        protected void WhiteRedPotionKeyPress()
        {

            // TO DO GET CURRENT CLASS AND SET PROPPER POTION USE
            if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassArcher)
            {
                /*                if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                                {
                                    KeyPresser.PressKey(8, 100, 100);
                                    KeyPresser.PressKey(7, 100, 100);
                                }
                */
                if (ProgramHandle.getCurrentAttackSpeed == PointersAndValues.attackSpeedKishValueBow)
                {
                    KeyPresser.PressKey(8, 100, 100);
                    KeyPresser.PressKey(7, 100, 100);
                }
            }
            else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSorcerer)
            {
                if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                {
                    KeyPresser.PressKey(8, 100, 100);
                }
            }

            else if (ProgramHandle.isCurrentClassSelected == PointersAndValues.ClassSpear)
            {
                if (ProgramHandle.getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                {
                    KeyPresser.PressKey(8, 100, 100);
                    // for now using with red potion later to change for a sorcerer
                    KeyPresser.PressKey(7, 100, 100);
                }
            }

        }




        protected IStartExpBotThread _expBotToStart;
        public MoverBotEnums whichBotThreadToStart
        {
            get;
            set;
        }
        public WhatToCollectEnums whatToCollect
        {
            get;
            set;
        }
        GoBackExpAbstract _goBackExpPlace;

        private AbstractWhatToCollect whatToCollectSetter()
        {
            if (whatToCollect == WhatToCollectEnums.Event)
            {
                return new CollectSodEvent();
            }
            else if (whatToCollect == WhatToCollectEnums.Stones)
            {
                return new CollectSodStones();
            }
            else if (whatToCollect == WhatToCollectEnums.Jewelery)
            {
                return new CollectSodJewelery();
            }
            else if (whatToCollect == WhatToCollectEnums.SellWeapons)
            {
                return new CollectSellerCry();
            }
            else if (whatToCollect == WhatToCollectEnums.SellAll)
            {
                return new CollectAllItems();
            }
            else
            {
                return new CollectSod();
            }
        }
        private void expPlaceToStartSetter()
        {
            if (whichBotThreadToStart == MoverBotEnums.NoRepot)
            {
               // System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                repoterCity = null;
                _goBackExpPlace = null;
            }
            else if (whichBotThreadToStart == MoverBotEnums.SacredThieves)
            {

            }
            else if (whichBotThreadToStart == MoverBotEnums.HolinaGoblins)
            {

            }
            else if (whichBotThreadToStart == MoverBotEnums.HershalLowLvl)
            {

            }
            else if (whichBotThreadToStart == MoverBotEnums.HershalLeafMages)
            {
                repoterCity = new RepoterHershalLeafMages();
                _goBackExpPlace = new GoBackExpHershalTeleport();
                _expBotToStart = new MoverHershalLeafMages() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
            }
            else if (whichBotThreadToStart == MoverBotEnums.HershalUWC1stFloor)
            {
                repoterCity = new RepoterHershalLeafMages();
                _goBackExpPlace = new GoBackExpUWC();
                _expBotToStart = new MoverHershalUwc1stFloor() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
            }
            else if (whichBotThreadToStart == MoverBotEnums.KharonWolves)
            {
                repoterCity = new RepoterKharonExp();
                _goBackExpPlace = new GoBackExpKharonWolves();
                _expBotToStart = new MoverKharonWolves() { attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(whatToCollectSetter())) };
                Thread blackScreenThread = new Thread(ProgramHandle.AntiBlackScreener);
                blackScreenThread.Start();

            }
        }

        protected IStartExpBotThread ExpBotToStart
        {
            get
            {
                expPlaceToStartSetter();
                return _expBotToStart;
            }
        }



    }
}
