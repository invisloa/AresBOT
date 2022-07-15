using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Windows.Input;
using System.Threading;
using System;

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
        static volatile int mobSelected = 0;

        static int _currentMap = 0;


        static IntPtr baseAddress = IntPtr.Zero;
        static IntPtr client = IntPtr.Zero;
        static Memory mem = new Memory();

        static Process proc = Process.GetProcessesByName("Nostalgia")[0];
        static IntPtr baseNormalOffset;
        // static IntPtr anim1AddressPointer;
        static IntPtr cameraBaseOffset;
        static IntPtr cameraFogOffset;
        static IntPtr mobSelectedOffset;
        static InputSimulator inputSimulator = new InputSimulator();
        static byte[] hpAddress;
        static byte[] MannaAddress;
        static byte[] skill1Address;
        static byte[] anim1Address;
        static byte[] anim2Address;
        static byte[] slotFirstAddress;
        static byte[] mobSelectedAddress;
        private static volatile bool _stopHeal = false;
        private static volatile bool _stopAnim = false;
        private static volatile bool _stopBot = false;

        public static bool StopAnim
        {
            get { return _stopAnim; }
        }




        private static volatile int _anim1 = 0;
        private static volatile int _anim2 = 0;
        private static volatile int _skillValue = 0;

        public static int hpHealValue;

        public static int MannaRestoreValue = 30;

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


            /*            // KOMBINACJE ZEBY POKAZAC ANIM1 Address ale caly czas base offset pokazywalo
            
                        IntPtr anim1AddressPointer = mem.readpointer(proc.Handle, IntPtr.Add(client, 0x2ad1fc));
                        Debug.WriteLine("anim1 Pointer");
                        Debug.WriteLine(mem.readpointer(proc.Handle, IntPtr.Add(client, 0x2ad1fc)));
            */


            baseNormalOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalOffset));

            cameraBaseOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.cameraBaseOffset));

            cameraFogOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogOffset));

            mobSelectedOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.mobSelectedOffset));

            hpAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4);

            MannaAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4);

            skill1Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), 4);

            anim1Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), 4);

            anim2Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), 4);

            slotFirstAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4);

            mobSelectedAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.mobSelected), 4);


            int myMaxHp = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4)), 0);
            if(myMaxHp <200)
            {
                hpHealValue = 100;
            }   
            else if (myMaxHp <400 && myMaxHp>200)
            {
                hpHealValue = 300;

            }
            else
            {
                hpHealValue = myMaxHp - 200;
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
        public static void RequestStopHeal()
        {
            if (_stopHeal)
                _stopHeal = false;
            else
                _stopHeal = true;
        }
        public static void RequestStopAnim()
        {
            if (_stopAnim)
                _stopAnim = false;
            else
                _stopAnim = true;
        }

        public static void RequestStopBot()
        {
            if (_stopBot)
                _stopBot = false;
            else
                _stopBot = true;
        }

        static void HealKeyPress()
        {
            if (BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4)), 0) > 16777220) // if less then 5 use key 6 which is teleport
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
                inputSimulator.Keyboard.Sleep(20000);
            }
        }
        static void MannaKeyPress()
        {
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
            inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            inputSimulator.Keyboard.Sleep(200);
        }

      

        public static void StartHealbot()
        {
            SetForegroundWindow(FindWindow(null, "Nostalgia"));


            while (_stopHeal)
            {
                Thread.Sleep(35);
                hpValue = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4)), 0);
                Thread.Sleep(35);
                mannaValue = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4)), 0);
                Thread.Sleep(35);


                if (hpValue < hpHealValue)
                {
                    HealKeyPress();
                }
                if (BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4)), 0) < MannaRestoreValue)
                {
                    MannaKeyPress();
                }
            }
            return;
        }

        public static void DrawCirclePoints(Tuple<int, int>[] GeneratedCircles)
        {
                foreach (Tuple<int, int> point in GeneratedCircles)
                {
                mobSelected = 0; //BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0);

                if (mobSelected == 0)
                    {

                        MouseOperations.SetCursorPosition(point.Item1, point.Item2);
                        Thread.Sleep(1);
                    }
                    else
                    {
                        SkillAttackBot();
                    }
                }
                return ;
        }
        static void SkillAttackBot()
        {
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(1);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(1);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            Thread.Sleep(1);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            Thread.Sleep(1);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);

            while (mobSelected!=0)
            {
                Thread.Sleep(5);
                mobSelected = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0);
                Thread.Sleep(5);

            }
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);

            return;

        }
        public static string MobSelectedText()
        {
            mobSelected = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0);
            return mobSelected.ToString();
        }


        public static void StartExpBot()
        {
            // SetForegroundWindow(FindWindow(null, "Nostalgia"));
            Tuple<int, int>[] GeneratedCircles = MouseCircleScanner.GenerateCirclePoints(10, 20, 30, 30, 962, 528);


            while (_stopBot)
            {
                DrawCirclePoints(GeneratedCircles);
            }
            return;
        }








        public static void Start1HitKO()
        {
            while (_stopAnim)
            {

                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(40000));

                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickDelayPointer), BitConverter.GetBytes(0));

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

        public static void SetCamera()
        {
            mem.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceAnimValue));
            mem.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAnglePointer), BitConverter.GetBytes(PointersAndValues.cameraAngleValue));
            mem.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
            mem.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
          // rining speed   mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.runSpeedOffset), BitConverter.GetBytes(PointersAndValues.runSpeedValue4));
        }




        #region teleport// Teleporter try
        public static void Teleporting()
        {
            _currentMap = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.mapNumberOffset), 4)), 0);


            if (_currentMap == TeleportValues.SacredLand)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSacredLandsOgre.Item3));
            }

            else if (_currentMap == TeleportValues.BaldorTempleFirstFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleFirstFloor.Item3));
            }
            else if (_currentMap == TeleportValues.BaldorTempleSecontloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosBaldorTempleSecontloor.Item3));
            }

            else if (_currentMap == TeleportValues.Hollina)
            {
                if (_variableForChangablePosition == 0)
                {
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item1));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item2));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaSiros.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item1));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item2));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHollinaTunnel.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (_currentMap == TeleportValues.EasternMiningTunnel)
            {
                if (_variableForChangablePosition == 0)
                {
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item1));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item2));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelExit.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item1));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item2));
                    mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEasternMiningTunnelEntrace.Item3));
                    _variableForChangablePosition = 0;

                }
            }
            else if (_currentMap == TeleportValues.Siros1stFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stFloor.Item3));
            }
            else if (_currentMap == TeleportValues.Siros2thFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloor.Item3));
            }
            else if (_currentMap == TeleportValues.Siros3thFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros3thFloor.Item3));
            }

            else if (_currentMap == TeleportValues.Siros4thFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros4thFloor.Item3));
            }

            else if (_currentMap == TeleportValues.EmpireSacred)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosEmpireSacred.Item3));
            }
            else if (_currentMap == TeleportValues.Ogre1stFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre1stFloor.Item3));
            }
            else if (_currentMap == TeleportValues.Ogre2ndFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosOgre2ndFloor.Item3));
            }
            else if (_currentMap == TeleportValues.Hershal)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item3));
            }
            else if (_currentMap == TeleportValues.UWC1stFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC1stFloor.Item3));
            }
            else if (_currentMap == TeleportValues.UWC2ndFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC2ndFloor.Item3));
            }
            else if (_currentMap == TeleportValues.UWC3rdFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC3rdFloor.Item3));
            }
            else if (_currentMap == TeleportValues.UWC4rdFloor)
            {
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item1));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item2));
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosUWC4rdFloor.Item3));
            }
        }
        #endregion
    }
}