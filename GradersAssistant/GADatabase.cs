using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

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
                OleDbCommand command = new OleDbCommand("SELECT * FROM testing", dbConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

                dbConnection.Open();
                dataAdapter.Fill(dataSet); // maybe additionally a "testing" argument

                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from the database.\n", ex);
            }
        }

        // Somthing like this for each query command. Use the above runQuery command and don't return a DataSet!
        //public GAClass GetClass()
        //{
        //}

        public Dictionary<int, Student> GetStudents()
        {
            DataSet studentDataSet = runQuery("SELECT * FROM " + tables.Student.TableName);
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            foreach (DataRow row in studentDataSet.Tables[tables.Student.TableName].Rows)
            {
                //studentDataSet.Tables[tables.Student.TableName].Rows[0][tables.Student.StudentID];
            }
        }

        public void TestDB()
        {
            DataSet dataSet = runQuery("SELECT * FROM testng");

            System.Windows.Forms.MessageBox.Show("Found " + dataSet.Tables.Count.ToString() + " tables.");
            return;
        }
    }
}