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
			ClassChangeComboBox = new ComboBox();
			label1 = new Label();
			StartSkillBtn = new Button();
			TextBoxLog = new RichTextBox();
			BtnHitKO = new Button();
			Log = new Button();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			BtnHealbotOnOff = new Button();
			OpenStorageBTN = new Button();
			teleport = new Button();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			HpToBuy = new TextBox();
			MpToBuy = new TextBox();
			SpeedPot = new TextBox();
			BuyMaxHp = new CheckBox();
			SellItemsCheckBox = new CheckBox();
			label12 = new Label();
			NumberOfCollectScans = new TextBox();
			label13 = new Label();
			label14 = new Label();
			RunSellerCheckBox = new CheckBox();
			SellItems = new Button();
			ExpBotComboBox = new ComboBox();
			PositionX = new TextBox();
			PositionY = new TextBox();
			ShowPositionsBtn = new Button();
			label15 = new Label();
			CollectorComboBox = new ComboBox();
			label17 = new Label();
			ShutDownWhenInCity = new CheckBox();
			label18 = new Label();
			CollectItemsBox = new CheckBox();
			label19 = new Label();
			fasttest = new Button();
			RunExpBot = new Button();
			FastTestWindow = new TextBox();
			label20 = new Label();
			GoToPos = new Button();
			checkBox1 = new CheckBox();
			label3 = new Label();
			label2 = new Label();
			MannaValueTextBox = new TextBox();
			HPValueTextBox = new TextBox();
			ShowPosShort = new Button();
			PositionZ = new TextBox();
			ItemBlesserBtn = new Button();
			label21 = new Label();
			RunExpcheckBox = new CheckBox();
			SuspendLayout();
			// 
			// ClassChangeComboBox
			// 
			ClassChangeComboBox.FormattingEnabled = true;
			ClassChangeComboBox.Items.AddRange(new object[] { "Arcer", "Spearman", "Mage", "Knight" });
			ClassChangeComboBox.Location = new Point(738, 137);
			ClassChangeComboBox.Name = "ClassChangeComboBox";
			ClassChangeComboBox.Size = new Size(121, 23);
			ClassChangeComboBox.TabIndex = 1;
			ClassChangeComboBox.SelectedIndexChanged += ClassChangeComboBox_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(738, 119);
			label1.Name = "label1";
			label1.Size = new Size(68, 15);
			label1.TabIndex = 2;
			label1.Text = "Select Class";
			// 
			// StartSkillBtn
			// 
			StartSkillBtn.Location = new Point(266, 270);
			StartSkillBtn.Name = "StartSkillBtn";
			StartSkillBtn.Size = new Size(91, 49);
			StartSkillBtn.TabIndex = 3;
			StartSkillBtn.Text = "Start Skill Speed";
			StartSkillBtn.UseVisualStyleBackColor = true;
			StartSkillBtn.Click += StartSkillBtn_Click;
			// 
			// TextBoxLog
			// 
			TextBoxLog.Location = new Point(154, 12);
			TextBoxLog.Name = "TextBoxLog";
			TextBoxLog.Size = new Size(307, 251);
			TextBoxLog.TabIndex = 10;
			TextBoxLog.Text = "";
			// 
			// BtnHitKO
			// 
			BtnHitKO.BackColor = SystemColors.GrayText;
			BtnHitKO.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			BtnHitKO.Location = new Point(47, 50);
			BtnHitKO.Name = "BtnHitKO";
			BtnHitKO.Size = new Size(95, 79);
			BtnHitKO.TabIndex = 13;
			BtnHitKO.Text = "OFF";
			BtnHitKO.UseVisualStyleBackColor = false;
			// 
			// Log
			// 
			Log.Location = new Point(159, 269);
			Log.Name = "Log";
			Log.Size = new Size(101, 23);
			Log.TabIndex = 17;
			Log.Text = "GenerateLog";
			Log.UseVisualStyleBackColor = true;
			Log.Click += Tester_Click;
			// 
			// button1
			// 
			button1.BackColor = SystemColors.GrayText;
			button1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			button1.Location = new Point(47, 153);
			button1.Name = "button1";
			button1.Size = new Size(94, 61);
			button1.TabIndex = 18;
			button1.Text = "OFF";
			button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			button2.BackColor = SystemColors.GrayText;
			button2.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			button2.Location = new Point(47, 228);
			button2.Name = "button2";
			button2.Size = new Size(94, 61);
			button2.TabIndex = 19;
			button2.Text = "OFF";
			button2.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			button3.BackColor = SystemColors.GrayText;
			button3.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			button3.Location = new Point(48, 316);
			button3.Name = "button3";
			button3.Size = new Size(94, 61);
			button3.TabIndex = 20;
			button3.Text = "OFF";
			button3.UseVisualStyleBackColor = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(77, 32);
			label4.Name = "label4";
			label4.Size = new Size(29, 15);
			label4.TabIndex = 21;
			label4.Text = "1Hit";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(47, 140);
			label5.Name = "label5";
			label5.Size = new Size(101, 15);
			label5.TabIndex = 22;
			label5.Text = "Right Click Attack";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(67, 213);
			label6.Name = "label6";
			label6.Size = new Size(58, 15);
			label6.TabIndex = 23;
			label6.Text = "UWC BOT";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(60, 298);
			label7.Name = "label7";
			label7.Size = new Size(65, 15);
			label7.TabIndex = 24;
			label7.Text = "GolemsBot";
			// 
			// BtnHealbotOnOff
			// 
			BtnHealbotOnOff.BackColor = SystemColors.GrayText;
			BtnHealbotOnOff.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			BtnHealbotOnOff.Location = new Point(159, 312);
			BtnHealbotOnOff.Name = "BtnHealbotOnOff";
			BtnHealbotOnOff.Size = new Size(94, 61);
			BtnHealbotOnOff.TabIndex = 25;
			BtnHealbotOnOff.Text = "OFF";
			BtnHealbotOnOff.UseVisualStyleBackColor = false;
			// 
			// OpenStorageBTN
			// 
			OpenStorageBTN.Location = new Point(8, 6);
			OpenStorageBTN.Name = "OpenStorageBTN";
			OpenStorageBTN.Size = new Size(98, 23);
			OpenStorageBTN.TabIndex = 29;
			OpenStorageBTN.Text = "OpenStorage";
			OpenStorageBTN.UseVisualStyleBackColor = true;
			OpenStorageBTN.Click += OpenStorageBTN_Click;
			// 
			// teleport
			// 
			teleport.Location = new Point(753, 364);
			teleport.Name = "teleport";
			teleport.Size = new Size(75, 23);
			teleport.TabIndex = 32;
			teleport.Text = "teleport";
			teleport.UseVisualStyleBackColor = true;
			teleport.Click += teleport_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(461, 92);
			label8.Name = "label8";
			label8.Size = new Size(23, 15);
			label8.TabIndex = 34;
			label8.Text = "Hp";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(499, 92);
			label9.Name = "label9";
			label9.Size = new Size(44, 15);
			label9.TabIndex = 35;
			label9.Text = "Manna";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(541, 92);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.TabIndex = 36;
			label10.Text = "SpeedPot";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(599, 92);
			label11.Name = "label11";
			label11.Size = new Size(50, 15);
			label11.TabIndex = 37;
			label11.Text = "BuyMax";
			// 
			// HpToBuy
			// 
			HpToBuy.Location = new Point(461, 110);
			HpToBuy.Name = "HpToBuy";
			HpToBuy.Size = new Size(36, 23);
			HpToBuy.TabIndex = 38;
			HpToBuy.Text = "0";
			HpToBuy.TextChanged += HpToBuy_TextChanged;
			// 
			// MpToBuy
			// 
			MpToBuy.Location = new Point(499, 110);
			MpToBuy.Name = "MpToBuy";
			MpToBuy.Size = new Size(36, 23);
			MpToBuy.TabIndex = 39;
			MpToBuy.Text = "0";
			MpToBuy.TextChanged += MpToBuy_TextChanged;
			// 
			// SpeedPot
			// 
			SpeedPot.Location = new Point(549, 111);
			SpeedPot.Name = "SpeedPot";
			SpeedPot.Size = new Size(18, 23);
			SpeedPot.TabIndex = 40;
			SpeedPot.Text = "0";
			SpeedPot.TextChanged += SpeedPot_TextChanged;
			// 
			// BuyMaxHp
			// 
			BuyMaxHp.AutoSize = true;
			BuyMaxHp.Location = new Point(602, 115);
			BuyMaxHp.Name = "BuyMaxHp";
			BuyMaxHp.Size = new Size(15, 14);
			BuyMaxHp.TabIndex = 41;
			BuyMaxHp.UseVisualStyleBackColor = true;
			BuyMaxHp.CheckedChanged += BuyMaxHp_CheckedChanged;
			// 
			// SellItemsCheckBox
			// 
			SellItemsCheckBox.AutoSize = true;
			SellItemsCheckBox.Location = new Point(656, 115);
			SellItemsCheckBox.Name = "SellItemsCheckBox";
			SellItemsCheckBox.Size = new Size(15, 14);
			SellItemsCheckBox.TabIndex = 46;
			SellItemsCheckBox.UseVisualStyleBackColor = true;
			SellItemsCheckBox.CheckedChanged += SellItemsCheckBox_CheckedChanged;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(653, 92);
			label12.Name = "label12";
			label12.Size = new Size(54, 15);
			label12.TabIndex = 45;
			label12.Text = "SellItems";
			// 
			// NumberOfCollectScans
			// 
			NumberOfCollectScans.Location = new Point(704, 110);
			NumberOfCollectScans.Name = "NumberOfCollectScans";
			NumberOfCollectScans.Size = new Size(36, 23);
			NumberOfCollectScans.TabIndex = 48;
			NumberOfCollectScans.Text = "1";
			NumberOfCollectScans.TextChanged += NumberOfCollectScans_TextChanged;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(704, 92);
			label13.Name = "label13";
			label13.Size = new Size(74, 15);
			label13.TabIndex = 47;
			label13.Text = "CollectScans";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(467, 41);
			label14.Name = "label14";
			label14.Size = new Size(59, 15);
			label14.TabIndex = 50;
			label14.Text = "Run Seller";
			// 
			// RunSellerCheckBox
			// 
			RunSellerCheckBox.AutoSize = true;
			RunSellerCheckBox.Location = new Point(488, 59);
			RunSellerCheckBox.Name = "RunSellerCheckBox";
			RunSellerCheckBox.Size = new Size(15, 14);
			RunSellerCheckBox.TabIndex = 51;
			RunSellerCheckBox.UseVisualStyleBackColor = true;
			RunSellerCheckBox.CheckedChanged += RunSellerCheckBox_CheckedChanged;
			// 
			// SellItems
			// 
			SellItems.Location = new Point(753, 8);
			SellItems.Name = "SellItems";
			SellItems.Size = new Size(75, 23);
			SellItems.TabIndex = 54;
			SellItems.Text = "SellItems";
			SellItems.UseVisualStyleBackColor = true;
			SellItems.Click += SellItems_Click;
			// 
			// ExpBotComboBox
			// 
			ExpBotComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpBotComboBox.FormattingEnabled = true;
			ExpBotComboBox.Items.AddRange(new object[] { "EtanaBuckerty", "SacredGiko", "SacredThieves", "SacredThievesSOD", "HolinaGoblins", "BucksLowLVL", "HershalLowLvl", "HershalLeafMages", "HershalUWC1stFloor", "KharonWolves", "KharonBigWolves", "Sloth1stFloor", "SlothNoIcebergs", "SlothHorseFarm", "SlothAoe", "SlothAoe2spot" });
			ExpBotComboBox.Location = new Point(719, 233);
			ExpBotComboBox.Name = "ExpBotComboBox";
			ExpBotComboBox.Size = new Size(121, 23);
			ExpBotComboBox.TabIndex = 58;
			ExpBotComboBox.SelectedIndexChanged += ExpBotComboBox_SelectedIndexChanged;
			// 
			// PositionX
			// 
			PositionX.Location = new Point(461, 183);
			PositionX.Name = "PositionX";
			PositionX.Size = new Size(100, 23);
			PositionX.TabIndex = 59;
			// 
			// PositionY
			// 
			PositionY.Location = new Point(565, 183);
			PositionY.Name = "PositionY";
			PositionY.Size = new Size(100, 23);
			PositionY.TabIndex = 60;
			// 
			// ShowPositionsBtn
			// 
			ShowPositionsBtn.Location = new Point(459, 153);
			ShowPositionsBtn.Name = "ShowPositionsBtn";
			ShowPositionsBtn.Size = new Size(118, 23);
			ShowPositionsBtn.TabIndex = 62;
			ShowPositionsBtn.Text = "position Long X Y ";
			ShowPositionsBtn.UseVisualStyleBackColor = true;
			ShowPositionsBtn.Click += ShowPositionsBtn_Click;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(719, 217);
			label15.Name = "label15";
			label15.Size = new Size(59, 15);
			label15.TabIndex = 64;
			label15.Text = "MoverBot";
			// 
			// CollectorComboBox
			// 
			CollectorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			CollectorComboBox.Items.AddRange(new object[] { "+Event", "+Jewelery", "+Seller", "+Stones", "+Stones+Jewelery", "AllItems" });
			CollectorComboBox.Location = new Point(719, 276);
			CollectorComboBox.Name = "CollectorComboBox";
			CollectorComboBox.Size = new Size(121, 23);
			CollectorComboBox.TabIndex = 66;
			CollectorComboBox.SelectedIndexChanged += CollectorComboBox_SelectedIndexChanged;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(719, 259);
			label17.Name = "label17";
			label17.Size = new Size(55, 15);
			label17.TabIndex = 67;
			label17.Text = "Collector";
			// 
			// ShutDownWhenInCity
			// 
			ShutDownWhenInCity.AutoSize = true;
			ShutDownWhenInCity.Location = new Point(719, 303);
			ShutDownWhenInCity.Name = "ShutDownWhenInCity";
			ShutDownWhenInCity.Size = new Size(15, 14);
			ShutDownWhenInCity.TabIndex = 69;
			ShutDownWhenInCity.UseVisualStyleBackColor = true;
			ShutDownWhenInCity.CheckedChanged += ShutDownWhenInCity_CheckedChanged;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(740, 302);
			label18.Name = "label18";
			label18.Size = new Size(110, 15);
			label18.TabIndex = 68;
			label18.Text = "ShutDown on repot";
			// 
			// CollectItemsBox
			// 
			CollectItemsBox.AutoSize = true;
			CollectItemsBox.Checked = true;
			CollectItemsBox.CheckState = CheckState.Checked;
			CollectItemsBox.Location = new Point(719, 326);
			CollectItemsBox.Name = "CollectItemsBox";
			CollectItemsBox.Size = new Size(15, 14);
			CollectItemsBox.TabIndex = 71;
			CollectItemsBox.UseVisualStyleBackColor = true;
			CollectItemsBox.CheckedChanged += CollectItemsBox_CheckedChanged;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(740, 325);
			label19.Name = "label19";
			label19.Size = new Size(76, 15);
			label19.TabIndex = 70;
			label19.Text = "Collect Items";
			// 
			// fasttest
			// 
			fasttest.Location = new Point(619, 421);
			fasttest.Name = "fasttest";
			fasttest.Size = new Size(75, 23);
			fasttest.TabIndex = 72;
			fasttest.Text = "Fast Test";
			fasttest.UseVisualStyleBackColor = true;
			fasttest.Click += fasttest_Click;
			// 
			// RunExpBot
			// 
			RunExpBot.Location = new Point(753, 393);
			RunExpBot.Name = "RunExpBot";
			RunExpBot.Size = new Size(75, 23);
			RunExpBot.TabIndex = 73;
			RunExpBot.Text = "RunExpBot";
			RunExpBot.UseVisualStyleBackColor = true;
			RunExpBot.Click += RunExpBot_Click;
			// 
			// FastTestWindow
			// 
			FastTestWindow.Location = new Point(594, 41);
			FastTestWindow.Name = "FastTestWindow";
			FastTestWindow.Size = new Size(100, 23);
			FastTestWindow.TabIndex = 74;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new Point(594, 16);
			label20.Name = "label20";
			label20.Size = new Size(71, 15);
			label20.TabIndex = 75;
			label20.Text = "TestWindow";
			// 
			// GoToPos
			// 
			GoToPos.Location = new Point(541, 213);
			GoToPos.Name = "GoToPos";
			GoToPos.Size = new Size(91, 23);
			GoToPos.TabIndex = 82;
			GoToPos.Text = "GoToPos";
			GoToPos.UseVisualStyleBackColor = true;
			GoToPos.Click += GoToPos_Click_1;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(479, 257);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(15, 14);
			checkBox1.TabIndex = 81;
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(599, 256);
			label3.Name = "label3";
			label3.Size = new Size(75, 15);
			label3.TabIndex = 80;
			label3.Text = "Manna value";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(500, 256);
			label2.Name = "label2";
			label2.Size = new Size(62, 15);
			label2.TabIndex = 79;
			label2.Text = "Heal value";
			// 
			// MannaValueTextBox
			// 
			MannaValueTextBox.Location = new Point(599, 274);
			MannaValueTextBox.Name = "MannaValueTextBox";
			MannaValueTextBox.Size = new Size(100, 23);
			MannaValueTextBox.TabIndex = 78;
			MannaValueTextBox.TextChanged += MannaValueTextBox_TextChanged;
			// 
			// HPValueTextBox
			// 
			HPValueTextBox.Location = new Point(477, 274);
			HPValueTextBox.Name = "HPValueTextBox";
			HPValueTextBox.Size = new Size(100, 23);
			HPValueTextBox.TabIndex = 77;
			HPValueTextBox.TextChanged += HPValueTextBox_TextChanged_1;
			// 
			// ShowPosShort
			// 
			ShowPosShort.Location = new Point(594, 153);
			ShowPosShort.Name = "ShowPosShort";
			ShowPosShort.Size = new Size(118, 23);
			ShowPosShort.TabIndex = 83;
			ShowPosShort.Text = "position Short X Y ";
			ShowPosShort.UseVisualStyleBackColor = true;
			ShowPosShort.Click += ShowPosShort_Click;
			// 
			// PositionZ
			// 
			PositionZ.Location = new Point(671, 182);
			PositionZ.Name = "PositionZ";
			PositionZ.Size = new Size(100, 23);
			PositionZ.TabIndex = 84;
			// 
			// ItemBlesserBtn
			// 
			ItemBlesserBtn.Location = new Point(672, 6);
			ItemBlesserBtn.Name = "ItemBlesserBtn";
			ItemBlesserBtn.Size = new Size(75, 23);
			ItemBlesserBtn.TabIndex = 85;
			ItemBlesserBtn.Text = "Bless Item";
			ItemBlesserBtn.UseVisualStyleBackColor = true;
			ItemBlesserBtn.Click += ItemBlesserBtn_Click;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new Point(529, 41);
			label21.Name = "label21";
			label21.Size = new Size(51, 15);
			label21.TabIndex = 87;
			label21.Text = "Run EXP";
			// 
			// RunExpcheckBox
			// 
			RunExpcheckBox.AutoSize = true;
			RunExpcheckBox.Location = new Point(546, 59);
			RunExpcheckBox.Name = "RunExpcheckBox";
			RunExpcheckBox.Size = new Size(15, 14);
			RunExpcheckBox.TabIndex = 88;
			RunExpcheckBox.UseVisualStyleBackColor = true;
			RunExpcheckBox.CheckedChanged += RunExpcheckBox_CheckedChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(860, 450);
			Controls.Add(RunExpcheckBox);
			Controls.Add(label21);
			Controls.Add(ItemBlesserBtn);
			Controls.Add(PositionZ);
			Controls.Add(ShowPosShort);
			Controls.Add(GoToPos);
			Controls.Add(checkBox1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(MannaValueTextBox);
			Controls.Add(HPValueTextBox);
			Controls.Add(label20);
			Controls.Add(FastTestWindow);
			Controls.Add(RunExpBot);
			Controls.Add(fasttest);
			Controls.Add(CollectItemsBox);
			Controls.Add(label19);
			Controls.Add(ShutDownWhenInCity);
			Controls.Add(label18);
			Controls.Add(label17);
			Controls.Add(CollectorComboBox);
			Controls.Add(label15);
			Controls.Add(ShowPositionsBtn);
			Controls.Add(PositionY);
			Controls.Add(PositionX);
			Controls.Add(ExpBotComboBox);
			Controls.Add(SellItems);
			Controls.Add(RunSellerCheckBox);
			Controls.Add(label14);
			Controls.Add(NumberOfCollectScans);
			Controls.Add(label13);
			Controls.Add(SellItemsCheckBox);
			Controls.Add(label12);
			Controls.Add(BuyMaxHp);
			Controls.Add(SpeedPot);
			Controls.Add(MpToBuy);
			Controls.Add(HpToBuy);
			Controls.Add(label11);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(teleport);
			Controls.Add(OpenStorageBTN);
			Controls.Add(BtnHealbotOnOff);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(Log);
			Controls.Add(BtnHitKO);
			Controls.Add(TextBoxLog);
			Controls.Add(StartSkillBtn);
			Controls.Add(label1);
			Controls.Add(ClassChangeComboBox);
			Name = "Form1";
			Text = "!!";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
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
		private Button ItemBlesserBtn;
		private Label label21;
		private CheckBox RunExpcheckBox;

		public EventHandler Tester_Click_1 { get; private set; }
	}
}