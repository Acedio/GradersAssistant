using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace GradersAssistant
{
    public partial class GradeEmailForm : Form
    {
        public GradeEmailForm()
        {
            InitializeComponent();
        }

        private void radioButtonProtocolSMTP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSendEmails_Click(object sender, EventArgs e)
        {
            if (radioButtonProtocolExchange.Checked)
            {
                EmailTest(textBoxEmailAddress.Text, textBoxExchangePassword.Text);
            }
        }

        public void EmailTest(string username, string password)
        {   // this function uses code from here: http://stackoverflow.com/questions/298363/how-can-i-make-smtp-authenticated-in-c
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential theCredential = new NetworkCredential(username, password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(username);

            //smtpClient.Host = "bl2prd0102.outlook.com";// bl2prd0102.outlook.com is the student outlook server, maybe this should be an option?
            smtpClient.Host = "hub1.whitworth.edu";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = theCredential;

            message.From = fromAddress;
            message.Subject = "Hey Cousin!";
            message.IsBodyHtml = false;
            message.Body = "Hey Josh,\nIt turns out we're second cousins, and all my money got stolen by some Nigerian scam artists.\n\nIf you could send me ten thousand dollars, I will be able to open my bank account and get my money back.  I'd be pleased to give you a half percent of my estate in exchange for the assistance.\n\nYour cousin,\nBill";
            message.To.Add("jsimmons10@my.whitworth.edu");

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in smtp stuff in function EmailTest: " + ex.Message, ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
