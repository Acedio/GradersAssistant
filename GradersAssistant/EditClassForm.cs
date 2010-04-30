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
    public partial class EditClassForm : Form
    {
        //holds the values input from text boxes
        public GAClass gacPublicClass;
        //holds the status that the form exited with
        public int intFormStatus;

        public EditClassForm()
        {
            InitializeComponent();
        }

        private void populateClassForm()
        {
            textClassName.Text = gacPublicClass.ClassName;
            textGraderName.Text = gacPublicClass.GraderName;
            comboBoxNumberOfSections.SelectedValue = gacPublicClass.NumberOfSections;
            comboBoxHostType.SelectedIndex = gacPublicClass.HostType;
            textUsername.Text = gacPublicClass.UserName;
            textFromAddress.Text = gacPublicClass.FromAddress;
            textAddressExtension.Text = gacPublicClass.AddressExtension;
            checkBoxAlertOnLate.Checked = gacPublicClass.AlertOnLate;
            checkBoxSetFullPoints.Checked = gacPublicClass.SetFullPoints;
            checkBoxIncludeNames.Checked = gacPublicClass.IncludeNames;
            checkBoxIncludeSection.Checked = gacPublicClass.IncludeSections;
            checkBoxFormatAsHTML.Checked = gacPublicClass.FormatAsHTML;
            checkBoxEmailStudentsNoGrade.Checked = gacPublicClass.EmailStudentsNoGrade;
            checkBoxOutputOnlyGraded.Checked = gacPublicClass.OutputOnlyGraded;
            checkBoxIncludeComments.Checked = gacPublicClass.IncludeComments;
            checkBoxShowOutOfTotals.Checked = gacPublicClass.ShowOutOfTotals;
            checkBoxDisplayClassStats.Checked = gacPublicClass.DisplayClassStats;
            checkBoxDisplayTotalPoints.Checked = gacPublicClass.DisplayTotalPoints;
        }

        private bool validateClassForm()
        {
            string strErrorMessage;
            strErrorMessage = "";
            if (textClassName.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "Class Name Is Required.\n";
            if (textGraderName.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "Grader Name Is Required.\n";
            if (comboBoxNumberOfSections.SelectedValue == null )
                strErrorMessage = strErrorMessage + "Number Of Sections Is Required.\n";
            if (comboBoxHostType.SelectedValue == null)
                strErrorMessage = strErrorMessage + "Host Type Is Required.\n";
            if (textUsername.Text.Trim() == "" )
                strErrorMessage = strErrorMessage + "Username Is Required.\n";
            if (textFromAddress.Text.Trim() == "" )
                strErrorMessage = strErrorMessage + "From Address Is Required.\n";
            if (textAddressExtension.Text.Trim() == "" )
                strErrorMessage = strErrorMessage + "Address Extension Is Required.\n";
            
            if (strErrorMessage == "")
                return true;
            else
            {
                WarningForm warningMessage = new WarningForm();
                warningMessage.Text = "Update Failed";
                warningMessage.strWarningMessage = strErrorMessage;
                warningMessage.ShowDialog();
                return false;
            }
        }

        private void EditClassForm_Load(object sender, EventArgs e)
        {
            //check if the text boxes need to be loaded
            if ( intFormStatus == 1)
            {
                populateClassForm();
                intFormStatus = 0;
            }
            intFormStatus = -1;
            

        }

        private void buttonUpdateClass_Click(object sender, EventArgs e)
        {
            if (validateClassForm())
            {
                intFormStatus = 1;

                gacPublicClass.ClassName = textClassName.Text;
                gacPublicClass.GraderName = textGraderName.Text;
                gacPublicClass.NumberOfSections = comboBoxNumberOfSections.SelectedIndex;
                gacPublicClass.HostType = comboBoxHostType.SelectedIndex;
                gacPublicClass.UserName = textUsername.Text;
                gacPublicClass.FromAddress = textFromAddress.Text;
                gacPublicClass.AddressExtension = textAddressExtension.Text;
                gacPublicClass.AlertOnLate = checkBoxAlertOnLate.Checked;
                gacPublicClass.SetFullPoints = checkBoxSetFullPoints.Checked;
                gacPublicClass.IncludeNames = checkBoxIncludeNames.Checked;
                gacPublicClass.IncludeSections = checkBoxIncludeSection.Checked;
                gacPublicClass.FormatAsHTML = checkBoxFormatAsHTML.Checked;
                gacPublicClass.EmailStudentsNoGrade = checkBoxEmailStudentsNoGrade.Checked;
                gacPublicClass.OutputOnlyGraded = checkBoxOutputOnlyGraded.Checked;
                gacPublicClass.IncludeComments = checkBoxIncludeComments.Checked;
                gacPublicClass.ShowOutOfTotals = checkBoxShowOutOfTotals.Checked;
                gacPublicClass.DisplayClassStats = checkBoxDisplayClassStats.Checked;
                gacPublicClass.DisplayTotalPoints = checkBoxDisplayTotalPoints.Checked;

                this.Close();
            }
        }

        private void buttonCancelClass_Click(object sender, EventArgs e)
        {
            intFormStatus = 0;
            this.Close();
        }
    }
}
