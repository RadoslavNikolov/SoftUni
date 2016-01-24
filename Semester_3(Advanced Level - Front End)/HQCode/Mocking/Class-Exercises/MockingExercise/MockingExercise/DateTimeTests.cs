using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MockingExercise
{
    using Moq;

    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void TestAddDayInTheMiddleOfTheMonth_ShouldAdd()
        {
            var mockTime = new Mock<ITimeProvider>();
            mockTime.SetupGet(t => t.Now).Returns(new DateTime(2016, 01, 16));

            ITimeProvider timeProvider = mockTime.Object;

            var time = timeProvider.Now.AddDays(1);
            Assert.AreEqual(17, time.Day, "Expected day is 17");
        }


    }
}
