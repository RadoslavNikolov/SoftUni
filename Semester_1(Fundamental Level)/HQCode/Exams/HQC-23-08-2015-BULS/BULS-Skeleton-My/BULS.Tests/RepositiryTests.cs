namespace BULS.Tests
{
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositiryTests
    {
        private IRepository<User> users;

        [TestInitialize]
        public void InitializeRepository()
        {
            this.users = new Repository<User>();
        }

        [TestMethod]
        public void Get_ValidId_ShouldReturnElement()
        {
            //Arrange
            var userList = new List<User>()
            {
                new User("Pesho", "123456", Role.Lecturer),
                new User("Gosho", "33445566", Role.Student)
            };
            
            userList.ForEach(u => this.users.Add(u));

            //Act
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            //Assert
            Assert.AreEqual(userList[Id-1], actualUser);
        }

        [TestMethod]
        public void Get_InvalidId_ShoulReturnDefaultUser()
        {
            //Act
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            //Assert
            Assert.AreEqual(default(User), actualUser);
        }

        [TestMethod]
        public void Get_OutOfRangeId_ShoulReturnDefaultUser()
        {
            //Arrange
            var userList = new List<User>()
            {
                new User("Pesho", "123456", Role.Lecturer),
                new User("Gosho", "33445566", Role.Student)
            };

            userList.ForEach(u => this.users.Add(u));

            //Act
            int id = userList.Count + 1;
            var actualUser = this.users.Get(id);

            //Assert
            Assert.AreEqual(default(User), actualUser);
        }
    }
}
