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
            // Connection to DB
            SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;" +
                @"Initial Catalog=MyLabDB1;" +
                //@"AttachDbFilename='C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MyLabDB1.mdf';" +   
                @"Integrated Security=sspi;Connect Timeout=30;");
            //@"User Instance=true;");
            connection.Open();

            // Create DataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "select * from TUBE", connection);
            // Set property for download primery keys
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Create CommandBuilder
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            // Create DataSet
            DataSet dataSet = new DataSet();

            // Fill DataSet
            dataAdapter.Fill(dataSet, "Table");

            // Check if new code is exist in DB            
            DataRow findRow = dataSet.Tables["Table"].Rows.Find(code);  // Try to find row with new code            
            if (findRow == null)    // new code isn't exist in DB - add new row
            {
                // Create new Row
                DataRow newRow = dataSet.Tables["Table"].NewRow();
                // Fill new Row with data
                //newRow["TUBE_ID"] = ;
                newRow["TUBE_CODE"] = code;
                newRow["TUBE_NAME"] = name;
                newRow["TUBE_VOLUME"] = volume;

                // Add new Row to DataRow collection            
                dataSet.Tables["Table"].Rows.Add(newRow);

                // Update Table in DB
                dataAdapter.Update(dataSet, "Table");

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

        /* Method to get collection of tube codes
        public string GetTubeCodes()
        {
            string[] array = new string[tubes.Count];
            Console.WriteLine(tubes.Count);
            int i = 0;
            foreach(string item in tubes.Keys)
            {
                array[i] = item;
            }
            string st2 = array[0];
            Console.WriteLine(st2);
            return "yee";
        }*/

        /*/ TEMP
        public string[] GetString(string st)
        {
            /*Dictionary<string, string> dic = new Dictionary<string,string>;
            dic.Add(st, st);
            return new string[] {st};
        }*/
    }
}
