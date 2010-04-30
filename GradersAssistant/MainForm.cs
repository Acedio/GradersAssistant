using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GradersAssistant
{
    public partial class MainForm : Form
    {
        private GADatabase dbConnention;
        private GAClass mainClass;
        public MainForm()
        {
            InitializeComponent();
            dbConnention = new GADatabase();
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
                    Student s = new Student("Tyranos", "Aurus", "taurus11", "taurus11@my.whitworth.edu", 1, "3567890");
                    s.StudentID = gad.AddStudent(s);
                    students.Add(s.StudentID, s);
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

        void emailToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GradeEmailForm gef = new GradeEmailForm();
            gef.Show();
        }

        private void createCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ValidateNames = true;
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != string.Empty)
            {
                // TODO create and actually save the .csv file
            }
        }

        private void CreateNewClass(object sender, EventArgs e)
        {
            //open 
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.Filter = "graders assistant db files (*.gadb)|*.gadb";
            saveFile.OverwritePrompt = true;
            saveFile.Title = "Create New Class File";
            saveFile.ValidateNames = true;
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
            {

                if ( !File.Exists("..\\..\\classDB.gat"))
                {
                    //if the template file does not exiist output an error message
                    MessageBox.Show("SYSTEM ERROR: \n This instilation of Graders Assistant appears to be corrupt.  Please restart the program and try again. If the problem continues please reinstall the program and try again.");
                }
                else
                {
                    //create access database
                    File.Copy("..\\..\\classDB.gat", saveFile.FileName);

                    //open a connection to the Database
                    if (!dbConnention.ConnectDB(saveFile.FileName))
                    {
                        MessageBox.Show("Connection Error:\n Database Connection failed!");  
                    }

                    //open edit class form in add mode
                    EditClassForm addClass = new EditClassForm();
                    addClass.ShowDialog();

                    //if the values on the form have been updated then commit the changes to the database
                    if (addClass.FormStatus == 1)
                    {
                        //check to make sure a connection exisists
                        if (dbConnention.IsConnected())
                        {
                            //insert
                            dbConnention.AddClass(addClass.PublicClass);
                            mainClass = addClass.PublicClass;
                        }
                        else
                        {
                            MessageBox.Show("No connection exists, unable to save class data.");
                        }
                    }
                }
            }
        }

        private void EditClass(object sender, EventArgs e)
        {
            //TODO where does the class to be editied come from


            EditClassForm editClass = new EditClassForm();
            editClass.PublicClass = mainClass;
            editClass.populateClassForm();
            editClass.ShowDialog();

            //if the values on the form have been updated then commit the changes to the database
            if (editClass.FormStatus == 1)
            {
                //check to make sure a connection exisists
                if (dbConnention.IsConnected())
                {
                    //update the class table in the database
                    dbConnention.UpdateClass(editClass.PublicClass);
                    mainClass = editClass.PublicClass;
                }
                else
                {
                    MessageBox.Show("No connection exists, unable to save class data.");
                }
            }
        }

        private void OpenClass(object sender, EventArgs e)
        {
            OpenFileDialog openClass = new OpenFileDialog();
            openClass.Filter = "graders assistant db files (*.gadb)|*.gadb";
            openClass.Title = "Open Class File";
            openClass.Multiselect = false;
            openClass.AddExtension = true;
            openClass.ValidateNames = true;
            openClass.ShowDialog();

            if (openClass.FileName != "")
            {
                dbConnention.ConnectDB(openClass.FileName);
                mainClass = dbConnention.GetClass();
            }
        }
        
        private void EditStudent(object sender, EventArgs e)
        {
            EditStudentForm editStudent = new EditStudentForm();
            editStudent.ShowDialog();
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            EditStudentForm addStudent = new EditStudentForm();
            addStudent.Text = "Add New Student";
            addStudent.ShowDialog();
        }

        private void deleteStudent(object sender, EventArgs e)
        {

        }

    }
}
