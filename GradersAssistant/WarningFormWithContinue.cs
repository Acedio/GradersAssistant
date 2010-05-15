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
    public partial class WarningFormWithContinue : Form
    {
        public bool Proceed;
        public string Message;
        public WarningFormWithContinue()
        {
            InitializeComponent();
            this.CancelButton = buttonCancel;
            this.AcceptButton = buttonContinue;
            Message = "WARNING:\n You are attempting to save an incomplete student\n entry.  This could potentially cause limited\n functionality of Graders Assistant with regards towards\n this entry.  Do you still\n want to continue?";
            Proceed = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Proceed = false;
            Close();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            Proceed = true;
            Close();

        }

        private void WarningFormWithContinue_Load(object sender, EventArgs e)
        {
            labelWarningMessage.Text = Message;
        }
    }
}
