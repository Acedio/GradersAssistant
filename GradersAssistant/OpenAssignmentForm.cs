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
    public partial class OpenAssignmentForm : Form
    {
        public Assignment SelectedAssignment;

        public bool Cancelled;

        public OpenAssignmentForm(List<Assignment> assignments)
        {
            InitializeComponent();

            Cancelled = true;

            assignmentsComboBox.BeginUpdate();

            assignmentsComboBox.Items.Clear();

            foreach (Assignment assignment in assignments)
            {
                assignmentsComboBox.Items.Add(assignment);
            }

            assignmentsComboBox.EndUpdate();
        }

        private void OopsButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;

            this.Close();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (assignmentsComboBox.SelectedItem != null)
            {
                Cancelled = false;

                SelectedAssignment = (Assignment)assignmentsComboBox.SelectedItem;
            }
            else
            {
                Cancelled = true;
            }

            this.Close();
        }
    }
}
