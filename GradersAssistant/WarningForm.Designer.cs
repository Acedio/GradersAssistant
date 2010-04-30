namespace GradersAssistant
{
    partial class WarningForm
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
            this.buttonOkError = new System.Windows.Forms.Button();
            this.labelErrorList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOkError
            // 
            this.buttonOkError.Location = new System.Drawing.Point(83, 196);
            this.buttonOkError.Name = "buttonOkError";
            this.buttonOkError.Size = new System.Drawing.Size(118, 41);
            this.buttonOkError.TabIndex = 10;
            this.buttonOkError.Text = "Cancel";
            this.buttonOkError.UseVisualStyleBackColor = true;
            this.buttonOkError.Click += new System.EventHandler(this.buttonOkError_Click);
            // 
            // labelErrorList
            // 
            this.labelErrorList.AutoSize = true;
            this.labelErrorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorList.ForeColor = System.Drawing.Color.Red;
            this.labelErrorList.Location = new System.Drawing.Point(65, 9);
            this.labelErrorList.Name = "labelErrorList";
            this.labelErrorList.Size = new System.Drawing.Size(58, 13);
            this.labelErrorList.TabIndex = 12;
            this.labelErrorList.Text = "Error List";
            // 
            // WarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.labelErrorList);
            this.Controls.Add(this.buttonOkError);
            this.Name = "WarningForm";
            this.Text = "Warning";
            this.Load += new System.EventHandler(this.WarningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOkError;
        private System.Windows.Forms.Label labelErrorList;

    }
}