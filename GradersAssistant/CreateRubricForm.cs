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

    public partial class CreateRubricForm : Form
    {
        public CreateRubricForm()
        {
            InitializeComponent();
        }

        public bool SaveCriteria = false;

        public TreeNodeCollection CriteriaTree;

        public bool NodeIsSelected = false;

        public CriteriaNode ROOTNODE;

        private void CreateRubricForm_Load(object sender, EventArgs e)
        {
            CriteriaDisplay.Nodes.Add(ROOTNODE);
            this.CriteriaDisplay.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.CriteriaDisplay.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.CriteriaDisplay.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
        }

        private void treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                CriteriaNode CN;
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (DestinationNode == null)
                {
                    TreeNode tempNode;
                    tempNode = (TreeNode)NewNode.Clone();
                    ROOTNODE.Nodes.Add(tempNode);
                    tempNode.Expand();
                    //Remove Original Node 
                    NewNode.Remove();

                }
                else if (DestinationNode.TreeView == NewNode.TreeView)
                {
                    DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                    DestinationNode.Expand();
                    //Remove Original Node
                    NewNode.Remove();
                }
            }
        }

        private void AddCriteriaButton_Click(object sender, EventArgs e)
        {
            if (CriteriaDisplay.SelectedNode != null && DescriptionTextbox.Text != String.Empty)
            {
                CriteriaNode newnode;
                int points;
                if (int.TryParse(this.PointsTextBox.Text, out points))
                {
                    newnode = new CriteriaNode(DescriptionTextbox.Text, points);
                }
                else
                {
                    newnode = new CriteriaNode(DescriptionTextbox.Text);
                }
                CriteriaDisplay.SelectedNode.Nodes.Add(newnode);
                if (newnode.Parent != null)
                {
                    ((CriteriaNode)newnode.Parent).UpdatePoints();
                    newnode.Parent.Expand();
                }
                else
                {
                    Debug.WriteLine("ERROR: Tried adding a root node to criteria tree.");
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (CriteriaDisplay.SelectedNode != null && CriteriaDisplay.SelectedNode != ROOTNODE)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected Criteria and all of its children?", "Remove Criteria", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CriteriaNode parent = (CriteriaNode)CriteriaDisplay.SelectedNode.Parent;
                    CriteriaDisplay.SelectedNode.Remove();
                    parent.Points = 0;
                    parent.UpdatePoints();
                }
            }
            else
            {
                MessageBox.Show("No Criteria Selected!");
            }
        }

        private void SaveCriteriaButton_Click(object sender, EventArgs e)
        {
            if (CriteriaDisplay.SelectedNode != null && CriteriaDisplay.SelectedNode != ROOTNODE)
            {
                ((CriteriaNode)CriteriaDisplay.SelectedNode).Description = DescriptionTextbox.Text;
                if (CriteriaDisplay.SelectedNode.Nodes.Count == 0)
                {
                    int points;
                    if (int.TryParse(this.PointsTextBox.Text, out points))
                    {
                        ((CriteriaNode)CriteriaDisplay.SelectedNode).Points = points;
                    }
                }
                CriteriaDisplay.SelectedNode.Text = CriteriaDisplay.SelectedNode.ToString();
            }
        }

        private void ExpandCollapseAllButton_Click(object sender, EventArgs e)
        {
            if (ExpandCollapseAllButton.Text == "Expand All")
            {
                CriteriaDisplay.ExpandAll();
                ExpandCollapseAllButton.Text = "Collapse All";
            }
            else if (ExpandCollapseAllButton.Text == "Collapse All")
            {
                CriteriaDisplay.CollapseAll();
                ExpandCollapseAllButton.Text = "Expand All";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CriteriaTree = ROOTNODE.Nodes;
            SaveCriteria = true;
            this.Close();
        }

        private void AwesomeCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit Rubric Creation?", "Alert!", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                SaveCriteria = false;
                this.Close();
            }
        }

        private void CriteriaDisplay_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DescriptionTextbox.Text = ((CriteriaNode)CriteriaDisplay.SelectedNode).Description;
            if (CriteriaDisplay.SelectedNode.Nodes.Count == 0)
            {
                PointsTextBox.Text = ((CriteriaNode)CriteriaDisplay.SelectedNode).Points.ToString();
            }
            else
            {
                PointsTextBox.Text = "0";
            }
        }

        //private void CriteriaDisplay_MouseClick(object sender, MouseEventArgs e)
        //{
        //    CriteriaNode CN = (CriteriaNode)CriteriaDisplay.GetNodeAt(e.X,e.Y);
        //    if (CN != null)
        //    {
        //        DescriptionTextbox.Text = CN.Description;
        //    }
        //}

    }

    // might not (probably not) need every aspect of such node..
    public class CriteriaNode : System.Windows.Forms.TreeNode
    {
        public CriteriaNode()
        {
            points = 0;
            description = string.Empty;
            this.Text = this.ToString();
        }

        public CriteriaNode(string cnDescription)
        {
            points = 0;
            description = cnDescription;
            this.Text = this.ToString();
        }

        public CriteriaNode(string cnDescription, int cnPoints)
        {
            points = cnPoints;
            description = cnDescription;
            this.Text = this.ToString();
        }

        public void UpdatePoints(){
            // only need to update if we have children
            if (Nodes.Count > 0)
            {
                points = 0;
                foreach (CriteriaNode cn in Nodes)
                {
                    points += cn.Points;
                }
            }
            this.Text = this.ToString();
            if (this.Parent != null)
            {
                ((CriteriaNode)this.Parent).UpdatePoints();
            }
        }

        int points;

        public int Points
        {
            get
            { return points; }
            set
            {
                // you can only directly update leaf nodes point values
                if (Nodes.Count == 0)
                {
                    points = value;
                    if (Parent != null)
                    {
                        ((CriteriaNode)Parent).UpdatePoints();
                    }
                }
                this.Text = this.ToString();
            }
        }

        string description;

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public override string ToString()
        {
            if (this.Nodes.Count > 0)
            {
                return string.Format("{0} ({1} Pts Total):", description, points);
            }
            else
            {
                // if we're a leaf
                return string.Format("{0} ({1} Pts)", description, points);
            }
        }
    }
}


/// http://support.microsoft.com/kb/307968