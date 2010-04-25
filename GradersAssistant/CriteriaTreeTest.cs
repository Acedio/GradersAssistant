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
    public partial class CriteriaTreeTest : Form
    {
        public CriteriaTreeTest()
        {
            InitializeComponent();
        }

        private void CriteriaTreeTest_Load(object sender, EventArgs e)
        {
            criteriaTreeView.Nodes.Add("12345", "lol");
        }

        private void criteriaTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(e.Node.Name.ToString());
            }
        }
    }
}
