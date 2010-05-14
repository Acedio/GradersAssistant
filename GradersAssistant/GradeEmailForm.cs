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
        Dictionary<int,int> studentScores = new Dictionary<int,int>();
        int totalScore, numZeros, numGraded, maxScore;
        bool useHtml = true;

        public GradeEmailForm(GAClass mainClass, Dictionary<int, Student> students, Assignment assignment, Dictionary<int,ResponseList> responseLists)
        {
            InitializeComponent();
            this.AcceptButton = buttonSendEmails;
            this.CancelButton = buttonCancel;

            this.mainClass = mainClass;
            this.students = students;
            this.currentAssignment = assignment;
            this.responseLists = responseLists;
            this.Text = "Email Grades - " + currentAssignment.Name + " - " + mainClass.ClassName;

            studentScores = getStudentTotals();
            totalScore = 0;
            foreach (int i in studentScores.Values)
            {
                try
                {
                    totalScore += i;
                    if (i == 0)
                    {
                        numZeros++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Crazy error!  Glad I'm not you, man (or woman).\nYeah, I've got nothing for you." +
                        ex.ToString(),
                        "Umm...");
                }
            }


            textBoxEmailAddress.Text = mainClass.FromAddress;
        }

        /// <summary>
        /// This returns a Dictionary<studentID, studentScore> using the class' students list.
        /// Side effect: Also sets numGraded.
        /// </summary>
        /// <returns>Dictionary connecting studentIDs to studentScores</returns>
        private Dictionary<int,int> getStudentTotals()
        {
            numGraded = students.Count;
            Dictionary<int,int> tempDict = new Dictionary<int,int>();
            foreach (Student s in students.Values)
            {
                try
                {
                    tempDict.Add(s.StudentID, getOneTotal(s));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Student responses not found, database may be corrupt.\n\n" +
                        ex.ToString(),
                        "Student score not found!");
                    numGraded--;
                }
            }
            return tempDict;
        }

        /// <summary>
        /// This function returns the total score of one Student.
        /// Side effect:  Also sets the maxScore object variable.  Messy, I know.
        /// </summary>
        /// <param name="s">The Student whose score is to be gotten.</param>
        /// <returns>An integer indicating the Student's score.</returns>
        private int getOneTotal(Student s)
        {   // this is ridiculous!      -- Josh
            if (!responseLists.ContainsKey(s.StudentID))
            {
                throw new Exception("Student " + s.FirstName + " " + s.LastName +
                    " (" + s.StudentID +
                    ") does not have any responses.  Please check the grading guide.");
            }
            Dictionary<int, Response> responseDict = responseLists[s.StudentID].Responses;
            if (responseDict.Count == 0)
            {
                throw new Exception("Student " + s.FirstName + " " + s.LastName +
                    " (" + s.StudentID +
                    ") does not have any responses.  Please check the grading guide.");
            }
            Rubric currentRubric = currentAssignment.Rubric;
            int theTotal = 0;
            maxScore = 0;

            foreach (int rootNodeID in currentRubric.RootNodes)
            {
                try
                {
                    theTotal += getScoreFromNode(rootNodeID, currentRubric.Nodes, responseDict);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some responses missing for student "
                        + s.FirstName + " " + s.LastName + ".  Try regrading this student.  " +
                        "If that doesn't work, the database is probably corrupt.\n\n" + ex.ToString(),
                        "Missing responses!");
                }
            }
            return theTotal;
        }

        /// <summary>
        /// This function is called recursively to navigate the criteria tree and get the
        /// score for one node of the response tree of one Student.
        /// </summary>
        /// <param name="nodeID">Start node.</param>
        /// <param name="nodes">Dictionary of all nodes in the criteria tree.</param>
        /// <param name="responseDict">Dictionary of all responses for this student.</param>
        /// <returns>The integer to be added to the total score for this student.</returns>
        private int getScoreFromNode(int nodeID, Dictionary<int, RubricNode> nodes, Dictionary<int, Response> responseDict)
        {
            LinkedList<int> children = nodes[nodeID].Children;

            if (children.Count > 0)
            {   // go deeper in recursion
                int theScore = 0;
                foreach (int nID in children)
                {
                    theScore += getScoreFromNode(nID, nodes, responseDict);
                }
                return theScore;
            }
            else
            {   // reached end, return an int now
                maxScore += currentAssignment.Rubric.Nodes[nodeID].Criteria.MaxPoints;
                return responseDict[nodeID].PointsReceived;
            }
        }

        /// <summary>
        /// This function returns the HTML text for an HTML formatted email for one Student.  Includes
        /// comments, grades, etc.  Throws an exception if the Student has no responses.
        /// </summary>
        /// <param name="s">The Student whose email HTML should be obtained.</param>
        /// <returns>Returns the string that should be sent to the sendEmail function.</returns>
        private string getEmailHtml(Student s)
        {
            int tempInt;
            List<string> commentStrings = new List<string>();

            if (!responseLists.ContainsKey(s.StudentID))
            {
                throw new Exception("Student " + s.FirstName + " " + s.LastName +
                    " (" + s.StudentID +
                    ") does not have any responses.  Please check the grading guide.");
            }
            Dictionary<int, Response> responseDict = responseLists[s.StudentID].Responses;
            // initialize html tags and add header text // NOTE: New lines are for minor source readability
            string theString = "<html><body>" + "<p>" + textBoxHeaderText.Text + "</p>";
            // add intro
            theString += "<p>Grading Report for " + mainClass.ClassName + "<br />" +
                "Assignment: " + currentAssignment.Name + "</p>";
            // class statistics
            theString += "<p>Statistics:" +
                "     Number of Students: " + students.Count + "<br />" +
                "     Numer of Students Graded: " + numGraded + "<br />" +
                "     Number of Zero Grades: " + numZeros + "<br />" +
                "     Average Grade: " + ((double)totalScore / (double)students.Count).ToString("F2") + "<br />" +
                "     Average (no zeros): " + ((double)totalScore / (double)studentScores.Count).ToString("F2") + "</p>";

            //Dictionary<int, RubricNode> criterion = currentAssignment.Rubric.Nodes;
            Rubric currentRubric = currentAssignment.Rubric;

            theString += "<p>Your Grades:<ul>";
            tempInt = 0;
            foreach (int rootNodeID in currentRubric.RootNodes)
            {
                theString += getHtmlFromNode(rootNodeID, currentRubric.Nodes, responseDict, ref tempInt, ref commentStrings);
            }
            theString += "</ul>";
            theString += "Total Score: " + studentScores[s.StudentID] + " out of " + maxScore +
                " -- " + (100 * studentScores[s.StudentID] / maxScore).ToString("F2") + "%</p><p>";
            theString += "Comments:</p>";
            foreach (string aComment in commentStrings)
            {
                theString += aComment;
            }
            theString += "</body></html>";
            return theString;
        }

        /// <summary>
        /// This function is called recursively to navigate the criteria tree and get some of the
        /// HTML for a student's email, starting at a single node.
        /// </summary>
        /// <param name="nodeID">Start node.</param>
        /// <param name="nodes">Dictionary of all nodes in the criteria tree.</param>
        /// <param name="responseDict">Dictionary of all responses for this student.</param>
        /// <param name="depth">This number indicates the level of recursion, starting at
        /// zero.  This will control the indentation in the returned HTML string.</param>
        /// <param name="anchorNum">Passed by reference, this tells which anchor number
        /// should be used for the next anchor reference (for comments).</param>
        /// <returns>The string to be added to the email to be sent for this student.</returns>
        private string getHtmlFromNode(int nodeID, Dictionary<int, RubricNode> nodes, Dictionary<int, Response> responseDict, ref int anchorNum, ref List<string> commentStrings)
        {
            LinkedList<int> children = nodes[nodeID].Children;
            string theString = "<li>";

            if (children.Count > 0)
            {   // go deeper in recursion

                theString += nodes[nodeID].Criteria.Description + ":" + "<ul>";
                foreach (int nID in children)
                {
                    theString += getHtmlFromNode(nID, nodes, responseDict, ref anchorNum, ref commentStrings);
                }
                theString += "</ul></li>";
                return theString;
            }
            else
            {   // reached end, return a string now
                theString += nodes[nodeID].Criteria.Description + ": ";
                if (responseDict[nodeID].GraderComment == "")
                {
                    theString += responseDict[nodeID].PointsReceived + " out of " +
                        nodes[nodeID].Criteria.MaxPoints;
                }
                else
                {   // if we have a comment, insert anchor
                    theString += "<a href=\"#C" + anchorNum + "\">" +
                        responseDict[nodeID].PointsReceived + " out of " +
                        nodes[nodeID].Criteria.MaxPoints + "</a>";
                    // add comment string to be rendered at end of email
                    commentStrings.Add("<h2><a name=\"C" + anchorNum + "\">" +
                        "</a></h2><p>" + nodes[nodeID].Criteria.Description + ": " + "<br />" +
                        responseDict[nodeID].GraderComment.Replace("\n", "</br>") + "</p>");
                    anchorNum++;
                }
                theString += "</li>";
                return theString;
            }
        }

        /// <summary>
        /// This function is called recursively to navigate the criteria tree and get some of the
        /// text for a student's email, starting at a single node.
        /// </summary>
        /// <param name="s">The Student whose email text should be obtained.</param>
        /// <returns>Returns the string that should be sent to the sendEmail function.</returns>
        private string getEmailText(Student s)
        {
            if (!responseLists.ContainsKey(s.StudentID))
            {
                throw new Exception("Student " + s.FirstName + " " + s.LastName +
                    " (" + s.StudentID + 
                    ") does not have any responses.  Please check the grading guide.");
            }
            Dictionary<int, Response> responseDict = responseLists[s.StudentID].Responses;
            // initialize text with header and blank line
            string theString = textBoxHeaderText.Text + "\n\n";
            // add intro
            theString += "Grading Report for " + mainClass.ClassName + "\n" +
                "Assignment: " + currentAssignment.Name + "\n\n";
            // class statistics
            theString += "Statistics:\n" +
                "     Number of Students: " + students.Count + "\n" +
                "     Numer of Students Graded: " + numGraded + "\n" +
                "     Number of Zero Grades: " + numZeros + "\n" +
                "     Average Grade: " + ((double)totalScore / (double)students.Count).ToString("F2") + "\n" +
                "     Average (no zeros): " + ((double)totalScore / (double)studentScores.Count).ToString("F2") + "\n\n";
            theString += "Your Score:\n\n";



            //Dictionary<int, RubricNode> criterion = currentAssignment.Rubric.Nodes;
            Rubric currentRubric = currentAssignment.Rubric;

            foreach (int rootNodeID in currentRubric.RootNodes)
            {
                theString += getTextFromNode(rootNodeID, currentRubric.Nodes, responseDict, 0) + "\n";
            }
            theString += "\n";
            theString += "Total Score: " + studentScores[s.StudentID] + " out of " + maxScore +
                " -- " + (100*studentScores[s.StudentID]/maxScore).ToString("F2") + "%";
            return theString;
        }

        /// <summary>
        /// This function is called recursively to navigate the criteria tree and get the
        /// responses for a student, starting at a single node.
        /// </summary>
        /// <param name="nodeID">Start node.</param>
        /// <param name="nodes">Dictionary of all nodes in the criteria tree.</param>
        /// <param name="responseDict">Dictionary of all responses for this student.</param>
        /// <param name="tabCount">This number indicates the level of recursion, starting at
        /// zero.  This will control the indentation in the returned string.</param>
        /// <returns>The string to be added to the email to be sent for this student.</returns>
        private string getTextFromNode(int nodeID, Dictionary<int, RubricNode> nodes, Dictionary<int, Response> responseDict, int tabCount)
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
                    theString += getTextFromNode(nID, nodes, responseDict, tabCount+1);
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
                        responseDict[nodeID].GraderComment.Replace("\n", "\n" + indentString) + "\n";
                }
                return theString;
            }
        }

        /// <summary>
        /// This function handles the distribution of emails to all students.
        /// Assumes all appropriate boxes have appropriate information.
        /// </summary>
        /// <returns>Number of successfull emails.</returns>
        private int distributeEmails(ref bool setOnAbort)
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
                        if (useHtml)
                        {
                            sendEmail(useHtml, getEmailHtml(pair.Value), pair.Value);
                        }
                        else
                        {
                            sendEmail(useHtml, getEmailText(pair.Value), pair.Value);
                        }
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
                            setOnAbort = true;
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
        /// <param name="useHTML">Boolean indicating whether or not to use send HTML or plain text.</param>
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

        /// <summary>
        /// This handles the click event for buttonSendEmails, as well as the Accept event,
        /// probably triggered by the enter/return key.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event args.</param>
        private void buttonSendEmails_Click(object sender, EventArgs e)
        {
            bool tempCheckAbort;
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
                    tempCheckAbort = false;
                    failedEmails = students.Count - distributeEmails(ref tempCheckAbort);
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
                    if (!tempCheckAbort)
                    {
                        this.Close();
                    }
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

        private void radioButtonHtml_CheckedChanged(object sender, EventArgs e)
        {
            useHtml = radioButtonHtml.Checked;
        }

        private void radioButtonPlainText_CheckedChanged(object sender, EventArgs e)
        {
            useHtml = !radioButtonPlainText.Checked;
        }
    }
}
