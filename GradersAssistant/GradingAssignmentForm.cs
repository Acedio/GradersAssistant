using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GradersAssistant
{
    public partial class GradingAssignmentForm : Form
    {
        private Assignment currentAssignment;

        private ResponseList currentResponseList;

        public GradingAssignmentForm()
        {
            InitializeComponent();
            currentAssignment = null;
            currentResponseList = null;
        }

        public void AddChildNodes(TreeNode parentNode, Rubric rubric, int parentKey)
        {
            foreach (int node in rubric.Nodes[parentKey].Children)
            {
                RubricNode parent = rubric.Nodes[node];
                AddChildNodes(parentNode.Nodes.Add(parent.ToString()), rubric, parent.Criteria.CriteriaID);
            }
        }

        public void LoadAssignment(Assignment assignment)
        {
            currentAssignment = assignment;

            rubricTreeView.BeginUpdate();

            rubricTreeView.Nodes.Clear();

            foreach (int node in assignment.Rubric.RootNodes)
            {
                RubricNode parent = assignment.Rubric.Nodes[node];
                AddChildNodes(rubricTreeView.Nodes.Add(parent.ToString()), assignment.Rubric, parent.Criteria.CriteriaID);
            }

            rubricTreeView.EndUpdate();
        }

        public void LoadResponseList(ResponseList responseList)
        {
            if (currentAssignment == null || responseList.AssignmentID != currentAssignment.AssignmentID)
            {
                Debug.WriteLine("The assignment response list do not match!");
                return;
            }

            foreach (KeyValuePair<int, Response> response in responseList.Responses)
            {
                // lol
            }
        }
    }
}
