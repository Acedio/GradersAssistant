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
                RubricNode child = rubric.Nodes[node];
                TreeNode treeViewNode = parentNode.Nodes.Add(child.ToString());
                treeViewNode.Name = child.Criteria.CriteriaID.ToString();
                AddChildNodes(treeViewNode, rubric, child.Criteria.CriteriaID);
            }
        }

        public void LoadAssignment(Assignment assignment)
        {
            currentAssignment = assignment;

            titleLabel.Text = currentAssignment.Name;

            dueLabel.Text = currentAssignment.DueDate.ToString("MM/dd/yyyy");

            rubricTreeView.BeginUpdate();

            rubricTreeView.Nodes.Clear();

            if (assignment.Rubric != null)
            {
                foreach (int node in assignment.Rubric.RootNodes)
                {
                    RubricNode child = assignment.Rubric.Nodes[node];
                    TreeNode treeViewNode = rubricTreeView.Nodes.Add(child.ToString());
                    treeViewNode.Name = child.Criteria.CriteriaID.ToString();
                    AddChildNodes(treeViewNode, assignment.Rubric, child.Criteria.CriteriaID);
                }
            }
            else
            {
                Debug.WriteLine("ERROR: The assignment doesn't have a rubric yet!");
            }

            rubricTreeView.EndUpdate();
        }

        public void LoadResponseList(Student student, ResponseList responseList)
        {
            if (currentAssignment == null || responseList.AssignmentID != currentAssignment.AssignmentID)
            {
                Debug.WriteLine("The assignment and response list IDs do not match!");
                return;
            }

            studentNameLabel.Text = string.Format("{0}, {1}", student.LastName, student.FirstName);

            studentIDLabel.Text = student.StudentSchoolID;

            foreach (KeyValuePair<int, RubricNode> rubricNode in currentAssignment.Rubric.Nodes)
            {
                TreeNode[] rubricTreeNodes = rubricTreeView.Nodes.Find(rubricNode.Value.Criteria.CriteriaID.ToString(),true);

                if (rubricTreeNodes.Length == 1)
                {
                    Response response;

                    if (responseList.Responses.TryGetValue(rubricNode.Value.Criteria.CriteriaID, out response))
                    {
                        // already created
                        if (response.PointsReceived > 0)
                        {
                            rubricTreeNodes[0].Checked = true;
                        }
                        else
                        {
                            // no checkmark if they have received 0 pts
                            rubricTreeNodes[0].Checked = false;
                        }
                    }
                    else
                    {
                        response = responseList.Responses[rubricNode.Value.Criteria.CriteriaID] = new Response();
                        rubricTreeNodes[0].Checked = true;
                        response.PointsReceived = rubricNode.Value.Criteria.MaxPoints;
                        Debug.WriteLine("The criteria in the rubric does not yet have a response for the given student.");
                    }
                    if (rubricNode.Value.Children.Count > 0)
                    {
                        rubricTreeNodes[0].Text = rubricNode.Value.Criteria.Description;
                    }
                    else
                    {
                        rubricTreeNodes[0].Text = string.Format("{0} ({1}): {2}",
                                            rubricNode.Value.Criteria.Description.ToString(),
                                            rubricNode.Value.Criteria.MaxPoints.ToString(),
                                            response.PointsReceived.ToString());
                    }
                }
                else if (rubricTreeNodes.Length == 0)
                {
                    Debug.WriteLine("The criteria in the rubric does not exist in the treeview.");
                }
                else
                {
                    Debug.WriteLine("Multiple criteria share the same key.");
                }
            }
        }
    }
}
