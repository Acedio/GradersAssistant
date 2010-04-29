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
                public const string Section = "Section";
                public const string StudentSchoolID = "StudentSchoolID";
            }
        }

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
                        int sSection = (int)row[tables.Student.Section];
                        string sStudentSchoolID = (string)row[tables.Student.StudentSchoolID];
                        students.Add(sID, new Student(sID, sFirstName, sLastName, sUserName, sEmailAddress, sSection, sStudentSchoolID));
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

        public bool SaveStudents(Dictionary<int, Student> students)
        {
            try
            {
                foreach (Student student in students.Values)
                {
                    string query = String.Format("UPDATE {0} SET ", tables.Student.TableName);
                    query += String.Format("{0} = a{0}, ", tables.Student.FirstName);
                    //query += String.Format("{0} = a{0}, ", tables.Student.FirstName, student.FirstName+"lol");
                    //query += String.Format("{0} = a{0}, ", tables.Student.LastName, student.LastName);
                    //query += String.Format("{0} = a{0}, ", tables.Student.Username, student.Username);
                    //query += String.Format("{0} = a{0}, ", tables.Student.EmailAddress, student.EmailAddress);
                    //query += String.Format("{0} = a{0}, ", tables.Student.Section, student.Section);
                    //query += String.Format("{0} = a{0} " , tables.Student.StudentSchoolID, student.StudentSchoolID);
                    query += String.Format("WHERE {0} = a{0}", tables.Student.StudentID, student.StudentID);
                    OleDbCommand update = new OleDbCommand(query, dbConnection);
                    update.Parameters.Add(new OleDbParameter("a" + tables.Student.FirstName, OleDbType.VarChar)).Value = student.FirstName + "lol";
                    update.ExecuteNonQuery();
                }
            }
            catch
            {
                Debug.WriteLine("Could not write students to DB.");
                return false;
            }
            return true;
        }

        public void TestDB()
        {
            DataSet dataSet = runQuery("SELECT * FROM testng");

            System.Windows.Forms.MessageBox.Show("Found " + dataSet.Tables.Count.ToString() + " tables.");
            return;
        }
    }
}