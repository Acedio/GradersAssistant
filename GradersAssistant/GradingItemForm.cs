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
    public partial class GradingItemForm : Form
    {
        public bool Cancelled;

        public Response GraderResponse;

        public GradingItemForm(Response r, Criteria criteria, Student student)
        {
            Cancelled = true; // fail closed rather than open

            GraderResponse = r;

            InitializeComponent();

            studentNameLabel.Text = string.Format("{0}, {1}", student.LastName, student.FirstName);

            criteriaDescLabel.Text = criteria.Description;

            pointsReceivedNumericUpDown.Maximum = criteria.MaxPoints;

            pointsReceivedNumericUpDown.Minimum = 0;

            maxPointsLabel.Text = string.Format("Pts out of {0} Pts", criteria.MaxPoints.ToString());

            graderCommentTextBox.Text = GraderResponse.GraderComment;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GraderResponse.PointsReceived = (int)pointsReceivedNumericUpDown.Value;

            GraderResponse.GraderComment = graderCommentTextBox.Text;

            Cancelled = false;

            this.Close();
        }
    }
}
