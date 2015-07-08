using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLabClient;

namespace MyLabUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TubeCollector_Add_WhenRowAdded_ReturnTrue()
        {
            // Add new row in Tube table
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            string tubeCode = "TUBE1";
            string tubeName = "Tube 1";
            int tubeVolume = 10;
            bool expected = true;
            bool actual = tubeCollector.Add(tubeCode, tubeName, tubeVolume);
            Assert.IsTrue(actual = expected, "New Tube row hasn't been added to DB");

            // Delete new row from Tube table

        }
    }
}
