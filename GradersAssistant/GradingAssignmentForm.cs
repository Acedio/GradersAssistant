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

        private Student currentStudent;

        public LinkedList<int> DeletedAdjustments;

        public GradingAssignmentForm()
        {
            InitializeComponent();
            currentAssignment = null;
            currentResponseList = null;
            DeletedAdjustments = new LinkedList<int>();
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

        // TODO: Make sure headers are unchecked if they have no checked children

        public void LoadAssignment(Assignment assignment)
        {
            currentAssignment = assignment;

            titleLabel.Text = currentAssignment.Name;

            this.Text = currentAssignment.Name;

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

            maxPointsLabel.Text = string.Format("out of {0} Pts", assignment.Rubric.MaxPoints().ToString());
        }

        public void LoadResponseList(Student student, ResponseList responseList)
        {
            if (currentAssignment == null || responseList.AssignmentID != currentAssignment.AssignmentID)
            {
                Debug.WriteLine("The assignment and response list IDs do not match!");
                return;
            }

            currentStudent = student;

            currentResponseList = responseList;

            studentNameLabel.Text = string.Format("{0}, {1}", currentStudent.LastName, currentStudent.FirstName);

            studentIDLabel.Text = currentStudent.StudentSchoolID;

            foreach (KeyValuePair<int, RubricNode> rubricNode in currentAssignment.Rubric.Nodes)
            {
                TreeNode[] rubricTreeNodes = rubricTreeView.Nodes.Find(rubricNode.Value.Criteria.CriteriaID.ToString(),true);

                if (rubricTreeNodes.Length == 1)
                {
                    Response response;

                    if (currentResponseList.Responses.TryGetValue(rubricNode.Value.Criteria.CriteriaID, out response))
                    { // if we have already created a response for this criteria/student
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
                    else if(rubricNode.Value.Children.Count == 0)
                    { // we need to create a response if none exists and this isn't a header
                        response = currentResponseList.Responses[rubricNode.Value.Criteria.CriteriaID] = new Response();
                        rubricTreeNodes[0].Checked = true;
                        response.PointsReceived = rubricNode.Value.Criteria.MaxPoints;
                    }

                    if (rubricNode.Value.Children.Count > 0)
                    {
                        rubricTreeNodes[0].Checked = true;
                        rubricTreeNodes[0].Text = rubricNode.Value.Criteria.Description;
                    }
                    else
                    {
                        rubricTreeNodes[0].Text = string.Format("{0} ({1}): {2}",
                                            rubricNode.Value.Criteria.Description,
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

            rubricTreeView.ExpandAll();

            updateAdjustmentListBox();

            updatePoints();
        }

        private void updateAdjustmentListBox()
        {
            adjustmentsListBox.BeginUpdate();

            adjustmentsListBox.Items.Clear();

            foreach (Adjustment adjustment in currentResponseList.Adjustments)
            {
                adjustmentsListBox.Items.Add(adjustment);
            }

            adjustmentsListBox.EndUpdate();
        }

        private void rubricTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Node.Nodes.Count == 0)
            {
                int criteriaID;

                if (int.TryParse(e.Node.Name, out criteriaID))
                {
                    Response response;
                    if (currentResponseList.Responses.TryGetValue(criteriaID, out response))
                    {
                        RubricNode rubricNode;
                        if (currentAssignment.Rubric.Nodes.TryGetValue(criteriaID, out rubricNode))
                        {
                            Criteria criteria = rubricNode.Criteria;

                            GradingItemForm gif = new GradingItemForm(response, criteria, currentStudent);

                            gif.ShowDialog();

                            if (!gif.Cancelled)
                            {
                                // update response tree
                                response.PointsReceived = gif.GraderResponse.PointsReceived;
                                response.GraderComment = gif.GraderResponse.GraderComment;

                                // update treeview
                                e.Node.Text = string.Format("{0} ({1}): {2}",
                                                    criteria.Description.ToString(),
                                                    criteria.MaxPoints.ToString(),
                                                    response.PointsReceived.ToString());
                            }
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Could not convert treenode name (CriteriaID) to integer.");
                }
            }
        }

        public ResponseList GetResponseList()
        {
            foreach (KeyValuePair<int, Response> responsePair in currentResponseList.Responses)
            {
                int criteriaID = responsePair.Key;

                Response response = responsePair.Value;

                TreeNode[] rubricTreeNodes = rubricTreeView.Nodes.Find(criteriaID.ToString(), true);

                if (rubricTreeNodes.Length > 0)
                {
                    if (rubricTreeNodes[0].Checked == false)
                    { // if a criteria is unchecked, zero points
                        response.PointsReceived = 0;
                    }
                }
            }

            return currentResponseList;
        }

        private void updatePoints()
        {
            int pointsSubtotal = 0;

            int pointsAdjustment = 0;

            // TODO: adjustments

            foreach (KeyValuePair<int, Response> responsePair in currentResponseList.Responses)
            {
                TreeNode[] rubricTreeNodes = rubricTreeView.Nodes.Find(responsePair.Key.ToString(), true);
                if (rubricTreeNodes.Length > 0)
                {
                    if (rubricTreeNodes[0].Nodes.Count == 0)
                    { // If this is not a header
                        if(rubricTreeNodes[0].Checked){
                            // If they are receiving points for this criteria, give them points
                            pointsSubtotal += responsePair.Value.PointsReceived;
                        }
                    }
                }
            }

            foreach (Adjustment adjustment in currentResponseList.Adjustments)
            {
                pointsAdjustment += adjustment.PointAdjustment;
            }

            pointsSubtotalTextBox.Text = pointsSubtotal.ToString();
            pointsAdjustmentTextBox.Text = pointsAdjustment.ToString();
            pointsTotalTextBox.Text = (pointsSubtotal + pointsAdjustment).ToString();
        }

        private void rubricTreeView_Click(object sender, EventArgs e)
        {
            updatePoints();
        }

        private void rubricTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            { // Only un/check all children if the click came from the user
                Queue<TreeNode> toVisit = new Queue<TreeNode>();
                toVisit.Enqueue(e.Node);
                while (toVisit.Count > 0)
                {
                    TreeNode node = toVisit.Dequeue();

                    node.Checked = e.Node.Checked;

                    if (node.Nodes.Count == 0)
                    { // if this is a leaf, toggle the point values
                        int criteriaID;

                        if (int.TryParse(node.Name, out criteriaID))
                        {
                            Response response;
                            if (currentResponseList.Responses.TryGetValue(criteriaID, out response))
                            {
                                RubricNode rubricNode;
                                if (currentAssignment.Rubric.Nodes.TryGetValue(criteriaID, out rubricNode))
                                {
                                    Criteria criteria = rubricNode.Criteria;

                                    if (node.Checked)
                                    {
                                        response.PointsReceived = criteria.MaxPoints;
                                    }
                                    else
                                    {
                                        response.PointsReceived = 0;
                                    }

                                    // update treeview
                                    node.Text = string.Format("{0} ({1}): {2}",
                                                        criteria.Description.ToString(),
                                                        criteria.MaxPoints.ToString(),
                                                        response.PointsReceived.ToString());
                                }
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Could not convert treenode name (CriteriaID) to integer.");
                        }
                    }
                    foreach (TreeNode n in node.Nodes)
                    {
                        toVisit.Enqueue(n);
                    }
                }
            }
        }

        private void addAdjustmentButton_Click(object sender, EventArgs e)
        {
            AdjustmentForm af = new AdjustmentForm(new Adjustment());

            af.ShowDialog();

            if (!af.Cancelled)
            {
                currentResponseList.Adjustments.Add(af.GraderAdjustment);
                updateAdjustmentListBox();
            }

            updatePoints();
        }

        private void editAdjustmentButton_Click(object sender, EventArgs e)
        {
            if (adjustmentsListBox.SelectedIndex >= 0 && currentResponseList.Adjustments.Count > adjustmentsListBox.SelectedIndex)
            {
                // hopefully the indices of the listbox will always match those of the adjustment list
                AdjustmentForm af = new AdjustmentForm(currentResponseList.Adjustments.ElementAt(adjustmentsListBox.SelectedIndex));

                af.ShowDialog();

                if (!af.Cancelled)
                {
                    currentResponseList.Adjustments[adjustmentsListBox.SelectedIndex] = af.GraderAdjustment;
                    updateAdjustmentListBox();
                }

                updatePoints();
            }
        }

        private void deleteAdjustmentButton_Click(object sender, EventArgs e)
        {
            if (adjustmentsListBox.SelectedIndex >= 0 && currentResponseList.Adjustments.Count > adjustmentsListBox.SelectedIndex)
            {
                DialogResult result = MessageBox.Show("Delete this adjustment?", "Delete?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (currentResponseList.Adjustments[adjustmentsListBox.SelectedIndex].HasID())
                    {
                        DeletedAdjustments.AddLast(currentResponseList.Adjustments[adjustmentsListBox.SelectedIndex].AdjustmentID);
                    }
                    currentResponseList.Adjustments.RemoveAt(adjustmentsListBox.SelectedIndex);
                    updateAdjustmentListBox();
                }
            }

            updatePoints();
        }
    }

    /// <summary>
    /// The NoExpandTreeView is necessary because the double-click event interferes with events tied to checkbox actions.
    /// All we have to do is catch all these double clicks (Msg = 515) and not process them.
    /// </summary>
    public class NoExpandTreeView : TreeView
    {
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg != 515)
            {
                base.DefWndProc(ref m);
            }
        }
    }
}