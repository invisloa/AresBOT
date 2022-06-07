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
            this.SuspendLayout();
            // 
            // StartHealbotBTN
            // 
            this.StartHealbotBTN.Location = new System.Drawing.Point(162, 246);
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
            this.ClassChangeComboBox.Location = new System.Drawing.Point(509, 82);
            this.ClassChangeComboBox.Name = "ClassChangeComboBox";
            this.ClassChangeComboBox.Size = new System.Drawing.Size(121, 23);
            this.ClassChangeComboBox.TabIndex = 1;
            this.ClassChangeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassChangeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Class";
            // 
            // StartSkillBtn
            // 
            this.StartSkillBtn.Location = new System.Drawing.Point(314, 247);
            this.StartSkillBtn.Name = "StartSkillBtn";
            this.StartSkillBtn.Size = new System.Drawing.Size(91, 49);
            this.StartSkillBtn.TabIndex = 3;
            this.StartSkillBtn.Text = "Start Skill Speed";
            this.StartSkillBtn.UseVisualStyleBackColor = true;
            this.StartSkillBtn.Click += new System.EventHandler(this.StartSkillBtn_Click);
            // 
            // StartNormalBtn
            // 
            this.StartNormalBtn.Location = new System.Drawing.Point(463, 247);
            this.StartNormalBtn.Name = "StartNormalBtn";
            this.StartNormalBtn.Size = new System.Drawing.Size(102, 49);
            this.StartNormalBtn.TabIndex = 4;
            this.StartNormalBtn.Text = "Start Nomral Speed";
            this.StartNormalBtn.UseVisualStyleBackColor = true;
            this.StartNormalBtn.Click += new System.EventHandler(this.StartNormalBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartNormalBtn);
            this.Controls.Add(this.StartSkillBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClassChangeComboBox);
            this.Controls.Add(this.StartHealbotBTN);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}