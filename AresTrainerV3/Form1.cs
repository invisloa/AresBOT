using Utilities;

namespace AresTrainerV3
{
    public partial class Form1 : Form
    {
        static Thread healbotThread = new Thread(ProgramHandle.StartHealbot);
        static Thread animbotThread = new Thread(ProgramHandle.Start1HitKO);
        static Thread expbotThread = new Thread(ProgramHandle.StartExpBot);
        static Thread pixelBotThread = new Thread(PixelBotSearcher.SearchPixel);

        static Thread expBotMoveThread = new Thread(TemporatyThreadMoveMethod);


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
            gkh.KeyF2Down += StartHealBotThread; 
            gkh.KeyF3Down += TemporaryThreadStartMoveMethod; // START TEMPORATY MO
            gkh.KeyF3Down += ShowIfOnOrOff;
            gkh.KeyF4Down += StartSkillAttack;
            gkh.KeyF4Down += ShowIfOnOrOff; 
            gkh.KeyF5Down += ProgramHandle.Teleporting;
            gkh.KeyF6Down += StartExpBotThread;
            gkh.KeyF6Down += ShowIfOnOrOff;
            gkh.KeyF9Down += StartPixelBotThread;
            gkh.KeyF9Down += ShowIfOnOrOff;




            // gkh.KeyF4Down += new globalKeyboardHook.KeyFXxXPressed(StartNormalAttack); //JUST ANOTHER WAY TO SUBSCRIBE DELEGATE with new...
        }

        /*        void gkh_KeyUp(object sender, KeyEventArgs e)
                {
                    lstLog.Items.Add("Up\t" + e.KeyCode.ToString());
                    e.Handled = true;
                }

                void gkh_KeyDown(object sender, KeyEventArgs e)
                {
                    lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
                    e.Handled = true;
                }
        */
        static void StartHealBotThread()
        {
            ProgramHandle.RequestStopHealBot();
            Thread.Sleep(500);
            if (healbotThread == null)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbot);
            }

            if (!healbotThread.IsAlive)
            {
                healbotThread = new Thread(ProgramHandle.StartHealbot);
                healbotThread.Start();
            }
        }
        static void StartPixelBotThread()
        {
            PixelBotSearcher.RequestStopPixel();
            Thread.Sleep(500);
            if (pixelBotThread == null)
            {
                pixelBotThread = new Thread(PixelBotSearcher.SearchPixel);
            }

            if (!pixelBotThread.IsAlive)
            {
                pixelBotThread = new Thread(PixelBotSearcher.SearchPixel);
                pixelBotThread.Start();
            }
        }
        static void TemporaryThreadStartMoveMethod()
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


        static void StartExpBotThread()
        {
            ProgramHandle.SetCameraForExpBot();

            Thread.Sleep(50);
            ProgramHandle.RequestStopExpBot();
            Thread.Sleep(50);


            if (expbotThread == null)
            {
                expbotThread = new Thread(ProgramHandle.StartExpBot);
            }
            if (!expbotThread.IsAlive)
            {
                expbotThread = new Thread(ProgramHandle.StartExpBot);
                expbotThread.Start();
            }

        }



        private void StartHealbotBTN_Click(object sender, EventArgs e)
        {
            StartHealBotThread();
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
            StartSkillAttack();
        }
        static void StartSkillAttack()
        {
            ProgramHandle.SetCameraForSpeed();

            ProgramHandle.SetAnim1Value = PointersAndValues.skill1AnimValue;
            ProgramHandle.SetAnim2Value = PointersAndValues.skill2AnimValue;
            ProgramHandle.SetSkillValue = PointersAndValues.skillValue;


            //
            // THERE IS NOT NORMALATACKTHREAD now so dont need to check for it
            //  
            /*            if (normalAttackThread.IsAlive)
                                        {
                                            ProgramHandle.RequestStopAnim();
                                        }
                            */
            Thread.Sleep(50);
            ProgramHandle.Request1hitKOBot();
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
            ValuesTextBox.Text = ProgramHandle.SetAnim1Value.ToString();
        }

        private void SubstractAnimValue_Click(object sender, EventArgs e)
        {
            ProgramHandle.SetAnim1Value -= ValueForAddSubstract;
            ValuesTextBox.Text = ProgramHandle.SetAnim1Value.ToString();

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
                OnOffButton.Text = "OFF";
                OnOffButton.BackColor = Color.Gray;
            }
            else
            {
                OnOffButton.Text = "ON";
                OnOffButton.BackColor = Color.Yellow;

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

            if (!PixelBotSearcher.isStopPixel)
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


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gkh = null;
            ProgramHandle.Request1hitKOBot();
            ProgramHandle.RequestStopHealBot();

        }

        private void MouseScannerBtn_Click(object sender, EventArgs e)
        {
            StartExpBotThread();
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
           // uwc ExpBotClass.goLeft(600, 520, 1109300565, 1110599230, 1109794945);
            ExpBotClass.goLeft(600, 520, 1120742008, 1144212271, 1144065573);  // thieves

        }


        #endregion

        private void Tester_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            TemporaryThreadStartMoveMethod();


            // ExpBotClass.goLeft(600, 520, 1109300565, 1110599230, 10);


            //    ExpBotClass.Repot(ProgramHandle.GetCurrentMap);
            /*            PixelBotSearcher pix = new PixelBotSearcher();

                        // ExpBotClass.Repot(ProgramHandle.GetCurrentMap);
                        pix.SearchPixel("#433B00");
                        GC.Collect();
            */
          }
    }
}
