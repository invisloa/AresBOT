﻿namespace AresTrainerV3
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
            this.StartHealbotBTN = new System.Windows.Forms.Button();
            this.ClassChangeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartSkillBtn = new System.Windows.Forms.Button();
            this.StartNormalBtn = new System.Windows.Forms.Button();
            this.AddAnimValue = new System.Windows.Forms.Button();
            this.SubstractAnimValue = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBoxLog = new System.Windows.Forms.RichTextBox();
            this.HPValueTextBox = new System.Windows.Forms.TextBox();
            this.MannaValueTextBox = new System.Windows.Forms.TextBox();
            this.BtnHitKO = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MouseScannerBtn = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnHealbotOnOff = new System.Windows.Forms.Button();
            this.TestingThread = new System.Windows.Forms.Button();
            this.FastTestBTN = new System.Windows.Forms.Button();
            this.OpenStorageBTN = new System.Windows.Forms.Button();
            this.Tester = new System.Windows.Forms.Button();
            this.SetWindowPos = new System.Windows.Forms.Button();
            this.teleport = new System.Windows.Forms.Button();
            this.TestMethod = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.HpToBuy = new System.Windows.Forms.TextBox();
            this.MpToBuy = new System.Windows.Forms.TextBox();
            this.SpeedPot = new System.Windows.Forms.TextBox();
            this.BuyMaxHp = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.UWCThread = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SellItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NumberOfCollectScans = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.RunSellerCheckBox = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.MoverGoblins = new System.Windows.Forms.Button();
            this.SellItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartHealbotBTN
            // 
            this.StartHealbotBTN.Location = new System.Drawing.Point(316, 273);
            this.StartHealbotBTN.Name = "StartHealbotBTN";
            this.StartHealbotBTN.Size = new System.Drawing.Size(93, 50);
            this.StartHealbotBTN.TabIndex = 0;
            this.StartHealbotBTN.Text = "Start Healbot";
            this.StartHealbotBTN.UseVisualStyleBackColor = true;
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
            this.StartSkillBtn.Location = new System.Drawing.Point(318, 329);
            this.StartSkillBtn.Name = "StartSkillBtn";
            this.StartSkillBtn.Size = new System.Drawing.Size(91, 49);
            this.StartSkillBtn.TabIndex = 3;
            this.StartSkillBtn.Text = "Start Skill Speed";
            this.StartSkillBtn.UseVisualStyleBackColor = true;
            this.StartSkillBtn.Click += new System.EventHandler(this.StartSkillBtn_Click);
            // 
            // StartNormalBtn
            // 
            this.StartNormalBtn.Location = new System.Drawing.Point(467, 329);
            this.StartNormalBtn.Name = "StartNormalBtn";
            this.StartNormalBtn.Size = new System.Drawing.Size(102, 49);
            this.StartNormalBtn.TabIndex = 4;
            this.StartNormalBtn.Text = "Start Nomral Speed";
            this.StartNormalBtn.UseVisualStyleBackColor = true;
            this.StartNormalBtn.Click += new System.EventHandler(this.StartNormalBtn_Click);
            // 
            // AddAnimValue
            // 
            this.AddAnimValue.Location = new System.Drawing.Point(467, 176);
            this.AddAnimValue.Name = "AddAnimValue";
            this.AddAnimValue.Size = new System.Drawing.Size(98, 52);
            this.AddAnimValue.TabIndex = 7;
            this.AddAnimValue.Text = "Add";
            this.AddAnimValue.UseVisualStyleBackColor = true;
            this.AddAnimValue.Click += new System.EventHandler(this.AddAnimValue_Click);
            // 
            // SubstractAnimValue
            // 
            this.SubstractAnimValue.Location = new System.Drawing.Point(589, 176);
            this.SubstractAnimValue.Name = "SubstractAnimValue";
            this.SubstractAnimValue.Size = new System.Drawing.Size(134, 52);
            this.SubstractAnimValue.TabIndex = 8;
            this.SubstractAnimValue.Text = "Substract";
            this.SubstractAnimValue.UseVisualStyleBackColor = true;
            this.SubstractAnimValue.Click += new System.EventHandler(this.SubstractAnimValue_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(527, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "1000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.Location = new System.Drawing.Point(154, 12);
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.Size = new System.Drawing.Size(307, 251);
            this.TextBoxLog.TabIndex = 10;
            this.TextBoxLog.Text = "";
            // 
            // HPValueTextBox
            // 
            this.HPValueTextBox.Location = new System.Drawing.Point(480, 295);
            this.HPValueTextBox.Name = "HPValueTextBox";
            this.HPValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.HPValueTextBox.TabIndex = 11;
            this.HPValueTextBox.TextChanged += new System.EventHandler(this.HPValueTextBox_TextChanged);
            // 
            // MannaValueTextBox
            // 
            this.MannaValueTextBox.Location = new System.Drawing.Point(609, 297);
            this.MannaValueTextBox.Name = "MannaValueTextBox";
            this.MannaValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.MannaValueTextBox.TabIndex = 12;
            this.MannaValueTextBox.TextChanged += new System.EventHandler(this.MannaValueTextBox_TextChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Heal value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Manna value";
            // 
            // MouseScannerBtn
            // 
            this.MouseScannerBtn.Location = new System.Drawing.Point(589, 328);
            this.MouseScannerBtn.Name = "MouseScannerBtn";
            this.MouseScannerBtn.Size = new System.Drawing.Size(134, 49);
            this.MouseScannerBtn.TabIndex = 16;
            this.MouseScannerBtn.Text = "MouseScannerBtn";
            this.MouseScannerBtn.UseVisualStyleBackColor = true;
            this.MouseScannerBtn.Click += new System.EventHandler(this.MouseScannerBtn_Click);
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
            // TestingThread
            // 
            this.TestingThread.Location = new System.Drawing.Point(360, 384);
            this.TestingThread.Name = "TestingThread";
            this.TestingThread.Size = new System.Drawing.Size(101, 23);
            this.TestingThread.TabIndex = 26;
            this.TestingThread.Text = "TestingThread";
            this.TestingThread.UseVisualStyleBackColor = true;
            this.TestingThread.Click += new System.EventHandler(this.TestingThread_Click);
            // 
            // FastTestBTN
            // 
            this.FastTestBTN.Location = new System.Drawing.Point(47, 422);
            this.FastTestBTN.Name = "FastTestBTN";
            this.FastTestBTN.Size = new System.Drawing.Size(75, 23);
            this.FastTestBTN.TabIndex = 27;
            this.FastTestBTN.Text = "LeafMages";
            this.FastTestBTN.UseVisualStyleBackColor = true;
            this.FastTestBTN.Click += new System.EventHandler(this.FastTestBTN_Click);
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
            // Tester
            // 
            this.Tester.Location = new System.Drawing.Point(145, 383);
            this.Tester.Name = "Tester";
            this.Tester.Size = new System.Drawing.Size(75, 23);
            this.Tester.TabIndex = 30;
            this.Tester.Text = "Goblin";
            this.Tester.UseVisualStyleBackColor = true;
            this.Tester.Click += new System.EventHandler(this.Tester_Click_1);
            // 
            // SetWindowPos
            // 
            this.SetWindowPos.Location = new System.Drawing.Point(753, 66);
            this.SetWindowPos.Name = "SetWindowPos";
            this.SetWindowPos.Size = new System.Drawing.Size(105, 23);
            this.SetWindowPos.TabIndex = 31;
            this.SetWindowPos.Text = "SetWindowPos";
            this.SetWindowPos.UseVisualStyleBackColor = true;
            this.SetWindowPos.Click += new System.EventHandler(this.SetWindowPos_Click);
            // 
            // teleport
            // 
            this.teleport.Location = new System.Drawing.Point(753, 37);
            this.teleport.Name = "teleport";
            this.teleport.Size = new System.Drawing.Size(75, 23);
            this.teleport.TabIndex = 32;
            this.teleport.Text = "teleport";
            this.teleport.UseVisualStyleBackColor = true;
            this.teleport.Click += new System.EventHandler(this.teleport_Click);
            // 
            // TestMethod
            // 
            this.TestMethod.Location = new System.Drawing.Point(235, 415);
            this.TestMethod.Name = "TestMethod";
            this.TestMethod.Size = new System.Drawing.Size(91, 23);
            this.TestMethod.TabIndex = 33;
            this.TestMethod.Text = "MoverThieves";
            this.TestMethod.UseVisualStyleBackColor = true;
            this.TestMethod.Click += new System.EventHandler(this.TestMethod_Click);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(48, 383);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 42;
            this.button4.Text = "GikoCave";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // UWCThread
            // 
            this.UWCThread.Location = new System.Drawing.Point(145, 422);
            this.UWCThread.Name = "UWCThread";
            this.UWCThread.Size = new System.Drawing.Size(75, 23);
            this.UWCThread.TabIndex = 43;
            this.UWCThread.Text = "UWC";
            this.UWCThread.UseVisualStyleBackColor = true;
            this.UWCThread.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(482, 278);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(235, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 49;
            this.button5.Text = "Kharon";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(580, 413);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 23);
            this.button6.TabIndex = 52;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MoverGoblins
            // 
            this.MoverGoblins.Location = new System.Drawing.Point(360, 413);
            this.MoverGoblins.Name = "MoverGoblins";
            this.MoverGoblins.Size = new System.Drawing.Size(91, 23);
            this.MoverGoblins.TabIndex = 53;
            this.MoverGoblins.Text = "MoverGoblins";
            this.MoverGoblins.UseVisualStyleBackColor = true;
            this.MoverGoblins.Click += new System.EventHandler(this.MoverGoblins_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.SellItems);
            this.Controls.Add(this.MoverGoblins);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.RunSellerCheckBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.NumberOfCollectScans);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SellItemsCheckBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.UWCThread);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BuyMaxHp);
            this.Controls.Add(this.SpeedPot);
            this.Controls.Add(this.MpToBuy);
            this.Controls.Add(this.HpToBuy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TestMethod);
            this.Controls.Add(this.teleport);
            this.Controls.Add(this.SetWindowPos);
            this.Controls.Add(this.Tester);
            this.Controls.Add(this.OpenStorageBTN);
            this.Controls.Add(this.FastTestBTN);
            this.Controls.Add(this.TestingThread);
            this.Controls.Add(this.BtnHealbotOnOff);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.MouseScannerBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnHitKO);
            this.Controls.Add(this.MannaValueTextBox);
            this.Controls.Add(this.HPValueTextBox);
            this.Controls.Add(this.TextBoxLog);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SubstractAnimValue);
            this.Controls.Add(this.AddAnimValue);
            this.Controls.Add(this.StartNormalBtn);
            this.Controls.Add(this.StartSkillBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClassChangeComboBox);
            this.Controls.Add(this.StartHealbotBTN);
            this.Name = "Form1";
            this.Text = "Ares V3.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartHealbotBTN;
        private ComboBox ClassChangeComboBox;
        private Label label1;
        private Button StartSkillBtn;
        private Button StartNormalBtn;
        private Button AddAnimValue;
        private Button SubstractAnimValue;
        private TextBox textBox1;
        private RichTextBox TextBoxLog;
        private TextBox HPValueTextBox;
        private TextBox MannaValueTextBox;
        private Button BtnHitKO;
        private Label label2;
        private Label label3;
        private Button MouseScannerBtn;
        private Button Log;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button BtnHealbotOnOff;
        private Button TestingThread;
        private Button FastTestBTN;
        private Button OpenStorageBTN;
        private Button Tester;
        private Button SetWindowPos;
        private Button teleport;
        private Button TestMethod;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox HpToBuy;
        private TextBox MpToBuy;
        private TextBox SpeedPot;
        private CheckBox BuyMaxHp;
        private Button button4;
        private Button UWCThread;
        private CheckBox checkBox1;
        private CheckBox SellItemsCheckBox;
        private Label label12;
        private TextBox NumberOfCollectScans;
        private Label label13;
        private Button button5;
        private Label label14;
        private CheckBox RunSellerCheckBox;
        private Button button6;
        private Button MoverGoblins;
        private Button SellItems;
    }
}