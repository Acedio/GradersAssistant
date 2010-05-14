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
            return String.Format("{2}, {1} [{0}]",studentSchoolID,firstName,lastName);
        }

        public bool HasID()
        {
            return (studentID != noID);
        }
    }

    public class Response
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
            graderComment = string.Empty;
        }

        public Response(int rID, int rPointsReceived, string rGraderComment)
        {
            responseID = rID;
            pointsReceived = rPointsReceived;
            graderComment = rGraderComment;
        }
    }

    public class Adjustment
    {
        private const int noID = -1;

        public int AdjustmentID;

        public string Comment;

        public int PointAdjustment;

        public Adjustment()
        {
            AdjustmentID = noID;
            Comment = string.Empty;
            PointAdjustment = 0;
        }

        public Adjustment(int aID, string aComment, int aPointAdjustment)
        {
            AdjustmentID = aID;
            Comment = aComment;
            PointAdjustment = aPointAdjustment;
        }
    }

    public class ResponseList
    {
        public const int noID = -1;

        public Dictionary<int, Response> Responses;

        public int StudentID;

        public int AssignmentID;

        public LinkedList<Adjustment> Adjustments;

        public ResponseList()
        {
            StudentID = noID;
            AssignmentID = noID;
            Responses = new Dictionary<int, Response>();
        }
    }

    public class Criteria
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

    public class RubricNode
    {
        public Criteria Criteria;

        public LinkedList<int> Children;

        public RubricNode(Criteria c)
        {
            Criteria = c;
            Children = new LinkedList<int>();
        }

        public override string ToString()
        {
            return Criteria.Description;
        }
    }

    public class Rubric
    {
        public Dictionary<int, RubricNode> Nodes;

        public LinkedList<int> RootNodes;

        public Rubric()
        {
            Nodes = new Dictionary<int, RubricNode>();
            RootNodes = new LinkedList<int>();
        }

        /// <summary>
        /// Takes a Criteria and creates a new CriteriaTreeNode at the root of the collection.
        /// </summary>
        /// <param name="c">A criteria with a key given by the database. The criteria should have a key already (it should not be NoID).</param>
        /// <returns>The criterias key (which references it in the dictionary as well as the DB).</returns>
        public int AddNewNode(Criteria c)
        {
            RubricNode node = new RubricNode(c);
            Nodes.Add(node.Criteria.CriteriaID, node);
            RootNodes.AddLast(node.Criteria.CriteriaID);
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
            RubricNode parentNode;
            if (Nodes.TryGetValue(parentKey, out parentNode))
            {
                Nodes.Add(c.CriteriaID, new RubricNode(c));
                parentNode.Children.AddLast(c.CriteriaID);
                return c.CriteriaID;
            }
            else
            {
                // The parent doesn't exist in the dictionary!
                return -1;
            }
        }

        public int MaxPoints()
        {
            int maxPoints = 0;

            foreach (RubricNode rn in Nodes.Values)
            {
                maxPoints += rn.Criteria.MaxPoints;
            }

            return maxPoints;
        }
    }

    public class Assignment
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
            Rubric = new Rubric();
            assignmentID = noID;
        }

        public Assignment(int aID, string aName, DateTime aDueDate)
        {
            Rubric = new Rubric();
            assignmentID = aID;
            name = aName;
            dueDate = aDueDate;
        }

        public Rubric Rubric;
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
