namespace NhlDownload
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.labelLeagueNumber = new System.Windows.Forms.Label();
            this.textBoxLeagueNumber = new System.Windows.Forms.TextBox();
            this.checkBoxPointsLeague = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(458, 161);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Build CSV File Players";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelLeagueNumber
            // 
            this.labelLeagueNumber.AutoSize = true;
            this.labelLeagueNumber.Location = new System.Drawing.Point(20, 20);
            this.labelLeagueNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLeagueNumber.Name = "labelLeagueNumber";
            this.labelLeagueNumber.Size = new System.Drawing.Size(123, 20);
            this.labelLeagueNumber.TabIndex = 1;
            this.labelLeagueNumber.Text = "League Number";
            // 
            // textBoxLeagueNumber
            // 
            this.textBoxLeagueNumber.Location = new System.Drawing.Point(153, 15);
            this.textBoxLeagueNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLeagueNumber.Name = "textBoxLeagueNumber";
            this.textBoxLeagueNumber.Size = new System.Drawing.Size(187, 26);
            this.textBoxLeagueNumber.TabIndex = 2;
            // 
            // checkBoxPointsLeague
            // 
            this.checkBoxPointsLeague.AutoSize = true;
            this.checkBoxPointsLeague.Checked = true;
            this.checkBoxPointsLeague.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPointsLeague.Location = new System.Drawing.Point(153, 55);
            this.checkBoxPointsLeague.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxPointsLeague.Name = "checkBoxPointsLeague";
            this.checkBoxPointsLeague.Size = new System.Drawing.Size(186, 24);
            this.checkBoxPointsLeague.TabIndex = 3;
            this.checkBoxPointsLeague.Text = "Points-based League";
            this.checkBoxPointsLeague.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(20, 168);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(51, 20);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "label1";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(458, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Build CSV File Goalies";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(420, 14);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(194, 24);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Yahoo Projection ROS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(420, 49);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(216, 24);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "2019-2020 Season Score";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 118);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 35);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(420, 83);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(175, 24);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "2021 Season Score";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 215);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxPointsLeague);
            this.Controls.Add(this.textBoxLeagueNumber);
            this.Controls.Add(this.labelLeagueNumber);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Yahoo Fantasy NHL Downloader v0.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelLeagueNumber;
        private System.Windows.Forms.TextBox textBoxLeagueNumber;
        private System.Windows.Forms.CheckBox checkBoxPointsLeague;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

