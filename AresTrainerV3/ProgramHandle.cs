﻿using AresTrainerV3.SkillSelection;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;

namespace AresTrainerV3
{



    public class ProgramHandle
    {

        public static string processName = PointersAndValues.GameProcessName;
        public static string foregroundProcessName = PointersAndValues.GameWindowProcessName;
        public static string foregroundWindowName = PointersAndValues.GameWindowVisualName;

        static int _variableForChangablePosition = 0;

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        static volatile int hpValue = 0;
        static volatile int mannaValue = 0;

        // FOR 1HITKO TESTING
        // FOR 1HITKO TESTING
        // FOR 1HITKO TESTING
        // FOR 1HITKO TESTING
       // static int Test1HitChangableValue = 40002;
        public static int SkillToOverride = PointersAndValues.arcerEmpBlasting;
        // FOR 1HITKO TESTING
        // FOR 1HITKO TESTING
        // FOR 1HITKO TESTING

        static IntPtr baseAddress = IntPtr.Zero;
        static IntPtr client = IntPtr.Zero;
        static Memory memNormal = new Memory();
        static Memory memSkill = new Memory();
        static Memory memRebuff = new Memory();
        static Memory memHealBot = new Memory();
        static Memory memWeight = new Memory();
        static Memory memTeleport = new Memory();
        static Memory memExpbot = new Memory();

        static Process proc = Process.GetProcessesByName(foregroundProcessName)[0];
        static IntPtr baseNormalOffset;
        // static IntPtr anim1AddressPointer;
        static IntPtr cameraBaseOffset;
        static IntPtr cameraFogOffset;
        static IntPtr mobSelectedOffset;
        static IntPtr mobBeingAttackedOffset;
        static IntPtr itemMouseoverHighlightedOffset;
        static IntPtr sellAdressMOffset;
        static IntPtr inventoryCurrentTabOffset;
        static IntPtr isCurrentSkillTabMOffset;

        static IntPtr UIWindowMOffset;
        static IntPtr BuffWindowMOffset;
        static IntPtr isCurrentSkillBar1Value;
        static IntPtr isCurrentSkillBar2Value;
        static IntPtr isCurrentSkillBar3Value;
        public static IntPtr isItemHighlightedType;



        static IntPtr shopWindowMOffset;
        static IntPtr inventoryWindowMOffset;
        static IntPtr storageWindowMOffset;


        static InputSimulator inputSimulator = new InputSimulator();
        public static volatile byte[] hpAddress;
        static volatile byte[] MannaAddress;
        static byte[] skill1Address;
        static byte[] anim1Address;
        static byte[] anim2Address;

        static IntPtr shopWindowAddress1;
        static IntPtr shopWindowAddress2;

        // !!!
        // TESTING
        // TESTING
        static byte lastSlotStat1;

        static byte[] slotFirstAddress;


        //!!!


        static byte[] slotFirstSellAddress;

        static volatile byte[] mobSelectedAddress;
        static volatile byte[] mobBeingAttackedAddress;

        private static volatile bool _stopHeal = false;
        private static volatile bool _stopAnim = false;
        private static volatile bool _stopBot = false;
        private static volatile bool _isRightMouseButtonPressed = false;

        private static volatile bool _stopKoChangeValue = false;

        public static void PressKey1Heal()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(50);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            inputSimulator.Keyboard.Sleep(50);
        }
        public static void PressKey2Heal()
        {
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
        }





        public static bool isStopAnim
        {
            get { return _stopAnim; }
        }
        public static bool isStopBot
        {
            get { return _stopBot; }
        }
        public static bool isStopHeal
        {
            get { return _stopHeal; }
        }
        public static bool isKoChangeValue
        {
            get { return _stopKoChangeValue; }
        }
        public static byte isCurrentInventoryTabOppened()
        {
            return memExpbot.readByte(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryCurrentTabOffset)); 
        }

        public static int GetCurrentPositionX
        {
            get { return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), 4)), 0);  }
        }
        public static int GetCurrentPositionShort
        {
            get { return BitConverter.ToInt32((memTeleport.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset+1))), 0); }
        }


        public static int GetCurrentPositionY
        {
            get { return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), 4)), 0); }
        }

        public static byte isCurrentClassSelected
        {
            get
            {
                return memExpbot.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.classSelected));
            }
        }
        public static byte getBuff1Informations
        {
            get
            {
                return memRebuff.readByte(proc.Handle, IntPtr.Add(BuffWindowMOffset, PointersAndValues.Buff1ActiveOffOffset));
            }

        }





        private static volatile int _anim1 = 0;
        private static volatile int _anim2 = 0;
        private static volatile int _skillValue = 0;

        public static int hpHealValue;

        public static int MannaRestoreValue = 250;


        public static void SetGameAsMainWindow()
        {
             SetForegroundWindow(FindWindow(null, foregroundWindowName));
        }
        public static void InitializeProgram()
        {

            if (proc == null)
            {
                return;
            }

            if (proc != null)
            {
                baseAddress = proc.MainModule.BaseAddress;
            }

            foreach (ProcessModule module in proc.Modules)
            {
                if (module.ModuleName == processName)
                {
                    client = module.BaseAddress;
                }

            }

            # region KOMBINACJE ZEBY POKAZAC ANIM1 Address
            /*            // KOMBINACJE ZEBY POKAZAC ANIM1 Address ale caly czas base offset pokazywalo
            
                        IntPtr anim1AddressPointer = mem.readpointer(proc.Handle, IntPtr.Add(client, 0x2ad1fc));
                        Debug.WriteLine("anim1 Pointer");
                        Debug.WriteLine(mem.readpointer(proc.Handle, IntPtr.Add(client, 0x2ad1fc)));
            */
            #endregion


            baseNormalOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalMOffset));

            cameraBaseOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.cameraBaseMOffset));

            cameraFogOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogMOffset));

            mobSelectedOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.mobSelectedMOffset));

            mobBeingAttackedOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalMOffset));

            itemMouseoverHighlightedOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.MouseoverHighlightedMOffset));



            sellAdressMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.SellWindowMOffset));

            inventoryCurrentTabOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.inventoryCurrentTabMOffset));

            UIWindowMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.UiWindowMOffset));

            BuffWindowMOffset = memRebuff.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.UiWindowMOffset));
            BuffWindowMOffset = memRebuff.readpointer(proc.Handle, IntPtr.Add(BuffWindowMOffset, PointersAndValues.Buff1Active2MOffset));

            isCurrentSkillTabMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.CurrentSkillTabMOffset));

            shopWindowMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.ShopWindow2MOffset));

            inventoryWindowMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.InventoryWindow2MOffset));
            
            storageWindowMOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.StorageWindow2MOffset));




            hpAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4);

            MannaAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4);

            skill1Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), 4);

            anim1Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), 4);

            anim2Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), 4);

            slotFirstAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotHPOffset), 4);


            isCurrentSkillBar1Value = (IntPtr)PointersAndValues.CurrentSkillBar1Address;
            isCurrentSkillBar2Value = (IntPtr)PointersAndValues.CurrentSkillBar2Address;
            isCurrentSkillBar3Value = (IntPtr)PointersAndValues.CurrentSkillBar3Address;
            isItemHighlightedType = (IntPtr)PointersAndValues.CurrentItemHighlightedType;


            int myMaxHp = getCurrentHp;
            if (myMaxHp < 200)
            {
                hpHealValue = 100;
            }
            else if (myMaxHp < 400 && myMaxHp > 200)
            {
                hpHealValue = 200;

            }
            else
            {
              hpHealValue = myMaxHp - 350;
            }


        }


        public static int SetAnim1Value
        {
            get
            {
                return _anim1;
            }
            set
            {
                _anim1 = value;
            }
        }

        public static int SetAnim2Value
        {
            get
            {
                return _anim2;
            }
            set
            {
                _anim2 = value;
            }
        }

        public static int SetSkillValue
        {
            get
            {
                return _skillValue;
            }
            set
            {
                _skillValue = value;
            }
        }

        public static void RequestStopHealBot()
        {
            if (_stopHeal)
                _stopHeal = false;
            else
                _stopHeal = true;
        }
        public static void RequestStopKoChangeValue()
        {
            if (_stopKoChangeValue)
                _stopKoChangeValue = false;
            else
                _stopKoChangeValue = true;
        }
        public static void RequestStopAnim()
        {
            if (_stopAnim)
                _stopAnim = false;
            else
                _stopAnim = true;
        }

        public static void RequestStopExpBot()
        {
            if (_stopBot)
                _stopBot = false;
            else
                _stopBot = true;
        }

        public static void HealBotRepotKharonSell()
        {
            if (ExpBotClass.isExpBotSell)
            {
                ExpBotClass.RequestisExpBotSell();
            }
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_6);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
            inputSimulator.Keyboard.Sleep(150);

            PressKey1Heal();
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(150);

            ExpBotClass.Repot(GetCurrentMap);
            // ExpBotClass.TeleportSScroll();
            ExpBotClass.ExpBotSellKharonGoBackToSpot();

           // TODO         I DELETED STARTTHEREADFORTESTING WIITH KINDA NO INTENTIONS TO MAKE THIS STOP WORKING  Form1.StartThreadForTesting();


        }



        public static void HealBotTeleportRepotGoUWC()
        {

            // STOP EXP BOT 
            // ZMIENIONE TYMCZASOWO NIE TESTOWANE

           if (ExpBotClass.isStopMoveExpBot)
            {
                ExpBotClass.RequestStopMoveExpBot();
            }

            ExpBotClass.scrollToCity();

            // TODO IF CITY && COORDS == XXX THEN DO XXX ELSE GO AGAIN

            if (getCurrentHp < hpHealValue)
                PressKey1Heal();
            if (getCurrentHp < hpHealValue)
                PressKey1Heal();
            if (getCurrentHp < hpHealValue)
                PressKey1Heal();
            if (getCurrentManna < MannaRestoreValue)
                PressKey2Heal();
            if (getCurrentManna < MannaRestoreValue)
                PressKey2Heal();
            if (getCurrentManna < MannaRestoreValue)
                PressKey2Heal();



            Thread.Sleep(3000);
            ExpBotClass.Repot(GetCurrentMap);
            ExpBotClass.WalkIntoUWC();
            Form1.StartExpBotUWCThread();


        }

        static void HealKeyPressSellKharon()
        {
            if (BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotHPOffset), 4)) > PointersAndValues.ItemCount1 + 10) // if less then 7 use key 6 which is teleport
            {
                PressKey1Heal();
            }
            else
            {
                // HealBotTeleportRepotGoUWC(); 
                HealBotRepotKharonSell();
            }
        }
        static void HealKeyPressExpBotUWC()
        {
            if (BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotHPOffset), 4)) > PointersAndValues.ItemCount1 + 5) // if less then 7 use key 6 which is teleport
            {
                PressKey1Heal();
            }

            else
            {
                 HealBotTeleportRepotGoUWC(); 
               // HealBotRepotKoHitTest();
            }
        }
        
        static void HealKeyPress()
        {
            if (getFirstSlotValue > PointersAndValues.ItemCount1 + 5) // if less then 7 use key 6 which is teleport
            {
                PressKey1Heal();
            }
            else
            {
                ExpBotClass.scrollToCity();
            }
        }

        static void MannaKeyPress()
        {
            if (getSecondSlotValue > PointersAndValues.ItemCount1 + 5) // if less then 4 use key 6 which is teleport
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
            }
            else
            {
                ExpBotClass.scrollToCity();
            }
        }
        public static void MannaKeyPressKharonSell()
        {
            if (getSecondSlotValue > PointersAndValues.ItemCount1 + 2) // if less then 4 use key 6 which is teleport
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
            }
            else
            {
                HealBotRepotKharonSell();
            }
        }
        static void MannaKeyPressUWC()
        {
            if (getSecondSlotValue > PointersAndValues.ItemCount1 + 5) // if less then 4 use key 6 which is teleport
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                inputSimulator.Keyboard.Sleep(200);
            }
            else
            {
                 HealBotTeleportRepotGoUWC(); 
               // HealBotRepotKoHitTest();
            }
        }

        static void WhiteRedPotionsKeyPress()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_7);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_7);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_8);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_8);
            inputSimulator.Keyboard.Sleep(200);
        }


        public static void StartHealbotSellKharon()
        {
            SetGameAsMainWindow();


            while (_stopHeal)
            {
                hpValue = getCurrentHp;
                Thread.Sleep(50);
                mannaValue = getCurrentManna;
                Thread.Sleep(50);


                if (hpValue < hpHealValue && hpValue != 0)
                {
                    HealKeyPressSellKharon();
                }
                if (hpValue == 0)
                {
                    if (ExpBotClass.isExpBotSell)
                    {
                        ExpBotClass.RequestisExpBotSell();
                    }

                    Thread.Sleep(180000);
                    HealBotRepotKharonSell();


                    // HealBotTeleportRepotGoUWC();  // GO EXP IN UWC
                    // HealBotRepotSSGolems();  // cant go golems cause threre is no SS scroll used
                }
                if (mannaValue < MannaRestoreValue)
                {
                    MannaKeyPressKharonSell();

                    // if running speed is normal use red and white potion
                    if (getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                    {
                        WhiteRedPotionsKeyPress();
                    }
                }

            }
            return;
        }




        public static void StartHealbotNormal()
        {
            SetGameAsMainWindow();


            while (_stopHeal)
            {
                hpValue = getCurrentHp;
                Thread.Sleep(50);
                mannaValue = getCurrentManna;
                Thread.Sleep(50);

                if (hpValue < hpHealValue && hpValue != 0)
                {
                    HealKeyPress();
                }


                if (mannaValue < MannaRestoreValue)
                {
                    MannaKeyPress();

                    // if running speed is normal use red and white potion
                    if (getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                    {
                        WhiteRedPotionsKeyPress();
                    }
                }

            }
            return;
        }
        public static void StartHealbotExpBotUWC()
        {
            SetGameAsMainWindow();


            while (_stopHeal)
            {
                hpValue = getCurrentHp;
                Thread.Sleep(20);
                mannaValue = getCurrentManna;
                Thread.Sleep(20);


                if (hpValue < hpHealValue && hpValue != 0)
                {
                    HealKeyPressExpBotUWC();
                }
                if (hpValue == 0)
                {
                    Thread.Sleep(180000);
                   HealBotTeleportRepotGoUWC();  // GO EXP IN UWC
                                                 // HealBotRepotSSGolems();  // cant go golems cause threre is no SS scroll used
                                                 // HealBotRepotKoHitTest();

                }
                if (mannaValue < MannaRestoreValue)
                {
                  MannaKeyPressUWC();

                    // if running speed is normal use red and white potion
                    if (getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                    {
                        WhiteRedPotionsKeyPress();
                    }
                }

            }
            return;
        }
        public static void StartOnlyHealBot()
        {
            SetGameAsMainWindow();


            while (_stopHeal)
            {
                hpValue = getCurrentHp;
                Thread.Sleep(50);
                mannaValue = getCurrentManna;
                Thread.Sleep(50);


                if (hpValue < hpHealValue && hpValue != 0)
                {
                    HealKeyPress();
                    // if running speed is normal use red and white potion
                    if (getCurrentRunningSpeed == PointersAndValues.runSpeedNormalValue)
                    {
                        WhiteRedPotionsKeyPress();
                    }

                }
                if (hpValue == 0)
                {
                    Thread.Sleep(180000);

                    // HealBotTeleportRepotGoUWC();  // GO EXP IN UWC
                    // HealBotRepotSSGolems();  // cant go golems cause threre is no SS scroll used
                }
                if (mannaValue < MannaRestoreValue)
                {
                    MannaKeyPress();
                }

            }
            return;
        }

        public static void Start1HitKO(SkillSelector skillSelector)
        {

            while (_stopAnim)
            {
                if(ProgramHandle.isInCity != 1)
                {
                skillSelector.SkillAssign();
                    memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(SkillToOverride));
                    memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.visualSkillAttack), BitConverter.GetBytes(0));

                    skillSelector.Rebuff();
                }

                // memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickDelayPointer), BitConverter.GetBytes(0));





                #region OldAnimFunction

                /*                // anim 1 
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), BitConverter.GetBytes(_anim1));

                //anim 2 
                 mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), BitConverter.GetBytes(_anim2));

                // skill   
                // mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(_skillValue));

                //skill Delay ?? not checked
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skillDelayPointer), BitConverter.GetBytes(0));

                */
                // click Delay ?? not checked






                // dont know if it works at all
                //
                /*                // ToCheckMicroTick Delay ?? not checked
                                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.toCheckTicksForAMicrosecond), BitConverter.GetBytes(1120927744));
                                // toCheckSkillVsNormal Delay ?? not checked
                                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.toCheckSkillVsNormal), BitConverter.GetBytes(0));
                */

                #endregion
            }
            return;
        }

        public static void Change1HitKoValue()
        {
            while (isKoChangeValue)
            {

                int currentSavedChangableValue = SkillToOverride;

                    if (isWhatAnimationRunning() == PointersAndValues.isAttackingBowAlliAnimation || isWhatAnimationRunning() == PointersAndValues.isAttackingSpearAlliAnimation || isWhatAnimationRunning() ==PointersAndValues.isAttackingKnightAlliAnimation || isWhatAnimationRunning() ==PointersAndValues.isAttackingSorcAlliAnimation || isWhatAnimationRunning() == PointersAndValues.isAttackingBowEmpAnimation)
                    {
                        Debug.WriteLine($"{SkillToOverride}");
                    SkillToOverride++;
                    Thread.Sleep(800);
                    }
                    if (isMobBeingAttacked == -1 && currentSavedChangableValue != SkillToOverride)
                    {
                        memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(SkillToOverride));

                        ExpBotClass.ExpBotLog += $"{SkillToOverride}\n";
                        // Debug.WriteLine($"Killed mob {Test1HitChangableValue}");
                        currentSavedChangableValue = SkillToOverride;
                    }
            }

        }




        public static void SetCameraLong()
        {
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceAnimValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
        }

        public static void SetCameraForExpBot()
        {
            MouseOperations.SetCursorPosition(900, 500);
            SetGameAsMainWindow();
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceBotValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleXPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleXValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
        }

        public static int isInCity
        {
            get
            {
                return memExpbot.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.isInCityOffset));
            }
        }
        public static int getFirstSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotHPOffset), 4)); }
        }
        public static int getSecondSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotMannaOffset), 4)); }
        }
        public static int getThirdSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotRedPotOffset), 4)); }
        }
        public static int getForthSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotWhitePotOffset), 4)); }
        }
        public static int getCurrentWeight
        {
            get { return BitConverter.ToInt32(memWeight.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.WeightOffset), 4)); }
        }
        public static int getCurrentHp
        {
            get { return BitConverter.ToInt32((memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4)), 0); }
        }
        public static int getCurrentManna
        {
            get{return BitConverter.ToInt32((memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4)), 0);}
        }
        public static int getCurrentRunningSpeed
        {
            get { return BitConverter.ToInt32((memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.runSpeedOffset), 4)), 0); }
        }
        public static int getCurrentAttackSpeed
        {
            get { return BitConverter.ToInt32((memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.AttackSpeedOffset), 4)), 0); }
        }

        public static int isWhatAnimationRunning()
        {
            return BitConverter.ToInt32(memExpbot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.typeOfAnimationIsRunning), 4));
        }

        public static int isMobSelected
        {
            get { return BitConverter.ToInt32((memExpbot.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0); }
        }
        public static int isMobBeingAttacked
        {
            get { return BitConverter.ToInt32((memExpbot.readbytes(proc.Handle, IntPtr.Add(mobBeingAttackedOffset, PointersAndValues.mobBeingTargeted), 4)), 0); }
        }
        public static int isItemHighlighted
        {
            get { return BitConverter.ToInt32((memExpbot.readbytes(proc.Handle, IntPtr.Add(itemMouseoverHighlightedOffset, PointersAndValues.MouseoverHighlightedOffset), 4)), 0); }
        }
        public static int isSellWindowStillOpen
        {
            get { return memExpbot.readByte(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellWindowOffset)); }
        }

        public static void OpenSellConfirmationUI()
        {
            memExpbot.writebytes(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellWindowOffset), BitConverter.GetBytes(1));
        }

        public static void TeleportToPosition(int x, int y, int z)
        {
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(x));
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(y));
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(z));
        }
        public static void TeleportToPositionTuple(Tuple<int,int,int> TuplePositions)
        {
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TuplePositions.Item1));
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TuplePositions.Item2));
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TuplePositions.Item3));

        }


        #region Teleporter 
        public static int GetCurrentMap
        {
            get
            { return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.mapNumberOffset), 4)), 0); }
        }
        public static void Teleporting()
        {

            if (GetCurrentMap == TeleportValues.AllianceSacredLand)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item3));
            }

            else if (GetCurrentMap == TeleportValues.BaldorTempleFirstFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.BaldorTempleSecondFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.Hollina)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (GetCurrentMap == TeleportValues.EasternMiningTunnel)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (GetCurrentMap == TeleportValues.Siros1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Siros2thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Siros3thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.Siros4thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.EmpireSacred)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Ogre1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Ogre2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Hershal)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC3rdFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC4rdFloor)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdPlant.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdPlant.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdPlant.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item3));
                    _variableForChangablePosition = 0;

                }

            }
            else if (GetCurrentMap == TeleportValues.COT1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT2ndFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT2ndFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT2ndFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT3rdFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT3rdFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT3rdFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT3rdFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT4thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT4thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT4thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT4thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT5thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT5thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT5thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT5thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT6thfloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT6thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT6thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT6thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT7thloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT7thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT7thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT7thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT8thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT8thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT8thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT8thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT9thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT9thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT9thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT9thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT10thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT10thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT10thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT10thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT11thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT11thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT11thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT11thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.COT12thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT12thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT12thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT12thFloor.Item3));
            }


            else if (GetCurrentMap == TeleportValues.KharonPlateau)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuSlothEntrace.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuSlothEntrace.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuSlothEntrace.Item3));
                    _variableForChangablePosition++;

                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuGardionEntrace.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuGardionEntrace.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosKharonPlateuGardionEntrace.Item3));
                    _variableForChangablePosition = 0;
                }
            }
                else if (GetCurrentMap == TeleportValues.SlothFloor1)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar1.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar1.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar1.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 2)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar2.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar2.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar2.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 3)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar3.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar3.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1BossBulgar3.Item3));
                    _variableForChangablePosition = 0;
                }
            }

            else if (GetCurrentMap == TeleportValues.SlothFloor2)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCubeMiddle.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCubeMiddle.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCubeMiddle.Item3));
                    _variableForChangablePosition ++;
                }
                else if (_variableForChangablePosition == 2)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCube.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCube.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor2IceCube.Item3));
111111                    _variableForChangablePosition = 0;
                }
            }


        }

        #endregion
        public static void StartAttackWhenMobSelectedBot()
        {

            while (_stopBot)
            {
                AttackMob.AttackMob.CheckIfSelectedAndAttackSkill();
            }
            return;
        }

        static int ReadPositionX()
        {
            return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), 4)), 0);
        }
        static int ReadPositionY()
        {
            return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), 4)), 0);
        }
        public static int GetPositionX
        {
            get
            {
                return ReadPositionX();
            }
        }
        public static int GetPositionY
        {
            get
            {
                return ReadPositionY();
            }
        }



        public static void SetItemForSaleSelected(int itemforSaleNumber)
        {
            // ADD +27 - FIRST SALE INVENTORY ITEM STARTS FROM 27
            memExpbot.writebytes(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellItemSelectedOffset), BitConverter.GetBytes(itemforSaleNumber+27));
        }

        public static byte ReadSellItemsByteValue(int offset)
        {
            return memNormal.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + (offset * 0x1c)));
        }

        public static byte ReadSellItemsStat1(int offset)
        {
            return memNormal.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + ((offset * 0x1c) - 2)));
        }

        public static byte ReadSellItemsStat2(int offset)
        {
            return memNormal.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + ((offset * 0x1c) - 1)));
        }
        public static byte isShopWindowStillOpen()
        {
            return memExpbot.readByte(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset1));
        }
        public static byte isCurrentSkillTabNr()
        {
            return memExpbot.readByte(proc.Handle, IntPtr.Add(isCurrentSkillTabMOffset, PointersAndValues.CurrentSkillTabOffOffset));
        }
        public static byte isCurrentSkill()
        {
            if (isCurrentSkillTabNr() == 0)
            {
                return memExpbot.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar1Value, 0));
            }
            else if (isCurrentSkillTabNr() == 1)
            {
                return memExpbot.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar2Value, 0));
            }
            else if (isCurrentSkillTabNr() == 2)
            {
                return memExpbot.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar3Value, 0));
            }
            else return 5;
        }


        public static byte getCurrentItemHighlightedType
        {
            get { return memExpbot.readByte(proc.Handle, IntPtr.Add(isItemHighlightedType, 0)); }
        }

        public static void OpenShopWindow()
        {
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
        }
        public static void OpenStorageWindow()
        {
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(storageWindowMOffset, PointersAndValues.StorageWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memExpbot.writebytes(proc.Handle, IntPtr.Add(storageWindowMOffset, PointersAndValues.StorageWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);

        }



    }
}