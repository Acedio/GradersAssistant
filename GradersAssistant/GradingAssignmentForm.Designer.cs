﻿namespace GradersAssistant
{
    partial class GradingAssignmentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.studentIDLabel = new System.Windows.Forms.Label();
            this.studentNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxPointsLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pointsTotalTextBox = new System.Windows.Forms.TextBox();
            this.pointsAdjustmentTextBox = new System.Windows.Forms.TextBox();
            this.pointsSubtotalTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.adjustmentsListBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.dueLabel = new System.Windows.Forms.Label();
            this.editAdjustmentButton = new System.Windows.Forms.Button();
            this.deleteAdjustmentButton = new System.Windows.Forms.Button();
            this.addAdjustmentButton = new System.Windows.Forms.Button();
            this.rubricTreeView = new NoExpandTreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Due:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.studentIDLabel);
            this.groupBox1.Controls.Add(this.studentNameLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(438, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student";
            // 
            // studentIDLabel
            // 
            this.studentIDLabel.AutoSize = true;
            this.studentIDLabel.Location = new System.Drawing.Point(82, 33);
            this.studentIDLabel.Name = "studentIDLabel";
            this.studentIDLabel.Size = new System.Drawing.Size(57, 13);
            this.studentIDLabel.TabIndex = 3;
            this.studentIDLabel.Text = "not loaded";
            // 
            // studentNameLabel
            // 
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.Location = new System.Drawing.Point(82, 20);
            this.studentNameLabel.Name = "studentNameLabel";
            this.studentNameLabel.Size = new System.Drawing.Size(57, 13);
            this.studentNameLabel.TabIndex = 2;
            this.studentNameLabel.Text = "not loaded";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Student ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.maxPointsLabel);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pointsTotalTextBox);
            this.groupBox2.Controls.Add(this.pointsAdjustmentTextBox);
            this.groupBox2.Controls.Add(this.pointsSubtotalTextBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(11, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Score";
            // 
            // maxPointsLabel
            // 
            this.maxPointsLabel.AutoSize = true;
            this.maxPointsLabel.Location = new System.Drawing.Point(287, 35);
            this.maxPointsLabel.Name = "maxPointsLabel";
            this.maxPointsLabel.Size = new System.Drawing.Size(107, 13);
            this.maxPointsLabel.TabIndex = 9;
            this.maxPointsLabel.Text = "Out of not loaded Pts";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "+";
            // 
            // pointsTotalTextBox
            // 
            this.pointsTotalTextBox.Location = new System.Drawing.Point(206, 32);
            this.pointsTotalTextBox.Name = "pointsTotalTextBox";
            this.pointsTotalTextBox.ReadOnly = true;
            this.pointsTotalTextBox.Size = new System.Drawing.Size(75, 20);
            this.pointsTotalTextBox.TabIndex = 6;
            // 
            // pointsAdjustmentTextBox
            // 
            this.pointsAdjustmentTextBox.Location = new System.Drawing.Point(106, 32);
            this.pointsAdjustmentTextBox.Name = "pointsAdjustmentTextBox";
            this.pointsAdjustmentTextBox.ReadOnly = true;
            this.pointsAdjustmentTextBox.Size = new System.Drawing.Size(75, 20);
            this.pointsAdjustmentTextBox.TabIndex = 5;
            // 
            // pointsSubtotalTextBox
            // 
            this.pointsSubtotalTextBox.Location = new System.Drawing.Point(6, 32);
            this.pointsSubtotalTextBox.Name = "pointsSubtotalTextBox";
            this.pointsSubtotalTextBox.ReadOnly = true;
            this.pointsSubtotalTextBox.Size = new System.Drawing.Size(75, 20);
            this.pointsSubtotalTextBox.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Adjustment";
            // 
            // adjustmentsListBox
            // 
            this.adjustmentsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.adjustmentsListBox.FormattingEnabled = true;
            this.adjustmentsListBox.Location = new System.Drawing.Point(12, 434);
            this.adjustmentsListBox.Name = "adjustmentsListBox";
            this.adjustmentsListBox.Size = new System.Drawing.Size(631, 95);
            this.adjustmentsListBox.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 418);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Comments/Adjustments";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(61, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(84, 20);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "not loaded";
            // 
            // dueLabel
            // 
            this.dueLabel.AutoSize = true;
            this.dueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueLabel.Location = new System.Drawing.Point(61, 43);
            this.dueLabel.Name = "dueLabel";
            this.dueLabel.Size = new System.Drawing.Size(84, 20);
            this.dueLabel.TabIndex = 12;
            this.dueLabel.Text = "not loaded";
            // 
            // editAdjustmentButton
            // 
            this.editAdjustmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editAdjustmentButton.Location = new System.Drawing.Point(487, 535);
            this.editAdjustmentButton.Name = "editAdjustmentButton";
            this.editAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.editAdjustmentButton.TabIndex = 14;
            this.editAdjustmentButton.Text = "Edit";
            this.editAdjustmentButton.UseVisualStyleBackColor = true;
            this.editAdjustmentButton.Click += new System.EventHandler(this.editAdjustmentButton_Click);
            // 
            // deleteAdjustmentButton
            // 
            this.deleteAdjustmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAdjustmentButton.Location = new System.Drawing.Point(568, 535);
            this.deleteAdjustmentButton.Name = "deleteAdjustmentButton";
            this.deleteAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAdjustmentButton.TabIndex = 15;
            this.deleteAdjustmentButton.Text = "Delete";
            this.deleteAdjustmentButton.UseVisualStyleBackColor = true;
            this.deleteAdjustmentButton.Click += new System.EventHandler(this.deleteAdjustmentButton_Click);
            // 
            // addAdjustmentButton
            // 
            this.addAdjustmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAdjustmentButton.Location = new System.Drawing.Point(406, 535);
            this.addAdjustmentButton.Name = "addAdjustmentButton";
            this.addAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.addAdjustmentButton.TabIndex = 13;
            this.addAdjustmentButton.Text = "Add";
            this.addAdjustmentButton.UseVisualStyleBackColor = true;
            this.addAdjustmentButton.Click += new System.EventHandler(this.addAdjustmentButton_Click);
            // 
            // rubricTreeView
            // 
            this.rubricTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rubricTreeView.CheckBoxes = true;
            this.rubricTreeView.Location = new System.Drawing.Point(11, 74);
            this.rubricTreeView.Name = "rubricTreeView";
            this.rubricTreeView.Size = new System.Drawing.Size(631, 255);
            this.rubricTreeView.TabIndex = 0;
            this.rubricTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rubricTreeView_AfterCheck);
            this.rubricTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rubricTreeView_NodeMouseClick);
            this.rubricTreeView.Click += new System.EventHandler(this.rubricTreeView_Click);
            // 
            // GradingAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(655, 563);
            this.ControlBox = false;
            this.Controls.Add(this.addAdjustmentButton);
            this.Controls.Add(this.deleteAdjustmentButton);
            this.Controls.Add(this.editAdjustmentButton);
            this.Controls.Add(this.dueLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.adjustmentsListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rubricTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GradingAssignmentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Grading";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label studentIDLabel;
        private System.Windows.Forms.Label studentNameLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pointsSubtotalTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pointsTotalTextBox;
        private System.Windows.Forms.TextBox pointsAdjustmentTextBox;
        private System.Windows.Forms.Label maxPointsLabel;
        private System.Windows.Forms.ListBox adjustmentsListBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label dueLabel;
        private System.Windows.Forms.Button editAdjustmentButton;
        private System.Windows.Forms.Button deleteAdjustmentButton;
        private System.Windows.Forms.Button addAdjustmentButton;
        private NoExpandTreeView rubricTreeView;


    }
}