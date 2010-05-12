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

            public struct GAClass
            {
                public const string TableName = "Class";
                public const string ClassName = "ClassName";
                public const string GraderName = "GraderName";
                public const string NumberOfSections = "NumberOfSections";
                public const string HostType = "HostType";
                public const string Username = "Username";
                public const string FromAddress = "FromAddress";
                public const string AddressExtension = "AddressExtension";
                public const string AlertOnLate = "AlertOnLate";
                public const string SetFullPoints = "SetFullPoints";
                public const string IncludeNames = "IncludeNames";
                public const string IncludeSection = "IncludeSection";
                public const string FormatAsHTML = "FormatAsHTML";
                public const string EmailStudentsNoGrades = "EmailStudentsNoGrades";
                public const string OutputOnlyGraded = "OutputOnlyGraded";
                public const string IncludeAllComments = "IncludeAllComments";
                public const string ShowOutOfTotals = "ShowOutOfTotals";
                public const string DisplayClassStats = "DisplayClassStats";
                public const string DisplayTotalPoints = "DisplayTotalPoints";
            }
        }

        public bool IsConnected()
        {
            return connected;
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

        public bool UpdateStudent(Student student)
        {
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
                return true;
            }
            else
            {
                Debug.WriteLine("A student without an ID was found in a student dictionary. That's not good.");
                return false;
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

        #region GAClass

        public bool AddClass(GAClass gaClass)
        {
                // We need to insert the new class
                string query = String.Format("INSERT INTO {0} (", tables.GAClass.TableName);
                query += String.Format("{0}, ", tables.GAClass.ClassName);
                query += String.Format("{0}, ", tables.GAClass.GraderName);
                query += String.Format("{0}, ", tables.GAClass.NumberOfSections);
                query += String.Format("{0}, ", tables.GAClass.HostType);
                query += String.Format("{0}, ", tables.GAClass.Username);
                query += String.Format("{0}, ", tables.GAClass.FromAddress);
                query += String.Format("{0}, ", tables.GAClass.AddressExtension);
                query += String.Format("{0}, ", tables.GAClass.AlertOnLate);
                query += String.Format("{0}, ", tables.GAClass.SetFullPoints);
                query += String.Format("{0}, ", tables.GAClass.IncludeNames);
                query += String.Format("{0}, ", tables.GAClass.IncludeSection);
                query += String.Format("{0}, ", tables.GAClass.FormatAsHTML);
                query += String.Format("{0}, ", tables.GAClass.EmailStudentsNoGrades);
                query += String.Format("{0}, ", tables.GAClass.OutputOnlyGraded);
                query += String.Format("{0}, ", tables.GAClass.IncludeAllComments);
                query += String.Format("{0}, ", tables.GAClass.ShowOutOfTotals);
                query += String.Format("{0}, ", tables.GAClass.DisplayClassStats);
                query += String.Format("{0}, ", tables.GAClass.DisplayTotalPoints);
                query += ") VALUES (";
                query += String.Format("{0}, ", tables.GAClass.ClassName);
                query += String.Format("{0}, ", tables.GAClass.GraderName);
                query += String.Format("{0}, ", tables.GAClass.NumberOfSections);
                query += String.Format("{0}, ", tables.GAClass.HostType);
                query += String.Format("{0}, ", tables.GAClass.Username);
                query += String.Format("{0}, ", tables.GAClass.FromAddress);
                query += String.Format("{0}, ", tables.GAClass.AddressExtension);
                query += String.Format("{0}, ", tables.GAClass.AlertOnLate);
                query += String.Format("{0}, ", tables.GAClass.SetFullPoints);
                query += String.Format("{0}, ", tables.GAClass.IncludeNames);
                query += String.Format("{0}, ", tables.GAClass.IncludeSection);
                query += String.Format("{0}, ", tables.GAClass.FormatAsHTML);
                query += String.Format("{0}, ", tables.GAClass.EmailStudentsNoGrades);
                query += String.Format("{0}, ", tables.GAClass.OutputOnlyGraded);
                query += String.Format("{0}, ", tables.GAClass.IncludeAllComments);
                query += String.Format("{0}, ", tables.GAClass.ShowOutOfTotals);
                query += String.Format("{0}, ", tables.GAClass.DisplayClassStats);
                query += String.Format("{0}, ", tables.GAClass.DisplayTotalPoints);
                query += ");";
                OleDbCommand update = new OleDbCommand(query, dbConnection);
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.ClassName, OleDbType.VarChar)).Value = gaClass.ClassName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.GraderName, OleDbType.VarChar)).Value = gaClass.GraderName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.NumberOfSections, OleDbType.VarChar)).Value = gaClass.NumberOfSections ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.HostType, OleDbType.Integer)).Value = gaClass.HostType ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.Username, OleDbType.VarChar)).Value = gaClass.UserName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.FromAddress, OleDbType.VarChar)).Value = gaClass.FromAddress ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.AddressExtension, OleDbType.VarChar)).Value = gaClass.AddressExtension ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.AlertOnLate, OleDbType.Boolean)).Value = gaClass.AlertOnLate ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.SetFullPoints, OleDbType.Boolean)).Value = gaClass.SetFullPoints ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeNames, OleDbType.Boolean)).Value = gaClass.IncludeNames ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeSection, OleDbType.Boolean)).Value = gaClass.IncludeSections ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.FormatAsHTML, OleDbType.Boolean)).Value = gaClass.FormatAsHTML ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.EmailStudentsNoGrades, OleDbType.Boolean)).Value = gaClass.EmailStudentsNoGrade ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.OutputOnlyGraded, OleDbType.Boolean)).Value = gaClass.OutputOnlyGraded ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeAllComments, OleDbType.Boolean)).Value = gaClass.IncludeAllComments ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.ShowOutOfTotals, OleDbType.Boolean)).Value = gaClass.ShowOutOfTotals ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.DisplayClassStats, OleDbType.Boolean)).Value = gaClass.DisplayClassStats ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.DisplayTotalPoints, OleDbType.Boolean)).Value = gaClass.DisplayTotalPoints ;
                try
                {
                    update.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    Debug.WriteLine("Could not insert class into the database.");
                    return false;
                }
        }

        public bool UpdateClass(GAClass gaClass)
        {
                // We need to update the class values
                string query = String.Format("UPDATE {0} SET ", tables.GAClass.TableName);
                query += String.Format("{0} = @{0}, ", tables.GAClass.ClassName);
                query += String.Format("{0} = @{0}, ", tables.GAClass.GraderName);
                query += String.Format("{0} = @{0}, ", tables.GAClass.NumberOfSections);
                query += String.Format("{0} = @{0}, ", tables.GAClass.HostType);
                query += String.Format("{0} = @{0}, ", tables.GAClass.Username);
                query += String.Format("{0} = @{0}, ", tables.GAClass.FromAddress);
                query += String.Format("{0} = @{0}, ", tables.GAClass.AddressExtension);
                query += String.Format("{0} = @{0}, ", tables.GAClass.AlertOnLate);
                query += String.Format("{0} = @{0}, ", tables.GAClass.SetFullPoints);
                query += String.Format("{0} = @{0}, ", tables.GAClass.IncludeNames);
                query += String.Format("{0} = @{0}, ", tables.GAClass.IncludeSection);
                query += String.Format("{0} = @{0}, ", tables.GAClass.FormatAsHTML);
                query += String.Format("{0} = @{0}, ", tables.GAClass.EmailStudentsNoGrades);
                query += String.Format("{0} = @{0}, ", tables.GAClass.OutputOnlyGraded);
                query += String.Format("{0} = @{0}, ", tables.GAClass.IncludeAllComments);
                query += String.Format("{0} = @{0}, ", tables.GAClass.ShowOutOfTotals);
                query += String.Format("{0} = @{0}, ", tables.GAClass.DisplayClassStats);
                query += String.Format("{0} = @{0}, ", tables.GAClass.DisplayTotalPoints);
                query += ";";
                OleDbCommand update = new OleDbCommand(query, dbConnection);
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.ClassName, OleDbType.VarChar)).Value = gaClass.ClassName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.GraderName, OleDbType.VarChar)).Value = gaClass.GraderName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.NumberOfSections, OleDbType.VarChar)).Value = gaClass.NumberOfSections ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.HostType, OleDbType.VarChar)).Value = gaClass.HostType ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.Username, OleDbType.VarChar)).Value = gaClass.UserName ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.FromAddress, OleDbType.VarChar)).Value = gaClass.FromAddress ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.AddressExtension, OleDbType.VarChar)).Value = gaClass.AddressExtension ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.AlertOnLate, OleDbType.VarChar)).Value = gaClass.AlertOnLate ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.SetFullPoints, OleDbType.VarChar)).Value = gaClass.SetFullPoints ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeNames, OleDbType.VarChar)).Value = gaClass.IncludeNames ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeSection, OleDbType.VarChar)).Value = gaClass.IncludeSections ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.FormatAsHTML, OleDbType.VarChar)).Value = gaClass.FormatAsHTML ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.EmailStudentsNoGrades, OleDbType.VarChar)).Value = gaClass.EmailStudentsNoGrade ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.OutputOnlyGraded, OleDbType.VarChar)).Value = gaClass.OutputOnlyGraded ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.IncludeAllComments, OleDbType.VarChar)).Value = gaClass.IncludeAllComments ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.ShowOutOfTotals, OleDbType.VarChar)).Value = gaClass.ShowOutOfTotals ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.DisplayClassStats, OleDbType.VarChar)).Value = gaClass.DisplayClassStats ;
                update.Parameters.Add(new OleDbParameter("@" + tables.GAClass.DisplayTotalPoints, OleDbType.VarChar)).Value = gaClass.DisplayTotalPoints ;
                try
                {
                    update.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    Debug.WriteLine("Could not update class values in the database.");
                    return false;
                }
        }

        public GAClass GetClass()
        {
            try
            {
                DataSet classDataSet = runQuery("SELECT * FROM " + tables.GAClass.TableName);
                if (classDataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in classDataSet.Tables[0].Rows)
                    {
                        string cClassName = (string)row[tables.GAClass.ClassName];
                        string cGraderName = (string)row[tables.GAClass.GraderName];
                        int cNumberOfSections = (int)row[tables.GAClass.NumberOfSections];
                        int cHostType = (int)row[tables.GAClass.HostType];
                        string cUserName = (string)row[tables.GAClass.Username];
                        string cFromAddress = (string)row[tables.GAClass.FromAddress];
                        string cAddressExtension = (string)row[tables.GAClass.AddressExtension];
                        bool cAlertOnLate = (bool)row[tables.GAClass.AlertOnLate];
                        bool cSetFullPoints = (bool)row[tables.GAClass.SetFullPoints];
                        bool cIncludeNames = (bool)row[tables.GAClass.IncludeNames];
                        bool cIncludeSection = (bool)row[tables.GAClass.IncludeSection];
                        bool cFormatAsHTML = (bool)row[tables.GAClass.FormatAsHTML];
                        bool cEmailStudentsNoGrades = (bool)row[tables.GAClass.EmailStudentsNoGrades];
                        bool cOutputOnlyGraded = (bool)row[tables.GAClass.OutputOnlyGraded];
                        bool cIncludeAllComments = (bool)row[tables.GAClass.IncludeAllComments];
                        bool cShowOutOfTotals = (bool)row[tables.GAClass.ShowOutOfTotals];
                        bool cDisplayClassStats = (bool)row[tables.GAClass.DisplayClassStats];
                        bool cDisplayTotalPoints = (bool)row[tables.GAClass.DisplayTotalPoints];

                        return new GAClass(cClassName, cGraderName, cNumberOfSections, cHostType, cUserName, cFromAddress, cAddressExtension, cAlertOnLate, cSetFullPoints, cIncludeNames, cIncludeSection, cFormatAsHTML, cEmailStudentsNoGrades, cOutputOnlyGraded, cIncludeAllComments, cShowOutOfTotals, cDisplayClassStats, cDisplayTotalPoints);
                    }
                }
                else
                {
                    Debug.WriteLine("Could not find the class results");
                    return new GAClass();
                }
                return new GAClass();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from the database.\n", ex);
            }
        }


        #endregion

        #region Criteria

        public Assignment GetAssignment(int assignmentID)
        {
            Assignment assignment = new Assignment();

            string assignmentQuery = String.Format("SELECT * FROM {0} WHERE {1} = {2}", tables.Assignment.TableName, tables.Assignment.AssignmentID, assignmentID);

            try
            {
                DataSet assignmentDataSet = runQuery(assignmentQuery);
                if (assignmentDataSet.Tables.Count > 0)
                {
                    if (assignmentDataSet.Tables[0].Rows.Count > 0)
                    {
                        assignment = new Assignment(assignmentID, (string)assignmentDataSet.Tables[0].Rows[0][tables.Assignment.Name], (DateTime)assignmentDataSet.Tables[0].Rows[0][tables.Assignment.DueDate]);

                        string criteriaQuery = String.Format("SELECT * FROM {0} WHERE {1} = {2} AND {3} IS NULL", tables.Criteria.TableName, tables.Criteria.AssignmentID, assignmentID, tables.Criteria.ParentCriteriaID);

                        try
                        {
                            Stack<int> toVisit = new Stack<int>();

                            //first we get the roots...
                            DataSet criteriaDataSet = runQuery(criteriaQuery);
                            if (criteriaDataSet.Tables.Count > 0)
                            {
                                foreach (DataRow row in criteriaDataSet.Tables[0].Rows)
                                {
                                    int cID = (int)row[tables.Criteria.CriteriaID];
                                    string cDescription = (string)row[tables.Criteria.Description];
                                    int cPoints = 0;
                                    if (!row.IsNull(tables.Criteria.Points))
                                    {
                                        cPoints = (int)row[tables.Criteria.Points];
                                    }
                                    assignment.Rubric.AddNewNode(new Criteria(cID, cDescription, cPoints));
                                    toVisit.Push(cID);
                                }
                            }
                            else
                            {
                                Debug.WriteLine("No criteria table found in results.");
                            }
                            criteriaDataSet.Dispose();

                            // ...then we get their CHILDREN! HAHAHAHAHAHA!
                            while (toVisit.Count > 0)
                            {
                                int parent = toVisit.Pop();
                                criteriaQuery = String.Format("SELECT * FROM {0} WHERE {1} = {2} AND {3} = {4}", tables.Criteria.TableName, tables.Criteria.AssignmentID, assignmentID, tables.Criteria.ParentCriteriaID, parent);
                                criteriaDataSet = runQuery(criteriaQuery);
                                if (criteriaDataSet.Tables.Count > 0)
                                {
                                    foreach (DataRow row in criteriaDataSet.Tables[0].Rows)
                                    {
                                        int cID = (int)row[tables.Criteria.CriteriaID];
                                        string cDescription = (string)row[tables.Criteria.Description];
                                        int cPoints = 0;
                                        if (!row.IsNull(tables.Criteria.Points))
                                        {
                                            cPoints = (int)row[tables.Criteria.Points];
                                        }
                                        assignment.Rubric.AddNewNode(new Criteria(cID, cDescription, cPoints), parent);
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
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not load assignment from DB.");
            }

            return assignment;
        }

        #endregion

        #region Response

        public ResponseList GetResponseList(int assignmentID, int studentID)
        {
            ResponseList responseList = new ResponseList();

            responseList.StudentID = studentID;

            responseList.AssignmentID = assignmentID;

            // Join the Criteria and Response tables on the criteria id
            string query = String.Format("SELECT R.{0}, R.{1}, R.{2}, R.{3} ", tables.Response.ResponseID, tables.Response.CriteriaID, tables.Response.PointsReceived, tables.Response.GraderComment);
            query += String.Format("FROM {0} AS R, {1} AS C ", tables.Response.TableName, tables.Criteria.TableName);
            query += String.Format("WHERE R.{0} = C.{1} ", tables.Response.CriteriaID, tables.Criteria.CriteriaID);
            query += String.Format("AND {0} = {1} ", tables.Criteria.AssignmentID, assignmentID);
            query += String.Format("AND {0} = {1} ", tables.Response.StudentID, studentID);

            DataSet responseSet = runQuery(query);

            if(responseSet.Tables.Count > 0){
                foreach (DataRow row in responseSet.Tables[0].Rows)
                {
                    int responseID = (int)row[tables.Response.ResponseID];
                    int criteriaID = (int)row[tables.Response.CriteriaID];
                    int pointsReceived = (int)row[tables.Response.PointsReceived];
                    string graderComment = row[tables.Response.GraderComment].ToString();
                    responseList.Responses.Add(criteriaID, new Response(responseID, pointsReceived, graderComment));
                }
            }

            return responseList;
        }

        public Dictionary<int, ResponseList> GetAssignmentResponses(int assignmentID)
        {
            Dictionary<int, ResponseList> assignmentResponses = new Dictionary<int,ResponseList>();

            Dictionary<int, Student> students = GetStudents();

            foreach (int studentID in students.Keys)
            {
                assignmentResponses.Add(studentID, GetResponseList(assignmentID, studentID));
            }

            return assignmentResponses;
        }

        #endregion
    }
}
