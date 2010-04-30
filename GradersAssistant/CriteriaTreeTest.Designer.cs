namespace GradersAssistant
{
    partial class CriteriaTreeTest
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
            this.criteriaTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // criteriaTreeView
            // 
            this.criteriaTreeView.Location = new System.Drawing.Point(13, 13);
            this.criteriaTreeView.Name = "criteriaTreeView";
            this.criteriaTreeView.Size = new System.Drawing.Size(467, 306);
            this.criteriaTreeView.TabIndex = 0;
            this.criteriaTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.criteriaTreeView_NodeMouseClick);
            // 
            // CriteriaTreeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 433);
            this.Controls.Add(this.criteriaTreeView);
            this.Name = "CriteriaTreeTest";
            this.Text = "CriteriaTreeTest";
            this.Load += new System.EventHandler(this.CriteriaTreeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView criteriaTreeView;
    }
}