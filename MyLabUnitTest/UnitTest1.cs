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
        // Data for testing
        public string tubeCode = "TESTCODE";
        public string tubeName = "Tube 1";
        public int tubeVolume = 1;
        public string tubeNameToUpdate = "Tube 1 - updated";
        public int tubeVolumeToUpdate = 9;
        
        #region TubeCollector_Add

        [TestMethod]
        public void TubeCollector_Add_WhenRowAdded_RowExistInDB()
        {
            // Add new row in table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();          
            tubeCollector.Add(tubeCode, tubeName, tubeVolume);
            
            // Find new row in table
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
            // Add new row in table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            bool expected = true;
            bool actual = tubeCollector.Add(tubeCode, tubeName, tubeVolume);

            Assert.IsTrue(actual == expected, "New Tube row hasn't been added to DB");

            // Delete new row from table if it is exist
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with Code in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);
            // Delete new row from DB
            if (findRow != null)
            {
                findRow.Delete();
                // Update table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);
            }
            // Close connection to DB
            dbAccessProvider.CloseConnection();
        }

        [TestMethod]
        public void TubeCollector_Add_WhenRowAlreadyExist_ReturnFalse()
        {
            // Add new row in table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            bool expected = false;
            tubeCollector.Add(tubeCode, tubeName, tubeVolume);
            // Try to add row with the same code second time in table
            bool actual = tubeCollector.Add(tubeCode, tubeName, tubeVolume);

            Assert.IsTrue(actual == expected, "New Tube row hasn't been added to DB");

            // Delete new row from table if it is exist
            // Open connection to DB
            string commandText = "select TUBE_CODE from TUBE";
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with Code in dataSet
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);
            // Delete new row from DB
            if (findRow != null)
            {
                findRow.Delete();
                // Update table
                dbAccessProvider.DataAdapter.Update(dbAccessProvider.DataSet, tableName);
            }
            // Close connection to DB
            dbAccessProvider.CloseConnection();
        }
        #endregion

        #region TubeCollector_Update

        [TestMethod]
        public void TubeCollector_Update_WhenRowUpdated_RowHasNewData()
        {
            // Add new row in table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            tubeCollector.Add(tubeCode, tubeName, tubeVolume);
            // Update new row in table
            tubeCollector.Update(tubeCode, tubeNameToUpdate, tubeVolumeToUpdate);

            // Find Updated row in table
            // Open connection to DB
            string commandText = "select * from TUBE where TUBE_CODE='";
            commandText = string.Concat(commandText, tubeCode, "'");
            string tableName = "Table";
            DBAccessProvider dbAccessProvider = new DBAccessProvider(commandText, tableName);
            dbAccessProvider.OpenConnection();
            // Find row with tubeCode in dataSet
            string actualTubeName = (string)dbAccessProvider.DataSet.Tables[tableName].Rows[0]["TUBE_NAME"];
            int actualTubeVolume = (int)dbAccessProvider.DataSet.Tables[tableName].Rows[0]["TUBE_VOLUME"];

            // Assert for checking tubeName
            Assert.AreEqual(tubeNameToUpdate, actualTubeName, "Updating of Name column is not correct");
            // Assert for checking tubeVolume
            Assert.AreEqual(tubeVolumeToUpdate, actualTubeVolume, "Updating of Volume column is not correct");

            // Delete new row from DB if it is exist            
            DataRow findRow = dbAccessProvider.DataSet.Tables[tableName].Rows.Find(tubeCode);   // Find row with tubeCode in dataSet
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
