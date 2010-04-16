using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GradersAssistant
{
    class Student
    {
        int studentID;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        int section;

        public int Section
        {
            get { return section; }
            set { section = value; }
        }

        string studentSchoolID;

        public string StudentSchoolID
        {
            get { return studentSchoolID; }
            set { studentSchoolID = value; }
        }
    }

    class Response
    {
        int responseID;

        public int ResponseID
        {
            get { return responseID; }
            set { responseID = value; }
        }

        int pointsReceived;

        public int PointsReceived
        {
            get { return pointsReceived; }
            set { pointsReceived = value; }
        }

        string graderComment;

        public string GraderComment
        {
            get { return graderComment; }
            set { graderComment = value; }
        }
    }

    class Criteria
    {
        int criteriaID;

        public int CriteriaID
        {
            get { return criteriaID; }
            set { criteriaID = value; }
        }

        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        int points;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }

    class Assignment
    {
        int assignmentID;

        public int AssignmentID
        {
            get { return assignmentID; }
            set { assignmentID = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
    }

    static class GradersAssistant
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
