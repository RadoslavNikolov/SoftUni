namespace Huy_Phuong.Test
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;

    [TestClass]
    public class MockTest
    {
        private Mock<IDataBaseProvider> repository;
        private IDataBaseProvider db;

        [TestInitialize]
        public void TestInitialize()
        {
            var time = DateTime.Now;

            var theatreName = "testTheatre";
            var performanceName = "testPerformance";
            
            var theatre = new Theatre(theatreName);
            var performance = new Performance(theatre, performanceName, time, new TimeSpan(1, 30, 0), 15m);
            theatre.AddPerformance(performance);
            var testListOfTheatres = new List<ITheatre>();
            testListOfTheatres.Add(theatre);

            this.repository = new Mock<IDataBaseProvider>();
            this.repository.Setup(x => x.GetMockDataBase)
                .Returns(testListOfTheatres);

            this.db = this.repository.Object;
        }

        [TestMethod]
        public void TestMockingDataBase_ShouldReturnCountOfTheatres()
        {
            var test = "";
            var countOfTheatres = this.db.GetMockDataBase.Count;

            Assert.AreEqual(1,countOfTheatres, string.Format("Expexed count of mocked data base is 1 instead of {0}", countOfTheatres));
        }
    }
}