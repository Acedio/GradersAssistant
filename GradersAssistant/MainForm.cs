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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void criteriaTreeFormOpenButton_Click(object sender, EventArgs e)
        {
            CriteriaTreeTest treeTest = new CriteriaTreeTest();
            treeTest.Show();
        }
    }
}
