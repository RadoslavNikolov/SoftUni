namespace BidSystem.Tests.UnitTestWithMoq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using System.Web.Routing;
    using System.Web.UI.WebControls;
    using Data.Models;
    using Data.UnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RestServices.Controllers;
    using RestServices.Mocks;
    using RestServices.Models.BindingModels;
    using RestServices.Models.ViewModels;
    using RestServices.Providers;
    using RouteParameter = System.Web.Http.RouteParameter;

    [TestClass]
    public class MyBidsUnitTestWithMocking
    {

        private MockContainer mocks;

        private Mock<IBidSystemData> mockContext;

        private Mock<IUserProvider> mockUserProvider;

        private BidsController controller;


        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
            this.mockContext = new Mock<IBidSystemData>();
            this.PrepareMockContext();
            this.mockUserProvider = new Mock<IUserProvider>();
            this.PrepareMockUserProvider();       
        }

        [TestMethod]
        public void ListUserBids_NotLogadUser_ShouldReturnUnauthorize()
        {
            this.controller = new BidsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);
            this.mockUserProvider.SetupGet(p => p.IsAuthenticated)
                .Returns(false);


          
            var httpResponse = this.controller.GetLogedUsersBids()
                .ExecuteAsync(CancellationToken.None).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
 

        }

        [TestMethod]
        public void CreateBid_LogedUser_ShouldReturn200OK()
        {
            this.controller = new BidsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);

            var fakeUser = this.mocks.UserRepositoryMock.Object.All()
                .FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            var newBid = new BidBindingModel()
            {
                BidPrice = 45,
                Comment = "Test moq"
            };

            var response = this.controller.BidForOfferById(1,newBid)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(this.mocks.InitialBidsCount + 1, this.mocks.BidsFakeRepo.Count);
            Assert.AreEqual(newBid.Comment, this.mocks.BidsFakeRepo.Last().Comment);
            Assert.AreEqual(newBid.BidPrice, this.mocks.BidsFakeRepo.Last().OfferedPrice);

        }

        [TestMethod]
        public void ListUserBids_Loged_ShouldReturn200OK()
        {
            this.controller = new BidsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);

            var fakeBids = this.mocks.BidsFakeRepo;
            var httpResponse = this.controller.GetLogedUsersBids()
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var bidsResponse = httpResponse.Content.ReadAsAsync<IEnumerable<BidOutputViewModel>>()
                .Result.Select(b => b.Id)
                .ToList();

            var orderedFakeBids = fakeBids
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(b => b.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeBids, bidsResponse);
        }



        private void PrepareMockContext()
        {
            this.mockContext.Setup(c => c.Bids)
                .Returns(this.mocks.BidsRepositoryMock.Object);
            this.mockContext.Setup(c => c.Offers)
                .Returns(this.mocks.OffersRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users.Find(It.IsAny<string>()))
                .Returns(this.mocks.UserRepositoryMock.Object.All().FirstOrDefault());
        }

        private void PrepareMockUserProvider()
        {
            this.mockUserProvider.SetupGet(ip => ip.IsAuthenticated)
                .Returns(true);
            this.mockUserProvider.Setup(ip => ip.GetUserId())
                .Returns(this.mocks.UserRepositoryMock.Object.All().First().Id);
        }


        private void SetupController(BidsController bidsController)
        {
            string serverUrl = "http://sample-url.com";

            bidsController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(serverUrl)
            };

            bidsController.Configuration = new HttpConfiguration();
            bidsController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = RouteParameter.Optional, id = RouteParameter.Optional });
        }
         
    }

}