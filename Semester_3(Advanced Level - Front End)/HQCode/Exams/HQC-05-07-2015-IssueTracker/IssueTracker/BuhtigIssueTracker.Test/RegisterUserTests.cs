using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuhtigIssueTracker.Test
{
    using Core;
    using Models;
    using Utils;

    [TestClass]
    public class RegisterUserTests
    {
        [TestInitialize]
        public void InitializeTracker()
        {
            
        }

        [TestMethod]
        public void Test_RegisterUser_ShouldregisterUser()
        {
            ////Arrange
            var urlString = "RegisterUser?username=admin&password=pass123&confirmPassword=pass123";
            var tracker = new IssueTracker();
            var endpoint = new Endpoint(urlString);

            ////Act
            string viewResult = tracker.RegisterUser(endpoint);

            ////Assert
            var expectedOutput = "User admin registered successfully";
            var user = tracker.Data.UsersDictionaryByUsername["admin"];
            Assert.AreEqual(expectedOutput, viewResult);
            Assert.AreEqual(1, tracker.Data.UsersDictionaryByUsername.Count);
            Assert.AreEqual("admin", user.UserName);
            Assert.AreEqual(HashUtils.HashPassword("pass123"), user.UserPassword);
        }

        [TestMethod]
        public void Test_RegisterUserNotMatchinPassword_ShouldFailedAndReturnErrorMessage()
        {
            ////Arrange
            var urlString = "RegisterUser?username=admin&password=pass123&confirmPassword=dont_match";
            var tracker = new IssueTracker();
            var endpoint = new Endpoint(urlString);

            ////Act
            string viewResult = tracker.RegisterUser(endpoint);

            ////Assert
            var expectedOutput = "The provided passwords do not match";  
            Assert.AreEqual(expectedOutput, viewResult);
            Assert.AreEqual(0, tracker.Data.UsersDictionaryByUsername.Count);  
        }


        [TestMethod]
        public void Test_RegisterUserExistingUser_ShouldFailedAndReturnErrorMessage()
        {
            ////Arrange
            var urlString = "RegisterUser?username=admin&password=pass123&confirmPassword=pass123";
            var urlString2 = "RegisterUser?username=admin&password=pass123&confirmPassword=pass123";
            var tracker = new IssueTracker();
            var endpoint = new Endpoint(urlString);
            var endpoint2 = new Endpoint(urlString2);

            ////Act
            string viewResult = tracker.RegisterUser(endpoint);
            viewResult = tracker.RegisterUser(endpoint2);
            ////Assert
            var expectedOutput = "A user with username admin already exists";
            Assert.AreEqual(expectedOutput, viewResult);
            Assert.AreEqual(1, tracker.Data.UsersDictionaryByUsername.Count);
        }
    }
}
