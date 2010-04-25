using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GradersAssistant
{
    class Student
    {
        private const int noID = -1;

        int studentID;

        public int StudentID
        {
            get { return studentID; }
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

        public Student()
        {
            studentID = noID;
        }

        public Student(int sID, string sFirstName, string sLastName, string sUsername, string sEmailAddress, int sSection, string sStudentSchoolID)
        {
            studentID = sID;
            firstName = sFirstName;
            lastName = sLastName;
            username = sUsername;
            emailAddress = sEmailAddress;
            section = sSection;
            studentSchoolID = sStudentSchoolID;
        }
    }

    class Response
    {
        private const int noID = -1;

        int responseID;

        public int ResponseID
        {
            get { return responseID; }
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

        public Response()
        {
            responseID = noID;
        }

        public Response(int rID, int rPointsReceived, string rGraderComment)
        {
            responseID = rID;
            pointsReceived = rPointsReceived;
            graderComment = rGraderComment;
        }
    }

    class Criteria
    {
        private const int noID = -1;

        int criteriaID;

        public int CriteriaID
        {
            get { return criteriaID; }
        }

        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        int maxPoints;

        public int MaxPoints
        {
            get { return maxPoints; }
            set { maxPoints = value; }
        }

        public Criteria()
        {
            criteriaID = noID;
        }

        public Criteria(int cID, string cDescription, int cMaxPoints)
        {
            criteriaID = cID;
            description = cDescription;
            maxPoints = cMaxPoints;
        }
    }

    class CriteriaTreeNode
    {
        Criteria criteria;

        public Criteria Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }

        Response response;

        public Response Response
        {
            get { return response; }
            set { response = value; }
        }

        LinkedList<CriteriaTreeNode> children;

        public LinkedList<CriteriaTreeNode> Children
        {
            get { return children; }
            set { children = value; }
        }

        public CriteriaTreeNode(Criteria c, Response r)
        {
            criteria = c;
            response = r;
            children = new LinkedList<CriteriaTreeNode>();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}/{2})", criteria.Description, response.PointsReceived, criteria.MaxPoints);
        }
    }

    class CriteriaTreeNodeCollection
    {
        Dictionary<int, CriteriaTreeNode> nodes;

        public Dictionary<int, CriteriaTreeNode> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        public void AddNode(CriteriaTreeNode node)
        {
            nodes = new Dictionary<int, CriteriaTreeNode>();
            nodes.Add(node.Criteria.CriteriaID, node);
        }

        public void AddNode(Criteria c)
        {
            nodes = new Dictionary<int, CriteriaTreeNode>();
            CriteriaTreeNode node = new CriteriaTreeNode(c, new Response());
            nodes.Add(node.Criteria.CriteriaID, node);
        }
    }

    class Assignment
    {
        private const int noID = -1;

        int assignmentID;

        public int AssignmentID
        {
            get { return assignmentID; }
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

        public Assignment()
        {
            assignmentID = noID;
        }

        public Assignment(int aID, string aName, DateTime aDueDate)
        {
            assignmentID = aID;
            name = aName;
            dueDate = aDueDate;
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
