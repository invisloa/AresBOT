using AresTrainerV3.AttackMob;
using AresTrainerV3.Buyer;
using AresTrainerV3.DoWhileMoving;
using AresTrainerV3.ExpBotManager;
using AresTrainerV3.HealBot;
using AresTrainerV3.HealBot.Repoter;
using AresTrainerV3.ItemCollect;
using AresTrainerV3.MovePositions;
using AresTrainerV3.MoveRandom;
using AresTrainerV3.MoveRandom.Etana;
using AresTrainerV3.MoveRandom.Hershal;
using AresTrainerV3.MoveRandom.Holina;
using AresTrainerV3.MoveRandom.Kharon;
using AresTrainerV3.MoveRandom.SacredAlliance;
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
        public static HealBotAbstract HealbotToRun = new HealBotOnlyHeal();
        globalKeyboardHook gkh = new globalKeyboardHook();

        MoverRandom ExpBotMoverToRun;


        public Form1()
        {
            InitializeComponent();
            ProgramHandle.InitializeProgram();
            HealbotToRun.setHealbotValues();
            HPValueTextBox.Text = HealBotAbstract.HpHealValue.ToString();
            MannaValueTextBox.Text = HealBotAbstract.MpRestoreValue.ToString();
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
     //       gkh.KeyF3Down += ;
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
            int i = 100;
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
            System.Environment.Exit(1); 
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

            TextBoxLog.Text = ExpBotClass.ExpBotLog;
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

        private void teleport_Click(object sender, EventArgs e)
        {
            ProgramHandle.TeleportToPositionTuple(TeleportValues.HershalMagicExp);

        }

        private void ShowPositionsBtn_Click(object sender, EventArgs e)
        {
            PositionX.Text = ProgramHandle.GetPositionX.ToString();
            PositionY.Text = ProgramHandle.GetPositionY.ToString();
        }
        private void ShowPosShort_Click(object sender, EventArgs e)
        {
            PositionX.Text = ProgramHandle.GetPositionShortX.ToString();
            PositionY.Text = ProgramHandle.GetPositionShortY.ToString();

        }


        private void GoToPos_Click(object sender, EventArgs e)
        {
            ProgramHandle.TeleportToPosition(Int32.Parse(PositionX.Text), Int32.Parse(PositionY.Text), 0);
        }



        private void FastTestBTN_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
           // MoverRandom mover = new MoverRandom(TeleportValues.Hershal, TeleportValues.moverRandomHershalLowLvl);

            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

            //    mover.MoveAttackCollect();
            }

        }


        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

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
        }
        private void RunSellerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BuyerPotions.BuyFromForm = true;
            BuyerPotions.HpPotionsToBuy = 20;
            HpToBuy.Text = BuyerPotions.HpPotionsToBuy.ToString();
            BuyerPotions.MpPotionsToBuy = 5;
            MpToBuy.Text = BuyerPotions.MpPotionsToBuy.ToString();
            BuyerPotions.SpeedPotionsToBuy = 3;
            SpeedPot.Text = BuyerPotions.SpeedPotionsToBuy.ToString();
            HealBotAbstract.SellItems = true;
            SellItemsCheckBox.Checked = true;
            DoScanAttackCollect.NumberOfCollectScans = 2;
            NumberOfCollectScans.Text = DoScanAttackCollect.NumberOfCollectScans.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void MoverGoblins_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();
           // ProgramHandle.TeleportToPositionTuple(TeleportValues.HolinaGoblinsExp);
            Thread.Sleep(2000);
            ExpBotManagerAbstract.RequestStartExpBot();
          //  MoverRandom mover = new MoverRandom(TeleportValues.Hollina ,TeleportValues.moverRandomHolinaGoblins);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                    ExpBotManagerAbstract.RequestStopExpBot();
                    HealBotAbstract.RequestStopHealBot();

                }

             //   mover.MoveAttackCollect();
            }


        }

        private void EtanaBot_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
           // MoverRandom mover = new MoverRandom(TeleportValues.Etana, TeleportValues.moverRandomEtanaBuckys);



            
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

               // mover.MoveAttackCollect();
            }

        }
        private void TestMethod_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
            //  MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand, TeleportValues.moverRandomThievesUnder);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }
             //   mover.MoveAttackCollect();
            }
        }

        private void MoverGiko_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetCameraForExpBot();

            HealbotToRun = new HealBotOnlyHeal();
            HealbotToRun.StartHealBotThread();

            ExpBotManagerAbstract.RequestStartExpBot();
           // MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand, TeleportValues.moverRandomSacredGiko);




            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }

              //  mover.MoveAttackCollect();
            }

        }
/*        void RunMoverExpBot()
        {
            HealbotToRun.StartHealBotThread();
            ProgramHandle.SetCameraForExpBot();
            ExpBotManagerAbstract.RequestStartExpBot();


            // MoverRandom mover = new MoverRandom(TeleportValues.AllianceSacredLand);
            while (ExpBotManagerAbstract.isExpBotRunning)
            {
                if (ProgramHandle.isInCity == 1 && ExpBotManagerAbstract.shutDownOnRepot)
                {
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                }
                ExpBotMoverToRun.MoveAttackCollect();
            }


        }
*/


/*private void HealbotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HealbotComboBox.SelectedItem.ToString() == "HealbotOnly")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "Etana")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "Sacred")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "Holina")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "Hershal")
            {
                HealbotToRun = new HealBotHershalExp();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "Kharon")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "UWC")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }
            else if (HealbotComboBox.SelectedItem.ToString() == "COT")
            {
                HealbotToRun = new HealBotOnlyHeal();
            }

        }
        
*/        private void ExpBotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ExpBotComboBox.SelectedItem.ToString() == "EtanaBuckerty")
            {
                ExpBotMoverToRun = new MoverEtanaBuckerty();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;

            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "SacredGiko")
            {
                ExpBotMoverToRun = new MoverGiko();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;
            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "SacredThieves")
            {
                ExpBotMoverToRun = new MoverThievesUnder();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;
            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "HolinaGoblins")
            {
                ExpBotMoverToRun = new MoverHolinaGoblins();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.NoRepot;
            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "HershalLeafMages")
            {
                ExpBotMoverToRun = new MoverHershalLeafMages();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HershalLeafMages;
            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "HershalUWC1stFloor")
            {
                ExpBotMoverToRun = new MoverHershalUwc1stFloor();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.HershalUWC1stFloor;
            }
            else if (ExpBotComboBox.SelectedItem.ToString() == "KharonWolves")
            {
                ExpBotMoverToRun = new MoverKharonWolves();
                HealbotToRun.whichBotThreadToStart = Enums.EnumsList.MoverBotEnums.KharonWolves;
            }
        }

        private void CollectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CollectorComboBox.SelectedItem.ToString() == "+Event")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.Event;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSodEvent())); 
            }
            else if (CollectorComboBox.SelectedItem.ToString() == "+Jewelery")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.Jewelery;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSodJewelery()));
            }
            else if (CollectorComboBox.SelectedItem.ToString() == "+Stones")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.Stones;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSodStones()));
            }
            else if (CollectorComboBox.SelectedItem.ToString() == "+Stones+Jewelery")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.StonesAndJewelery;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSodStonesJewleryItems()));
            }
            else if (CollectorComboBox.SelectedItem.ToString() == "+Seller")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.SellWeapons;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectSellerCry()));
            }
            else if (CollectorComboBox.SelectedItem.ToString() == "AllItems")
            {
                HealbotToRun.whatToCollect = Enums.EnumsList.WhatToCollectEnums.SellAll;
                ExpBotMoverToRun.attackAndCollectSODDefault = new DoScanAttackCollect(new PixelItemCollector(new CollectAllItems()));
            }
        }

        private void ShutDownWhenInCity_CheckedChanged(object sender, EventArgs e)
        {
            if(ShutDownWhenInCity.Checked)
            {
                ExpBotManagerAbstract.shutDownOnRepot = true;
            }
            else
            {
                ExpBotManagerAbstract.shutDownOnRepot = false;
            }
        }

        private void CollectItemsBox_CheckedChanged(object sender, EventArgs e)
        {
            if(CollectItemsBox.Checked)
            {
                DoScanAttackCollect.CollectItems = true;
            }
            else
            {
                DoScanAttackCollect.CollectItems = false;
            }
        }

        private void RunExpBot_Click(object sender, EventArgs e)
        {
            HealbotToRun.StartHealBotThread();
            ProgramHandle.SetCameraForExpBot();

            ExpBotMoverToRun.StartExpBotThread();

        }
        private void fasttest_Click(object sender, EventArgs e)
        {
            while(true)
            {
                PositionX.Text = ProgramHandle.getCurrentAttackSpeed.ToString();
                Refresh();
                //1073741824
            }
            /*            int i;
                        RepoterKharonExp zzz = new RepoterKharonExp();
                        zzz.GoRepot();
            *//*

            ProgramHandle.AntiBlackScreener();
*/
        }

        private void GoToPos_Click_1(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            Int32.TryParse(PositionX.Text, out x);
            Int32.TryParse(PositionY.Text, out y);
            ProgramHandle.TeleportToPosition(x, y, 0);
        }
    }
/*    
    



*/
}
