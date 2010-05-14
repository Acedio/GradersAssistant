using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradersAssistant
{
    public partial class AdjustmentForm : Form
    {
        public bool Cancelled;

        public Adjustment GraderAdjustment;

        public AdjustmentForm(Adjustment a)
        {
            Cancelled = true; // fail closed rather than open

            GraderAdjustment = a;

            InitializeComponent();

            pointAdjustmentNumericUpDown.Value = GraderAdjustment.PointAdjustment;

            commentTextBox.Text = GraderAdjustment.Comment;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GraderAdjustment.PointAdjustment = (int)pointAdjustmentNumericUpDown.Value;

            GraderAdjustment.Comment = commentTextBox.Text;

            Cancelled = false;

            this.Close();
        }
    }
}
