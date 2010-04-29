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
    public partial class GradingAssignmentForm : Form
    {
        public GradingAssignmentForm()
        {
            InitializeComponent();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            GradingItemForm gradingItemForm = new GradingItemForm();
            gradingItemForm.Show();
        }
    }
}
