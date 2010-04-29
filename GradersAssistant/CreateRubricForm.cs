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

        LinkedList<CriteriaNode> Tree = new LinkedList<CriteriaNode>();

        public int TotalRoots = 0;

        private void CreateRubricForm_Load(object sender, EventArgs e)
        {
            

            //TreeNode ParentNode1;
            //TreeNode ParentNode2;

            //ParentNode1 = CriteriaDisplay.Nodes.Add("Parent Node 1");
            //ParentNode1.Nodes.Add("Child Node 1.1");
            //ParentNode1.Nodes.Add("Child Node 1.2");
            //ParentNode1.Nodes.Add("Child Node 1.3");
            //ParentNode1.Nodes.Add("Child Node 1.4");
            //ParentNode1.Expand();

            //ParentNode2 = CriteriaDisplay.Nodes.Add("Parent Node 2");
            //ParentNode2.Nodes.Add("Child Node 2.1");
            //ParentNode2.Nodes.Add("Child Node 2.2");
            //ParentNode2.Expand();

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
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (DestinationNode == null)
                {
                    TreeNode tempNode;
                    tempNode = (TreeNode)NewNode.Clone();
                    CriteriaDisplay.Nodes.Add(tempNode);
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

        private void CriteriaDisplay_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DescriptionTextbox.Text = e.Node.Text;
            if (e.Node.Nodes.Count == 0)
            {
                // get and put the point value into the points textbox
            }
        }

        private void AddCriteriaButton_Click(object sender, EventArgs e)
        {
            if (PointsTextBox.TextLength == 0)
            {
                // when connected, save criteria and pointvalue
                //CriteriaDisplay.Nodes.Add(DescriptionTextbox.Text);
                CriteriaNode newnode = new CriteriaNode("Node " + TotalRoots.ToString());
                newnode.ParentName = "Tree";
                newnode.Description = this.DescriptionTextbox.Text;
                CriteriaDisplay.Nodes.Add(new TreeNode(newnode.Description));
                Tree.AddLast(newnode);
                TotalRoots++;
            }
            else
            {
                if (CriteriaDisplay.SelectedNode.IsSelected == false)
                {
                    CriteriaDisplay.Nodes.Add(DescriptionTextbox.Text);
                }
                else
                {
                    CriteriaDisplay.SelectedNode.Nodes.Add(DescriptionTextbox.Text + "(" + PointsTextBox.Text + "pts.)");
                    CriteriaDisplay.SelectedNode.ExpandAll();
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            CriteriaDisplay.SelectedNode.Remove();
        }

        private void SaveCriteriaButton_Click(object sender, EventArgs e)
        {
            CriteriaDisplay.SelectedNode.Text = DescriptionTextbox.Text;
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
            // FIND OUT FROM JOSH WHAT IS SUPPOSE TO HAPPEN HERE!!
        }
    }

    public class CriteriaNode : System.Object
    {
        string parentname;

        public string ParentName
        {
            get { return parentname; }
            set { parentname = value; }
        }

        string Name;

        public CriteriaNode(string name)
        {
            this.Name = name;
        }

        int points;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        string description;

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        LinkedList<CriteriaNode> childlist;

        public LinkedList<CriteriaNode> ChildList
        {
            get { return childlist; }
            set { childlist = value; }
        }

        public int NumberOfChildren
        {
            get { return this.childlist.Count; }
        }

    }
}


/// http://support.microsoft.com/kb/307968