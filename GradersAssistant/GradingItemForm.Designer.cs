namespace GradersAssistant
{
    partial class GradingItemForm
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
            this.pointsReceivedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxPointsLabel = new System.Windows.Forms.Label();
            this.graderCommentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.studentNameLabel = new System.Windows.Forms.Label();
            this.criteriaDescLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointsReceivedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pointsReceivedNumericUpDown
            // 
            this.pointsReceivedNumericUpDown.Location = new System.Drawing.Point(12, 58);
            this.pointsReceivedNumericUpDown.Name = "pointsReceivedNumericUpDown";
            this.pointsReceivedNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.pointsReceivedNumericUpDown.TabIndex = 0;
            this.pointsReceivedNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // maxPointsLabel
            // 
            this.maxPointsLabel.AutoSize = true;
            this.maxPointsLabel.Location = new System.Drawing.Point(70, 60);
            this.maxPointsLabel.Name = "maxPointsLabel";
            this.maxPointsLabel.Size = new System.Drawing.Size(123, 13);
            this.maxPointsLabel.TabIndex = 1;
            this.maxPointsLabel.Text = "Pts out of not loaded Pts";
            // 
            // graderCommentTextBox
            // 
            this.graderCommentTextBox.Location = new System.Drawing.Point(12, 97);
            this.graderCommentTextBox.Multiline = true;
            this.graderCommentTextBox.Name = "graderCommentTextBox";
            this.graderCommentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.graderCommentTextBox.Size = new System.Drawing.Size(500, 169);
            this.graderCommentTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comments:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(356, 272);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(437, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Student:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Criteria:";
            // 
            // studentNameLabel
            // 
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNameLabel.Location = new System.Drawing.Point(81, 9);
            this.studentNameLabel.Name = "studentNameLabel";
            this.studentNameLabel.Size = new System.Drawing.Size(84, 20);
            this.studentNameLabel.TabIndex = 8;
            this.studentNameLabel.Text = "not loaded";
            // 
            // criteriaDescLabel
            // 
            this.criteriaDescLabel.AutoSize = true;
            this.criteriaDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaDescLabel.Location = new System.Drawing.Point(81, 29);
            this.criteriaDescLabel.Name = "criteriaDescLabel";
            this.criteriaDescLabel.Size = new System.Drawing.Size(84, 20);
            this.criteriaDescLabel.TabIndex = 9;
            this.criteriaDescLabel.Text = "not loaded";
            // 
            // GradingItemForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(518, 303);
            this.Controls.Add(this.criteriaDescLabel);
            this.Controls.Add(this.studentNameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.graderCommentTextBox);
            this.Controls.Add(this.maxPointsLabel);
            this.Controls.Add(this.pointsReceivedNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GradingItemForm";
            this.Text = "Grading Item";
            ((System.ComponentModel.ISupportInitialize)(this.pointsReceivedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown pointsReceivedNumericUpDown;
        private System.Windows.Forms.Label maxPointsLabel;
        private System.Windows.Forms.TextBox graderCommentTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label studentNameLabel;
        private System.Windows.Forms.Label criteriaDescLabel;
    }
}