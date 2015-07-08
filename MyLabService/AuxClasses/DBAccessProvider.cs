using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    public class DBAccessProvider
    {
        # region Fields and Properties

        private SqlConnection connection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;
        private SqlCommandBuilder commandBuilder;
        private string commandText;
        private string tableName;

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public DataSet DataSet
        {
            get
            {
                return dataSet;
            }
        }

        public SqlDataAdapter DataAdapter
        {
            get
            {
                return dataAdapter;
            }
        }

        public SqlCommandBuilder CommandBuilder
        {
            get
            {
                return commandBuilder;
            }
        }

        #endregion
    
        // Constructor
        public DBAccessProvider(string commandText, string tableName)
        {
            this.commandText = commandText;
            this.tableName = tableName;
        }

        // Method for Open Sql Connection
        public void OpenConnection()
        {
            // Connection to DB
            connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;" +
                @"Initial Catalog=MyLabDB1;" +
                //@"AttachDbFilename='C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MyLabDB1.mdf';" +   
                @"Integrated Security=sspi;Connect Timeout=30;");
            //@"User Instance=true;");
            connection.Open();

            // Create DataAdapter
            dataAdapter = new SqlDataAdapter(commandText, connection);
            // Set property for download primery keys
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Create CommandBuilder
            commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Create DataSet
            dataSet = new DataSet();

            // Fill DataSet
            dataAdapter.Fill(dataSet, tableName);
        }

        // Method for Close Sql Connection
        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
