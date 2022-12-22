namespace AresTrainerV3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.ClassChangeComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.StartSkillBtn = new System.Windows.Forms.Button();
			this.TextBoxLog = new System.Windows.Forms.RichTextBox();
			this.BtnHitKO = new System.Windows.Forms.Button();
			this.Log = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.BtnHealbotOnOff = new System.Windows.Forms.Button();
			this.OpenStorageBTN = new System.Windows.Forms.Button();
			this.teleport = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.HpToBuy = new System.Windows.Forms.TextBox();
			this.MpToBuy = new System.Windows.Forms.TextBox();
			this.SpeedPot = new System.Windows.Forms.TextBox();
			this.BuyMaxHp = new System.Windows.Forms.CheckBox();
			this.SellItemsCheckBox = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.NumberOfCollectScans = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.RunSellerCheckBox = new System.Windows.Forms.CheckBox();
			this.SellItems = new System.Windows.Forms.Button();
			this.ExpBotComboBox = new System.Windows.Forms.ComboBox();
			this.PositionX = new System.Windows.Forms.TextBox();
			this.PositionY = new System.Windows.Forms.TextBox();
			this.ShowPositionsBtn = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.CollectorComboBox = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.ShutDownWhenInCity = new System.Windows.Forms.CheckBox();
			this.label18 = new System.Windows.Forms.Label();
			this.CollectItemsBox = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.fasttest = new System.Windows.Forms.Button();
			this.RunExpBot = new System.Windows.Forms.Button();
			this.FastTestWindow = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.GoToPos = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.MannaValueTextBox = new System.Windows.Forms.TextBox();
			this.HPValueTextBox = new System.Windows.Forms.TextBox();
			this.ShowPosShort = new System.Windows.Forms.Button();
			this.PositionZ = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ClassChangeComboBox
			// 
			this.ClassChangeComboBox.FormattingEnabled = true;
			this.ClassChangeComboBox.Items.AddRange(new object[] {
            "Arcer",
            "Spearman",
            "Mage",
            "Knight"});
			this.ClassChangeComboBox.Location = new System.Drawing.Point(738, 137);
			this.ClassChangeComboBox.Name = "ClassChangeComboBox";
			this.ClassChangeComboBox.Size = new System.Drawing.Size(121, 23);
			this.ClassChangeComboBox.TabIndex = 1;
			this.ClassChangeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassChangeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(738, 119);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select Class";
			// 
			// StartSkillBtn
			// 
			this.StartSkillBtn.Location = new System.Drawing.Point(266, 270);
			this.StartSkillBtn.Name = "StartSkillBtn";
			this.StartSkillBtn.Size = new System.Drawing.Size(91, 49);
			this.StartSkillBtn.TabIndex = 3;
			this.StartSkillBtn.Text = "Start Skill Speed";
			this.StartSkillBtn.UseVisualStyleBackColor = true;
			this.StartSkillBtn.Click += new System.EventHandler(this.StartSkillBtn_Click);
			// 
			// TextBoxLog
			// 
			this.TextBoxLog.Location = new System.Drawing.Point(154, 12);
			this.TextBoxLog.Name = "TextBoxLog";
			this.TextBoxLog.Size = new System.Drawing.Size(307, 251);
			this.TextBoxLog.TabIndex = 10;
			this.TextBoxLog.Text = "";
			// 
			// BtnHitKO
			// 
			this.BtnHitKO.BackColor = System.Drawing.SystemColors.GrayText;
			this.BtnHitKO.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnHitKO.Location = new System.Drawing.Point(47, 50);
			this.BtnHitKO.Name = "BtnHitKO";
			this.BtnHitKO.Size = new System.Drawing.Size(95, 79);
			this.BtnHitKO.TabIndex = 13;
			this.BtnHitKO.Text = "OFF";
			this.BtnHitKO.UseVisualStyleBackColor = false;
			// 
			// Log
			// 
			this.Log.Location = new System.Drawing.Point(159, 269);
			this.Log.Name = "Log";
			this.Log.Size = new System.Drawing.Size(101, 23);
			this.Log.TabIndex = 17;
			this.Log.Text = "GenerateLog";
			this.Log.UseVisualStyleBackColor = true;
			this.Log.Click += new System.EventHandler(this.Tester_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.GrayText;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button1.Location = new System.Drawing.Point(47, 153);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 61);
			this.button1.TabIndex = 18;
			this.button1.Text = "OFF";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.GrayText;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button2.Location = new System.Drawing.Point(47, 228);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 61);
			this.button2.TabIndex = 19;
			this.button2.Text = "OFF";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.GrayText;
			this.button3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button3.Location = new System.Drawing.Point(48, 316);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(94, 61);
			this.button3.TabIndex = 20;
			this.button3.Text = "OFF";
			this.button3.UseVisualStyleBackColor = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(77, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 15);
			this.label4.TabIndex = 21;
			this.label4.Text = "1Hit";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(47, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 15);
			this.label5.TabIndex = 22;
			this.label5.Text = "Right Click Attack";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(67, 213);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 15);
			this.label6.TabIndex = 23;
			this.label6.Text = "UWC BOT";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(60, 298);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 15);
			this.label7.TabIndex = 24;
			this.label7.Text = "GolemsBot";
			// 
			// BtnHealbotOnOff
			// 
			this.BtnHealbotOnOff.BackColor = System.Drawing.SystemColors.GrayText;
			this.BtnHealbotOnOff.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnHealbotOnOff.Location = new System.Drawing.Point(159, 312);
			this.BtnHealbotOnOff.Name = "BtnHealbotOnOff";
			this.BtnHealbotOnOff.Size = new System.Drawing.Size(94, 61);
			this.BtnHealbotOnOff.TabIndex = 25;
			this.BtnHealbotOnOff.Text = "OFF";
			this.BtnHealbotOnOff.UseVisualStyleBackColor = false;
			// 
			// OpenStorageBTN
			// 
			this.OpenStorageBTN.Location = new System.Drawing.Point(8, 6);
			this.OpenStorageBTN.Name = "OpenStorageBTN";
			this.OpenStorageBTN.Size = new System.Drawing.Size(98, 23);
			this.OpenStorageBTN.TabIndex = 29;
			this.OpenStorageBTN.Text = "OpenStorage";
			this.OpenStorageBTN.UseVisualStyleBackColor = true;
			this.OpenStorageBTN.Click += new System.EventHandler(this.OpenStorageBTN_Click);
			// 
			// teleport
			// 
			this.teleport.Location = new System.Drawing.Point(753, 364);
			this.teleport.Name = "teleport";
			this.teleport.Size = new System.Drawing.Size(75, 23);
			this.teleport.TabIndex = 32;
			this.teleport.Text = "teleport";
			this.teleport.UseVisualStyleBackColor = true;
			this.teleport.Click += new System.EventHandler(this.teleport_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(461, 92);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 15);
			this.label8.TabIndex = 34;
			this.label8.Text = "Hp";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(499, 92);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 15);
			this.label9.TabIndex = 35;
			this.label9.Text = "Manna";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(541, 92);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(57, 15);
			this.label10.TabIndex = 36;
			this.label10.Text = "SpeedPot";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(599, 92);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(50, 15);
			this.label11.TabIndex = 37;
			this.label11.Text = "BuyMax";
			// 
			// HpToBuy
			// 
			this.HpToBuy.Location = new System.Drawing.Point(461, 110);
			this.HpToBuy.Name = "HpToBuy";
			this.HpToBuy.Size = new System.Drawing.Size(36, 23);
			this.HpToBuy.TabIndex = 38;
			this.HpToBuy.Text = "0";
			this.HpToBuy.TextChanged += new System.EventHandler(this.HpToBuy_TextChanged);
			// 
			// MpToBuy
			// 
			this.MpToBuy.Location = new System.Drawing.Point(499, 110);
			this.MpToBuy.Name = "MpToBuy";
			this.MpToBuy.Size = new System.Drawing.Size(36, 23);
			this.MpToBuy.TabIndex = 39;
			this.MpToBuy.Text = "0";
			this.MpToBuy.TextChanged += new System.EventHandler(this.MpToBuy_TextChanged);
			// 
			// SpeedPot
			// 
			this.SpeedPot.Location = new System.Drawing.Point(549, 111);
			this.SpeedPot.Name = "SpeedPot";
			this.SpeedPot.Size = new System.Drawing.Size(18, 23);
			this.SpeedPot.TabIndex = 40;
			this.SpeedPot.Text = "0";
			this.SpeedPot.TextChanged += new System.EventHandler(this.SpeedPot_TextChanged);
			// 
			// BuyMaxHp
			// 
			this.BuyMaxHp.AutoSize = true;
			this.BuyMaxHp.Location = new System.Drawing.Point(602, 115);
			this.BuyMaxHp.Name = "BuyMaxHp";
			this.BuyMaxHp.Size = new System.Drawing.Size(15, 14);
			this.BuyMaxHp.TabIndex = 41;
			this.BuyMaxHp.UseVisualStyleBackColor = true;
			this.BuyMaxHp.CheckedChanged += new System.EventHandler(this.BuyMaxHp_CheckedChanged);
			// 
			// SellItemsCheckBox
			// 
			this.SellItemsCheckBox.AutoSize = true;
			this.SellItemsCheckBox.Location = new System.Drawing.Point(656, 115);
			this.SellItemsCheckBox.Name = "SellItemsCheckBox";
			this.SellItemsCheckBox.Size = new System.Drawing.Size(15, 14);
			this.SellItemsCheckBox.TabIndex = 46;
			this.SellItemsCheckBox.UseVisualStyleBackColor = true;
			this.SellItemsCheckBox.CheckedChanged += new System.EventHandler(this.SellItemsCheckBox_CheckedChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(653, 92);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(54, 15);
			this.label12.TabIndex = 45;
			this.label12.Text = "SellItems";
			// 
			// NumberOfCollectScans
			// 
			this.NumberOfCollectScans.Location = new System.Drawing.Point(704, 110);
			this.NumberOfCollectScans.Name = "NumberOfCollectScans";
			this.NumberOfCollectScans.Size = new System.Drawing.Size(36, 23);
			this.NumberOfCollectScans.TabIndex = 48;
			this.NumberOfCollectScans.Text = "1";
			this.NumberOfCollectScans.TextChanged += new System.EventHandler(this.NumberOfCollectScans_TextChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(704, 92);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(74, 15);
			this.label13.TabIndex = 47;
			this.label13.Text = "CollectScans";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(499, 32);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 15);
			this.label14.TabIndex = 50;
			this.label14.Text = "Run Seller";
			// 
			// RunSellerCheckBox
			// 
			this.RunSellerCheckBox.AutoSize = true;
			this.RunSellerCheckBox.Location = new System.Drawing.Point(520, 50);
			this.RunSellerCheckBox.Name = "RunSellerCheckBox";
			this.RunSellerCheckBox.Size = new System.Drawing.Size(15, 14);
			this.RunSellerCheckBox.TabIndex = 51;
			this.RunSellerCheckBox.UseVisualStyleBackColor = true;
			this.RunSellerCheckBox.CheckedChanged += new System.EventHandler(this.RunSellerCheckBox_CheckedChanged);
			// 
			// SellItems
			// 
			this.SellItems.Location = new System.Drawing.Point(753, 8);
			this.SellItems.Name = "SellItems";
			this.SellItems.Size = new System.Drawing.Size(75, 23);
			this.SellItems.TabIndex = 54;
			this.SellItems.Text = "SellItems";
			this.SellItems.UseVisualStyleBackColor = true;
			this.SellItems.Click += new System.EventHandler(this.SellItems_Click);
			// 
			// ExpBotComboBox
			// 
			this.ExpBotComboBox.FormattingEnabled = true;
			this.ExpBotComboBox.Items.AddRange(new object[] {
            "EtanaBuckerty",
            "SacredGiko",
            "SacredThieves",
            "HolinaGoblins",
            "HolinaBuckSlavePit",
            "HershalLowLvl",
            "HershalLeafMages",
            "HershalUWC1stFloor",
            "KharonWolves",
            "Sloth1stFloor",
            "SlothNoIcebergs",
            "SlothAoe",
            "testUWC"});
			this.ExpBotComboBox.Location = new System.Drawing.Point(719, 233);
			this.ExpBotComboBox.Name = "ExpBotComboBox";
			this.ExpBotComboBox.Size = new System.Drawing.Size(121, 23);
			this.ExpBotComboBox.TabIndex = 58;
			this.ExpBotComboBox.Text = "SlothAoe";
			this.ExpBotComboBox.SelectedIndexChanged += new System.EventHandler(this.ExpBotComboBox_SelectedIndexChanged);
			// 
			// PositionX
			// 
			this.PositionX.Location = new System.Drawing.Point(461, 183);
			this.PositionX.Name = "PositionX";
			this.PositionX.Size = new System.Drawing.Size(100, 23);
			this.PositionX.TabIndex = 59;
			// 
			// PositionY
			// 
			this.PositionY.Location = new System.Drawing.Point(565, 183);
			this.PositionY.Name = "PositionY";
			this.PositionY.Size = new System.Drawing.Size(100, 23);
			this.PositionY.TabIndex = 60;
			// 
			// ShowPositionsBtn
			// 
			this.ShowPositionsBtn.Location = new System.Drawing.Point(459, 153);
			this.ShowPositionsBtn.Name = "ShowPositionsBtn";
			this.ShowPositionsBtn.Size = new System.Drawing.Size(118, 23);
			this.ShowPositionsBtn.TabIndex = 62;
			this.ShowPositionsBtn.Text = "position Long X Y ";
			this.ShowPositionsBtn.UseVisualStyleBackColor = true;
			this.ShowPositionsBtn.Click += new System.EventHandler(this.ShowPositionsBtn_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(719, 217);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(59, 15);
			this.label15.TabIndex = 64;
			this.label15.Text = "MoverBot";
			// 
			// CollectorComboBox
			// 
			this.CollectorComboBox.FormattingEnabled = true;
			this.CollectorComboBox.Items.AddRange(new object[] {
            "+Event",
            "+Jewelery",
            "+Seller",
            "+Stones",
            "+Stones+Jewelery",
            "AllItems"});
			this.CollectorComboBox.Location = new System.Drawing.Point(719, 276);
			this.CollectorComboBox.Name = "CollectorComboBox";
			this.CollectorComboBox.Size = new System.Drawing.Size(121, 23);
			this.CollectorComboBox.TabIndex = 66;
			this.CollectorComboBox.Text = "+Jewelery";
			this.CollectorComboBox.SelectedIndexChanged += new System.EventHandler(this.CollectorComboBox_SelectedIndexChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(719, 259);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(55, 15);
			this.label17.TabIndex = 67;
			this.label17.Text = "Collector";
			// 
			// ShutDownWhenInCity
			// 
			this.ShutDownWhenInCity.AutoSize = true;
			this.ShutDownWhenInCity.Location = new System.Drawing.Point(719, 303);
			this.ShutDownWhenInCity.Name = "ShutDownWhenInCity";
			this.ShutDownWhenInCity.Size = new System.Drawing.Size(15, 14);
			this.ShutDownWhenInCity.TabIndex = 69;
			this.ShutDownWhenInCity.UseVisualStyleBackColor = true;
			this.ShutDownWhenInCity.CheckedChanged += new System.EventHandler(this.ShutDownWhenInCity_CheckedChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(740, 302);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(110, 15);
			this.label18.TabIndex = 68;
			this.label18.Text = "ShutDown on repot";
			// 
			// CollectItemsBox
			// 
			this.CollectItemsBox.AutoSize = true;
			this.CollectItemsBox.Checked = true;
			this.CollectItemsBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CollectItemsBox.Location = new System.Drawing.Point(719, 326);
			this.CollectItemsBox.Name = "CollectItemsBox";
			this.CollectItemsBox.Size = new System.Drawing.Size(15, 14);
			this.CollectItemsBox.TabIndex = 71;
			this.CollectItemsBox.UseVisualStyleBackColor = true;
			this.CollectItemsBox.CheckedChanged += new System.EventHandler(this.CollectItemsBox_CheckedChanged);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(740, 325);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(76, 15);
			this.label19.TabIndex = 70;
			this.label19.Text = "Collect Items";
			// 
			// fasttest
			// 
			this.fasttest.Location = new System.Drawing.Point(619, 421);
			this.fasttest.Name = "fasttest";
			this.fasttest.Size = new System.Drawing.Size(75, 23);
			this.fasttest.TabIndex = 72;
			this.fasttest.Text = "Fast Test";
			this.fasttest.UseVisualStyleBackColor = true;
			this.fasttest.Click += new System.EventHandler(this.fasttest_Click);
			// 
			// RunExpBot
			// 
			this.RunExpBot.Location = new System.Drawing.Point(753, 393);
			this.RunExpBot.Name = "RunExpBot";
			this.RunExpBot.Size = new System.Drawing.Size(75, 23);
			this.RunExpBot.TabIndex = 73;
			this.RunExpBot.Text = "RunExpBot";
			this.RunExpBot.UseVisualStyleBackColor = true;
			this.RunExpBot.Click += new System.EventHandler(this.RunExpBot_Click);
			// 
			// FastTestWindow
			// 
			this.FastTestWindow.Location = new System.Drawing.Point(594, 41);
			this.FastTestWindow.Name = "FastTestWindow";
			this.FastTestWindow.Size = new System.Drawing.Size(100, 23);
			this.FastTestWindow.TabIndex = 74;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(594, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(71, 15);
			this.label20.TabIndex = 75;
			this.label20.Text = "TestWindow";
			// 
			// GoToPos
			// 
			this.GoToPos.Location = new System.Drawing.Point(541, 213);
			this.GoToPos.Name = "GoToPos";
			this.GoToPos.Size = new System.Drawing.Size(91, 23);
			this.GoToPos.TabIndex = 82;
			this.GoToPos.Text = "GoToPos";
			this.GoToPos.UseVisualStyleBackColor = true;
			this.GoToPos.Click += new System.EventHandler(this.GoToPos_Click_1);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(479, 257);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(15, 14);
			this.checkBox1.TabIndex = 81;
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(599, 256);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 15);
			this.label3.TabIndex = 80;
			this.label3.Text = "Manna value";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(500, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 15);
			this.label2.TabIndex = 79;
			this.label2.Text = "Heal value";
			// 
			// MannaValueTextBox
			// 
			this.MannaValueTextBox.Location = new System.Drawing.Point(599, 274);
			this.MannaValueTextBox.Name = "MannaValueTextBox";
			this.MannaValueTextBox.Size = new System.Drawing.Size(100, 23);
			this.MannaValueTextBox.TabIndex = 78;
			// 
			// HPValueTextBox
			// 
			this.HPValueTextBox.Location = new System.Drawing.Point(477, 274);
			this.HPValueTextBox.Name = "HPValueTextBox";
			this.HPValueTextBox.Size = new System.Drawing.Size(100, 23);
			this.HPValueTextBox.TabIndex = 77;
			// 
			// ShowPosShort
			// 
			this.ShowPosShort.Location = new System.Drawing.Point(594, 153);
			this.ShowPosShort.Name = "ShowPosShort";
			this.ShowPosShort.Size = new System.Drawing.Size(118, 23);
			this.ShowPosShort.TabIndex = 83;
			this.ShowPosShort.Text = "position Short X Y ";
			this.ShowPosShort.UseVisualStyleBackColor = true;
			this.ShowPosShort.Click += new System.EventHandler(this.ShowPosShort_Click);
			// 
			// PositionZ
			// 
			this.PositionZ.Location = new System.Drawing.Point(671, 182);
			this.PositionZ.Name = "PositionZ";
			this.PositionZ.Size = new System.Drawing.Size(100, 23);
			this.PositionZ.TabIndex = 84;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(860, 450);
			this.Controls.Add(this.PositionZ);
			this.Controls.Add(this.ShowPosShort);
			this.Controls.Add(this.GoToPos);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MannaValueTextBox);
			this.Controls.Add(this.HPValueTextBox);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.FastTestWindow);
			this.Controls.Add(this.RunExpBot);
			this.Controls.Add(this.fasttest);
			this.Controls.Add(this.CollectItemsBox);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.ShutDownWhenInCity);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.CollectorComboBox);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.ShowPositionsBtn);
			this.Controls.Add(this.PositionY);
			this.Controls.Add(this.PositionX);
			this.Controls.Add(this.ExpBotComboBox);
			this.Controls.Add(this.SellItems);
			this.Controls.Add(this.RunSellerCheckBox);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.NumberOfCollectScans);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.SellItemsCheckBox);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.BuyMaxHp);
			this.Controls.Add(this.SpeedPot);
			this.Controls.Add(this.MpToBuy);
			this.Controls.Add(this.HpToBuy);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.teleport);
			this.Controls.Add(this.OpenStorageBTN);
			this.Controls.Add(this.BtnHealbotOnOff);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Log);
			this.Controls.Add(this.BtnHitKO);
			this.Controls.Add(this.TextBoxLog);
			this.Controls.Add(this.StartSkillBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClassChangeComboBox);
			this.Name = "Form1";
			this.Text = "Ares V3.1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private ComboBox ClassChangeComboBox;
        private Label label1;
        private Button StartSkillBtn;
        private RichTextBox TextBoxLog;
        private Button BtnHitKO;
        private Button Log;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button BtnHealbotOnOff;
        private Button OpenStorageBTN;
        private Button teleport;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox HpToBuy;
        private TextBox MpToBuy;
        private TextBox SpeedPot;
        private CheckBox BuyMaxHp;
        private CheckBox SellItemsCheckBox;
        private Label label12;
        private TextBox NumberOfCollectScans;
        private Label label13;
        private Label label14;
        private CheckBox RunSellerCheckBox;
        private Button SellItems;
        private ComboBox HealbotComboBox;
        private ComboBox ExpBotComboBox;
        private TextBox PositionX;
        private TextBox PositionY;
        private Button ShowPositionsBtn;
        private Label label15;
        private Label label16;
        private ComboBox CollectorComboBox;
        private Label label17;
        private CheckBox ShutDownWhenInCity;
        private Label label18;
        private CheckBox CollectItemsBox;
        private Label label19;
        private Button fasttest;
        private Button RunExpBot;
        private TextBox FastTestWindow;
        private Label label20;
        private Button GoToPos;
        private CheckBox checkBox1;
        private Label label3;
        private Label label2;
        private TextBox MannaValueTextBox;
        private TextBox HPValueTextBox;
        private Button ShowPosShort;
        private TextBox PositionZ;

        public EventHandler Tester_Click_1 { get; private set; }
    }
}