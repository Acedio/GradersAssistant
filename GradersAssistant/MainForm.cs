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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected void NewRubricCreator(object sender, EventArgs e)
        {
            CreateRubricForm newRubric = new CreateRubricForm();
            // Set the Parent Form of the Child window.
           // newMDIChild.MdiParent = this;
            // Display the new form.
            newRubric.Show();

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.ValidateNames = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != string.Empty)
            {
                GADatabase gad = new GADatabase();
                if (!gad.ConnectDB(openFileDialog.FileName))
                {
                    MessageBox.Show("Could not connect to DB.");
                }
                else
                {
                    Dictionary<int,Student> students = gad.GetStudents();
                    studentComboBox.BeginUpdate();
                    studentComboBox.Items.Clear();
                    foreach (Student student in students.Values)
                    {
                        studentComboBox.Items.Add(student);
                    }
                    if (studentComboBox.Items.Count > 0)
                    {
                        studentComboBox.SelectedItem = studentComboBox.Items[0];
                    }
                    studentComboBox.EndUpdate();
                    gad.SaveStudents(students);
                }
                gad.CloseDB();
            }
        }
    }
}
