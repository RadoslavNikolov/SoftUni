namespace AirConditionerTestingSystem.Test
{
    using Core;
    using Data;
    using Helpers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
    {
        private IConditionerController controller;
        private IConditionerDataBase db;

        [TestInitialize]
        public void DataBaseInitializing()
        {
            this.db = new ConditionerDataBase();
            this.controller = new ConditionerController(this.db);
        }

        [TestMethod]
        public void TestStatus_Valid_ShouldSuccess()
        {
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX500", "B", 1000);
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX200", "B", 1000);
            this.controller.TestAirConditioner("Toshiba", "EX1000");
            this.controller.TestAirConditioner("Toshiba", "EX500");
            var expectedOutput = string.Format(Constants.STATUS, 66.67);

            var result = this.controller.Status();
            
            Assert.AreEqual(expectedOutput,result);
        }
    }
}