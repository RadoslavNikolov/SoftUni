namespace BULS.Tests
{
    using System;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ActionsTests
    {
        private UsersController usersController;

        [TestInitialize]
        public void InitializeMethod()
        {
            var user = new User("Pesho", "123456", Role.Student);

            this.usersController = new UsersController(new BangaloreUniversityData(), user);
        }

        [TestMethod]
        public void Login_RegisteredUser_ShouldReturnCorrectView()
        {
            //Arrange
            this.usersController.CurrentUser = null;
            this.usersController.Register("Pesho", "123456", "123456", "student");

            //Act
            IView view = this.usersController.Login("Pesho", "123456");
            var expectedOutput = "User Pesho logged in successfully.";

            //Assert
            Assert.AreEqual(expectedOutput, view.Display());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_AlreadyLogedUser_ShouldThrowException()
        {
            //Arrange
            this.usersController.CurrentUser = null;
            this.usersController.Register("Pesho", "123456", "123456", "student");
            this.usersController.Register("Pesho1", "1234567", "1234567", "student");

            //Act
            IView view = this.usersController.Login("Pesho", "123456");
            IView view1 = this.usersController.Login("Pesho1", "1234567");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_NonExistingUser_ShouldThrowException()
        {
            //Arrange
            this.usersController.CurrentUser = null;
            this.usersController.Register("Pesho", "123456", "123456", "student");

            //Act
            IView view = this.usersController.Login("Pesho1", "123456");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_InvalidPassword_ShouldThrowException()
        {
            //Arrange
            this.usersController.CurrentUser = null;
            this.usersController.Register("Pesho", "123456", "123456", "student");

            //Act
            IView view = this.usersController.Login("Pesho", "1234567");
        }

        [TestMethod]
        public void Login_RegisteredUser_ShouldReturnCorrectCurrentuser()
        {
            //Arrange
            var user = new User("Pesho", "123456", Role.Student);
            this.usersController.CurrentUser = null;
            this.usersController.Register("Pesho", "123456", "123456", "student");


            IView view = this.usersController.Login("Pesho", "123456");

            //Assert
            Assert.AreEqual(user.Username, this.usersController.CurrentUser.Username);
            Assert.AreEqual(user.Role, this.usersController.CurrentUser.Role);
        }
    }
}