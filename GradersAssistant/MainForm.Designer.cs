﻿namespace GradersAssistant
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
            this.criteriaTreeFormOpenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // criteriaTreeFormOpenButton
            // 
            this.criteriaTreeFormOpenButton.Location = new System.Drawing.Point(103, 111);
            this.criteriaTreeFormOpenButton.Name = "criteriaTreeFormOpenButton";
            this.criteriaTreeFormOpenButton.Size = new System.Drawing.Size(75, 23);
            this.criteriaTreeFormOpenButton.TabIndex = 0;
            this.criteriaTreeFormOpenButton.Text = "Button";
            this.criteriaTreeFormOpenButton.UseVisualStyleBackColor = true;
            this.criteriaTreeFormOpenButton.Click += new System.EventHandler(this.criteriaTreeFormOpenButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.criteriaTreeFormOpenButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button criteriaTreeFormOpenButton;

    }
}

