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

        private bool SaveCriteria = false;

        LinkedList<CriteriaNode> CriteriaTree = new LinkedList<CriteriaNode>();

        public int TotalNodes = 0;

        public bool NodeIsSelected = false;

        private void CreateRubricForm_Load(object sender, EventArgs e)
        {

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

            for (int i = 0; i < CriteriaDisplay.Nodes.Count; i++)
            {
                if (CriteriaTree.ElementAt(i).Name == e.Node.Name)
                {
                    this.DescriptionTextbox.Text = CriteriaTree.ElementAt(i).Description;
                    if (CriteriaTree.ElementAt(i).NumberOfChildren == 0)
                    {
                        this.PointsTextBox.Text = CriteriaTree.ElementAt(i).Points.ToString();
                    }
                }
            }
            CriteriaDisplay.HideSelection = false;
        }

        private void AddCriteriaButton_Click(object sender, EventArgs e)
        {
            // parent node
            if (PointsTextBox.TextLength == 0)
            {
                TreeNode tnode = new TreeNode();
                CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                newnode.ParentNode = null;
                newnode.Description = this.DescriptionTextbox.Text;
                tnode.Name = newnode.Name;
                tnode.Text = newnode.Description;
                newnode.Points = 0;
                CriteriaDisplay.Nodes.Add(tnode);
                CriteriaTree.AddLast(newnode);
                TotalNodes++;
                newnode.Node = tnode;
                NodeIsSelected = false;
            }
            else
            {
                // root node
                if (CriteriaDisplay.SelectedNode == null)
                {
                    TreeNode tnode = new TreeNode();
                    CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                    newnode.ParentNode = null;
                    tnode.Name = newnode.Name;
                    newnode.Description = this.DescriptionTextbox.Text;
                    newnode.Points = Convert.ToInt32(this.PointsTextBox.Text);
                    tnode.Text = newnode.Description + "(" + newnode.Points + "pts.)";
                    CriteriaDisplay.Nodes.Add(tnode);
                    CriteriaTree.AddLast(newnode);
                    TotalNodes++;
                    newnode.Node = tnode;
                    NodeIsSelected = false;
                }
                // child node
                else
                {
                    TreeNode tnode = new TreeNode();
                    CriteriaNode newnode = new CriteriaNode("Node " + TotalNodes.ToString());
                    newnode.ParentNode = CriteriaDisplay.SelectedNode;
                    tnode.Name = newnode.Name;
                    newnode.Description = this.DescriptionTextbox.Text;
                    newnode.Points = Convert.ToInt32(this.PointsTextBox.Text);
                    tnode.Text = newnode.Description + "(" + newnode.Points + "pts.)";
                    CriteriaDisplay.SelectedNode.ExpandAll();
                    CriteriaDisplay.SelectedNode.Nodes.Add(tnode);
                    CriteriaDisplay.SelectedNode.ExpandAll();
                    TotalNodes++;
                    newnode.Node = tnode;

                    // this for loop puts the newly created child node at the end of its parent node's list of children
                    for (int i = 0; i < CriteriaTree.Count; i++)
                    {
                        if (CriteriaTree.ElementAt(i).Node == newnode.ParentNode)
                        {
                            CriteriaTree.ElementAt(i).ChildList.AddLast(newnode);
                        }
                        
                    }

                    //for (int j = 0; j < CriteriaDisplay.Nodes.Count; j++)
                    //{

                    //}
                }
               // UpdateCriteriaDisplay();
            }
        }

        //public void UpdateCriteriaDisplay()
        //{
        //    CriteriaDisplay.BeginUpdate();
        //    {
        //        TreeNode temp = CriteriaDisplay.SelectedNode;
        //        CriteriaDisplay.Nodes.Clear();
        //        foreach (CriteriaNode c in CriteriaTree)
        //        {
        //            TreeNode temp2 = new TreeNode(c.Name);
        //            temp2.Text = c.Description + "(" + c.Points + "pts.)";
        //            CriteriaDisplay.Nodes.Add(temp2);

        //            foreach (CriteriaNode cn in c.ChildList)
        //            {
        //                GetChildrensChildren(cn, temp2);
        //            }
        //        }
        //        CriteriaDisplay.SelectedNode = temp;
        //    }
        //    CriteriaDisplay.EndUpdate();
        //}

        //// recursion...
        //public void GetChildrensChildren(CriteriaNode C, TreeNode T)
        //{
        //    TreeNode temp = new TreeNode(C.Name);
        //    temp.Text = C.Description + "(" + C.Points + "pts)";
        //    T.Nodes.Add(temp);

        //    if (C.NumberOfChildren > 0)
        //    {
        //        foreach (CriteriaNode c in C.ChildList)
        //            GetChildrensChildren(c, temp);
        //    }
        //}

        //public void AddChildrensChildren(CriteriaNode C)
        //{
        //    foreach (CriteriaNode c in C.ChildList)
        //    {
        //        if (c.ParentNode == C.Node)
        //        {
        //            C.ChildList.AddLast(c);
        //            return;
        //        }
        //    }
        //    AddChildrensChildren(c);
        //}

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete the selected Criteria and all of its children?", "Remove Criteria", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (CriteriaDisplay.Nodes.Count != 0 && CriteriaDisplay.SelectedNode != null)
            {
                for (int i = 0; i < CriteriaTree.Count; i++)
                {
                    if (CriteriaTree.ElementAt(i).Node == CriteriaDisplay.SelectedNode)
                    {
                        CriteriaTree.Remove(CriteriaTree.ElementAt(i));
                    }
                }
                CriteriaDisplay.SelectedNode.Remove();
            }
            else
                MessageBox.Show("No Criteria Selected", "", System.Windows.Forms.MessageBoxButtons.OK);
        }

        private void SaveCriteriaButton_Click(object sender, EventArgs e)
        {
            CriteriaDisplay.SelectedNode.Text = DescriptionTextbox.Text;
            for (int i = 0; i < CriteriaTree.Count; i++)
            {
                if (CriteriaTree.ElementAt(i).Node == CriteriaDisplay.SelectedNode)
                {
                    CriteriaTree.ElementAt(i).Description = DescriptionTextbox.Text;
                    CriteriaTree.ElementAt(i).Points = Convert.ToInt32(PointsTextBox.Text);
                }
            }
            CriteriaDisplay.SelectedNode.Text += "("+PointsTextBox.Text+"pts.)";
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
        }

        private void deselectbtn_Click(object sender, EventArgs e)
        {
            CriteriaDisplay.SelectedNode = null;
        }

    }

    // might not (probably not) need every aspect of such node..
    public class CriteriaNode : System.Object
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

        TreeNode parentnode;

        public TreeNode ParentNode
        {
            get { return parentnode; }
            set { parentnode = value; }
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
            { return points;  }
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