using AresTrainerV3.ItemCollect;
using AresTrainerV3.SkillSelection;
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

        public static int SkillToOverride = PointersAndValues.arcerEmpBlasting;

        static IntPtr baseAddress = IntPtr.Zero;
        static IntPtr client = IntPtr.Zero;
        static Memory memNormal = new Memory();
        static Memory memBaseOffset = new Memory();
        static Memory memSkill = new Memory();
        static Memory memRebuff = new Memory();
        static Memory memHealBot = new Memory();
        static Memory memWeight = new Memory();
        static Memory memTeleport = new Memory();
        static Memory memExpbot = new Memory();
        static Memory memAttacking = new Memory();
        static Memory memAnimation = new Memory();
        static Memory memScanner = new Memory();
        static Memory memSeller = new Memory();
        static Memory memIsInCity = new Memory();


        static Process proc = Process.GetProcessesByName(foregroundProcessName)[0];
        static IntPtr baseNormalOffset;
        static IntPtr cameraBaseOffset;
		static IntPtr cameraFogOffsetComp;
		static IntPtr cameraFogOffsetLapt;		
		static IntPtr antiBlackOffset;
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
        public static IntPtr isAttackingMob;



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
            return memSeller.readByte(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryCurrentTabOffset)); 
        }

        public static int GetSkillDelay
        {
            get { return BitConverter.ToInt16((memRebuff.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skillDelayShortPointer))), 0); }
        }


        public static byte isCurrentClassSelected
        {
            get
            {
                return memSkill.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.classSelected));
            }
        }
        public static Tuple<int,int, int, int> getBuff1Informations
        {

            get
            {
                {
                    int firstbuff = BitConverter.ToInt16((memRebuff.readShort(proc.Handle, IntPtr.Add(BuffWindowMOffset, PointersAndValues.Buff1FirstOffset))), 0);
                    int secondBuff = BitConverter.ToInt16((memRebuff.readShort(proc.Handle, IntPtr.Add(BuffWindowMOffset, (PointersAndValues.Buff2FirstOffset)))), 0);
                    int thirdBuff = BitConverter.ToInt16((memRebuff.readShort(proc.Handle, IntPtr.Add(BuffWindowMOffset, PointersAndValues.Buff3FirstOffset))), 0);
                    int forthBuff = BitConverter.ToInt16((memRebuff.readShort(proc.Handle, IntPtr.Add(BuffWindowMOffset, PointersAndValues.Buff4FirstOffset))), 0);

                    return new Tuple<int, int, int, int>(firstbuff, secondBuff, thirdBuff, forthBuff);
                }
            }
        }

        static void SetGamePosition () // On laptop the position is different on screen
        {
            SetGameAsMainWindow();
            Thread.Sleep(1000);
            MouseOperations.SetCursorPosition(446, 129);
            Thread.Sleep(300);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.Move);
            Thread.Sleep(10);
            MouseOperations.SetCursorPosition(446, 133);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);

        }




    private static volatile int _anim1 = 0;
        private static volatile int _anim2 = 0;
        private static volatile int _skillValue = 0;

        public static int hpHealValue;

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


            baseNormalOffset = memBaseOffset.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalMOffset));

            cameraBaseOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.cameraBaseMOffset));

			cameraFogOffsetComp = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogMOffsetComp));
			cameraFogOffsetLapt = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.fogMOffsetLapt));

			antiBlackOffset = memNormal.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.antiBlackMOffset));

            mobSelectedOffset = memScanner.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.mobSelectedMOffset));

            mobBeingAttackedOffset = memScanner.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.baseNormalMOffset));

            itemMouseoverHighlightedOffset = memScanner.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.MouseoverHighlightedMOffset));

            sellAdressMOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.SellWindowMOffset));

            inventoryCurrentTabOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.inventoryCurrentTabMOffset));

            UIWindowMOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(client, PointersAndValues.UiWindowMOffset));

            BuffWindowMOffset = memRebuff.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.Buff1FirstOffOffset));

            isCurrentSkillTabMOffset = memSkill.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.CurrentSkillTabMOffset));

            shopWindowMOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.ShopWindow2MOffset));

            inventoryWindowMOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.InventoryWindow2MOffset));
            
            storageWindowMOffset = memSeller.readpointer(proc.Handle, IntPtr.Add(UIWindowMOffset, PointersAndValues.StorageWindow2MOffset));

            hpAddress = memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.hpOffset), 4);

            MannaAddress = memHealBot.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.MannaOffset), 4);

            skill1Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), 4);

            anim1Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim1Offset), 4);

            anim2Address = memSkill.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.anim2Offset), 4);

            slotFirstAddress = memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotHPOffset), 4);

            isCurrentSkillBar1Value = (IntPtr)PointersAndValues.CurrentSkillBar1Address;
            isCurrentSkillBar2Value = (IntPtr)PointersAndValues.CurrentSkillBar2Address;
            isCurrentSkillBar3Value = (IntPtr)PointersAndValues.CurrentSkillBar3Address;
            isItemHighlightedType = (IntPtr)PointersAndValues.CurrentItemHighlightedType;
            isAttackingMob = (IntPtr)PointersAndValues.isAttackingMob;
            SetGamePosition();
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

        public static void Start1HitKO(/*SkillSelector skillSelector*/)
        {

            while (_stopAnim)
            {
                if(ProgramHandle.isInCity != 1)
                {
                 //  skillSelector.SkillAssign();
                 // memSkill.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.skill1Offset), BitConverter.GetBytes(SkillToOverride));
                 //   memSkill.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.visualSkillAttack), BitConverter.GetBytes(0));

                  //  skillSelector.Rebuff();
                }

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

        public static void SetCameraLong()
        {
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceAnimValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
			memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffsetComp, PointersAndValues.cameraFogPointerComp), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
			// memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffsetLapt, PointersAndValues.cameraFogPointerLapt), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
			//  memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffset, PointersAndValues.cameraFogPointer), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
		}
		public static void AntiBlackScreener()
        {
            while (true)
            {
                memNormal.writebytes(proc.Handle, IntPtr.Add(antiBlackOffset, PointersAndValues.AntiBlack1Offset), BitConverter.GetBytes(1));
                memNormal.writebytes(proc.Handle, IntPtr.Add(antiBlackOffset, PointersAndValues.AntiBlack2Offset), BitConverter.GetBytes(1));
                memNormal.writebytes(proc.Handle, IntPtr.Add(antiBlackOffset, PointersAndValues.AntiBlack3Offset), BitConverter.GetBytes(1));
            }
        }

        public static void SetCameraForExpBot()
        {
            MouseOperations.SetCursorPosition(900, 500);
            SetGameAsMainWindow();
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraDistancePointer), BitConverter.GetBytes(PointersAndValues.cameraDistanceBotValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleYPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleYValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraBaseOffset, PointersAndValues.cameraAngleXPointer), BitConverter.GetBytes(PointersAndValues.cameraAngleXValue));
            memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffsetComp, PointersAndValues.cameraFogPointerComp), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
			//memNormal.writebytes(proc.Handle, IntPtr.Add(cameraFogOffsetLapt, PointersAndValues.cameraFogPointerLapt), BitConverter.GetBytes(PointersAndValues.cameraFogValue));
		}

		public static int isInCity
        {
            get
            {
                return memIsInCity.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.isInCityOffset));
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
        public static int getMaxWeight
        {
            get { return BitConverter.ToInt32(memWeight.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.WeightMaxOffset), 4)); }
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
        public static int getCurrentAC
        {
            get { return BitConverter.ToInt32(memNormal.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.currentAC), 4)); }
        }


        public static int isWhatAnimationRunning
        {
            get {return BitConverter.ToInt32(memAnimation.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.typeOfAnimationIsRunning), 4)); }
        }

        public static int isMobSelected
        {
            get { return BitConverter.ToInt32((memScanner.readbytes(proc.Handle, IntPtr.Add(mobSelectedOffset, PointersAndValues.mobSelected), 4)), 0); }
        }
        public static int isMobBeingAttacked
        {
            get { return BitConverter.ToInt32((memScanner.readbytes(proc.Handle, IntPtr.Add(mobBeingAttackedOffset, PointersAndValues.mobBeingTargeted), 4)), 0); }
        }
        public static int isItemHighlightedAtAll
        {
            get { return BitConverter.ToInt32((memScanner.readbytes(proc.Handle, IntPtr.Add(itemMouseoverHighlightedOffset, PointersAndValues.MouseoverHighlightedOffset), 4)), 0); }
        }
        public static int isSellWindowStillOpen
        {
            get { return memSeller.readByte(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellWindowOffset)); }
        }

        public static void OpenSellConfirmationUI()
        {
            memSeller.writebytes(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellWindowOffset), BitConverter.GetBytes(1));
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
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorToBasement.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorToBasement.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorToBasement.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorTo3rd.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorTo3rd.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2thFloorTo3rd.Item3));
                    _variableForChangablePosition = 0;
                }

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
            else if (GetCurrentMap == TeleportValues.SirosBasement1stFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stBasementFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stBasementFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros1stBasementFloor.Item3));
            }
            else if (GetCurrentMap == TeleportValues.SirosBasement2ndFloor)
            {
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSiros2ndBasementFloor.Item1));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSiros2ndBasementFloor.Item2));
                memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSiros2ndBasementFloor.Item3));
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
            else if (GetCurrentMap == TeleportValues.Hershal)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosHershalUWC.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniHershalTurtle.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniHershalTurtle.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniHershalTurtle.Item3));
                    _variableForChangablePosition = 0;
                }

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
			else if (GetCurrentMap == TeleportValues.COT13thFloor)
			{
				memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosCOT13thFloor.Item1));
				memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosCOT13thFloor.Item2));
				memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosCOT13thFloor.Item3));
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
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar1.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar1.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar1.Item3));
                    _variableForChangablePosition++;

                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1NoIceBergs.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1NoIceBergs.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1NoIceBergs.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 2)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar2.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar2.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar2.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 3)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar3.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar3.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar3.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 4)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar4.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar4.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor1BossBulgar4.Item3));
                    _variableForChangablePosition++;

                }
                else if (_variableForChangablePosition == 5)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.PosSlothFloor1.Item3));
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
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCubeMiddle.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCubeMiddle.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCubeMiddle.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 2)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCube.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCube.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.MiniPosSlothFloor2IceCube.Item3));
                    _variableForChangablePosition = 0;
                }
            }
            else if (GetCurrentMap == TeleportValues.KharonHorse)
            {
                if (_variableForChangablePosition == 0)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item3));
                    _variableForChangablePosition = 1;
                }
                else if (_variableForChangablePosition == 1)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item3));
                    _variableForChangablePosition++;
                }
                else if (_variableForChangablePosition == 2)
                {
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item1));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item2));
                    memTeleport.writebytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), BitConverter.GetBytes(TeleportValues.KharonHorseBulglarAoe.Item3));
                    _variableForChangablePosition = 0;
                }



            }


        }

        #endregion
        public static void StartAttackWhenMobSelectedBot()
        {

            while (_stopBot)
            {
                AttackMob.AttackMobCollectSod.CheckIfSelectedAndAttackSkill();
            }
            return;
        }
        static int ReadPositionShortX()
        {
            return BitConverter.ToInt16((memTeleport.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXShortOffset))), 0);
        }
        static int ReadPositionShortY()
        {
            return BitConverter.ToInt16((memTeleport.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYShortOffset))), 0);
        }
        static int ReadPositionShortZ()
        {
            return BitConverter.ToInt16((memTeleport.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZShortOffset))), 0);
        }
        static int ReadPositionX()
        {
            return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionXOffset), 4)), 0);
        }
        static int ReadPositionY()
        {
            return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionYOffset), 4)), 0);
        }
        static int ReadPositionZ()
        {
            return BitConverter.ToInt32((memTeleport.readbytes(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.positionZOffset), 4)), 0);
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
        public static int GetPositionZ
        {
            get
            {
                return ReadPositionZ();
            }
        }
        public static int GetPositionShortX
        {
            get
            {
                return ReadPositionShortX();
            }
        }
        public static int GetPositionShortY
        {
            get
            {
                return ReadPositionShortY();
            }
        }
        public static int GetPositionShortZ
        {
            get
            {
                return ReadPositionShortZ();
            }
        }




        public static void SetItemForSaleSelected(int itemforSaleNumber)
        {
            // ADD +27 - FIRST SALE INVENTORY ITEM STARTS FROM 27
            memSeller.writebytes(proc.Handle, IntPtr.Add(sellAdressMOffset, PointersAndValues.SellItemSelectedOffset), BitConverter.GetBytes(itemforSaleNumber+27));
        }

        public static byte ReadSellItemsByteValue(int offset)
        {
            return memSeller.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + (offset * 0x1c)));
        }

        public static byte ReadSellItemsStat1(int offset)
        {
            return memSeller.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + ((offset * 0x1c) - 2)));
        }

        public static byte ReadSellItemsStat2(int offset)
        {
            return memSeller.readByte(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + ((offset * 0x1c) - 1)));
        }
        public static int ReadSellItemsType(int offset)
        {
            return BitConverter.ToInt16(memSeller.readShort(proc.Handle, IntPtr.Add(baseNormalOffset, PointersAndValues.slotFirstSellOffset + ((offset * 0x1c) - 4))));
        }

        public static byte isShopWindowStillOpen()
        {
            return memSeller.readByte(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset1));
        }
        public static byte isCurrentSkillTabNr()
        {
            return memSkill.readByte(proc.Handle, IntPtr.Add(isCurrentSkillTabMOffset, PointersAndValues.CurrentSkillTabOffOffset));
        }
        public static byte isCurrentSkill()
        {
            if (isCurrentSkillTabNr() == 0)
            {
                return memSkill.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar1Value, 0));
            }
            else if (isCurrentSkillTabNr() == 1)
            {
                return memSkill.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar2Value, 0));
            }
            else if (isCurrentSkillTabNr() == 2)
            {
                return memSkill.readByte(proc.Handle, IntPtr.Add(isCurrentSkillBar3Value, 0));
            }
            else return 5;
        }


        public static int getCurrentItemHighlightedType
        {
           get { return BitConverter.ToInt16((memScanner.readShort(proc.Handle, IntPtr.Add(isItemHighlightedType, 0))), 0); }
        }
        public static int isMouseClickedOnMob
        {
            get { return BitConverter.ToInt16((memAttacking.readShort(proc.Handle, IntPtr.Add(isAttackingMob, 0))), 0); }
        }

        public static void OpenShopWindow()
        {
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(shopWindowMOffset, PointersAndValues.ShopWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
        }
        public static void OpenStorageWindow()
        {
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(inventoryWindowMOffset, PointersAndValues.inventoryWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(storageWindowMOffset, PointersAndValues.StorageWindowOffset1), BitConverter.GetBytes(1));
            Thread.Sleep(10);
            memSeller.writebytes(proc.Handle, IntPtr.Add(storageWindowMOffset, PointersAndValues.StorageWindowOffset2), BitConverter.GetBytes(1));
            Thread.Sleep(10);

        }
        public static bool isNowStandingCity()
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationArcerEmpCity
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationArcerAlliCity
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSorcAlliCity
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSorcEmpCityF
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSpearAlliCity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isNowRunningCity()
        {
            if (ProgramHandle.isWhatAnimationRunning != PointersAndValues.isStandingAnimationArcerEmpCity
                || ProgramHandle.isWhatAnimationRunning != PointersAndValues.isStandingAnimationArcerAlliCity
                || ProgramHandle.isWhatAnimationRunning != PointersAndValues.isStandingAnimationSorcAlliCity
                || ProgramHandle.isWhatAnimationRunning != PointersAndValues.isStandingAnimationSorcEmpCityF
                || ProgramHandle.isWhatAnimationRunning != PointersAndValues.isStandingAnimationSpearAlliCity
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool isNowAttackingAnim()
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isAttackingSpearAlliAnimation
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isAttackingSorcAlliAnimation
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isAttackingBowAlliAnimation
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isAttackingKnightAlliAnimation
                || ProgramHandle.isWhatAnimationRunning == PointersAndValues.isAttackingBowEmpAnimation
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isAttacking()
        {
            /*            if (ProgramHandle.isMobBeingAttacked != -1 && !isNowStandingOut())
                        {
                            return true;
                        }
            */

            if (isNowAttackingAnim() || isNowRunningOut())
            {
                return true;
            }
            else
            { return false; }
        }
        public static bool isNowRunningOut()
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationArcALLIOutside ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationArcEMPOutside ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationSpearALLIOutside ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationSorcAlliStaffOutside ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isRunningAnimationSorcAlliOrbOutside
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void waitMouseInPos()
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedTicks < PointersAndValues.mouseWaitTimeMs * 1600)
            {
                Thread.Sleep(0);
            }
        }
        public static void waitMouseInPosScanUnder()
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedTicks < PointersAndValues.mouseWaitTimeMs * 2000)
            {
                Thread.Sleep(0);
            }
        }
        public static bool isNowStandingOut()
        {
            if (ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSorcAlliOutStaff ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationArcerEmpOut ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationArcerAlliOut ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSorcAlliOutOrb ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isStandingAnimationSpearAlliOut ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isBeingHitSorcAlli ||
                ProgramHandle.isWhatAnimationRunning == PointersAndValues.isBeingHitSorcAlli2
                )
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