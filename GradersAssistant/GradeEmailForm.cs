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
        GAClass mainClass;
        Dictionary<int, Student> students;
        Assignment currentAssignment;
        Dictionary<int,ResponseList> responseLists;

        bool useHtml = false;
        public GradeEmailForm(GAClass mainClass, Dictionary<int, Student> students, Assignment assignment, Dictionary<int,ResponseList> responseLists)
        {
            InitializeComponent();
            this.AcceptButton = buttonSendEmails;
            this.CancelButton = buttonCancel;

            this.mainClass = mainClass;
            this.students = students;
            this.currentAssignment = assignment;
            this.responseLists = responseLists;


            textBoxEmailAddress.Text = mainClass.FromAddress;
        }

        private void radioButtonProtocolSMTP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSendEmails_Click(object sender, EventArgs e)
        {
            int failedEmails = 0;
            if (textBoxEmailAddress.Text == "")
            {
                MessageBox.Show("Please enter an email address.","No email address");
            }
            else if (radioButtonProtocolExchange.Checked && textBoxExchangePassword.Text == "")
            {
                MessageBox.Show("Please enter a password for authenticated SMTP.","No password");
            }
            else if (textBoxSMTPServer.Text == "")
            {
                MessageBox.Show("Please enter an smtp server.","No SMTP Server");
            }
            else if (radioButtonEmailOne.Checked && comboBoxStudentSelect.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a student to send to.", "No student selected");
            }
            else if (radioButtonEmailAll.Checked)
            {   // send a lot of emails
                if (MessageBox.Show("Are you sure you want to send " + students.Count + " emails?", "Send " + students.Count + " emails?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    failedEmails = students.Count - distributeEmails();
                    if (failedEmails == 0)
                    {
                        MessageBox.Show(students.Count.ToString() + " emails sent successfully!", "Success!");
                    }
                    else
                    {
                        MessageBox.Show((students.Count - failedEmails).ToString() + " out of " + students.Count +
                            " emails sent successfully.  " + failedEmails.ToString() + " email not sent."
                            , "Failed Emails");                    
                    }
                    this.Close();
                }
            }
        }

        private string getEmailText(Student s, bool useHtml)
        {
            // check for existence of student id in dictionary responseDict
            Dictionary<int, Response> responseDict = responseLists[s.StudentID].Responses;

            //Dictionary<int, RubricNode> criterion = currentAssignment.Rubric.Nodes;
            Rubric currentRubric = currentAssignment.Rubric;

            foreach (int rootNodeID in currentRubric.RootNodes)
            {
                getTextFromNodes    //make recursive function 
            }
        }

        private int distributeEmails()
        {
            int emailsSent = 0;
            bool keepGoing = true;
            bool breakNow = false;
            DialogResult ari = new DialogResult();
            List<Student> failedStudents = new List<Student>();
            foreach ( KeyValuePair<int,Student> pair in students)
            {
                keepGoing = true;
                breakNow = false;
                while(keepGoing)
                {
                    try
                    {
                        sendEmail(useHtml, getEmailText(pair.Value,useHtml), pair.Value);
                        emailsSent++;   // only happens if sendEmail function goes through
                        keepGoing = false;
                    }
                    catch(Exception ex)
                    {
                        ari = MessageBox.Show("Email to student " + pair.Value.FirstName + " " +
                            pair.Value.LastName + " failed. Abort emailing, retry, or ignore and continue.\n\n" +
                            "Email address: " + pair.Value.EmailAddress +
                            "\nError Info: " + ex.ToString(),
                            "Email failed",
                            MessageBoxButtons.AbortRetryIgnore);
                        if (ari == DialogResult.Abort)
                        {   // stop sending emails
                            keepGoing = false;
                            breakNow = true;
                        }
                        else if (ari == DialogResult.Ignore)
                        {   // move along
                            keepGoing = false;
                            breakNow = false;
                        }
                        else
                        {   // retry or other: try again
                            keepGoing = true;
                            breakNow = false;
                        }
                    }
                }
                if (breakNow)
                {
                    break;
                }
            }
            return emailsSent;   // TODO actually check how many emails worked
        }

        private bool sendEmail(bool useHTML, string text, Student s)
        {
            try
            {
                if (!textBoxEmailAddress.Text.Contains('@'))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email!");
                    throw new Exception("Invalid sender email address.");
                }
                if (!s.EmailAddress.Contains('@'))
                {
                    //MessageBox.Show("The recipient \"" + s.EmailAddress + "\" has an invalid email address.");
                    throw new Exception("Invalid student email address.");
                }
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential theCredential = new NetworkCredential(textBoxEmailAddress.Text, textBoxExchangePassword.Text);
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(textBoxEmailAddress.Text);

                try
                {
                    smtpClient.Host = textBoxSMTPServer.Text;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: Please enter a valid SMTP server.", "No SMTP Server");
                    throw ex;
                }
                if (radioButtonProtocolExchange.Checked)
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                }
                smtpClient.Credentials = theCredential;

                message.From = fromAddress;
                message.Subject = textBoxSubject.Text;
                message.IsBodyHtml = useHTML;
                message.Body = text;
                message.To.Add(s.EmailAddress);

                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error sending email:\n" + ex.Message, ex.Message);
                    throw ex;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private bool sendEmail(bool authenticated, string host, string username, string password, string text, string subject, string recipient)
        //{
        //    if (!username.Contains('@'))
        //    {
        //        MessageBox.Show("Please enter a valid email address.", "Invalid Email!");
        //        return false;
        //    }
        //    if (!recipient.Contains('@'))
        //    {
        //        MessageBox.Show("The recipient \"" + recipient + "\" has an invalid email address.");
        //        return false;
        //    }
        //    SmtpClient smtpClient = new SmtpClient();
        //    NetworkCredential theCredential = new NetworkCredential(username, password);
        //    MailMessage message = new MailMessage();
        //    MailAddress fromAddress = new MailAddress(username);

        //    smtpClient.Host = host;
        //    if (authenticated)
        //    {
        //        smtpClient.UseDefaultCredentials = false;
        //        smtpClient.Port = 587;
        //        smtpClient.EnableSsl = true;
        //        //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    }
        //    smtpClient.Credentials = theCredential;

        //    message.From = fromAddress;
        //    message.Subject = subject;
        //    message.IsBodyHtml = false;
        //    message.Body = text;
        //    message.To.Add(recipient);
            
        //    try
        //    {
        //        smtpClient.Send(message);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error sending email:\n" + ex.Message, ex.Message);
        //    }
        //    return false;
        //}

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
