using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService.Services
{
    public class TubeCollector: ITubeCollector
    {
        // Method to Add new tube
        // Return true - if new row was added
        // Return false - if new row wasn't added
        public bool Add(string code, string name, int volume)
        {
            // Open connection to DB
            SqlConnection connection = this.CreateSqlConnection();
            connection.Open();

            // Create DataSet with data from DB
            DataSet dataSet;
            SqlDataAdapter dataAdapter;
            string tableName = "Table";
            GetDataSet("select * from TUBE", connection, tableName, out dataSet, out dataAdapter);
   
            // Check if new code is exist in DB            
            DataRow findRow = dataSet.Tables[tableName].Rows.Find(code);  // Try to find row with new code            
            if (findRow == null)    // new code isn't exist in DB - add new row
            {
                // Create new Row
                DataRow newRow = dataSet.Tables[tableName].NewRow();
                // Fill new Row with data
                //newRow["TUBE_ID"] = ;
                newRow["TUBE_CODE"] = code;
                newRow["TUBE_NAME"] = name;
                newRow["TUBE_VOLUME"] = volume;

                // Add new Row to DataRow collection            
                dataSet.Tables["Table"].Rows.Add(newRow);

                // Update Table in DB
                dataAdapter.Update(dataSet, tableName);

                // Close
                connection.Close(); 

                // Check if new row was added
                if ((findRow = dataSet.Tables["Table"].Rows.Find(code)) != null)
                    return true;
                else
                    return false;
            }
            else     // new code is already exist in DB - don't add new row
            {
                // Close
                connection.Close();
                return false;
            }
        }

        // Method to checks if code is presented in DB
        // Return true - if code is presented in DB
        // Return false - if code isn't presented in DB
        public bool Contains(string code)
        {
            // Open connection to DB
            SqlConnection connection = this.CreateSqlConnection();
            connection.Open();

            // Create DataSet with data from DB
            DataSet dataSet;
            SqlDataAdapter dataAdapter;
            string tableName = "Table";
            GetDataSet("select TUBE_CODE from TUBE", connection, tableName, out dataSet, out dataAdapter);

            // Try to find code in dataSet
            DataRow findRow = dataSet.Tables["Table"].Rows.Find(code);

            // Close connection
            connection.Close();

            return (findRow != null);
        }

        // Method Create Sql Connection
        // Return SqlConnection instance
        private SqlConnection CreateSqlConnection()
        {
            // Connection to DB
            SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;" +
                @"Initial Catalog=MyLabDB1;" +
                //@"AttachDbFilename='C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MyLabDB1.mdf';" +   
                @"Integrated Security=sspi;Connect Timeout=30;");
            //@"User Instance=true;");
                        
            return connection;
        }

        // Method Get DataSet
        private void GetDataSet(string commandText, SqlConnection connection, string tableName, out DataSet dataSet, out SqlDataAdapter dataAdapter)
        {
            // Create DataAdapter
            dataAdapter = new SqlDataAdapter(
                commandText, connection);
            // Set property for download primery keys
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Create CommandBuilder
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            // Create DataSet
            dataSet = new DataSet();

            // Fill DataSet
            dataAdapter.Fill(dataSet, tableName);
        }
    }
}
