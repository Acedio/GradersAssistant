using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace GradersAssistant
{
    class GADatabase
    {
        private const string accessConnStrHead = "Provider=Microsoft.ACE.OLEDB.12.0;";

        OleDbConnection dbConnection = null;

        public void ConnectDB(string filename)
        {
            if (System.IO.File.Exists(filename) == false)
            {
                System.Windows.Forms.MessageBox.Show("Could not find file \"" + filename + "\"." + System.IO.Directory.GetCurrentDirectory());
                return;
            }

            string connectionString = accessConnStrHead + "Data Source=" + filename;

            try
            {
                dbConnection = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to connect to DB \"" + filename + "\".\n" + ex.Message);
                return;
            }
        }

        public void CloseDB()
        {
            dbConnection.Close();
            return;
        }

        public void TestDB()
        {
            DataSet dataSet = new DataSet();
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM testing", dbConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

                dbConnection.Open();
                dataAdapter.Fill(dataSet); // maybe additionally a "testing" argument
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to retrieve data from the database.\n" + ex.Message);
                return;
            }

            System.Windows.Forms.MessageBox.Show("Found " + dataSet.Tables.Count.ToString() + " tables.");
            return;
        }
    }
}