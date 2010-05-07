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
        public int status;
     
        public EditStudentForm()
        {
            InitializeComponent();
            if (Text == "Add New Student")
            {
                buttonUpdate.Text = "Add";
            }
            status = -1;
            PublicStudent = new Student();
        }

        private bool validateNewStudent()
        {
            Int32 blank;
            if (!Int32.TryParse(comboBoxSection.SelectedItem.ToString(), out blank))
            {
                if (textFirstName.Text.Trim() == "" | textLastName.Text.Trim() == "" | textUsername.Text.Trim() == "" | textEmailAddress.Text.Trim() == "" | comboBoxSection.SelectedValue == null | textSchoolGivenID.Text.Trim() == "")
                {
                    WarningFormWithContinue incompleteWarning = new WarningFormWithContinue();
                    incompleteWarning.ShowDialog();
                    return incompleteWarning.Proceed;
                }
                else
                    return true;
            }
            else
            {
                MessageBox.Show("The Section selected is not valid.");
                return false;
            }
        }

        public void populateForm()
        {
            if (status == 1)
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
                if( comboBoxSection.SelectedItem != null)
                {
                    PublicStudent.ClassSection = Int32.Parse(comboBoxSection.SelectedItem.ToString());
                }
                if (textSchoolGivenID.Text.Trim() != "")
                {
                    PublicStudent.StudentSchoolID = textSchoolGivenID.Text.Trim();
                }

                status = 1;
                Close();
            }
        }

        private void closeWithoutUpdate(object sender, EventArgs e)
        {
            status = 0;
            Close();
        }
        
    }

}
