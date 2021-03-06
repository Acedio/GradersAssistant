﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradersAssistant
{
    public partial class CreateAssignmentForm : Form
    {
        public CreateAssignmentForm()
        {
            InitializeComponent();
        }

        public TreeNodeCollection CriteriaTree;
        public Assignment assignment = new Assignment();
        public bool IsClosed = false;
        private string D_date;
        private string A_name;

        public string d_date
        {
            get { return D_date; }
            set { D_date = value; }
        }

        public string a_name
        {
            get { return A_name; }
            set { A_name = value; }
        }

        private void CreateAssignmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
        }

        private void acceptbtn_Click(object sender, EventArgs e)
        {
            a_name = this.a_name_textbox.Text;
            d_date = String.Format("{0:G}", d_date_box.Value);
            assignment.Name = a_name;
            assignment.DueDate = DateTime.Parse(d_date);

            CreateRubricForm newRubric = new CreateRubricForm();
            newRubric.ROOTNODE = new CriteriaNode(a_name);
            this.Hide();
            newRubric.ShowDialog();


            if (newRubric.SaveCriteria == true)
            {
                CriteriaTree = newRubric.CriteriaTree;
            }

            this.Close();
        }
    }
}
