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
    public partial class EditStudentForm : Form
    {
        public Student PublicStudent;
        public int FormStatus;
        public int NumOfSections;

        public EditStudentForm()
        {
            InitializeComponent();
            NumOfSections = 1;
            this.CancelButton = buttonCancel;
            this.AcceptButton = buttonUpdate;
            PublicStudent = new Student();
        }

        private bool validateNewStudent()
        {
                if (comboBoxSection.SelectedItem == null | textFirstName.Text.Trim() == "" | textLastName.Text.Trim() == "" | textUsername.Text.Trim() == "" | textEmailAddress.Text.Trim() == "" | textSchoolGivenID.Text.Trim() == "")
                {
                    WarningFormWithContinue incompleteWarning = new WarningFormWithContinue();
                    incompleteWarning.ShowDialog();
                    return incompleteWarning.Proceed;
                }
                else
                    return true;
        }

        public void populateForm()
        {
            //populate the values if you are updateing a student
            if (FormStatus == 1)
            {
                textFirstName.Text = PublicStudent.FirstName;

                textLastName.Text = PublicStudent.LastName;

                textUsername.Text = PublicStudent.Username;

                textEmailAddress.Text = PublicStudent.EmailAddress;

                comboBoxSection.SelectedItem = PublicStudent.ClassSection;

                textSchoolGivenID.Text = PublicStudent.StudentSchoolID;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (validateNewStudent())
            {
                if (textFirstName.Text.Trim() != "")
                {
                    PublicStudent.FirstName = textFirstName.Text.Trim();
                }
                if (textLastName.Text.Trim() != "")
                {
                    PublicStudent.LastName = textLastName.Text.Trim();
                }
                if (textUsername.Text.Trim() != "")
                {
                    PublicStudent.Username = textUsername.Text.Trim();
                }
                if (textEmailAddress.Text.Trim() != "")
                {
                    PublicStudent.EmailAddress = textEmailAddress.Text.Trim();
                }
                if (comboBoxSection.SelectedItem != null)
                {
                    Int32 classSection;
                    if (Int32.TryParse(comboBoxSection.SelectedItem.ToString(), out classSection))
                    {
                        // PublicStudent.ClassSection = Int32.Parse(comboBoxSection.SelectedItem.ToString());
                    }
                }
                if (textSchoolGivenID.Text.Trim() != "")
                {
                    PublicStudent.StudentSchoolID = textSchoolGivenID.Text.Trim();
                }

                FormStatus = 1;
                Close();
            }
        }

        private void closeWithoutUpdate(object sender, EventArgs e)
        {
            FormStatus = 0;
            Close();
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {

            //give the Section DropDownList an appropriate number of sections based on class data
            for (int sectionCount = 1; sectionCount <= NumOfSections; sectionCount++)
            {
                comboBoxSection.Items.Add(sectionCount);
            }

            if (FormStatus == 0)
            {
                Text = "Add New Student";
                buttonUpdate.Text = "Add";
            }
            FormStatus = -1;
        }

    }

}
