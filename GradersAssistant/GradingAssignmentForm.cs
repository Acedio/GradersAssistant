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

        private Rubric currentRubric;

        public void AddChildNodes(TreeNode parentNode, Rubric rubric, int parentKey)
        {
            foreach (int node in rubric.Nodes[parentKey].Children)
            {
                RubricNode parent = rubric.Nodes[node];
                AddChildNodes(parentNode.Nodes.Add(parent.ToString()), rubric, parent.Criteria.CriteriaID);
            }
        }

        public void LoadRubric(Rubric rubric)
        {
            currentRubric = rubric;

            rubricTreeView.BeginUpdate();

            rubricTreeView.Nodes.Clear();

            foreach (int node in rubric.RootNodes)
            {
                RubricNode parent = rubric.Nodes[node];
                AddChildNodes(rubricTreeView.Nodes.Add(parent.ToString()), rubric, parent.Criteria.CriteriaID);
            }

            rubricTreeView.EndUpdate();
        }
    }
}
