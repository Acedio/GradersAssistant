namespace GradersAssistant
{
    partial class OpenAssignmentForm
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
            this.assignmentsComboBox = new System.Windows.Forms.ComboBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.OopsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // assignmentsComboBox
            // 
            this.assignmentsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assignmentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assignmentsComboBox.FormattingEnabled = true;
            this.assignmentsComboBox.Location = new System.Drawing.Point(12, 12);
            this.assignmentsComboBox.Name = "assignmentsComboBox";
            this.assignmentsComboBox.Size = new System.Drawing.Size(303, 21);
            this.assignmentsComboBox.TabIndex = 0;
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Location = new System.Drawing.Point(240, 46);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OopsButton
            // 
            this.OopsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OopsButton.Location = new System.Drawing.Point(159, 46);
            this.OopsButton.Name = "OopsButton";
            this.OopsButton.Size = new System.Drawing.Size(75, 23);
            this.OopsButton.TabIndex = 2;
            this.OopsButton.Text = "Cancel";
            this.OopsButton.UseVisualStyleBackColor = true;
            this.OopsButton.Click += new System.EventHandler(this.OopsButton_Click);
            // 
            // OpenAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 81);
            this.Controls.Add(this.OopsButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.assignmentsComboBox);
            this.Name = "OpenAssignmentForm";
            this.Text = "Open Assignment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox assignmentsComboBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button OopsButton;
    }
}