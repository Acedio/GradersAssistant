namespace GradersAssistant
{
    partial class GradeEmailForm
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
            this.groupBoxProtocolInfo = new System.Windows.Forms.GroupBox();
            this.SMTPServerLabel = new System.Windows.Forms.Label();
            this.textBoxSMTPServer = new System.Windows.Forms.TextBox();
            this.textBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.labelEmailAddress = new System.Windows.Forms.Label();
            this.textBoxExchangePassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.radioButtonProtocolSMTP = new System.Windows.Forms.RadioButton();
            this.radioButtonProtocolExchange = new System.Windows.Forms.RadioButton();
            this.groupBoxRecipientOptions = new System.Windows.Forms.GroupBox();
            this.comboBoxStudentSelect = new System.Windows.Forms.ComboBox();
            this.radioButtonEmailOne = new System.Windows.Forms.RadioButton();
            this.radioButtonEmailAll = new System.Windows.Forms.RadioButton();
            this.groupBoxBodyText = new System.Windows.Forms.GroupBox();
            this.radioButtonPlainText = new System.Windows.Forms.RadioButton();
            this.radioButtonHtml = new System.Windows.Forms.RadioButton();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxHeaderText = new System.Windows.Forms.TextBox();
            this.checkBoxAddHeader = new System.Windows.Forms.CheckBox();
            this.buttonSendEmails = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxProtocolInfo.SuspendLayout();
            this.groupBoxRecipientOptions.SuspendLayout();
            this.groupBoxBodyText.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProtocolInfo
            // 
            this.groupBoxProtocolInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxProtocolInfo.Controls.Add(this.SMTPServerLabel);
            this.groupBoxProtocolInfo.Controls.Add(this.textBoxSMTPServer);
            this.groupBoxProtocolInfo.Controls.Add(this.textBoxEmailAddress);
            this.groupBoxProtocolInfo.Controls.Add(this.labelEmailAddress);
            this.groupBoxProtocolInfo.Controls.Add(this.textBoxExchangePassword);
            this.groupBoxProtocolInfo.Controls.Add(this.labelPassword);
            this.groupBoxProtocolInfo.Controls.Add(this.radioButtonProtocolSMTP);
            this.groupBoxProtocolInfo.Controls.Add(this.radioButtonProtocolExchange);
            this.groupBoxProtocolInfo.Location = new System.Drawing.Point(13, 13);
            this.groupBoxProtocolInfo.Name = "groupBoxProtocolInfo";
            this.groupBoxProtocolInfo.Size = new System.Drawing.Size(256, 299);
            this.groupBoxProtocolInfo.TabIndex = 2;
            this.groupBoxProtocolInfo.TabStop = false;
            this.groupBoxProtocolInfo.Text = "Protocol Info";
            // 
            // SMTPServerLabel
            // 
            this.SMTPServerLabel.AutoSize = true;
            this.SMTPServerLabel.Location = new System.Drawing.Point(6, 179);
            this.SMTPServerLabel.Name = "SMTPServerLabel";
            this.SMTPServerLabel.Size = new System.Drawing.Size(74, 13);
            this.SMTPServerLabel.TabIndex = 9;
            this.SMTPServerLabel.Text = "SMTP Server:";
            // 
            // textBoxSMTPServer
            // 
            this.textBoxSMTPServer.Location = new System.Drawing.Point(88, 176);
            this.textBoxSMTPServer.Name = "textBoxSMTPServer";
            this.textBoxSMTPServer.Size = new System.Drawing.Size(100, 20);
            this.textBoxSMTPServer.TabIndex = 4;
            // 
            // textBoxEmailAddress
            // 
            this.textBoxEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmailAddress.Location = new System.Drawing.Point(88, 26);
            this.textBoxEmailAddress.Name = "textBoxEmailAddress";
            this.textBoxEmailAddress.Size = new System.Drawing.Size(148, 20);
            this.textBoxEmailAddress.TabIndex = 0;
            // 
            // labelEmailAddress
            // 
            this.labelEmailAddress.AutoSize = true;
            this.labelEmailAddress.Location = new System.Drawing.Point(6, 29);
            this.labelEmailAddress.Name = "labelEmailAddress";
            this.labelEmailAddress.Size = new System.Drawing.Size(76, 13);
            this.labelEmailAddress.TabIndex = 6;
            this.labelEmailAddress.Text = "Email Address:";
            // 
            // textBoxExchangePassword
            // 
            this.textBoxExchangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExchangePassword.Location = new System.Drawing.Point(88, 98);
            this.textBoxExchangePassword.Name = "textBoxExchangePassword";
            this.textBoxExchangePassword.PasswordChar = '*';
            this.textBoxExchangePassword.Size = new System.Drawing.Size(148, 20);
            this.textBoxExchangePassword.TabIndex = 3;
            this.textBoxExchangePassword.Text = "*********";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 101);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // radioButtonProtocolSMTP
            // 
            this.radioButtonProtocolSMTP.AutoSize = true;
            this.radioButtonProtocolSMTP.Location = new System.Drawing.Point(9, 52);
            this.radioButtonProtocolSMTP.Name = "radioButtonProtocolSMTP";
            this.radioButtonProtocolSMTP.Size = new System.Drawing.Size(77, 17);
            this.radioButtonProtocolSMTP.TabIndex = 1;
            this.radioButtonProtocolSMTP.TabStop = true;
            this.radioButtonProtocolSMTP.Text = "Use SMTP";
            this.radioButtonProtocolSMTP.UseVisualStyleBackColor = true;
            this.radioButtonProtocolSMTP.CheckedChanged += new System.EventHandler(this.radioButtonProtocolSMTP_CheckedChanged);
            // 
            // radioButtonProtocolExchange
            // 
            this.radioButtonProtocolExchange.AutoSize = true;
            this.radioButtonProtocolExchange.Checked = true;
            this.radioButtonProtocolExchange.Location = new System.Drawing.Point(9, 75);
            this.radioButtonProtocolExchange.Name = "radioButtonProtocolExchange";
            this.radioButtonProtocolExchange.Size = new System.Drawing.Size(183, 17);
            this.radioButtonProtocolExchange.TabIndex = 2;
            this.radioButtonProtocolExchange.TabStop = true;
            this.radioButtonProtocolExchange.Text = "Use Microsoft Exchange Protocol";
            this.radioButtonProtocolExchange.UseVisualStyleBackColor = true;
            this.radioButtonProtocolExchange.CheckedChanged += new System.EventHandler(this.radioButtonProtocolExchange_CheckedChanged);
            // 
            // groupBoxRecipientOptions
            // 
            this.groupBoxRecipientOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxRecipientOptions.Controls.Add(this.comboBoxStudentSelect);
            this.groupBoxRecipientOptions.Controls.Add(this.radioButtonEmailOne);
            this.groupBoxRecipientOptions.Controls.Add(this.radioButtonEmailAll);
            this.groupBoxRecipientOptions.Location = new System.Drawing.Point(275, 13);
            this.groupBoxRecipientOptions.Name = "groupBoxRecipientOptions";
            this.groupBoxRecipientOptions.Size = new System.Drawing.Size(153, 299);
            this.groupBoxRecipientOptions.TabIndex = 3;
            this.groupBoxRecipientOptions.TabStop = false;
            this.groupBoxRecipientOptions.Text = "Recipient Options";
            // 
            // comboBoxStudentSelect
            // 
            this.comboBoxStudentSelect.Enabled = false;
            this.comboBoxStudentSelect.FormattingEnabled = true;
            this.comboBoxStudentSelect.Items.AddRange(new object[] {
            "Anders Erickson",
            "Joshua Pereyda",
            "Joshua Simmons",
            "Shawn Towry"});
            this.comboBoxStudentSelect.Location = new System.Drawing.Point(20, 68);
            this.comboBoxStudentSelect.Name = "comboBoxStudentSelect";
            this.comboBoxStudentSelect.Size = new System.Drawing.Size(127, 21);
            this.comboBoxStudentSelect.TabIndex = 2;
            this.comboBoxStudentSelect.Text = "Select Student:";
            // 
            // radioButtonEmailOne
            // 
            this.radioButtonEmailOne.AutoSize = true;
            this.radioButtonEmailOne.Location = new System.Drawing.Point(7, 45);
            this.radioButtonEmailOne.Name = "radioButtonEmailOne";
            this.radioButtonEmailOne.Size = new System.Drawing.Size(107, 17);
            this.radioButtonEmailOne.TabIndex = 1;
            this.radioButtonEmailOne.Text = "EmailOneStudent";
            this.radioButtonEmailOne.UseVisualStyleBackColor = true;
            this.radioButtonEmailOne.CheckedChanged += new System.EventHandler(this.radioButtonEmailOne_CheckedChanged);
            // 
            // radioButtonEmailAll
            // 
            this.radioButtonEmailAll.AutoSize = true;
            this.radioButtonEmailAll.Checked = true;
            this.radioButtonEmailAll.Location = new System.Drawing.Point(7, 20);
            this.radioButtonEmailAll.Name = "radioButtonEmailAll";
            this.radioButtonEmailAll.Size = new System.Drawing.Size(103, 17);
            this.radioButtonEmailAll.TabIndex = 0;
            this.radioButtonEmailAll.TabStop = true;
            this.radioButtonEmailAll.Text = "EmailAllStudents";
            this.radioButtonEmailAll.UseVisualStyleBackColor = true;
            this.radioButtonEmailAll.CheckedChanged += new System.EventHandler(this.radioButtonEmailAll_CheckedChanged);
            // 
            // groupBoxBodyText
            // 
            this.groupBoxBodyText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBodyText.Controls.Add(this.radioButtonPlainText);
            this.groupBoxBodyText.Controls.Add(this.radioButtonHtml);
            this.groupBoxBodyText.Controls.Add(this.subjectLabel);
            this.groupBoxBodyText.Controls.Add(this.textBoxSubject);
            this.groupBoxBodyText.Controls.Add(this.textBoxHeaderText);
            this.groupBoxBodyText.Controls.Add(this.checkBoxAddHeader);
            this.groupBoxBodyText.Location = new System.Drawing.Point(434, 13);
            this.groupBoxBodyText.Name = "groupBoxBodyText";
            this.groupBoxBodyText.Size = new System.Drawing.Size(408, 262);
            this.groupBoxBodyText.TabIndex = 4;
            this.groupBoxBodyText.TabStop = false;
            this.groupBoxBodyText.Text = "BodyText";
            // 
            // radioButtonPlainText
            // 
            this.radioButtonPlainText.AutoSize = true;
            this.radioButtonPlainText.Location = new System.Drawing.Point(10, 66);
            this.radioButtonPlainText.Name = "radioButtonPlainText";
            this.radioButtonPlainText.Size = new System.Drawing.Size(146, 17);
            this.radioButtonPlainText.TabIndex = 5;
            this.radioButtonPlainText.Text = "Use Plain Text Formatting";
            this.radioButtonPlainText.UseVisualStyleBackColor = true;
            this.radioButtonPlainText.CheckedChanged += new System.EventHandler(this.radioButtonPlainText_CheckedChanged);
            // 
            // radioButtonHtml
            // 
            this.radioButtonHtml.AutoSize = true;
            this.radioButtonHtml.Checked = true;
            this.radioButtonHtml.Location = new System.Drawing.Point(10, 43);
            this.radioButtonHtml.Name = "radioButtonHtml";
            this.radioButtonHtml.Size = new System.Drawing.Size(126, 17);
            this.radioButtonHtml.TabIndex = 4;
            this.radioButtonHtml.TabStop = true;
            this.radioButtonHtml.Text = "Use HTML formatting";
            this.radioButtonHtml.UseVisualStyleBackColor = true;
            this.radioButtonHtml.CheckedChanged += new System.EventHandler(this.radioButtonHtml_CheckedChanged);
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(7, 20);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 3;
            this.subjectLabel.Text = "Subject:";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubject.Location = new System.Drawing.Point(59, 17);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(343, 20);
            this.textBoxSubject.TabIndex = 0;
            // 
            // textBoxHeaderText
            // 
            this.textBoxHeaderText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHeaderText.Enabled = false;
            this.textBoxHeaderText.Location = new System.Drawing.Point(7, 112);
            this.textBoxHeaderText.Multiline = true;
            this.textBoxHeaderText.Name = "textBoxHeaderText";
            this.textBoxHeaderText.Size = new System.Drawing.Size(395, 144);
            this.textBoxHeaderText.TabIndex = 2;
            // 
            // checkBoxAddHeader
            // 
            this.checkBoxAddHeader.AutoSize = true;
            this.checkBoxAddHeader.Location = new System.Drawing.Point(6, 89);
            this.checkBoxAddHeader.Name = "checkBoxAddHeader";
            this.checkBoxAddHeader.Size = new System.Drawing.Size(108, 17);
            this.checkBoxAddHeader.TabIndex = 1;
            this.checkBoxAddHeader.Text = "Add email header";
            this.checkBoxAddHeader.UseVisualStyleBackColor = true;
            this.checkBoxAddHeader.CheckedChanged += new System.EventHandler(this.checkBoxAddHeader_CheckedChanged);
            // 
            // buttonSendEmails
            // 
            this.buttonSendEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSendEmails.Location = new System.Drawing.Point(555, 281);
            this.buttonSendEmails.Name = "buttonSendEmails";
            this.buttonSendEmails.Size = new System.Drawing.Size(130, 31);
            this.buttonSendEmails.TabIndex = 6;
            this.buttonSendEmails.Text = "Send Emails";
            this.buttonSendEmails.UseVisualStyleBackColor = true;
            this.buttonSendEmails.Click += new System.EventHandler(this.buttonSendEmails_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(435, 281);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 31);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // GradeEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 324);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSendEmails);
            this.Controls.Add(this.groupBoxBodyText);
            this.Controls.Add(this.groupBoxRecipientOptions);
            this.Controls.Add(this.groupBoxProtocolInfo);
            this.Name = "GradeEmailForm";
            this.Text = "Email Grades";
            this.groupBoxProtocolInfo.ResumeLayout(false);
            this.groupBoxProtocolInfo.PerformLayout();
            this.groupBoxRecipientOptions.ResumeLayout(false);
            this.groupBoxRecipientOptions.PerformLayout();
            this.groupBoxBodyText.ResumeLayout(false);
            this.groupBoxBodyText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProtocolInfo;
        private System.Windows.Forms.RadioButton radioButtonProtocolSMTP;
        private System.Windows.Forms.RadioButton radioButtonProtocolExchange;
        private System.Windows.Forms.TextBox textBoxExchangePassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxEmailAddress;
        private System.Windows.Forms.Label labelEmailAddress;
        private System.Windows.Forms.GroupBox groupBoxRecipientOptions;
        private System.Windows.Forms.ComboBox comboBoxStudentSelect;
        private System.Windows.Forms.RadioButton radioButtonEmailOne;
        private System.Windows.Forms.RadioButton radioButtonEmailAll;
        private System.Windows.Forms.GroupBox groupBoxBodyText;
        private System.Windows.Forms.TextBox textBoxHeaderText;
        private System.Windows.Forms.CheckBox checkBoxAddHeader;
        private System.Windows.Forms.Button buttonSendEmails;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label SMTPServerLabel;
        private System.Windows.Forms.TextBox textBoxSMTPServer;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.RadioButton radioButtonPlainText;
        private System.Windows.Forms.RadioButton radioButtonHtml;

    }
}

