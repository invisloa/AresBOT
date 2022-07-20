using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;

namespace AresTrainerV3
{
    public class ProgramHandle
    {
        // public static temporaryAnimAddress = 

        static int _variableForChangablePosition = 0;

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        static volatile int hpValue = 0;
        static volatile int mannaValue = 0; // Changed to volatile 
                                            // static volatile int mobSelected = 0;
                                            //  static volatile int mobBeingAttacked = 0;



        static IntPtr baseAddress = IntPtr.Zero;
        static IntPtr client = IntPtr.Zero;
        static Memory memNormal = new Memory();
        static Memory memTeleport = new Memory();
        static Memory memExpbot = new Memory();

        static Process proc = Process.GetProcessesByName("Nostalgia")[0];
        static IntPtr baseNormalOffset;
        // static IntPtr anim1AddressPointer;
        static IntPtr cameraBaseOffset;
        static IntPtr cameraFogOffset;
        static IntPtr mobSelectedOffset;
        static IntPtr mobBeingAttackedOffset;
        static InputSimulator inputSimulator = new InputSimulator();
        static volatile byte[] hpAddress;
        static volatile byte[] MannaAddress;
        static byte[] skill1Address;
        static byte[] anim1Address;
        static byte[] anim2Address;
        static volatile byte[] slotFirstAddress;
        static volatile byte[] mobSelectedAddress;
        static volatile byte[] mobBeingAttackedAddress;
        private static volatile bool _stopHeal = false;
        private static volatile bool _stopAnim = false;
        private static volatile bool _stopBot = false;
        private static volatile bool _isRightMouseButtonPressed = false;

        public static bool isStopAnim
        {
            get { return _stopAnim; }
        }
        public static bool isStopBot
        {
            get { return _stopBot; }
        }




        private static volatile int _anim1 = 0;
        private static volatile int _anim2 = 0;
        private static volatile int _skillValue = 0;

        public static int hpHealValue;

        public static int MannaRestoreValue = 50;

        public static void SetNostalgiaMainWindow()
        {
            SetForegroundWindow(FindWindow(null, "Nostalgia"));
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
                if (module.ModuleName == "Nostalgia.exe")
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


            baseNormalOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalOffset));

            cameraBaseOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.cameraBaseOffset));

            cameraFogOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogOffset));

            mobSelectedOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.mobSelectedOffset));

            mobBeingAttackedOffset = memExpbot.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.mobBeingAttackedOffset));



            hpAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4);

            MannaAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4);

            skill1Address = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), 4);

            anim1Address = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), 4);

            anim2Address = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), 4);

            slotFirstAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4);

            // mobSelectedAddress = memExpbot.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4);

            // mobBeingAttackedAddress = memExpbot.readbytes(proc.Handle, IntPtr.Add(mobBeingAttackedOffset, PointersAndValues.mobBeingAttacked), 4);




            int myMaxHp = BitConverter.ToInt32((memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4)), 0);
            if (myMaxHp < 200)
            {
                hpHealValue = 100;
            }
            else if (myMaxHp < 400 && myMaxHp > 200)
            {
                hpHealValue = 300;

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
        public static void Request1hitKOBot()
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

        static void HealKeyPress()
        {
            if (BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4)) > 16777222) // if less then 7 use key 6 which is teleport
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(150);
            }
            else
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                inputSimulator.Keyboard.Sleep(150);

                // STOP EXP BOT 
                //
                // STOP EXP BOT 
                //
                // STOP EXP BOT 
                //
                if (ExpBotClass.isStopMoveExpBot)
                {
                    ExpBotClass.RequestStopMoveExpBot();
                }

                inputSimulator.Keyboard.Sleep(2000);

                ExpBotClass.Repot(GetCurrentMap);
               ExpBotClass.WalkIntoUWC();
                Form1.TemporaryThreadStartMoveMethod();

            }
        }
        static void MannaKeyPress()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
        }
        static void UsePotionsKeyPress()
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




        public static void StartHealbot()
        {
            SetForegroundWindow(FindWindow(null, "Nostalgia"));


            while (_stopHeal)
            {
                hpValue = BitConverter.ToInt32((memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4)), 0);
                Thread.Sleep(50);
                mannaValue = BitConverter.ToInt32((memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4)), 0);
                Thread.Sleep(50);


                if (hpValue < hpHealValue && hpValue != 0)
                {
                    HealKeyPress();
                }
                if (BitConverter.ToInt32((memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4)), 0) < MannaRestoreValue)
                {
                    MannaKeyPress();

                    // if running speed is normal use red and white potion
                    if (BitConverter.ToInt32((memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.runSpeedOffset), 4)), 0) == PointersAndValues.runSpeedNormalValue)
                    {
                        UsePotionsKeyPress();
                    }
                }
            }
            return;
        }

        public static void AttackMobWhenSelected()
        {
            if (isMobSelected != 0 && isMobSelected < 8300000)
            {
                SkillAttackBot();
            }
        }
        public static void SkillAttackBot()
        {
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(500);
            while(isMobBeingTargeted != -1 && isWhatAnimationRunning != PointersAndValues.isStandingAnimation)
            {
                Thread.Sleep(1000);
            }
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            /*Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            _isRightMouseButtonPressed = true;
            while (isMobBeingTargeted != -1)
            {
                Thread.Sleep(10);

                if (isWhatAnimationRunning == PointersAndValues.isStandingAnimation)
                {
                    Thread.Sleep(10);

                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    Thread.Sleep(10);
                    _isRightMouseButtonPressed = false;
                }
                else
                {
                    Thread.Sleep(10);
                }

            }

            if (_isRightMouseButtonPressed)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);

            }
*/
        }
        public static void Start1HitKO()
        {
            while (_stopAnim)
            {

                memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(40000));

                memNormal.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickDelayPointer), BitConverter.GetBytes(0));

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
        public static void StartNormalAttack()
        {

            /*            // COMENTED FOR TESTING MICROTICK,
                        //
                        //
                        //
                        //

                        while (_stopAnim)
                        {
                            // anim 1 
                            mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), BitConverter.GetBytes(_anim1));

                            //anim 2 
                            mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), BitConverter.GetBytes(_anim2));
                        }

                        //
                        //
                        //
                        //
                        // COMENTED FOR TESTING MICROTICK,
            *//*




            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,

            while (_stopAnim)
            {
             
                    // first part of changable value
                    // mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(0));

                    // second part of changable value
              //      mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(40000));
            }
            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,
*/
            return;
        }

        public static void SetCameraForSpeed()
        {
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceAnimValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
          // rining speed   mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.runSpeedOffset), BitConverter.GetBytes(PointersAndValues.runSpeedValue4));
        }

        public static void SetCameraForExpBot()
        {
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceBotValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleXPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleXValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
            // rining speed   mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.runSpeedOffset), BitConverter.GetBytes(PointersAndValues.runSpeedValue4));
        }




        #region teleport// Teleporter try
        public static int GetCurrentMap
        {
            get
            {
                return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.mapNumberOffset), 4)), 0);
            }
        }
        public static int getFirstSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4)); }
        }
        public static int getSecondSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotSecondOffset), 4)); }
        }
        public static int getThirdSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotThirdOffset), 4)); }
        }
        public static int getForthSlotValue
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotForthOffset), 4)); }
        }
        public static int isWhatAnimationRunning
        {
            get { return BitConverter.ToInt32(memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.typeOfAnimationIsRunning), 4)); }
        }


        public static int isMobSelected
        {
            get { return BitConverter.ToInt32((memExpbot.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0); }
        }
        public static int isMobBeingTargeted
        {
            get { return BitConverter.ToInt32((memExpbot.readbytes(proc.Handle, IntPtr.Add(mobBeingAttackedOffset, PointersAndValues.mobBeingTargeted), 4)), 0);}
        }


        public static void Teleporting()
        {

            if (GetCurrentMap == TeleportValues.AllianceSacredLand)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item3));
            }

            else if (GetCurrentMap == TeleportValues.BaldorTempleFirstFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.BaldorTempleSecondFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.Hollina)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (GetCurrentMap == TeleportValues.EasternMiningTunnel)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (GetCurrentMap == TeleportValues.Siros1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Siros2thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Siros3thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.Siros4thFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item3));
            }

            else if (GetCurrentMap == TeleportValues.EmpireSacred)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Ogre1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Ogre2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.Hershal)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC3rdFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.UWC4rdFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item3));
            }
        }
        #endregion





        public static void StartAttackBot()
        {

            while (_stopBot)
            {
                AttackMobWhenSelected();
            }
            return;
        }

        static void WriteClickPositionX(int posX)
        {
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickPositionXOffset), BitConverter.GetBytes(posX));
        }
        static void WriteClickPositionY(int posY)
        {
            memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickPositionYOffset), BitConverter.GetBytes(posY));
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

    }
}