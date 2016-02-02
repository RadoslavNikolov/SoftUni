namespace BULS.Tests
{
    using System;
    using System.Linq;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class MoqTests
    {
        private IBangaloreUniversityDate mockedData;
        private Course course;

        [TestInitialize]
        public void InitializeMocks()
        {
            var dataMock = new Mock<IBangaloreUniversityDate>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# advanced");

            courseRepoMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(this.course);
            dataMock.Setup(d => d.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;

        }

        [TestMethod]
        public void Addlecture_ValidCourseId_ShouldAddToCourse()
        {
            //Arrange
            var controller = new CoursesController(this.mockedData, new User("Pesho", "123456", Role.Lecturer));
            string lectureName = DateTime.Now.ToString();

            //Act
            var view = controller.AddLecture(5, lectureName);

            //Assert
            Assert.IsNotNull(view);
            Assert.AreEqual(this.course.Lectures.FirstOrDefault().Name, lectureName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLecture_InvalidCourseId_ShouldThrow()
        {
            var dataMock = new Mock<IBangaloreUniversityDate>();
            var courseRepoMock = new Mock<IRepository<Course>>();

            courseRepoMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(default(Course));
            dataMock.Setup(d => d.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;

            var controller = new CoursesController(this.mockedData, new User("Pesho", "123456", Role.Lecturer));
            string lectureName = DateTime.Now.ToString();


            //Act
            var view = controller.AddLecture(5, lectureName);
        }
    }
}