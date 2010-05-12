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

        private int currentAssignmentID;

        private Dictionary<int, Student> students;

        private GradingAssignmentForm gaf;

        public MainForm()
        {
            InitializeComponent();
            dbConnention = new GADatabase();
            noClassOpenDisableMenu();
        }
        
        private void noClassOpenDisableMenu()
        {
            createNewAssignmentRubricMenuItem.Enabled = false;
            openAssignmentMenuItem.Enabled = false;
            saveMenuItem.Enabled = false;
            saveAsMenuItem.Enabled = false;
            prefrencesToolStripMenuItem.Enabled = false;
            studentMenuItem.Enabled = false;
            resultstoolStripMenuItem.Enabled = false;
            toolsToolStripMenuItem.Enabled = false;
        }

        private void classOpenEnableMenu()
        {
            createNewAssignmentRubricMenuItem.Enabled = true;
            openAssignmentMenuItem.Enabled = true;
            saveMenuItem.Enabled = true;
            saveAsMenuItem.Enabled = true;
            prefrencesToolStripMenuItem.Enabled = true;
            studentMenuItem.Enabled = true;
            resultstoolStripMenuItem.Enabled = true;
            toolsToolStripMenuItem.Enabled = true;
        }

        protected void NewRubricCreator(object sender, EventArgs e)
        {
            CreateRubricForm newRubric = new CreateRubricForm();
            // Set the Parent Form of the Child window.
           // newMDIChild.MdiParent = this;
            // Display the new form.
            newRubric.Show();

        }

        private void updateStudentComboBox()
        {
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
        }

        private void loadStudents(GADatabase gad)
        {
            students = gad.GetStudents();
            updateStudentComboBox();
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

        //creates a new class
        //TODO still needs to acount for functionality to re populate the new main form once hte class is created
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
                        if (dbConnention.ConnectDB(saveFile.FileName))
                        {
                            //insert
                            dbConnention.AddClass(addClass.PublicClass);
                            mainClass = addClass.PublicClass;
                            classOpenEnableMenu();
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

        //edits the deatails of the current class
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

        private void loadGradingForm(int assignmentID)
        {
            gaf = new GradingAssignmentForm();
            gaf.MdiParent = this;
            int height = gaf.ClientSize.Height + this.Height - this.ClientSize.Height + mainMenuStrip.Height + upperToolStrip.Height + lowerToolStrip.Height + mainStatusStrip.Height;
            int width = gaf.ClientSize.Width + this.Width - this.ClientSize.Width;
            this.Size = new Size(width, height);
            gaf.Show();
            gaf.WindowState = FormWindowState.Maximized;
            if (students.Count > 0)
            {
                Assignment assignment = dbConnention.GetAssignment(1);
                gaf.LoadAssignment(assignment);
                ResponseList studentResponse = dbConnention.GetResponseList(1, 10);
                gaf.LoadResponseList(students[studentResponse.StudentID], studentResponse);
            }
        }

        //open Class, this opens an exisiting class 
        //accessed through open folder icon/open class in the file menu
        private void OpenClass(object sender, EventArgs e)
        {
            //get the class to open
            OpenFileDialog openClass = new OpenFileDialog();
            openClass.Filter = "Graders Assistant DB Files (*.gadb)|*.gadb";
            openClass.Title = "Open Class File";
            openClass.Multiselect = false;
            openClass.AddExtension = true;
            openClass.ValidateNames = true;
            openClass.ShowDialog();

            //if a class was opened generate the database connection
            if (openClass.FileName != "")
            {
                dbConnention.ConnectDB(openClass.FileName);
                mainClass = dbConnention.GetClass();

                loadStudents(dbConnention);

                currentAssignmentID = 1;
                loadGradingForm(currentAssignmentID);

                classOpenEnableMenu();
            }
        }
        
        private void EditStudent(object sender, EventArgs e)
        {
            EditStudentForm editStudent = new EditStudentForm();
            editStudent.status = 1;
            editStudent.populateForm();
            //TODO load the right student into the public student of the form
            //editStudent.PublicStudent. = studentComboBox.SelectedItem
            editStudent.ShowDialog();

            //if the dialog is closed with a status of 1 the student needs to be updated
            if (editStudent.status == 1)
            {
                //check to make sure a connection exisists
                if (dbConnention.IsConnected())
                {
                    //update the class table in the database
                    dbConnention.UpdateStudent(editStudent.PublicStudent);
                    dbConnention.GetStudents();
                }
                else
                {
                    MessageBox.Show("No connection exists, unable to save student data.");
                }
            }
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            EditStudentForm addStudent = new EditStudentForm();
            addStudent.Text = "Add New Student";
            addStudent.status = 0;
            addStudent.ShowDialog();
            //if the dialog is closed with a status of 1 the student needs to be added
            if (addStudent.status == 1)
            {
                if (dbConnention.IsConnected())
                {
                    //update the class table in the database
                    dbConnention.AddStudent(addStudent.PublicStudent);
                    dbConnention.GetStudents();
                }
                else
                {
                    MessageBox.Show("No connection exists, unable to save student data.");
                }
            }
        }

        private void deleteStudent(object sender, EventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (gaf != null)
            {
                gaf.Close();
                gaf.Dispose();
            }
            this.Close();
            this.Dispose();
        }

        private void studentComboBox_DropDownClosed(object sender, EventArgs e)
        {
            //if (studentComboBox.SelectedItem != null)
            //{
            //    Student student = (Student)studentComboBox.SelectedItem;

            //    gaf.LoadResponseList(student, dbConnention.GetResponseList(currentAssignmentID, student.StudentID));
            //}
        }

        private void studentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gaf != null && studentComboBox.SelectedItem != null)
            {
                Student student = (Student)studentComboBox.SelectedItem;

                gaf.LoadResponseList(student, dbConnention.GetResponseList(currentAssignmentID, student.StudentID));
            }
        }
    }
}
