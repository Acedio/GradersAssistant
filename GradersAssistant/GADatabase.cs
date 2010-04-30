using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Diagnostics;

namespace GradersAssistant
{
    class GADatabase
    {
        string filename;

        const string accessConnStrHead = "Provider=Microsoft.ACE.OLEDB.12.0;";

        OleDbConnection dbConnection;

        bool connected;

        struct tables
        {
            public struct Student
            {
                public const string TableName = "Student";
                public const string StudentID = "StudentID";
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string Username = "Username";
                public const string EmailAddress = "EmailAddress";
                public const string ClassSection = "ClassSection";
                public const string StudentSchoolID = "StudentSchoolID";
            }

            public struct Assignment
            {
                public const string TableName = "Assignment";
                public const string AssignmentID = "AssignmentID";
                public const string Name = "Name";
                public const string DueDate = "DueDate";
            }

            public struct Response
            {
                public const string TableName = "Response";
                public const string ResponseID = "ResponseID";
                public const string PointsReceived = "PointsReceived";
                public const string GraderComment = "GraderComment";
                public const string StudentID = "StudentID";
                public const string CriteriaID = "CriteriaID";
            }

            public struct Criteria
            {
                public const string TableName = "Criteria";
                public const string CriteriaID = "CriteriaID";
                public const string Description = "Description";
                public const string Points = "Points";
                public const string ParentCriteriaID = "ParentCriteriaID";
                public const string AssignmentID = "AssignmentID";
            }
        }

        #region GADatabase

        public GADatabase()
        {
            filename = string.Empty;
            connected = false;
            dbConnection = null;
        }

        public GADatabase(string fname)
        {
            filename = fname;
            connected = false;
            dbConnection = null;
        }

        public bool ConnectDB(string fname)
        {
            filename = fname;

            if (System.IO.File.Exists(filename) == false)
            {
                connected = false;
            }
            else
            {
                string connectionString = accessConnStrHead + "Data Source=" + filename;

                try
                {
                    dbConnection = new OleDbConnection(connectionString);
                    dbConnection.Open();
                    connected = true;
                }
                catch
                {
                    connected = false;
                }
            }

            return connected;
        }

        public void CloseDB()
        {
            if (connected)
            {
                dbConnection.Close();
            }
            return;
        }

        private DataSet runQuery(string query)
        {
            DataSet dataSet = new DataSet();
            try
            {
                OleDbCommand command = new OleDbCommand(query, dbConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

                dataAdapter.Fill(dataSet, "results");

                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from the database.\n", ex);
            }
        }

        #endregion

        #region Student

        public Dictionary<int, Student> GetStudents()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            try
           { 
                DataSet studentDataSet = runQuery("SELECT * FROM " + tables.Student.TableName);
                if (studentDataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in studentDataSet.Tables[0].Rows)
                    {
                        int sID = (int)row[tables.Student.StudentID];
                        string sFirstName = (string)row[tables.Student.FirstName];
                        string sLastName = (string)row[tables.Student.LastName];
                        string sUserName = (string)row[tables.Student.Username];
                        string sEmailAddress = (string)row[tables.Student.EmailAddress];
                        int sClassSection = (int)row[tables.Student.ClassSection];
                        string sStudentSchoolID = (string)row[tables.Student.StudentSchoolID];
                        students.Add(sID, new Student(sID, sFirstName, sLastName, sUserName, sEmailAddress, sClassSection, sStudentSchoolID));
                    }
                }
                else
                {
                    Debug.WriteLine("Could not find the student table in results");
                }
            }
            catch
            {
                Debug.WriteLine("The student query failed.");
            }
            return students;
        }

        public int AddStudent(Student student)
        {
            if (student.HasID())
            {
                Debug.WriteLine("You should not add students if they already have an ID assigned.");
                return student.StudentID;
            }
            else
            {
                // We need to insert rather than update because the student has no key.
                string query = String.Format("INSERT INTO {0} (", tables.Student.TableName);
                query += String.Format("{0}, ", tables.Student.FirstName);
                query += String.Format("{0}, ", tables.Student.LastName);
                query += String.Format("{0}, ", tables.Student.Username);
                query += String.Format("{0}, ", tables.Student.EmailAddress);
                query += String.Format("{0}, ", tables.Student.ClassSection);
                query += String.Format("{0}", tables.Student.StudentSchoolID);
                query += ") VALUES (";
                query += String.Format("@{0}, ", tables.Student.FirstName);
                query += String.Format("@{0}, ", tables.Student.LastName);
                query += String.Format("@{0}, ", tables.Student.Username);
                query += String.Format("@{0}, ", tables.Student.EmailAddress);
                query += String.Format("@{0}, ", tables.Student.ClassSection);
                query += String.Format("@{0}", tables.Student.StudentSchoolID);
                query += ");";
                OleDbCommand update = new OleDbCommand(query, dbConnection);
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.FirstName, OleDbType.VarChar)).Value = student.FirstName;// student.FirstName;
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.LastName, OleDbType.VarChar)).Value = student.LastName;
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.Username, OleDbType.VarChar)).Value = student.Username;
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.EmailAddress, OleDbType.VarChar)).Value = student.EmailAddress;
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.ClassSection, OleDbType.Integer)).Value = student.ClassSection;
                update.Parameters.Add(new OleDbParameter("@" + tables.Student.StudentSchoolID, OleDbType.VarChar)).Value = student.StudentSchoolID;
                try
                {
                    update.ExecuteNonQuery();
                }
                catch
                {
                    Debug.WriteLine("Could not insert student.");
                }

                // Now that we inserted the student, we need to get its ID
                query = "SELECT @@IDENTITY;";
                OleDbCommand getID = new OleDbCommand(query, dbConnection);
                int key = student.StudentID;
                try
                {
                    key = (int)getID.ExecuteScalar();
                }
                catch
                {
                    Debug.WriteLine("Could not retrieve student ID.");
                }
                return key;
            }
        }

        public bool SaveStudents(Dictionary<int, Student> students)
        {
            try
            {
                foreach (Student student in students.Values)
                {
                    // AAAAAAAAAGH ACCESS AND OLEDB SUCK. You can used named parameters BUT OleDb doesn't respect them and just relies on order. SUCKS.
                        
                    if (student.HasID())
                    {
                        // We need to update because the student already has a key.
                        string query = String.Format("UPDATE {0} SET ", tables.Student.TableName);
                        query += String.Format("{0} = @{0}, ", tables.Student.FirstName);
                        query += String.Format("{0} = @{0}, ", tables.Student.LastName);
                        query += String.Format("{0} = @{0}, ", tables.Student.Username);
                        query += String.Format("{0} = @{0}, ", tables.Student.EmailAddress);
                        query += String.Format("{0} = @{0}, ", tables.Student.ClassSection);
                        query += String.Format("{0} = @{0} ", tables.Student.StudentSchoolID);
                        query += String.Format("WHERE {0} = @{0};", tables.Student.StudentID);
                        OleDbCommand update = new OleDbCommand(query, dbConnection);
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.FirstName, OleDbType.VarChar)).Value = student.FirstName;// student.FirstName;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.LastName, OleDbType.VarChar)).Value = student.LastName;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.Username, OleDbType.VarChar)).Value = student.Username;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.EmailAddress, OleDbType.VarChar)).Value = student.EmailAddress;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.ClassSection, OleDbType.Integer)).Value = student.ClassSection;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.StudentSchoolID, OleDbType.VarChar)).Value = student.StudentSchoolID;
                        update.Parameters.Add(new OleDbParameter("@" + tables.Student.StudentID, OleDbType.Integer)).Value = student.StudentID;
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        Debug.WriteLine("A student without an ID was found in a student dictionary. That's not good.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not write students to DB.");
                return false;
            }
            return true;
        }

        #endregion

        public CriteriaResponseTree MakeCriteriaResponseTree(int assignmentID)
        {
            CriteriaResponseTree tree = new CriteriaResponseTree();
            string query = String.Format("SELECT * FROM {0} WHERE {1} = {2} AND {3} IS NULL", tables.Criteria.TableName, tables.Criteria.AssignmentID, assignmentID, tables.Criteria.ParentCriteriaID);

            try
            {
                Stack<int> toVisit = new Stack<int>();
                
                //first we get the roots...
                DataSet criteriaDataSet = runQuery(query);
                if(criteriaDataSet.Tables.Count > 0){
                    foreach (DataRow row in criteriaDataSet.Tables[0].Rows)
                    {
                        int cID = (int)row[tables.Criteria.CriteriaID];
                        string cDescription = (string)row[tables.Criteria.Description];
                        int cPoints = (int)row[tables.Criteria.Points];
                        int cParentCriteriaID = -1;
                        int cAssignmentID = (int)row[tables.Criteria.AssignmentID];
                        tree.AddNewNode(new Criteria(cID, cDescription, cPoints, cParentCriteriaID, cAssignmentID));
                        toVisit.Push(cID);
                    }
                } else {
                    Debug.WriteLine("No criteria table found in results.");
                }
                criteriaDataSet.Dispose();

                // ...then we get their CHILDREN! HAHAHAHAHAHA!
                while (toVisit.Count > 0)
                {
                    int parent = toVisit.Pop();
                    query = String.Format("SELECT * FROM {0} WHERE {1} = {2} AND {3} = {4}", tables.Criteria.TableName, tables.Criteria.AssignmentID, assignmentID, tables.Criteria.ParentCriteriaID, parent);
                    criteriaDataSet = runQuery(query);
                    if (criteriaDataSet.Tables.Count > 0)
                    {
                        foreach (DataRow row in criteriaDataSet.Tables[0].Rows)
                        {
                            int cID = (int)row[tables.Criteria.CriteriaID];
                            string cDescription = (string)row[tables.Criteria.Description];
                            int cPoints = (int)row[tables.Criteria.Points];
                            int cParentCriteriaID = (int)row[tables.Criteria.ParentCriteriaID];
                            int cAssignmentID = (int)row[tables.Criteria.AssignmentID];
                            tree.AddNewNode(new Criteria(cID, cDescription, cPoints, cParentCriteriaID, cAssignmentID), parent);
                            toVisit.Push(cID);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No criteria table found in child table results.");
                    }
                    criteriaDataSet.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to fetch criteria for assignment ID = " + assignmentID + "\n");
            }

            return tree;
        }

        public bool FillCriteriaResponseTree(CriteriaResponseTree crt, int assignmentID, int studentID)
        {
            crt.BlankResponses();

            //TODO

            return true;
        }
    }
}
