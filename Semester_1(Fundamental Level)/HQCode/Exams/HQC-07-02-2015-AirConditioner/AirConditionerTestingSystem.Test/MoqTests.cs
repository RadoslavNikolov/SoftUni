namespace AirConditionerTestingSystem.Test
{
    using Core;
    using Helpers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;

    [TestClass]
    public class MoqTests
    {
        private IConditionerDataBase mockedData;
        private IConditionerController controller;

        [TestInitialize]
        public void DataBaseInitializing()
        {
            var dataMock = new Mock<IConditionerDataBase>();
            var conditioner = new AirConditioner("Toshiba", "EX1000", "B", 1000);
            dataMock.Setup(x => x.GetAirConditioner(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(conditioner);
            this.mockedData = dataMock.Object;

            this.controller = new ConditionerController(this.mockedData);
        }


        [TestMethod] 
        public void TetsAirConditonerTests_ShouldCalculateMark()
        {
            AirConditioner airConditioner = this.mockedData.GetAirConditioner("Toshiba", "EX1000");
            var mark = airConditioner.Test();

            Assert.AreEqual(1,mark);
        }

        [TestMethod]
        public void TetsAirConditonerTests_ShouldReturnSuccessMessage()
        {
            var expectedResult = string.Format(Constants.TEST, "EX1000", "Toshiba");

            var result = this.controller.TestAirConditioner("Toshiba", "EX1000");
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}