﻿namespace GermanNumbersTrainer
{
    partial class MainForm
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.answersListBox = new System.Windows.Forms.ListBox();
            this.marksListBox = new System.Windows.Forms.ListBox();
            this.hintsGroup = new System.Windows.Forms.GroupBox();
            this.playSoundAgain = new System.Windows.Forms.Button();
            this.corectAnswerLabel = new System.Windows.Forms.Label();
            this.userAnswerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.commasCheckBox = new System.Windows.Forms.CheckBox();
            this.hintsGroup.SuspendLayout();
            this.settingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Location = new System.Drawing.Point(13, 139);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(123, 20);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextBox_KeyPress);
            // 
            // answersListBox
            // 
            this.answersListBox.FormattingEnabled = true;
            this.answersListBox.Location = new System.Drawing.Point(12, 12);
            this.answersListBox.Name = "answersListBox";
            this.answersListBox.Size = new System.Drawing.Size(99, 121);
            this.answersListBox.TabIndex = 1;
            this.answersListBox.SelectedIndexChanged += new System.EventHandler(this.answersListBox_SelectedIndexChanged);
            // 
            // marksListBox
            // 
            this.marksListBox.FormattingEnabled = true;
            this.marksListBox.Location = new System.Drawing.Point(117, 12);
            this.marksListBox.Name = "marksListBox";
            this.marksListBox.Size = new System.Drawing.Size(19, 121);
            this.marksListBox.TabIndex = 2;
            this.marksListBox.SelectedIndexChanged += new System.EventHandler(this.marksListBox_SelectedIndexChanged);
            // 
            // hintsGroup
            // 
            this.hintsGroup.Controls.Add(this.playSoundAgain);
            this.hintsGroup.Controls.Add(this.corectAnswerLabel);
            this.hintsGroup.Controls.Add(this.userAnswerLabel);
            this.hintsGroup.Controls.Add(this.label2);
            this.hintsGroup.Controls.Add(this.label1);
            this.hintsGroup.Location = new System.Drawing.Point(142, 6);
            this.hintsGroup.Name = "hintsGroup";
            this.hintsGroup.Size = new System.Drawing.Size(195, 93);
            this.hintsGroup.TabIndex = 3;
            this.hintsGroup.TabStop = false;
            // 
            // playSoundAgain
            // 
            this.playSoundAgain.Enabled = false;
            this.playSoundAgain.Location = new System.Drawing.Point(9, 60);
            this.playSoundAgain.Name = "playSoundAgain";
            this.playSoundAgain.Size = new System.Drawing.Size(99, 23);
            this.playSoundAgain.TabIndex = 2;
            this.playSoundAgain.Text = "Play Sound Again";
            this.playSoundAgain.UseVisualStyleBackColor = true;
            this.playSoundAgain.Click += new System.EventHandler(this.playSoundAgain_Click);
            // 
            // corectAnswerLabel
            // 
            this.corectAnswerLabel.AutoSize = true;
            this.corectAnswerLabel.Location = new System.Drawing.Point(94, 40);
            this.corectAnswerLabel.Name = "corectAnswerLabel";
            this.corectAnswerLabel.Size = new System.Drawing.Size(13, 13);
            this.corectAnswerLabel.TabIndex = 1;
            this.corectAnswerLabel.Text = "0";
            // 
            // userAnswerLabel
            // 
            this.userAnswerLabel.AutoSize = true;
            this.userAnswerLabel.Location = new System.Drawing.Point(94, 16);
            this.userAnswerLabel.Name = "userAnswerLabel";
            this.userAnswerLabel.Size = new System.Drawing.Size(13, 13);
            this.userAnswerLabel.TabIndex = 1;
            this.userAnswerLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Right answer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your answer:";
            // 
            // settingsBox
            // 
            this.settingsBox.Controls.Add(this.startButton);
            this.settingsBox.Controls.Add(this.commasCheckBox);
            this.settingsBox.Location = new System.Drawing.Point(142, 105);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(200, 54);
            this.settingsBox.TabIndex = 4;
            this.settingsBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(103, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(91, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // commasCheckBox
            // 
            this.commasCheckBox.AutoSize = true;
            this.commasCheckBox.Checked = true;
            this.commasCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.commasCheckBox.Location = new System.Drawing.Point(9, 21);
            this.commasCheckBox.Name = "commasCheckBox";
            this.commasCheckBox.Size = new System.Drawing.Size(91, 17);
            this.commasCheckBox.TabIndex = 0;
            this.commasCheckBox.Text = "Real numbers";
            this.commasCheckBox.UseVisualStyleBackColor = true;
            this.commasCheckBox.CheckedChanged += new System.EventHandler(this.commasCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 167);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.hintsGroup);
            this.Controls.Add(this.marksListBox);
            this.Controls.Add(this.answersListBox);
            this.Controls.Add(this.inputTextBox);
            this.MinimumSize = new System.Drawing.Size(357, 194);
            this.Name = "MainForm";
            this.Text = "GermanNumbers";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.hintsGroup.ResumeLayout(false);
            this.hintsGroup.PerformLayout();
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.ListBox answersListBox;
        private System.Windows.Forms.ListBox marksListBox;
        private System.Windows.Forms.GroupBox hintsGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label corectAnswerLabel;
        private System.Windows.Forms.Label userAnswerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button playSoundAgain;
        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.CheckBox commasCheckBox;
        private System.Windows.Forms.Button startButton;
    }
}

