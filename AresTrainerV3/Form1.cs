using Utilities;

namespace AresTrainerV3
{
    public partial class Form1 : Form
    {
        static Thread healbotThread = new Thread(ProgramHandle.StartHealbot);
        static Thread animbotThread = new Thread(ProgramHandle.Start1HitKO);
        static Thread expbotThread = new Thread(ProgramHandle.StartExpBot);

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


            gkh.KeyF2Down += StartHealBot; // SUBSCRIBE globalKeyboardHook.KeyFXxXPressed to KeyF2DownEvent
            gkh.KeyF3Down += StartMoveBot;
            gkh.KeyF4Down += StartSkillAttack;
            gkh.KeyF4Down += ShowIfOnOrOff; // SUBSCRIBE function to chane button visibility according to state of speed
            gkh.KeyF5Down += ProgramHandle.Teleporting;
            gkh.KeyF6Down += StartExpBot;



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
        static void StartHealBot()
        {
            ProgramHandle.RequestStopHeal();
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

        static void StartExpBot()
        {
            ProgramHandle.SetCameraForExpBot();

            Thread.Sleep(50);
            ProgramHandle.RequestStopBot();
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
            StartHealBot();
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

            if (!ProgramHandle.StopAnim)
            {
                OnOffButton.Text = "OFF";
                OnOffButton.BackColor = Color.Gray;
            }
            else
            {
                OnOffButton.Text = "ON";
                OnOffButton.BackColor = Color.Yellow;

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gkh = null;
            ProgramHandle.RequestStopAnim();
            ProgramHandle.RequestStopHeal();

        }






        private void MouseScannerBtn_Click(object sender, EventArgs e)
        {
            StartExpBot();
        }

        void StartMoveBot()
        {
            ProgramHandle.MoveToPosition(1147303303, 1124479960);
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

    }
}
