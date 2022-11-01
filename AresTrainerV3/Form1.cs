using AresTrainerV3.Buyer;
using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManagement;
using AresTrainerV3.ExpBotManagement.Etana;
using AresTrainerV3.ExpBotManagement.Hershal;
using AresTrainerV3.ExpBotManagement.Holina;
using AresTrainerV3.ExpBotManagement.Kharon;
using AresTrainerV3.ExpBotManagement.Sacred;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using AresTrainerV3.MoveRandom;
using AresTrainerV3.SkillSelection;
using AresTrainerV3.Unstuck;
using System.Diagnostics;
using Utilities;







namespace AresTrainerV3
{
    public partial class Form1 : Form
    {
        static Thread animbotThread;
        static Thread expbotThread = new Thread(ProgramHandle.StartAttackWhenMobSelectedBot);
        public SkillSelector CurrentlySelectedClass = SkillSelector.SelectPropperClass();
        HealBotAbstract HealbotToRun;
        globalKeyboardHook gkh = new globalKeyboardHook();

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
            gkh.HookedKeys.Add(Keys.F8);
            gkh.HookedKeys.Add(Keys.F9);
            //
            //SUBSCRIBE globalKeyboardHook.
            //
            gkh.KeyF2Down += StartOnlyHealbotThread;
            gkh.KeyF2Down += ShowIfOnOrOff;
            gkh.KeyF3Down += StartHolinaGoblinsBot;
            gkh.KeyF3Down += ShowIfOnOrOff;
            gkh.KeyF4Down += Start1HitKoThread;
            gkh.KeyF4Down += ShowIfOnOrOff;
            gkh.KeyF5Down += ProgramHandle.Teleporting;
            gkh.KeyF6Down += AttackWhenMobSelectedThread;
            gkh.KeyF6Down += ShowIfOnOrOff;
            gkh.KeyF9Down += ShowIfOnOrOff;
        }

        void StartOnlyHealbotThread()
        {
            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                HealBotAbstract.SelfSetHealValue = true;
            }
            else
            {
                HealBotAbstract.SelfSetHealValue = false;

            }
        }



        public void startSacredLandsBot()
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();
            ProgramHandle.TeleportToPositionTuple(TeleportValues.SacredlandsAlliExp);

            HealBotAbstract HealBotToStart = new HealBotSacredAlli();
            HealBotToStart.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTostart = new ExpBotSacredAlliExp();
            ExpBotTostart.StartExpBotThread();
        }

        public void StartHolinaGoblinsBot()
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();
            ProgramHandle.TeleportToPositionTuple(TeleportValues.HolinaGoblinsExp);


            HealBotAbstract HealBotToStart = new HealBotHolinaExp();
            HealBotToStart.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTostart = new ExpBotHolinaSod();
            ExpBotTostart.StartExpBotThread();

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
        void Start1HitKoThread()
        {
            ProgramHandle.SetCameraLong();
            CurrentlySelectedClass = SkillSelector.SelectPropperClass();

            Thread.Sleep(50);
            ProgramHandle.RequestStopAnim();
            Thread.Sleep(50);


            if (animbotThread == null)
            {
                animbotThread = new Thread(() => ProgramHandle.Start1HitKO(CurrentlySelectedClass));
            }
            if (!animbotThread.IsAlive)
            {
                animbotThread = new Thread(() => ProgramHandle.Start1HitKO(CurrentlySelectedClass));
                animbotThread.Start();
            }
        }

        private void StartNormalBtn_Click(object sender, EventArgs e)
        {
            // StartNormalAttack();
        }



        private void HpToBuy_TextChanged(object sender, EventArgs e)
        {
            if (HpToBuy.Text != "0")
            {
                BuyerPotions.BuyFromForm = true;
            }
            int i = 0;
            int.TryParse(HpToBuy.Text, out i);
            BuyerPotions.HpPotionsToBuy = i;
        }

        private void MpToBuy_TextChanged(object sender, EventArgs e)
        {
            {
                int i = 0;
                int.TryParse(MpToBuy.Text, out i);
                BuyerPotions.MpPotionsToBuy = i;

            }
        }

        private void SpeedPot_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            int.TryParse(SpeedPot.Text, out i);
            BuyerPotions.SpeedPotionsToBuy = i;

        }

        private void BuyMaxHp_CheckedChanged(object sender, EventArgs e)
        {
            if (BuyMaxHp.Checked)
            {
                BuyerPotions.BuyMaxPotions = true;
            }
            else
            {
                BuyerPotions.BuyMaxPotions = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddAnimValue_Click(object sender, EventArgs e)
        {
        }

        private void SubstractAnimValue_Click(object sender, EventArgs e)
        {

        }

        private void HPValueTextBox_TextChanged(object sender, EventArgs e)
        {

            int i = 100;
            int.TryParse(HPValueTextBox.Text, out i);
            HealBotAbstract.HpHealValue = i;
        }

        private void MannaValueTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = ProgramHandle.MannaRestoreValue;
            int.TryParse(MannaValueTextBox.Text, out i);
            HealBotAbstract.MpRestoreValue = i;
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

            /*            if (!BitmapCreator.isStopPixelAttack)
                        {
                            button2.Text = "OFF";
                            button2.BackColor = Color.Gray;
                        }
                        else
                        {
                            button2.Text = "ON";
                            button2.BackColor = Color.Yellow;

                        }
            */
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
            */
        }

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

        }
        private void SellItems_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetGameAsMainWindow();
            //ProgramHandle.OpenShopWindow();
            Thread.Sleep(1000);

            ItemSeller.SellItemsMouseMove();


            /*            foreach (var item in ItemSeller.itemsForSaleList)
                        {
                            Debug.WriteLine($"{item.ToString()}");
                        }
            */

        }


        private void OpenStorageBTN_Click(object sender, EventArgs e)
        {
            ProgramHandle.OpenStorageWindow();
        }
        private void SetWindowPos_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(1000);
            MouseOperations.SetCursorPosition(446, 129);
            Thread.Sleep(300);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(300);

            MouseOperations.SetCursorPosition(446, 133);
            MouseOperations.SetCursorPosition(446, 133);
            MouseOperations.SetCursorPosition(446, 133);
            Thread.Sleep(300);

            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);

        }

        private void teleport_Click(object sender, EventArgs e)
        {
            ProgramHandle.TeleportToPositionTuple(TeleportValues.MiniHershalTurtle);

        }




        private void Tester_Click_1(object sender, EventArgs e)
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();
            ProgramHandle.TeleportToPositionTuple(TeleportValues.HolinaGoblinsExp);


            HealbotToRun = new HealBotHolinaExp();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTostart = new ExpBotHolinaSod();
            ExpBotTostart.StartExpBotThread();


        }
        private void FastTestBTN_Click(object sender, EventArgs e)
        {
            ProgramHandle.TeleportToPositionTuple(TeleportValues.HershalMagicExp);
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotHershalExp();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTest = new ExpBotHershalSellLeafMages();
            ExpBotTest.StartExpBotThread();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ProgramHandle.TeleportToPositionTuple(TeleportValues.SacredlandsAlliExp);
            //ProgramHandle.TeleportToPosition(1142406013, 1134435082, 0);
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotSacredAlli();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTest = new ExpBotSacredAlliExp();
            ExpBotTest.StartExpBotThread();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();
            ExpBotClass.WalkIntoUWC();

            HealbotToRun = new HealBotUWC();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTest = new ExpBotUWC();
            ExpBotTest.StartExpBotThread();


        }

        private void SellItemsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(SellItemsCheckBox.Checked)
            {
                HealBotAbstract.SellItems = true;
                checkBox1.Checked = false;
            }
            else
            {
                HealBotAbstract.SellItems = false;
            }
        }

        private void NumberOfCollectScans_TextChanged(object sender, EventArgs e)
        {
            int i = 1;
            int.TryParse(NumberOfCollectScans.Text, out i);
            DoScanAttackCollect.NumberOfCollectScans = i;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotKharonExp();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract ExpBotTest = new ExpBotKharonWolvesExp();
            ExpBotTest.StartExpBotThread();

        }
        private void RunSellerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BuyerPotions.BuyFromForm = true;
            BuyerPotions.HpPotionsToBuy = 70;
            HpToBuy.Text = BuyerPotions.HpPotionsToBuy.ToString();
            BuyerPotions.MpPotionsToBuy = 45;
            MpToBuy.Text = BuyerPotions.MpPotionsToBuy.ToString();
            BuyerPotions.SpeedPotionsToBuy = 4;
            SpeedPot.Text = BuyerPotions.SpeedPotionsToBuy.ToString();
            HealBotAbstract.SellItems = true;
            SellItemsCheckBox.Checked = true;
            DoScanAttackCollect.NumberOfCollectScans = 3;
            NumberOfCollectScans.Text = DoScanAttackCollect.NumberOfCollectScans.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExpBotManagerAbstract.RequestStartExpBot();
            AbstractWhatToCollect allCollect = new CollectAllItems();
            PixelItemCollector pixelSodCollect = new PixelItemCollector(allCollect);
            ProgramHandle.SetGameAsMainWindow();
            Thread.Sleep(599);
            ProgramHandle.SetCameraForExpBot();
            int i = 0;

            
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                while (!ProgramHandle.isNowStandingOut())
                {
                    Debug.WriteLine(ProgramHandle.isWhatAnimationRunning);
                    //pixelSodCollect.ClickAndCollectItem();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void MoverGoblins_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
            MoverRandom mover = new MoverRandom(TeleportValues.Hollina);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

                mover.MoveAttackCollect(DirectionsEnum.Around, TeleportValues.moverRandomHolinaGoblins.Item1,
                    TeleportValues.moverRandomHolinaGoblins.Item2, TeleportValues.moverRandomHolinaGoblins.Item3, TeleportValues.moverRandomHolinaGoblins.Item4);
            }


        }

        private void EtanaBot_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
            MoverRandom mover = new MoverRandom(TeleportValues.Etana);



            
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

                mover.MoveAttackCollect(DirectionsEnum.Around, TeleportValues.moverRandomEtanaBuckys.Item1,
                    TeleportValues.moverRandomEtanaBuckys.Item2, TeleportValues.moverRandomEtanaBuckys.Item3, TeleportValues.moverRandomEtanaBuckys.Item4);
            }

        }
        private void TestMethod_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
            MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }
                mover.MoveAttackCollect(DirectionsEnum.Around, TeleportValues.moverRandomThievesUnder.Item1,
                    TeleportValues.moverRandomThievesUnder.Item2, TeleportValues.moverRandomThievesUnder.Item3, TeleportValues.moverRandomThievesUnder.Item4);
            }
        }


        private void MoverGiko_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
            MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

                mover.MoveAttackCollect(DirectionsEnum.Around, TeleportValues.moverRandomSacredGiko.Item1,
                    TeleportValues.moverRandomSacredGiko.Item2, TeleportValues.moverRandomSacredGiko.Item3,
                    TeleportValues.moverRandomSacredGiko.Item4);
            }

        }
    }
}
