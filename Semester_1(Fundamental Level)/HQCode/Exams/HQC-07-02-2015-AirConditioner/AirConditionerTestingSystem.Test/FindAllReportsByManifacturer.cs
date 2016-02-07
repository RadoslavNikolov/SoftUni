namespace AirConditionerTestingSystem.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Data;
    using Helpers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class FindAllReportsByManifacturer
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
        public void TetsFindAllReports_NoEntryReports_ShouldReturnProperMessage()
        {
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            var expectedOutput = Constants.Noreports;

            var result = this.controller.FindAllReportsByManufacturer("Toshiba");

            Assert.AreEqual(this.db.GetAirConditionersCount(),1);
            Assert.AreEqual(this.db.GetReportsCount(),0);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void TetsFindAllReports_ExistingEntries_ShouldReturnProperMessage()
        {
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            this.controller.TestAirConditioner("Toshiba", "EX1000");
            List<Report> reports = this.db.GetReportsByManufacturer("Toshiba");
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(string.Format("Reports from {0}:", "Toshiba"));
            expectedOutput.Append(string.Join(Environment.NewLine, reports));

 
            var result = this.controller.FindAllReportsByManufacturer("Toshiba");

            Assert.AreEqual(this.db.GetAirConditionersCount(), 1);
            Assert.AreEqual(this.db.GetReportsCount(), 1);
            Assert.AreEqual(expectedOutput.ToString(), result.ToString());
        }

        [TestMethod]
        public void TetsFindAllReports_ExistingEntriesOrdered_ShouldReturnProperMessage()
        {
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            this.controller.RegisterStationaryAirConditioner("Toshiba", "WH70", "A", 780);
            this.controller.TestAirConditioner("Toshiba", "EX1000");
            this.controller.TestAirConditioner("Toshiba", "WH70");
            IOrderedEnumerable<Report> reports = this.db.GetReportsByManufacturer("Toshiba").OrderBy(c => c.Mark);
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(string.Format("Reports from {0}:", "Toshiba"));
            expectedOutput.Append(string.Join(Environment.NewLine, reports));

            var result = this.controller.FindAllReportsByManufacturer("Toshiba");

            Assert.AreEqual(this.db.GetAirConditionersCount(), 2);
            Assert.AreEqual(this.db.GetReportsCount(), 2);
            Assert.AreEqual(expectedOutput.ToString(), result.ToString());
        }
    }
}