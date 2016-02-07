using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirConditionerTestingSystem.Test
{
    using Core;
    using Data;
    using Helpers;
    using Helpers.CustomException;
    using Interfaces;

    [TestClass]
    public class RegisterStationaryAirConditionerTests
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
        public void TestAddCondiitioner_ValidInput_ShouldAdd()
        {
            var result = this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);

            string expectedOutput = string.Format(Constants.REGISTER, "EX1000", "Toshiba");
            Assert.AreEqual(1, this.db.GetAirConditionersCount());
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddCondiitioner_InvalidEfficiencyRating_ShouldThrow()
        {
            var result = this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "X", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddCondiitioner_InvalidManifacturerLength_ShouldThrow()
        {
            var result = this.controller.RegisterStationaryAirConditioner("Tos", "EX1000", "B", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddCondiitioner_InvalidModelLength_ShouldThrow()
        {
            var result = this.controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddCondiitioner_InvalidPOwerUsage_ShouldThrow()
        {
            var result = this.controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", -1000);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void TestAddCondiitioner_SuchAlreadyExists_ShouldThrow()
        {
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
        }
    }
}
