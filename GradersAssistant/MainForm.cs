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

        private void loadStudents(GADatabase gad)
        {
            Dictionary<int, Student> students = gad.GetStudents();
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
            CriteriaResponseTree crt = gad.MakeCriteriaResponseTree(1);
            gad.FillCriteriaResponseTree(crt, 0, 0);
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
            saveFile.Filter = "GradersAssistant DB Files (*.gadb)|*.gadb";
            saveFile.OverwritePrompt = true;
            saveFile.Title = "Create New Class File";
            saveFile.ValidateNames = true;
            saveFile.ShowDialog();

            if (saveFile.FileName != string.Empty)
            {
                try
                {
                    Stream template = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GradersAssistant.template.gat");
                    FileStream fileOut = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write);

                    // Now that we have the stream, we have to save it.

                    int len = 256;
                    Byte[] buffer = new Byte[len];
                    int bytesRead = template.Read(buffer, 0, len);
                    while (bytesRead > 0)
                    {
                        fileOut.Write(buffer, 0, bytesRead);
                        bytesRead = template.Read(buffer, 0, len);
                    }
                    template.Close();
                    fileOut.Close();

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
                catch (Exception ex)
                {
                    //if the template file does not exiist output an error message
                    MessageBox.Show("SYSTEM ERROR!!!!:\n This instilation of Graders Assistant\n appears to be corrupt.  Please\n restart the program and try again.\n If the problem continues please reinstall \n the program and try again.");
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

        private void openClass(object sender, EventArgs e)
        {
            OpenFileDialog openClass = new OpenFileDialog();
            openClass.Filter = "Graders Assistant DB Files (*.gadb)|*.gadb";
            openClass.Title = "Open Class File";
            openClass.Multiselect = false;
            openClass.AddExtension = true;
            openClass.ValidateNames = true;
            openClass.ShowDialog();

            if (openClass.FileName != "")
            {
                dbConnention.ConnectDB(openClass.FileName);
                mainClass = dbConnention.GetClass();
                loadStudents(dbConnention);
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
