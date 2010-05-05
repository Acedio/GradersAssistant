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
        public GradeEmailForm()//Dictionary<int, Student> students
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
                //EmailTest(textBoxEmailAddress.Text, textBoxExchangePassword.Text);
            }
            sendEmail(radioButtonProtocolExchange.Checked, "smtp.gmail.com", textBoxEmailAddress.Text, textBoxExchangePassword.Text, "This is a spoof email!", "Hi cousin!", "raptorcantor@gmail.com");
        }

        private bool sendEmail(bool authenticated, string host, string username, string password, string text, string subject, string recipient)
        {
            if (!username.Contains('@'))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email!");
                return false;
            }
            if (!recipient.Contains('@'))
            {
                MessageBox.Show("The recipient \"" + recipient + "\" has an invalid email address.");
                return false;
            }
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential theCredential = new NetworkCredential(username, password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("josh.simmons@gmail.com");

            smtpClient.Host = host;
            if (authenticated)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            }
            smtpClient.Credentials = theCredential;

            message.From = fromAddress;
            message.Subject = subject;
            message.IsBodyHtml = false;
            message.Body = text;
            message.To.Add(recipient);
            
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email:\n" + ex.Message, ex.Message);
            }
            return false;
        }

        public void EmailTest(string username, string password)
        {   // this function uses code from here: http://stackoverflow.com/questions/298363/how-can-i-make-smtp-authenticated-in-c
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential theCredential = new NetworkCredential(username, password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(username);

            //smtpClient.Host = "bl2prd0102.outlook.com";// bl2prd0102.outlook.com is the student outlook server, maybe this should be an option?
            smtpClient.Host = "hub1.whitworth.edu";
            smtpClient.Credentials = theCredential;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            

            message.From = fromAddress;
            message.Subject = "Hey Cousin!";
            message.IsBodyHtml = false;
            message.Body = "Hey Josh,\nIt turns out we're second cousins, and all my money got stolen by some Nigerian scam artists.\n\nIf you could send me ten thousand dollars, I will be able to open my bank account and get my money back.  I'd be pleased to give you a half percent of my estate in exchange for the assistance.\n\nYour cousin,\nBill";
            message.To.Add("raptorcantor@gmail.com");
            //message.To.Add("@my.whitworth.edu");

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
