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
        // Method to Add new row
        // Return true - if new row was added
        // Return false - if new row wasn't added, already exists
        public bool Add(string code, string name, int volume)
        {
            // Open connection to DB
            string commandText = "select * from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
   
            // Check if new code is exist in DB            
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(code);  // Try to find row with new code            
            if (findRow == null)    // new code isn't exist in DB - add new row
            {
                // Create new Row
                DataRow newRow = dbAccessProvider.DataSet.Tables[tableName].NewRow();
                // Fill new Row with data
                //newRow["TUBE_ID"] = ;
                newRow["TUBE_CODE"] = code;
                newRow["TUBE_NAME"] = name;
                newRow["TUBE_VOLUME"] = volume;

                // Add new Row to DataRow collection            
                dbAccessProvider.DataSet.Tables["Table"].Rows.Add(newRow);

                // Update Table in DB
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);

                // Close connection to DB
                dbAccessProvider.CloseConnection();

                return true;
            }
            else     // new code is already exist in DB - don't add new row
            {
                // Close connection to DB
                dbAccessProvider.CloseConnection();
                return false;
            }
        }

        // Method to Update row
        // Return true - if row was updated
        // Return false - if row wasn't found
        public bool Update(string code, string name, int volume)
        {
            // Open connection to DB
            string commandText = "select * from TUBE where TUBE_CODE='";
            commandText = String.Concat(commandText, code, "'");
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();

            // Check if row is exist in DB
            if (dbAccessProvider.DataSet.Tables[tableName].Rows.Count > 0)    // row is exist in DB - update row
            {
                // Update data in row
                dbAccessProvider.DataSet.Tables[tableName].Rows[0]["TUBE_NAME"] = name;
                dbAccessProvider.DataSet.Tables[tableName].Rows[0]["TUBE_VOLUME"] = volume;

                // Update Table in DB
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);

                // Close connection to DB
                dbAccessProvider.CloseConnection();

                return true;
            }
            else     // row isn't exist in DB - nothing to update
            {
                // Close connection to DB
                dbAccessProvider.CloseConnection();
                return false;
            }
        }

        // Method to check if code is presented in DB
        // Return true - if code is presented in DB
        // Return false - if code isn't presented in DB
        public bool Contains(string code)
        {
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();

            // Try to find code in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(code);

            // Close connection to DB
            dbAccessProvider.CloseConnection();

            return (findRow != null);
        }
    }
}
