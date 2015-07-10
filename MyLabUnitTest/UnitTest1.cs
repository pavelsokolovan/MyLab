using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
//using System.Xml;
using MyLabClient;
using MyLabService;

namespace MyLabUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public string tubeCode = "TESTCODE";
        
        #region TubeCollector_Add

        [TestMethod]
        public void TubeCollector_Add_WhenRowAdded_RowExistInDB()
        {
            // Add new row in Tube table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            string tubeCode = "TUBE1";
            string tubeName = "Tube 1";
            int tubeVolume = 1;            
            tubeCollector.Add(tubeCode, tubeName, tubeVolume);
            
            // Find new row in Tube table
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with tubeCode in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);

            Assert.IsTrue(findRow != null, "New Tube row hasn't been added to DB");

            // Delete new row from DB if it is exist
            if (findRow != null)
            {
                findRow.Delete();
                // Update Tube table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);                
            }
            // Close connection to DB
            dbAccessProvider.CloseConnection();
        }
        
        [TestMethod]
        public void TubeCollector_Add_WhenRowAdded_ReturnTrue()
        {
            // Add new row in Tube table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            string tubeCode = "TUBE2";
            string tubeName = "Tube 2";
            int tubeVolume = 2;
            bool expected = true;
            bool actual = tubeCollector.Add(tubeCode, tubeName, tubeVolume);

            Assert.IsTrue(actual = expected, "New Tube row hasn't been added to DB");

            // Delete new row from Tube table if it is exist
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with tubeCode in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);
            // Delete new row from DB
            if (findRow != null)
            {
                findRow.Delete();
                // Update Tube table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);
            }
            // Close connection to DB
            dbAccessProvider.CloseConnection();
        }
        #endregion

        #region TubeCollector_Contains

        [TestMethod]
        public void TubeCollector_Contains_WhenCodeExist_ReturnTrue()
        { 
            // Add new row in Tube table if it isn't exist in DB
            // Open connection to DB
            string commandText = "select * from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();            
            // Find row with tubeCode in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);
            if (findRow == null)
            {
                // Create new Row
                DataRow newRow = dbAccessProvider.DataSet.Tables[tableName].NewRow();
                // Fill new Row with data
                //newRow["TUBE_ID"] = ;
                newRow["TUBE_CODE"] = tubeCode;
                newRow["TUBE_NAME"] = "Testing row";
                newRow["TUBE_VOLUME"] = 55;
                // Add new Row to DataRow collection            
                dbAccessProvider.DataSet.Tables[tableName].Rows.Add(newRow);
                // Update Table in DB
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);

                // Check if row was added. If not - fail test            
                if ((findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode)) == null)
                    Assert.Fail("No ability to add testing row in DB");
            }

            // Check Contains method
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            bool actual = tubeCollector.Contains(tubeCode);
            Assert.IsTrue(actual, "Table isn't contain code");

            // Delete new row from DB
            if (findRow != null)
            {
                findRow.Delete();
                // Update Tube table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);
            }
            // Close connection to DB
            dbAccessProvider.CloseConnection();
        }

        [TestMethod]
        public void TubeCollector_Contains_WhenCodeNotExist_ReturnFalse()
        {
            // Check if code is exist in DB. If exist - delete it
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with tubeCode in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);
            // If code is exist in DB - delete it
            if (findRow != null)
            {
                findRow.Delete();
                // Update Tube table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);
            }            
            // Close connection to DB
            dbAccessProvider.CloseConnection();
            
            // Check Contains method
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            bool actual = tubeCollector.Contains(tubeCode);
            Assert.IsFalse(actual, "Table is contain code");
        }
        #endregion
    }
}
