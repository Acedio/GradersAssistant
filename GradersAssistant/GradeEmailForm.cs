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
        List<int> studentScores = new List<int>();
        int totalScore;

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

        private string getEmailText(Student s, bool useHtml)
        {   // this is ridiculous!      -- Josh
            // check for existence of student id in dictionary responseDict
            Dictionary<int, Response> responseDict = responseLists[s.StudentID].Responses;
            string theString = "The scores:\n\n";

            //Dictionary<int, RubricNode> criterion = currentAssignment.Rubric.Nodes;
            Rubric currentRubric = currentAssignment.Rubric;

            foreach (int rootNodeID in currentRubric.RootNodes)
            {
                theString += getTextFromNodes(rootNodeID, currentRubric.Nodes, responseDict, 0) + "\n";
            }
            return theString;
        }

        private string getTextFromNodes(int nodeID, Dictionary<int, RubricNode> nodes, Dictionary<int, Response> responseDict, int tabCount)
        {
            string tabString = "     ";
            LinkedList<int> children = nodes[nodeID].Children;
            string theString = "";
            string indentString = "";
            for (int i = 0; i < tabCount; i++)
            {
                indentString += tabString;
            }
            theString += indentString;

            if (children.Count > 0)
            {   // go deeper in recursion

                theString += nodes[nodeID].Criteria.Description + ":\n";
                foreach (int nID in children)
                {
                    theString += getTextFromNodes(nID, nodes, responseDict, tabCount+1);
                }
                return theString;
            }
            else
            {   // reached end, return a string now
                theString += nodes[nodeID].Criteria.Description + " -- Score: " +
                    responseDict[nodeID].PointsReceived + " out of " +
                    nodes[nodeID].Criteria.MaxPoints + "\n";
                if (responseDict[nodeID].GraderComment != "")
                {
                    indentString = indentString + tabString;
                    theString += indentString + "Comments:\n" + indentString +
                        responseDict[nodeID].GraderComment.Replace("\n", "\n" + indentString);
                }
                return theString;
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
        /// <summary>
        /// This function actually does the email sending, using SMTP.
        /// </summary>
        /// <param name="useHTML">Boolean indicating whether or nto to use HTML.</param>
        /// <param name="text">The actual text of the email, with or without HTML formatting.</param>
        /// <param name="s">The student to whom the email should be sent.</param>
        /// <returns>Returns a boolean indicating whether or not the email went through,
        /// but an exception will be caught and thrown if the email does not work.</returns>
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

        /// <summary>
        /// This handles the click event for buttonSendEmails, as well as the Accept event,
        /// probably triggered by the enter/return key.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void buttonSendEmails_Click(object sender, EventArgs e)
        {
            int failedEmails = 0;
            if (textBoxEmailAddress.Text == "")
            {
                MessageBox.Show("Please enter an email address.", "No email address");
            }
            else if (radioButtonProtocolExchange.Checked && textBoxExchangePassword.Text == "")
            {
                MessageBox.Show("Please enter a password for authenticated SMTP.", "No password");
            }
            else if (textBoxSMTPServer.Text == "")
            {
                MessageBox.Show("Please enter an smtp server.", "No SMTP Server");
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

        /// <summary>
        /// This handles the click event for buttonCancel, as well as the Cancel event,
        /// probably triggered by the escape key.  This function will likely result in
        /// the sending of emails
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This handles the radioButtonEmailAll event for the check being changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void radioButtonEmailAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEmailAll.Checked)
            {
                comboBoxStudentSelect.Enabled = false;
            }
            else
            {
                comboBoxStudentSelect.Enabled = true;
            }
        }

        /// <summary>
        /// This handles the radioButtonEmailOne event for the check being changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void radioButtonEmailOne_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEmailOne.Checked)
            {
                comboBoxStudentSelect.Enabled = true;
            }
            else
            {
                comboBoxStudentSelect.Enabled = false;
            }
        }

        /// <summary>
        /// This handles the radioButtonEmailProtocolExchange event for the check
        /// being changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void radioButtonProtocolExchange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonProtocolExchange.Checked)
            {
                textBoxExchangePassword.Enabled = true;
            }
            else
            {
                textBoxExchangePassword.Enabled = false;
            }
        }

        /// <summary>
        /// This handles the radioButtonEmailProtocolSMTP event for the check
        /// being changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void radioButtonProtocolSMTP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonProtocolSMTP.Checked)
            {
                textBoxExchangePassword.Enabled = false;
            }
            else
            {
                textBoxExchangePassword.Enabled = true;
            }
        }

        /// <summary>
        /// This handles the checkBoxAddHeader event for the check being changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void checkBoxAddHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddHeader.Checked)
            {
                textBoxHeaderText.Enabled = true;
            }
            else
            {
                textBoxHeaderText.Enabled = false;
            }
        }
    }
}
