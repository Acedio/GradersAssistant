using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GradersAssistant
{
    public class Student
    {
        private const int noID = -1;

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

        int classSection;

        public int ClassSection
        {
            get { return classSection; }
            set { ClassSection = value; }
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

        public Student(int sID, string sFirstName, string sLastName, string sUsername, string sEmailAddress, int sClassSection, string sStudentSchoolID)
        {
            studentID = sID;
            firstName = sFirstName;
            lastName = sLastName;
            username = sUsername;
            emailAddress = sEmailAddress;
            classSection = sClassSection;
            studentSchoolID = sStudentSchoolID;
        }

        public Student(string sFirstName, string sLastName, string sUsername, string sEmailAddress, int sClassSection, string sStudentSchoolID)
        {
            studentID = noID;
            firstName = sFirstName;
            lastName = sLastName;
            username = sUsername;
            emailAddress = sEmailAddress;
            classSection = sClassSection;
            studentSchoolID = sStudentSchoolID;
        }

        public override string ToString()
        {
            return String.Format("({0}) {2}, {1} [{3}]",studentID,firstName,lastName,emailAddress);
        }

        public bool HasID()
        {
            return (studentID != noID);
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

    class CriteriaResponseTreeNode
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

        LinkedList<int> children;

        public LinkedList<int> Children
        {
            get { return children; }
            set { children = value; }
        }

        public CriteriaResponseTreeNode(Criteria c, Response r)
        {
            criteria = c;
            response = r;
            children = new LinkedList<int>();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}/{2})", criteria.Description, response.PointsReceived, criteria.MaxPoints);
        }
    }

    class CriteriaResponseTree
    {
        Dictionary<int, CriteriaResponseTreeNode> nodes;

        public Dictionary<int, CriteriaResponseTreeNode> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        public CriteriaResponseTree()
        {
            nodes = new Dictionary<int, CriteriaResponseTreeNode>();
        }

        /// <summary>
        /// Takes a Criteria and creates a new CriteriaTreeNode at the root of the collection.
        /// </summary>
        /// <param name="c">A criteria with a key given by the database. The criteria should have a key already (it should not be NoID).</param>
        /// <returns>The criterias key (which references it in the dictionary as well as the DB).</returns>
        public int AddNewNode(Criteria c)
        {
            CriteriaResponseTreeNode node = new CriteriaResponseTreeNode(c, new Response());
            nodes.Add(node.Criteria.CriteriaID, node);
            return node.Criteria.CriteriaID;
        }

        /// <summary>
        /// Adds a new node to the given parent.
        /// </summary>
        /// <param name="c">A criteria with a key given by the database. The criteria should have a key already (it should not be NoID).</param>
        /// <param name="parentKey">The valid parent key that the node should be added to.</param>
        /// <returns>The criterias key (which references it in the dictionary as well as the DB).</returns>
        public int AddNewNode(Criteria c, int parentKey)
        {
            CriteriaResponseTreeNode parentNode;
            if (nodes.TryGetValue(parentKey, out parentNode))
            {
                nodes.Add(c.CriteriaID, new CriteriaResponseTreeNode(c, new Response()));
                parentNode.Children.AddLast(c.CriteriaID);
                return c.CriteriaID;
            }
            else
            {
                // The parent doesn't exist in the dictionary!
                return -1;
            }
        }

        public void BlankResponses()
        {
            foreach (CriteriaResponseTreeNode node in nodes.Values)
            {
                if (node.Children.Count > 0)
                {
                    node.Response = new Response();
                }
                else
                {
                    node.Response = null;
                }
            }
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


   public class GAClass
    {
        public string ClassName;
        public string GraderName;
        public int NumberOfSections;
        public int HostType;
        public string UserName;
        public string FromAddress;
        public string AddressExtension;
        public bool AlertOnLate;
        public bool SetFullPoints;
        public bool IncludeNames;
        public bool IncludeSections;
        public bool FormatAsHTML;
        public bool EmailStudentsNoGrade;
        public bool OutputOnlyGraded;
        public bool IncludeAllComments;
        public bool ShowOutOfTotals;
        public bool DisplayClassStats;
        public bool DisplayTotalPoints;

        public GAClass()
        {
            ClassName = "";
            GraderName = "";
            NumberOfSections = 0;
            HostType = 0;
            UserName = "";
            FromAddress = "";
            AddressExtension = "";
            AlertOnLate = false;
            SetFullPoints = false;
            IncludeNames = false;
            IncludeSections = false;
            FormatAsHTML = false;
            EmailStudentsNoGrade = false;
            OutputOnlyGraded = false;
            IncludeAllComments = false;
            ShowOutOfTotals = false;
            DisplayClassStats = false;
            DisplayTotalPoints = false;
        }

        public GAClass(string cClassName, string cGraderName, int cNumberOfSections, int cHostType, string cUserName, string cFromAddress, string cAddressExtension, bool cAlertOnLate, bool cSetFullPoints, bool cIncludeNames, bool cIncludeSections, bool cFormatAsHTML, bool cEmailStudentsNoGrade, bool cOutputOnlyGraded, bool cIncludeAllComments, bool cShowOutOfTotals, bool cDisplayClassStats, bool cDisplayTotalPoints)
        {
            ClassName = cClassName;
            GraderName = cGraderName;
            NumberOfSections = cNumberOfSections;
            HostType = cHostType;
            UserName = cUserName;
            FromAddress = cFromAddress;
            AddressExtension = cAddressExtension;
            AlertOnLate = cAlertOnLate;
            SetFullPoints = cSetFullPoints;
            IncludeNames = cIncludeNames;
            IncludeSections = cIncludeSections;
            FormatAsHTML = cFormatAsHTML;
            EmailStudentsNoGrade = cEmailStudentsNoGrade;
            OutputOnlyGraded = cOutputOnlyGraded;
            IncludeAllComments = cIncludeAllComments;
            ShowOutOfTotals = cShowOutOfTotals;
            DisplayClassStats = cDisplayClassStats;
            DisplayTotalPoints = cDisplayTotalPoints;
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
