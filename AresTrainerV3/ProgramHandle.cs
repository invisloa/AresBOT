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



        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        static int hpValue = 0;
        static int mannaValue = 0;

        static IntPtr baseAddress = IntPtr.Zero;
        static IntPtr client = IntPtr.Zero;
        static Memory mem = new Memory();

        static Process proc = Process.GetProcessesByName("Nostalgia")[0];
        static IntPtr baseNormalOffset;
        // static IntPtr anim1AddressPointer;
        static IntPtr cameraBaseOffset;
        static IntPtr cameraFogOffset;
        static InputSimulator inputSimulator = new InputSimulator();
        static byte[] hpAddress;
        static byte[] MannaAddress;
        static byte[] skill1Address;
        static byte[] anim1Address;
        static byte[] anim2Address;
        static byte[] slotFirstAddress;
        private static volatile bool _stopHeal = false;
        private static volatile bool _stopAnim = false;

       

        private static volatile int _anim1 = 0;
        private static volatile int _anim2 = 0;
        private static volatile int _skillValue = 0;

        public static int hpHealValue = 100;
        public static int MannaRestoreValue = 20;

        public static void InitializeProgram()
        {

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


            baseNormalOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, 0x2ad1fc));
            Debug.WriteLine("baseWithOffsetAddress2");
            Debug.WriteLine(baseNormalOffset);


            cameraBaseOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.cameraBaseOffset));

            cameraFogOffset = mem.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogOffset));

            hpAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4);

            MannaAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4);

            skill1Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), 4);


            anim1Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), 4);
            Debug.WriteLine("anim1");
            Debug.WriteLine(BitConverter.ToInt32(anim1Address, 0));

            anim2Address = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), 4);

            slotFirstAddress = mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstOffset), 4);

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
                hpValue = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, 0x148), 4)), 0);
                mannaValue = BitConverter.ToInt32((mem.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, 0x980), 4)), 0);

                if (hpValue < hpHealValue)
                {
                    HealKeyPress();
                }
                if (mannaValue < 15)
                {
                    MannaKeyPress();
                }
            }
            return;
        }
        public static void StartAnimBot()
        {
            while (_stopAnim)
            {


                // anim 1 
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), BitConverter.GetBytes(_anim1));

                //anim 2 
                 mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), BitConverter.GetBytes(_anim2));

                // skill   
                // mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(_skillValue));

                // click Delay ?? not checked
               mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.clickDelayPointer), BitConverter.GetBytes(0));


                
                
                //skill Delay ?? not checked
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skillDelayPointer), BitConverter.GetBytes(0));




                // dont know if it works at all
                //
                /*                // ToCheckMicroTick Delay ?? not checked
                                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.toCheckTicksForAMicrosecond), BitConverter.GetBytes(1120927744));
                                // toCheckSkillVsNormal Delay ?? not checked
                                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.toCheckSkillVsNormal), BitConverter.GetBytes(0));
                */




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
            */




            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,

            while (true)
            {
                // first part of changable value
                 mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(0));
                Thread.Sleep(1);

                // second part of changable value
                mem.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(40000));
                Thread.Sleep(1);
            }
            // TESTING MICROTICK,
            // TESTING MICROTICK,
            // TESTING MICROTICK,

            return;
        }

        public static void SetCamera()
        {
            mem.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceValue));
            mem.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAnglePointer), BitConverter.GetBytes(PointersAndValues.cameraAngleValue));
            mem.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
        }

    }
}