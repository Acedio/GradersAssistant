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

        private void menuItemCreateNewClass_Click(object sender, EventArgs e)
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

                if ( !File.Exists("classDB.gat"))
                {
                    //if the template file does not exiist output an error message
                    WarningForm wfSystemError = new WarningForm();
                    wfSystemError.Text = "SYSTEM ERROR!!!!";
                    wfSystemError.strWarningMessage = "This instilation of Graders Assistant\n appears to be corrupt.  Please\n restart the program and try again.\n If the problem continues please reinstall \n the program and try again.";
                    wfSystemError.ShowDialog();
                }
                else
                {
                    //create access database
                    File.Copy("classDB.gat", saveFile.FileName);

                    //open edit class form in add mode
                    EditClassForm EditClass = new EditClassForm();
                    EditClass.ShowDialog();

                    //if the values on the form have been updated then commit the changes to the database
                    if (EditClass.intFormStatus == 1)
                    {


                    }
                }
            }
        }

        private void menuItemEditClass_Click(object sender, EventArgs e)
        {
            EditClassForm addClass = new EditClassForm();
            addClass.ShowDialog();
        }

        private void menuItemEditStudent_Click(object sender, EventArgs e)
        {
            EditStudentForm editStudent = new EditStudentForm();
            editStudent.ShowDialog();
        }

        private void menuItemAddNewStudent_Click(object sender, EventArgs e)
        {
            EditStudentForm addStudent = new EditStudentForm();
            addStudent.ShowDialog();
        }
    }
}
