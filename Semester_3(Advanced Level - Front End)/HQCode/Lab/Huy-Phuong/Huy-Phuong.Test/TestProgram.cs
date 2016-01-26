using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huy_Phuong.Test
{
    using System.Linq;
    using Core;
    using Custom_Exceptions;
    using Infrastructure;

    [TestClass]
    public class TestProgram
    {
        private ITheatreData data;

        [TestInitialize]
        public void TestInitialize()
        {
            this.data = new TheatreData();
        }



        [TestMethod]
        public void TestAddTheatre_ShoulAddTheatre()
        {
            //Arrange
            var theatreName = "test";
            this.data.AddTheatre(theatreName);
            
            //Act
            var theatres = this.data.ListTheatres();

            //Assert
            Assert.AreEqual(theatreName, theatres.First(), string.Format("Theatre witn name: {0} expexted instead of {1}", theatreName, theatres.First()));
        }

        [ExpectedException(typeof(DuplicateTheatreException))]
        [TestMethod]
        public void TestAddDuplicateTheatre_ShouldThrowException()
        {
            //Arrange
            var theatreName = "test";
            this.data.AddTheatre(theatreName);

            //Act
            this.data.AddTheatre(theatreName);
           
        }

        [ExpectedException(typeof(TheatreNotFoundException))]
        [TestMethod]
        public void TestAddPerformanceEmptyTheatres_ShouldThrowException()
        {
            var theatreTest = "test";
            var performanceName = "testPerformance";

            this.data.AddPerformance(theatreTest,performanceName, DateTime.Now, new TimeSpan(1,30,0), 15m);

           
        }

        [TestMethod]
        public void TestAddPerformance_ShouldAddPerformance()
        {
            //Arrange
            var theatreName = "test";
            this.data.AddTheatre(theatreName);
            var performanceName = "testPerformance";

            //Act
            this.data.AddPerformance(theatreName, performanceName, DateTime.Now, new TimeSpan(1, 30, 0), 15m);

            //Assert
            var countOfTheatres = this.data.Theatres.FirstOrDefault().Performances.Count();
            Assert.AreEqual(1, countOfTheatres, string.Format("Expected 1 imported theatre instead of {0}", countOfTheatres));

            var addedTheatre = this.data.Theatres.FirstOrDefault();
            Assert.AreEqual(performanceName, addedTheatre.Performances.FirstOrDefault().Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestListPerformancesWithEmptyTheatresList_ShouldThrowException()
        {
            //Arrange
            var theatreName = "test";

            //Act
            this.data.ListPerformances(theatreName);
        }

        [TestMethod]
        public void TestListPerformancesWithNotEmptyTheatresList_ShouldReturnPerformances()
        {
            var time = DateTime.Now;

            var theatreName = "test";
            this.data.AddTheatre(theatreName);
            
            var performanceName = "testPerformance";
            this.data.AddPerformance(theatreName, performanceName, time, new TimeSpan(1, 30, 0), 15m);

            var outputString = string.Join(", ",this.data.ListPerformances(theatreName));
            var expectedOutputString = string.Format("({0}, {1})",performanceName, time.ToString("dd.MM.yyyy hh:mm"));

            Assert.AreEqual(expectedOutputString, outputString);

        }
    }
}
