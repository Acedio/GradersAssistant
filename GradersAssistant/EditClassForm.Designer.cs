namespace GradersAssistant
{
    partial class EditClassForm
    {
        public int Status;

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
            this.panelDetails = new System.Windows.Forms.Panel();
            this.comboBoxNumberOfSections = new System.Windows.Forms.ComboBox();
            this.textGraderName = new System.Windows.Forms.TextBox();
            this.labelNumberOfSection = new System.Windows.Forms.Label();
            this.labelGraderName = new System.Windows.Forms.Label();
            this.textClassName = new System.Windows.Forms.TextBox();
            this.labelClassName = new System.Windows.Forms.Label();
            this.panelResultOutput = new System.Windows.Forms.Panel();
            this.checkBoxDisplayClassStats = new System.Windows.Forms.CheckBox();
            this.checkBoxEmailStudentsNoGrade = new System.Windows.Forms.CheckBox();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.checkBoxIncludeSection = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeNames = new System.Windows.Forms.CheckBox();
            this.checkBoxSetFullPoints = new System.Windows.Forms.CheckBox();
            this.checkBoxAlertOnLate = new System.Windows.Forms.CheckBox();
            this.labelHostType = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelFormAddress = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHostType = new System.Windows.Forms.ComboBox();
            this.textFromAddress = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelDetails = new System.Windows.Forms.Label();
            this.labelGeneral = new System.Windows.Forms.Label();
            this.labelResultsOutput = new System.Windows.Forms.Label();
            this.buttonCancelClass = new System.Windows.Forms.Button();
            this.buttonUpdateClass = new System.Windows.Forms.Button();
            this.textPortNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFormatAsHTML = new System.Windows.Forms.CheckBox();
            this.panelDetails.SuspendLayout();
            this.panelResultOutput.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.comboBoxNumberOfSections);
            this.panelDetails.Controls.Add(this.textGraderName);
            this.panelDetails.Controls.Add(this.labelNumberOfSection);
            this.panelDetails.Controls.Add(this.labelGraderName);
            this.panelDetails.Controls.Add(this.textClassName);
            this.panelDetails.Controls.Add(this.labelClassName);
            this.panelDetails.Location = new System.Drawing.Point(27, 29);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(296, 124);
            this.panelDetails.TabIndex = 0;
            // 
            // comboBoxNumberOfSections
            // 
            this.comboBoxNumberOfSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfSections.FormattingEnabled = true;
            this.comboBoxNumberOfSections.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.comboBoxNumberOfSections.Location = new System.Drawing.Point(132, 92);
            this.comboBoxNumberOfSections.Name = "comboBoxNumberOfSections";
            this.comboBoxNumberOfSections.Size = new System.Drawing.Size(57, 21);
            this.comboBoxNumberOfSections.TabIndex = 2;
            // 
            // textGraderName
            // 
            this.textGraderName.AcceptsTab = true;
            this.textGraderName.Location = new System.Drawing.Point(100, 49);
            this.textGraderName.Name = "textGraderName";
            this.textGraderName.Size = new System.Drawing.Size(165, 20);
            this.textGraderName.TabIndex = 1;
            // 
            // labelNumberOfSection
            // 
            this.labelNumberOfSection.AutoSize = true;
            this.labelNumberOfSection.Location = new System.Drawing.Point(24, 95);
            this.labelNumberOfSection.Name = "labelNumberOfSection";
            this.labelNumberOfSection.Size = new System.Drawing.Size(102, 13);
            this.labelNumberOfSection.TabIndex = 3;
            this.labelNumberOfSection.Text = "Number Of Sections";
            // 
            // labelGraderName
            // 
            this.labelGraderName.AutoSize = true;
            this.labelGraderName.Location = new System.Drawing.Point(24, 52);
            this.labelGraderName.Name = "labelGraderName";
            this.labelGraderName.Size = new System.Drawing.Size(70, 13);
            this.labelGraderName.TabIndex = 2;
            this.labelGraderName.Text = "Grader Name";
            // 
            // textClassName
            // 
            this.textClassName.AcceptsTab = true;
            this.textClassName.Location = new System.Drawing.Point(102, 12);
            this.textClassName.Name = "textClassName";
            this.textClassName.Size = new System.Drawing.Size(165, 20);
            this.textClassName.TabIndex = 0;
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(24, 15);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(63, 13);
            this.labelClassName.TabIndex = 0;
            this.labelClassName.Text = "Class Name";
            // 
            // panelResultOutput
            // 
            this.panelResultOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResultOutput.Controls.Add(this.checkBoxFormatAsHTML);
            this.panelResultOutput.Controls.Add(this.checkBoxDisplayClassStats);
            this.panelResultOutput.Controls.Add(this.checkBoxEmailStudentsNoGrade);
            this.panelResultOutput.Location = new System.Drawing.Point(347, 165);
            this.panelResultOutput.Name = "panelResultOutput";
            this.panelResultOutput.Size = new System.Drawing.Size(234, 96);
            this.panelResultOutput.TabIndex = 3;
            // 
            // checkBoxDisplayClassStats
            // 
            this.checkBoxDisplayClassStats.AutoSize = true;
            this.checkBoxDisplayClassStats.Location = new System.Drawing.Point(13, 65);
            this.checkBoxDisplayClassStats.Name = "checkBoxDisplayClassStats";
            this.checkBoxDisplayClassStats.Size = new System.Drawing.Size(208, 17);
            this.checkBoxDisplayClassStats.TabIndex = 1;
            this.checkBoxDisplayClassStats.Text = "Display Class Statistics in Result E-mail";
            this.checkBoxDisplayClassStats.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmailStudentsNoGrade
            // 
            this.checkBoxEmailStudentsNoGrade.AutoSize = true;
            this.checkBoxEmailStudentsNoGrade.Location = new System.Drawing.Point(13, 42);
            this.checkBoxEmailStudentsNoGrade.Name = "checkBoxEmailStudentsNoGrade";
            this.checkBoxEmailStudentsNoGrade.Size = new System.Drawing.Size(171, 17);
            this.checkBoxEmailStudentsNoGrade.TabIndex = 0;
            this.checkBoxEmailStudentsNoGrade.Text = "E-mail Students With no Grade";
            this.checkBoxEmailStudentsNoGrade.UseVisualStyleBackColor = true;
            // 
            // panelGeneral
            // 
            this.panelGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGeneral.Controls.Add(this.checkBoxIncludeSection);
            this.panelGeneral.Controls.Add(this.checkBoxIncludeNames);
            this.panelGeneral.Controls.Add(this.checkBoxSetFullPoints);
            this.panelGeneral.Controls.Add(this.checkBoxAlertOnLate);
            this.panelGeneral.Location = new System.Drawing.Point(347, 29);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(223, 114);
            this.panelGeneral.TabIndex = 2;
            // 
            // checkBoxIncludeSection
            // 
            this.checkBoxIncludeSection.AutoSize = true;
            this.checkBoxIncludeSection.Location = new System.Drawing.Point(13, 84);
            this.checkBoxIncludeSection.Name = "checkBoxIncludeSection";
            this.checkBoxIncludeSection.Size = new System.Drawing.Size(187, 17);
            this.checkBoxIncludeSection.TabIndex = 3;
            this.checkBoxIncludeSection.Text = "Include Section in Drop Down List";
            this.checkBoxIncludeSection.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeNames
            // 
            this.checkBoxIncludeNames.AutoSize = true;
            this.checkBoxIncludeNames.Location = new System.Drawing.Point(15, 61);
            this.checkBoxIncludeNames.Name = "checkBoxIncludeNames";
            this.checkBoxIncludeNames.Size = new System.Drawing.Size(184, 17);
            this.checkBoxIncludeNames.TabIndex = 2;
            this.checkBoxIncludeNames.Text = "Include Names in Drop Down List";
            this.checkBoxIncludeNames.UseVisualStyleBackColor = true;
            // 
            // checkBoxSetFullPoints
            // 
            this.checkBoxSetFullPoints.AutoSize = true;
            this.checkBoxSetFullPoints.Location = new System.Drawing.Point(15, 38);
            this.checkBoxSetFullPoints.Name = "checkBoxSetFullPoints";
            this.checkBoxSetFullPoints.Size = new System.Drawing.Size(142, 17);
            this.checkBoxSetFullPoints.TabIndex = 1;
            this.checkBoxSetFullPoints.Text = "Set Full Points as default";
            this.checkBoxSetFullPoints.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlertOnLate
            // 
            this.checkBoxAlertOnLate.AutoSize = true;
            this.checkBoxAlertOnLate.Location = new System.Drawing.Point(15, 15);
            this.checkBoxAlertOnLate.Name = "checkBoxAlertOnLate";
            this.checkBoxAlertOnLate.Size = new System.Drawing.Size(149, 17);
            this.checkBoxAlertOnLate.TabIndex = 0;
            this.checkBoxAlertOnLate.Text = "Alert On Late Submissions";
            this.checkBoxAlertOnLate.UseVisualStyleBackColor = true;
            // 
            // labelHostType
            // 
            this.labelHostType.AutoSize = true;
            this.labelHostType.Location = new System.Drawing.Point(22, 16);
            this.labelHostType.Name = "labelHostType";
            this.labelHostType.Size = new System.Drawing.Size(56, 13);
            this.labelHostType.TabIndex = 4;
            this.labelHostType.Text = "Host Type";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(22, 48);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "Username";
            // 
            // labelFormAddress
            // 
            this.labelFormAddress.AutoSize = true;
            this.labelFormAddress.Location = new System.Drawing.Point(22, 73);
            this.labelFormAddress.Name = "labelFormAddress";
            this.labelFormAddress.Size = new System.Drawing.Size(71, 13);
            this.labelFormAddress.TabIndex = 6;
            this.labelFormAddress.Text = "From Address";
            // 
            // panelEmail
            // 
            this.panelEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEmail.Controls.Add(this.textServerName);
            this.panelEmail.Controls.Add(this.label1);
            this.panelEmail.Controls.Add(this.comboBoxHostType);
            this.panelEmail.Controls.Add(this.textFromAddress);
            this.panelEmail.Controls.Add(this.textUsername);
            this.panelEmail.Controls.Add(this.labelFormAddress);
            this.panelEmail.Controls.Add(this.labelHostType);
            this.panelEmail.Controls.Add(this.labelUsername);
            this.panelEmail.Location = new System.Drawing.Point(27, 174);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(296, 151);
            this.panelEmail.TabIndex = 1;
            // 
            // textServerName
            // 
            this.textServerName.Location = new System.Drawing.Point(93, 96);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(171, 20);
            this.textServerName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server Name";
            // 
            // comboBoxHostType
            // 
            this.comboBoxHostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHostType.FormattingEnabled = true;
            this.comboBoxHostType.Items.AddRange(new object[] {
            "SMTP",
            "Exchange"});
            this.comboBoxHostType.Location = new System.Drawing.Point(83, 13);
            this.comboBoxHostType.Name = "comboBoxHostType";
            this.comboBoxHostType.Size = new System.Drawing.Size(106, 21);
            this.comboBoxHostType.TabIndex = 0;
            // 
            // textFromAddress
            // 
            this.textFromAddress.Location = new System.Drawing.Point(94, 70);
            this.textFromAddress.Name = "textFromAddress";
            this.textFromAddress.Size = new System.Drawing.Size(171, 20);
            this.textFromAddress.TabIndex = 2;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(83, 45);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(182, 20);
            this.textUsername.TabIndex = 1;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(30, 163);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(47, 17);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "E-mail";
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetails.Location = new System.Drawing.Point(30, 19);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(51, 17);
            this.labelDetails.TabIndex = 5;
            this.labelDetails.Text = "Details";
            // 
            // labelGeneral
            // 
            this.labelGeneral.AutoSize = true;
            this.labelGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneral.Location = new System.Drawing.Point(350, 19);
            this.labelGeneral.Name = "labelGeneral";
            this.labelGeneral.Size = new System.Drawing.Size(59, 17);
            this.labelGeneral.TabIndex = 7;
            this.labelGeneral.Text = "General";
            // 
            // labelResultsOutput
            // 
            this.labelResultsOutput.AutoSize = true;
            this.labelResultsOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultsOutput.Location = new System.Drawing.Point(350, 155);
            this.labelResultsOutput.Name = "labelResultsOutput";
            this.labelResultsOutput.Size = new System.Drawing.Size(102, 17);
            this.labelResultsOutput.TabIndex = 8;
            this.labelResultsOutput.Text = "Results Output";
            // 
            // buttonCancelClass
            // 
            this.buttonCancelClass.Location = new System.Drawing.Point(174, 342);
            this.buttonCancelClass.Name = "buttonCancelClass";
            this.buttonCancelClass.Size = new System.Drawing.Size(118, 41);
            this.buttonCancelClass.TabIndex = 5;
            this.buttonCancelClass.Text = "Cancel";
            this.buttonCancelClass.UseVisualStyleBackColor = true;
            this.buttonCancelClass.Click += new System.EventHandler(this.buttonCancelClass_Click);
            // 
            // buttonUpdateClass
            // 
            this.buttonUpdateClass.Location = new System.Drawing.Point(334, 342);
            this.buttonUpdateClass.Name = "buttonUpdateClass";
            this.buttonUpdateClass.Size = new System.Drawing.Size(118, 41);
            this.buttonUpdateClass.TabIndex = 4;
            this.buttonUpdateClass.Text = "Update";
            this.buttonUpdateClass.UseVisualStyleBackColor = true;
            this.buttonUpdateClass.Click += new System.EventHandler(this.buttonUpdateClass_Click);
            // 
            // textPortNumber
            // 
            this.textPortNumber.Location = new System.Drawing.Point(121, 297);
            this.textPortNumber.Name = "textPortNumber";
            this.textPortNumber.Size = new System.Drawing.Size(73, 20);
            this.textPortNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port Number";
            // 
            // checkBoxFormatAsHTML
            // 
            this.checkBoxFormatAsHTML.AutoSize = true;
            this.checkBoxFormatAsHTML.Location = new System.Drawing.Point(13, 19);
            this.checkBoxFormatAsHTML.Name = "checkBoxFormatAsHTML";
            this.checkBoxFormatAsHTML.Size = new System.Drawing.Size(106, 17);
            this.checkBoxFormatAsHTML.TabIndex = 2;
            this.checkBoxFormatAsHTML.Text = "Format As HTML";
            this.checkBoxFormatAsHTML.UseVisualStyleBackColor = true;
            // 
            // EditClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 410);
            this.Controls.Add(this.textPortNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUpdateClass);
            this.Controls.Add(this.buttonCancelClass);
            this.Controls.Add(this.labelResultsOutput);
            this.Controls.Add(this.labelGeneral);
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.panelGeneral);
            this.Controls.Add(this.panelResultOutput);
            this.Controls.Add(this.panelDetails);
            this.MaximumSize = new System.Drawing.Size(621, 448);
            this.MinimumSize = new System.Drawing.Size(621, 448);
            this.Name = "EditClassForm";
            this.Text = "Edit Class";
            this.Load += new System.EventHandler(this.EditClassForm_Load);
            this.Shown += new System.EventHandler(this.EditClassForm_Load);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelResultOutput.ResumeLayout(false);
            this.panelResultOutput.PerformLayout();
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelResultOutput;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Label labelFormAddress;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelHostType;
        private System.Windows.Forms.Label labelNumberOfSection;
        private System.Windows.Forms.Label labelGraderName;
        private System.Windows.Forms.TextBox textClassName;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.ComboBox comboBoxNumberOfSections;
        private System.Windows.Forms.TextBox textGraderName;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.ComboBox comboBoxHostType;
        private System.Windows.Forms.TextBox textFromAddress;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.CheckBox checkBoxIncludeSection;
        private System.Windows.Forms.CheckBox checkBoxIncludeNames;
        private System.Windows.Forms.CheckBox checkBoxSetFullPoints;
        private System.Windows.Forms.CheckBox checkBoxAlertOnLate;
        private System.Windows.Forms.CheckBox checkBoxDisplayClassStats;
        private System.Windows.Forms.CheckBox checkBoxEmailStudentsNoGrade;
        private System.Windows.Forms.Label labelGeneral;
        private System.Windows.Forms.Label labelResultsOutput;
        private System.Windows.Forms.Button buttonCancelClass;
        private System.Windows.Forms.Button buttonUpdateClass;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPortNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxFormatAsHTML;
    }
}