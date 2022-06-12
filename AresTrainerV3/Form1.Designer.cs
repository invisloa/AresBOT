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
            "Mage"});
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
            this.ValuesTextBox.Location = new System.Drawing.Point(60, 88);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}