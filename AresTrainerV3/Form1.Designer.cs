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
            this.StartHealbotBTN = new System.Windows.Forms.Button();
            this.ClassChangeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartSkillBtn = new System.Windows.Forms.Button();
            this.StartNormalBtn = new System.Windows.Forms.Button();
            this.AddAnimValue = new System.Windows.Forms.Button();
            this.SubstractAnimValue = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ValuesTextBox = new System.Windows.Forms.RichTextBox();
            this.HPValueTextBox = new System.Windows.Forms.TextBox();
            this.MannaValueTextBox = new System.Windows.Forms.TextBox();
            this.OnOffButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MouseScannerBtn = new System.Windows.Forms.Button();
            this.Tester = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartHealbotBTN
            // 
            this.StartHealbotBTN.Location = new System.Drawing.Point(166, 328);
            this.StartHealbotBTN.Name = "StartHealbotBTN";
            this.StartHealbotBTN.Size = new System.Drawing.Size(93, 50);
            this.StartHealbotBTN.TabIndex = 0;
            this.StartHealbotBTN.Text = "Start Healbot";
            this.StartHealbotBTN.UseVisualStyleBackColor = true;
            this.StartHealbotBTN.Click += new System.EventHandler(this.StartHealbotBTN_Click);
            // 
            // ClassChangeComboBox
            // 
            this.ClassChangeComboBox.FormattingEnabled = true;
            this.ClassChangeComboBox.Items.AddRange(new object[] {
            "Arcer",
            "Spearman",
            "Mage",
            "Knight"});
            this.ClassChangeComboBox.Location = new System.Drawing.Point(527, 106);
            this.ClassChangeComboBox.Name = "ClassChangeComboBox";
            this.ClassChangeComboBox.Size = new System.Drawing.Size(121, 23);
            this.ClassChangeComboBox.TabIndex = 1;
            this.ClassChangeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassChangeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 88);
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
            // ValuesTextBox
            // 
            this.ValuesTextBox.Location = new System.Drawing.Point(189, 88);
            this.ValuesTextBox.Name = "ValuesTextBox";
            this.ValuesTextBox.Size = new System.Drawing.Size(220, 108);
            this.ValuesTextBox.TabIndex = 10;
            this.ValuesTextBox.Text = "";
            // 
            // HPValueTextBox
            // 
            this.HPValueTextBox.Location = new System.Drawing.Point(477, 266);
            this.HPValueTextBox.Name = "HPValueTextBox";
            this.HPValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.HPValueTextBox.TabIndex = 11;
            this.HPValueTextBox.TextChanged += new System.EventHandler(this.HPValueTextBox_TextChanged);
            // 
            // MannaValueTextBox
            // 
            this.MannaValueTextBox.Location = new System.Drawing.Point(606, 268);
            this.MannaValueTextBox.Name = "MannaValueTextBox";
            this.MannaValueTextBox.Size = new System.Drawing.Size(100, 23);
            this.MannaValueTextBox.TabIndex = 12;
            this.MannaValueTextBox.TextChanged += new System.EventHandler(this.MannaValueTextBox_TextChanged);
            // 
            // OnOffButton
            // 
            this.OnOffButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.OnOffButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OnOffButton.Location = new System.Drawing.Point(25, 12);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(135, 116);
            this.OnOffButton.TabIndex = 13;
            this.OnOffButton.Text = "OFF";
            this.OnOffButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Heal value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 248);
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
            // Tester
            // 
            this.Tester.Location = new System.Drawing.Point(308, 278);
            this.Tester.Name = "Tester";
            this.Tester.Size = new System.Drawing.Size(75, 23);
            this.Tester.TabIndex = 17;
            this.Tester.Text = "Tester";
            this.Tester.UseVisualStyleBackColor = true;
            this.Tester.Click += new System.EventHandler(this.Tester_Click);
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
            this.button3.Location = new System.Drawing.Point(47, 353);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 61);
            this.button3.TabIndex = 20;
            this.button3.Text = "OFF";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tester);
            this.Controls.Add(this.MouseScannerBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OnOffButton);
            this.Controls.Add(this.MannaValueTextBox);
            this.Controls.Add(this.HPValueTextBox);
            this.Controls.Add(this.ValuesTextBox);
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
        private RichTextBox ValuesTextBox;
        private TextBox HPValueTextBox;
        private TextBox MannaValueTextBox;
        private Button OnOffButton;
        private Label label2;
        private Label label3;
        private Button MouseScannerBtn;
        private Button Tester;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}