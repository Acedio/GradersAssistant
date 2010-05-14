namespace GradersAssistant
{
    partial class CreateAssignmentForm
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
            this.a_name_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.d_date_box = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // a_name_textbox
            // 
            this.a_name_textbox.Location = new System.Drawing.Point(28, 32);
            this.a_name_textbox.Name = "a_name_textbox";
            this.a_name_textbox.Size = new System.Drawing.Size(200, 20);
            this.a_name_textbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assignment Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Due date:";
            // 
            // acceptbtn
            // 
            this.acceptbtn.Location = new System.Drawing.Point(169, 106);
            this.acceptbtn.Name = "acceptbtn";
            this.acceptbtn.Size = new System.Drawing.Size(75, 23);
            this.acceptbtn.TabIndex = 4;
            this.acceptbtn.Text = "Begin..";
            this.acceptbtn.UseVisualStyleBackColor = true;
            this.acceptbtn.Click += new System.EventHandler(this.acceptbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbtn.Location = new System.Drawing.Point(88, 106);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 5;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            // 
            // d_date_box
            // 
            this.d_date_box.Location = new System.Drawing.Point(28, 71);
            this.d_date_box.Name = "d_date_box";
            this.d_date_box.Size = new System.Drawing.Size(200, 20);
            this.d_date_box.TabIndex = 6;
            // 
            // CreateAssignmentForm
            // 
            this.AcceptButton = this.acceptbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelbtn;
            this.ClientSize = new System.Drawing.Size(256, 137);
            this.Controls.Add(this.d_date_box);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.acceptbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.a_name_textbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateAssignmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create a new Assignment";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateAssignmentForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox a_name_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acceptbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.DateTimePicker d_date_box;
    }
}