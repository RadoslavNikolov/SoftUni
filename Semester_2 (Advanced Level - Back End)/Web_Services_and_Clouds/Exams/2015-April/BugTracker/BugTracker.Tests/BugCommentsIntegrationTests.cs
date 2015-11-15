namespace BugTracker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class BugCommentsIntegrationTests
    {

        [TestMethod]
        public void CreateBugWithComments_ListComments_ShouldListCommentsCorrectly()
        {
            // Arrange -> create a new bug with 3 comments
            TestingEngine.CleanDatabase();

            var bugTitle = "integration test bug";
            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, "Just test");
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPOstResponseFirstComment = TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPOstResponseFirstComment.StatusCode);
            Thread.Sleep(15);


            var httpPOstResponseSecondComment = TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPOstResponseSecondComment.StatusCode);
            Thread.Sleep(15);

            var httpPOstResponseThirdComment = TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 3");
            Assert.AreEqual(HttpStatusCode.OK, httpPOstResponseThirdComment.StatusCode);
            Thread.Sleep(15);

            //Act -> find bug comments
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<List<CommentModel>>().Result;
            Assert.AreEqual(3, commentsFromService.Count());
            Assert.AreEqual("Comment 1", commentsFromService[0].Text);
            Assert.AreEqual("Comment 2", commentsFromService[1].Text);


            var httpFakePostRespone = TestingEngine.SubmitCommentHttpPost(150, "Not Found");
            Assert.AreEqual(HttpStatusCode.NotFound, httpFakePostRespone.StatusCode);
        }

    }
}