using Utilities;


//TODO List
//TODO List
//TODO List
//TODO List
/*
 * 
 *          IF weight is lowet then x-200 and pixel attack returned 0 run collect items
 *          
            Sell items from inventory propably has to sell last slot item all the time so that bot knows whether there is full storage to go to Sell and Repot
            
            Try to change black To maybe Red or Something so it wont scan after walls in uwc
            if it doesnt work need to go for wolves


            



WINDOW POSITION
                    446
                    133
*/
//TODO List
//TODO List
//TODO List
//TODO List
//TODO List
//TODO List
//TODO List










namespace AresTrainerV3
{
    public partial class Form1 : Form
    {
        static Thread healbotThread;
        static Thread animbotThread = new Thread(ProgramHandle.Start1HitKO);
        static Thread expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
        static Thread pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
        static Thread ChangeKoHitValueThread = new Thread(ProgramHandle.Change1HitKoValue);
        // static Thread ChangeKoHitValueThread = new Thread(ProgramHandle.TestFoundValues);
        static Thread expBotMoveThread = new Thread(TemporatyThreadMoveMethod);



        static Thread threadForTesting = new Thread(StartScanAndAttackAndCollect);




        public static void StartThreadForTesting()
        {
            ExpBotClass.RequestisExpBotSell();
            Thread.Sleep(500);
            if (threadForTesting == null)
            {
                threadForTesting = new Thread(StartScanAndAttackAndCollect);
            }

            if (!threadForTesting.IsAlive)
            {
                threadForTesting = new Thread(StartScanAndAttackAndCollect);
                threadForTesting.Start();
            }

            // also starts healbot automaticalyy

            StartHealBotThreadSellKharon();
        }

        static void StartScanAndAttackAndCollect()
        {
            ProgramHandle.SetCameraForExpBot();

            while (ExpBotClass.isExpBotSell)
            {
                PixelBotSearcher.ScanAndAttackAndCollect();
            }    
        }












        globalKeyboardHook gkh = new globalKeyboardHook();

        static int ValueForAddSubstract = 1000;

        public Form1()
        {
            InitializeComponent();

            ProgramHandle.InitializeProgram();
            MannaValueTextBox.Text = ProgramHandle.MannaRestoreValue.ToString();
            HPValueTextBox.Text = ProgramHandle.hpHealValue.ToString();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.HookedKeys.Add(Keys.F5);
            gkh.HookedKeys.Add(Keys.F6);
            gkh.HookedKeys.Add(Keys.F9);

           //
           //SUBSCRIBE globalKeyboardHook.
           //
            gkh.KeyF2Down += StartHealBotThreadNormal;
            // gkh.KeyF3Down += StartMoveAndExpThread; // START TEMPORATY MO
            gkh.KeyF3Down += StartThreadForTesting;
            gkh.KeyF3Down += ShowIfOnOrOff;
            gkh.KeyF4Down += Start1HitKoThread;
            gkh.KeyF4Down += ShowIfOnOrOff; 
            gkh.KeyF5Down += ProgramHandle.Teleporting;
            gkh.KeyF6Down += AttackWhenMobSelectedThread;
            gkh.KeyF6Down += ShowIfOnOrOff;
            //gkh.KeyF9Down += StartKoHitThread;
            gkh.KeyF9Down += StartChangeValuesKoHitThread;

            gkh.KeyF9Down += ShowIfOnOrOff;
        }

        public static void StartHealBotThreadNormal()
        {
            ProgramHandle.RequestStopHealBot();
            Thread.Sleep(500);
            if (healbotThread == null)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotNormal);
            }

            if (!healbotThread.IsAlive)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotNormal);
                healbotThread.Start();
            }
        }
        public static void StartHealBotThreadSellKharon()
        {
            // !!!!!!!!!!!!!!!!!!!!!!  TODO if some other healbot is on  turn it off;
            if (!ProgramHandle.isStopHeal)
            {
                ProgramHandle.RequestStopHealBot();
            }

            Thread.Sleep(500);
            if (healbotThread == null)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotSellKharon);
                healbotThread.Start();

            }

            if (!healbotThread.IsAlive)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotSellKharon);
                healbotThread.Start();
            }
        }



        public static void StartHealBotThreadGolems()
        {
            ProgramHandle.RequestStopHealBot();
            Thread.Sleep(500);
            if (healbotThread == null)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotGolems);
            }

            if (!healbotThread.IsAlive)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotGolems);
                healbotThread.Start();
            }
        }
        public static void StartHealBotThreadKoHit()
        {
            ProgramHandle.RequestStopHealBot();
            Thread.Sleep(500);
            if (healbotThread == null)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotKoHitTest);
            }

            if (!healbotThread.IsAlive)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbotKoHitTest);
                healbotThread.Start();
            }
        }
        public static void StartPixelGolemsThread()
        {
            PixelBotSearcher.RequestStopPixelAttack();
            Thread.Sleep(500);
            if (pixelExpBotGolemsPlatform == null)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
            }

            if (!pixelExpBotGolemsPlatform.IsAlive)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
                pixelExpBotGolemsPlatform.Start();
            }
        }

        public static void StartOnlyPixelScanThread()
        {
            PixelBotSearcher.RequestStopPixelAttack();
            Thread.Sleep(500);
            if (pixelExpBotGolemsPlatform == null)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
            }

            if (!pixelExpBotGolemsPlatform.IsAlive)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
                pixelExpBotGolemsPlatform.Start();
            }
        }
        public static void StartKoHitThread()
        {
            PixelBotSearcher.RequestStopPixelAttack();
            Thread.Sleep(500);
            if (pixelExpBotGolemsPlatform == null)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
            }

            if (!pixelExpBotGolemsPlatform.IsAlive)
            {
                pixelExpBotGolemsPlatform = new Thread(PixelBotSearcher.PixelOnlyScanAndAttack);
                pixelExpBotGolemsPlatform.Start();
            }
        }
        public static void StartChangeValuesKoHitThread()
        {
            ProgramHandle.RequestStopKoChangeValue();
            Thread.Sleep(500);
            if (ChangeKoHitValueThread == null)
            {
                ChangeKoHitValueThread = new Thread(ProgramHandle.Change1HitKoValue);
            }

            if (!ChangeKoHitValueThread.IsAlive)
            {
                ChangeKoHitValueThread = new Thread(ProgramHandle.Change1HitKoValue);
                ChangeKoHitValueThread.Start();
            }
        }

        public static void StartMoveAndExpThread()
        {
            ExpBotClass.RequestStopMoveExpBot();
            Thread.Sleep(500);

            if (expBotMoveThread == null)
            {
                expBotMoveThread = new Thread(TemporatyThreadMoveMethod);
            }

            if (!expBotMoveThread.IsAlive)
            {
                expBotMoveThread = new Thread(TemporatyThreadMoveMethod);
                expBotMoveThread.Start();
            }

        }


        static void AttackWhenMobSelectedThread()
        {
            ProgramHandle.SetCameraForExpBot();

            Thread.Sleep(50);
            ProgramHandle.RequestStopExpBot();
            Thread.Sleep(50);


            if (expbotThread == null)
            {
                expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
            }
            if (!expbotThread.IsAlive)
            {
                expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
                expbotThread.Start();
            }

        }



        private void StartHealbotBTN_Click(object sender, EventArgs e)
        {
            StartHealBotThreadNormal();
        }

        private void ClassChangeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassChangeComboBox.SelectedIndex == 0)
            {
                PointersAndValues.skill1AnimValue = PointersAndValues.arcerAnim1;
                PointersAndValues.skill2AnimValue = PointersAndValues.arcerAnim2;
                PointersAndValues.skillValue = PointersAndValues.arcerFirstSkill;
                PointersAndValues.normal1AnimValue = PointersAndValues.arcerAnim1;
                PointersAndValues.normal2AnimValue = PointersAndValues.arcerAnim2;

            }

            if (ClassChangeComboBox.SelectedIndex == 1)
            {
                PointersAndValues.skill1AnimValue = PointersAndValues.spearSkillAnim1FirstSkill;
                PointersAndValues.skill2AnimValue = PointersAndValues.spearSkillAnim2;
                PointersAndValues.skillValue = PointersAndValues.spearFirstSkill;
            }
            if (ClassChangeComboBox.SelectedIndex == 2)
            {
                PointersAndValues.skill1AnimValue = PointersAndValues.mageAnim1;
                PointersAndValues.skill2AnimValue = PointersAndValues.mageAnim2;
                PointersAndValues.skillValue = PointersAndValues.mageStriking;
            }
            if (ClassChangeComboBox.SelectedIndex == 3)
            {
                PointersAndValues.skill1AnimValue = PointersAndValues.knightskilllAnim1;
                PointersAndValues.skill2AnimValue = PointersAndValues.knightskilllAnim2;
                PointersAndValues.skillValue = PointersAndValues.knightFirstBlunt;
                PointersAndValues.normal1AnimValue = PointersAndValues.knightNormalAnim1;
                PointersAndValues.normal2AnimValue = PointersAndValues.knightskilllAnim2;

            }


        }

        private void StartSkillBtn_Click(object sender, EventArgs e)
        {
            Start1HitKoThread();
        }
        static void Start1HitKoThread()
        {
            ProgramHandle.SetCameraLong();

           // ProgramHandle.SetAnim1Value = PointersAndValues.skill1AnimValue;
           // ProgramHandle.SetAnim2Value = PointersAndValues.skill2AnimValue;
           // ProgramHandle.SetSkillValue = PointersAndValues.skillValue;


            Thread.Sleep(50);
            ProgramHandle.RequestStopAnim();
            Thread.Sleep(50);


            if (animbotThread == null)
            {
                animbotThread = new Thread(ProgramHandle.Start1HitKO);
            }
            if (!animbotThread.IsAlive)
            {
                animbotThread = new Thread(ProgramHandle.Start1HitKO);
                animbotThread.Start();
            }
        }

        private void StartNormalBtn_Click(object sender, EventArgs e)
        {
           // StartNormalAttack();
        }




       private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int tempValue = 1000;
            int.TryParse(textBox1.Text,out tempValue);
            ValueForAddSubstract = tempValue;
        }

        private void AddAnimValue_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetAnim1Value += ValueForAddSubstract;
            TextBoxLog.Text = ProgramHandle.SetAnim1Value.ToString();
        }

        private void SubstractAnimValue_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetAnim1Value -= ValueForAddSubstract;
            TextBoxLog.Text = ProgramHandle.SetAnim1Value.ToString();

        }

        private void HPValueTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 100;
            int.TryParse(HPValueTextBox.Text,out i);
            ProgramHandle.hpHealValue = i;
        }

        private void MannaValueTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = ProgramHandle.MannaRestoreValue;
            int.TryParse(MannaValueTextBox.Text, out i);
            ProgramHandle.MannaRestoreValue = i;

        }

        void ShowIfOnOrOff()

        {

            if (!ProgramHandle.isStopAnim)
            {
                BtnHitKO.Text = "OFF";
                BtnHitKO.BackColor = Color.Gray;
            }
            else
            {
                BtnHitKO.Text = "ON";
                BtnHitKO.BackColor = Color.Yellow;
            }

            if (!ProgramHandle.isStopBot)
            {
                button1.Text = "OFF";
                button1.BackColor = Color.Gray;
            }
            else
            {
                button1.Text = "ON";
                button1.BackColor = Color.Yellow;

            }

            if (!PixelBotSearcher.isStopPixelAttack)
            {
                button2.Text = "OFF";
                button2.BackColor = Color.Gray;
            }
            else
            {
                button2.Text = "ON";
                button2.BackColor = Color.Yellow;

            }
            if (!ExpBotClass.isStopMoveExpBot)
            {
                button3.Text = "OFF";
                button3.BackColor = Color.Gray;
            }
            else
            {
                button3.Text = "ON";
                button3.BackColor = Color.Yellow;

            }
            if (!ProgramHandle.isStopHeal)
            {
                BtnHealbotOnOff.Text = "OFF";
                BtnHealbotOnOff.BackColor = Color.Gray;
            }
            else
            {
                BtnHealbotOnOff.Text = "ON";
                BtnHealbotOnOff.BackColor = Color.Yellow;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1); // terminate all procesess when closing the form
/*            gkh = null;
            if (ProgramHandle.isStopHeal)
            {
                ProgramHandle.RequestStopHealBot();
            }

            ProgramHandle.Request1hitKOBot();

            if (ProgramHandle.isStopHeal)
            {
                ProgramHandle.RequestStopHealBot();
            }
*/        }

        private void MouseScannerBtn_Click(object sender, EventArgs e)
        {
            AttackWhenMobSelectedThread();
        }

        #region OLD NORMAL ATTACK THREAD and Functuiobn
        // static Thread normalAttackThread = new Thread(ProgramHandle.StartNormalAttack);

        /*        static void StartNormalAttack()
        {
            ProgramHandle.SetAnim1Value = PointersAndValues.skill1AnimValue;
            ProgramHandle.SetAnim2Value = PointersAndValues.skill2AnimValue;
            ProgramHandle.SetSkillValue = PointersAndValues.skillValue;


            if (animbotThread.IsAlive)
            {
                ProgramHandle.RequestStopAnim();
            }
            Thread.Sleep(50);
            ProgramHandle.RequestStopAnim();
            Thread.Sleep(50);
            if (!normalAttackThread.IsAlive)
            {
                normalAttackThread = new Thread(ProgramHandle.StartNormalAttack);
                normalAttackThread.Start();
            }
        }

*/


        static void TemporatyThreadMoveMethod()
        {

            ProgramHandle.SetCameraForExpBot();
            if(!ProgramHandle.isStopHeal)
            {
                StartHealBotThreadNormal();
            }

            ExpBotClass.RunAndExpSquare();  // uwc values

        }


        #endregion

        private void Tester_Click(object sender, EventArgs e)
        {

            // ProgramHandle.TeleportKoHitTest();
            TextBoxLog.Text = ExpBotClass.ExpBotLog;
            // Thread.Sleep(5000);


            //ExpBotClass.Repot(ProgramHandle.GetCurrentMap);
          }

        private void TestingThread_Click(object sender, EventArgs e)
        {
            StartThreadForTesting();
        }

        private void FastTestBTN_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetNostalgiaMainWindow();
            Thread.Sleep(500);
            //ProgramHandle.SetCameraForExpBot();
            //ProgramHandle.MannaKeyPressKharonSell();
            ExpBotClass.Repot(ProgramHandle.GetCurrentMap);


            /// ExpBotClass.SellItems();
        }
    }
}
