using Utilities;

namespace AresTrainerV3
{
    public partial class Form1 : Form
    {
        static Thread healbotThread;
        static Thread animbotThread = new Thread(ProgramHandle.StartAnimBot);
        static Thread normalAttackThread = new Thread(ProgramHandle.StartNormalAttack);
        globalKeyboardHook gkh = new globalKeyboardHook();

        static int ValueForAddSubstract = 1000;

        public Form1()
        {

            InitializeComponent();
            ProgramHandle.InitializeProgram();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.KeyF2Down += StartHealBot; // SUBSCRIBE globalKeyboardHook.KeyFXxXPressed to KeyF2DownEvent
            gkh.KeyF3Down += StartSkillAttack;
            gkh.KeyF4Down += new globalKeyboardHook.KeyFXxXPressed(StartNormalAttack); //JUST ANOTHER WAY TO SUBSCRIBE DELEGATE with new...
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
            ProgramHandle.SetCamera();

            ProgramHandle.SetAnim1Value = PointersAndValues.skill1AnimValue;
            ProgramHandle.SetAnim2Value = PointersAndValues.skill2AnimValue;
            ProgramHandle.SetSkillValue = PointersAndValues.skillValue;

            if (normalAttackThread.IsAlive)
            {
                ProgramHandle.RequestStopAnim();
            }
            Thread.Sleep(50);
            ProgramHandle.RequestStopAnim();
            Thread.Sleep(50);
            if (animbotThread == null)
            {
                animbotThread = new Thread(ProgramHandle.StartAnimBot);
            }
            if (!animbotThread.IsAlive)
            {
                animbotThread = new Thread(ProgramHandle.StartAnimBot);
                animbotThread.Start();
            }
        }

        private void StartNormalBtn_Click(object sender, EventArgs e)
        {
            StartNormalAttack();
        }
        static void StartNormalAttack()
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

/*        private void button1_Click(object sender, EventArgs e)
        {

        }
*/
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
            int i = 10;
            int.TryParse(MannaValueTextBox.Text, out i);
            ProgramHandle.MannaRestoreValue = i;

        }
    }
}
