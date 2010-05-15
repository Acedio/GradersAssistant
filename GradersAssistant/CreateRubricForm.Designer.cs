namespace GradersAssistant
{
    partial class CreateRubricForm
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
            this.CriteriaDisplay = new System.Windows.Forms.TreeView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AwesomeCancelButton = new System.Windows.Forms.Button();
            this.EditCriteriaPanel = new System.Windows.Forms.Panel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SaveCriteriaButton = new System.Windows.Forms.Button();
            this.AddCriteriaButton = new System.Windows.Forms.Button();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.ptsLabel = new System.Windows.Forms.Label();
            this.PointsTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.DescriptionTextbox = new System.Windows.Forms.TextBox();
            this.ExpandCollapseAllButton = new System.Windows.Forms.Button();
            this.EditCriteriaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CriteriaDisplay
            // 
            this.CriteriaDisplay.AllowDrop = true;
            this.CriteriaDisplay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CriteriaDisplay.HideSelection = false;
            this.CriteriaDisplay.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.CriteriaDisplay.ItemHeight = 15;
            this.CriteriaDisplay.Location = new System.Drawing.Point(12, 12);
            this.CriteriaDisplay.Name = "CriteriaDisplay";
            this.CriteriaDisplay.Size = new System.Drawing.Size(475, 313);
            this.CriteriaDisplay.TabIndex = 1;
            this.CriteriaDisplay.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CriteriaDisplay_AfterSelect);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(389, 450);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(1);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 25);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AwesomeCancelButton
            // 
            this.AwesomeCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AwesomeCancelButton.Location = new System.Drawing.Point(10, 450);
            this.AwesomeCancelButton.Margin = new System.Windows.Forms.Padding(1);
            this.AwesomeCancelButton.Name = "AwesomeCancelButton";
            this.AwesomeCancelButton.Size = new System.Drawing.Size(100, 25);
            this.AwesomeCancelButton.TabIndex = 3;
            this.AwesomeCancelButton.Text = "Cancel";
            this.AwesomeCancelButton.UseVisualStyleBackColor = true;
            this.AwesomeCancelButton.Click += new System.EventHandler(this.AwesomeCancelButton_Click);
            // 
            // EditCriteriaPanel
            // 
            this.EditCriteriaPanel.Controls.Add(this.RemoveButton);
            this.EditCriteriaPanel.Controls.Add(this.SaveCriteriaButton);
            this.EditCriteriaPanel.Controls.Add(this.AddCriteriaButton);
            this.EditCriteriaPanel.Controls.Add(this.PointsLabel);
            this.EditCriteriaPanel.Controls.Add(this.ptsLabel);
            this.EditCriteriaPanel.Controls.Add(this.PointsTextBox);
            this.EditCriteriaPanel.Controls.Add(this.DescriptionLbl);
            this.EditCriteriaPanel.Controls.Add(this.DescriptionTextbox);
            this.EditCriteriaPanel.Location = new System.Drawing.Point(13, 359);
            this.EditCriteriaPanel.Name = "EditCriteriaPanel";
            this.EditCriteriaPanel.Size = new System.Drawing.Size(474, 87);
            this.EditCriteriaPanel.TabIndex = 4;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(352, 19);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(119, 23);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Remove Selected";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SaveCriteriaButton
            // 
            this.SaveCriteriaButton.Location = new System.Drawing.Point(352, 54);
            this.SaveCriteriaButton.Name = "SaveCriteriaButton";
            this.SaveCriteriaButton.Size = new System.Drawing.Size(119, 23);
            this.SaveCriteriaButton.TabIndex = 6;
            this.SaveCriteriaButton.Text = "Save Selected";
            this.SaveCriteriaButton.UseVisualStyleBackColor = true;
            this.SaveCriteriaButton.Click += new System.EventHandler(this.SaveCriteriaButton_Click);
            // 
            // AddCriteriaButton
            // 
            this.AddCriteriaButton.Location = new System.Drawing.Point(188, 52);
            this.AddCriteriaButton.Name = "AddCriteriaButton";
            this.AddCriteriaButton.Size = new System.Drawing.Size(104, 23);
            this.AddCriteriaButton.TabIndex = 5;
            this.AddCriteriaButton.Text = "Insert Criteria";
            this.AddCriteriaButton.UseVisualStyleBackColor = true;
            this.AddCriteriaButton.Click += new System.EventHandler(this.AddCriteriaButton_Click);
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.Location = new System.Drawing.Point(7, 38);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(39, 13);
            this.PointsLabel.TabIndex = 4;
            this.PointsLabel.Text = "Points:";
            // 
            // ptsLabel
            // 
            this.ptsLabel.AutoSize = true;
            this.ptsLabel.Location = new System.Drawing.Point(93, 62);
            this.ptsLabel.Name = "ptsLabel";
            this.ptsLabel.Size = new System.Drawing.Size(24, 13);
            this.ptsLabel.TabIndex = 3;
            this.ptsLabel.Text = "pts.";
            // 
            // PointsTextBox
            // 
            this.PointsTextBox.Location = new System.Drawing.Point(33, 56);
            this.PointsTextBox.Name = "PointsTextBox";
            this.PointsTextBox.Size = new System.Drawing.Size(53, 20);
            this.PointsTextBox.TabIndex = 2;
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(4, 4);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLbl.TabIndex = 1;
            this.DescriptionLbl.Text = "Description:";
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.AutoCompleteCustomSource.AddRange(new string[] {
            "Turned in on time",
            "Written Portion",
            "Code",
            "Comments",
            "Extra Credit"});
            this.DescriptionTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DescriptionTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.DescriptionTextbox.Location = new System.Drawing.Point(33, 19);
            this.DescriptionTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.DescriptionTextbox.Size = new System.Drawing.Size(259, 20);
            this.DescriptionTextbox.TabIndex = 0;
            this.DescriptionTextbox.Text = "(Criteria Description)";
            // 
            // ExpandCollapseAllButton
            // 
            this.ExpandCollapseAllButton.Location = new System.Drawing.Point(389, 331);
            this.ExpandCollapseAllButton.Name = "ExpandCollapseAllButton";
            this.ExpandCollapseAllButton.Size = new System.Drawing.Size(98, 22);
            this.ExpandCollapseAllButton.TabIndex = 5;
            this.ExpandCollapseAllButton.Text = "Collapse All";
            this.ExpandCollapseAllButton.UseVisualStyleBackColor = true;
            this.ExpandCollapseAllButton.Click += new System.EventHandler(this.ExpandCollapseAllButton_Click);
            // 
            // CreateRubricForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 485);
            this.Controls.Add(this.ExpandCollapseAllButton);
            this.Controls.Add(this.EditCriteriaPanel);
            this.Controls.Add(this.AwesomeCancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CriteriaDisplay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRubricForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rubric Creator";
            this.Load += new System.EventHandler(this.CreateRubricForm_Load);
            this.EditCriteriaPanel.ResumeLayout(false);
            this.EditCriteriaPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CriteriaDisplay;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AwesomeCancelButton;
        private System.Windows.Forms.Panel EditCriteriaPanel;
        private System.Windows.Forms.TextBox DescriptionTextbox;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Label ptsLabel;
        private System.Windows.Forms.TextBox PointsTextBox;
        private System.Windows.Forms.Button AddCriteriaButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button SaveCriteriaButton;
        private System.Windows.Forms.Button ExpandCollapseAllButton;

    }
}