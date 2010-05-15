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

    public partial class CreateRubricForm : Form
    {
        public CreateRubricForm()
        {
            InitializeComponent();
        }

        public bool SaveCriteria = false;
        public LinkedList<CriteriaNode> CriteriaTree = new LinkedList<CriteriaNode>();

        public int TotalNodes = 0;

        public bool NodeIsSelected = false;

        public TreeNode ROOTNODE = new TreeNode();

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
            // parent node
            if (PointsTextBox.TextLength == 0)
            {
                CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                newnode.Description = this.DescriptionTextbox.Text;
                newnode.Text = newnode.Description;
                newnode.Points = 0;
                ROOTNODE.Nodes.Add(newnode);   // adds to the root node
                TotalNodes++;
                CriteriaDisplay.ExpandAll();
            }
            else
            {
                // root node
                if (CriteriaDisplay.SelectedNode == ROOTNODE)
                {
                    CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                    newnode.Description = this.DescriptionTextbox.Text;
                    newnode.Points = Convert.ToInt32(this.PointsTextBox.Text);
                    newnode.Text = newnode.Description + "(" + newnode.Points + "pts.)";
                    ROOTNODE.Nodes.Add(newnode);
                    CriteriaTree.AddLast(newnode);
                    TotalNodes++;
                    CriteriaDisplay.ExpandAll();
                }
                // child node
                else
                {
                    CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                    newnode.Description = this.DescriptionTextbox.Text;
                    newnode.Points = Convert.ToInt32(this.PointsTextBox.Text);
                    newnode.Text = newnode.Description + "(" + newnode.Points + "pts.)";
                    CriteriaDisplay.SelectedNode.Nodes.Add(newnode);
                    CriteriaDisplay.SelectedNode.ExpandAll();
                    TotalNodes++;
                    CriteriaDisplay.ExpandAll();
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete the selected Criteria and all of its children?", "Remove Criteria", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (CriteriaDisplay.Nodes.Count != 0 && CriteriaDisplay.SelectedNode != null)
            {
                CriteriaDisplay.SelectedNode.Remove();
            }
            else
                MessageBox.Show("No Criteria Selected", "", System.Windows.Forms.MessageBoxButtons.OK);
        }

        private void SaveCriteriaButton_Click(object sender, EventArgs e)
        {
            CriteriaDisplay.SelectedNode.Text = DescriptionTextbox.Text;
            if (CriteriaDisplay.SelectedNode.GetNodeCount(true) == 0)
                CriteriaDisplay.SelectedNode.Text += "(" + PointsTextBox.Text + "pts.)";
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
            SaveCriteria = true;
            this.Close();
        }

        private void AwesomeCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit Rubric Creation?", "Alert!", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            { this.Close(); }
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
        int nodeindex;

        public int NodeIndex
        {
            get { return nodeindex; }
            set { nodeindex = value; }
        }

        TreeNode node;

        public TreeNode Node
        {
            get { return node; }
            set { node = value; }
        }

        int parentid;

        public int ParentID
        {
            get { return parentid; }
            set { parentid = value; }
        }

        int criteriaid;

        public int CriteriaID
        {
            get { return criteriaid; }
            set { criteriaid = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
        }

        public CriteriaNode(string s)
        {
            this.name = s;
        }

        int points;

        public int Points
        {
            get
            { return points; }
            set
            {
                if (NumberOfChildren > 0)
                {
                    points = 0;
                    foreach (CriteriaNode c in ChildList)
                        points += c.Points;
                }
                else
                    points = value;
            }
        }

        string description;

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        LinkedList<CriteriaNode> childlist = new LinkedList<CriteriaNode>();

        public LinkedList<CriteriaNode> ChildList
        {
            get { return childlist; }
            set { childlist = value; }
        }

        public int NumberOfChildren
        {
            get
            {
                if (childlist == null)
                    return 0;
                else
                    return ChildList.Count;
            }
        }

    }
}


/// http://support.microsoft.com/kb/307968