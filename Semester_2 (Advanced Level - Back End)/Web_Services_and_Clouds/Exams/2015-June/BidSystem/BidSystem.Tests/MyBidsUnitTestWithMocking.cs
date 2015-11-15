namespace BidSystem.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using System.Web.Routing;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
 
    using RestServices.Controllers;
    using RestServices.Mocks;

    [TestClass]
    public class MyBidsUnitTestWithMocking
    {

        [TestMethod]
        public void ListUserBids_NotLogaduser_ShouldReturnUnauthorize()
        {
            //Arrange -> create bugs
            var datalayerMock = new BidSystemDataMock();
            var bidsMock = datalayerMock.Bids;
            var offerMock = datalayerMock.Offers;


            offerMock.Add(new Offer()
            {
                Id = 1,
                Title = "Offer #1",
                Description = "Mock Offer",
                SellerId = 1.ToString(),
                InitialPrice = 20,
                DatePublished = DateTime.Now,
                ExpirationDateTime = DateTime.Now.AddMonths(5)
            });

            bidsMock.Add(new Bid()
            {
                Id = 2,
                BidderId = 5.ToString(),
                OfferId = 1,
                DateCreated = DateTime.Now,
                OfferedPrice = 30,
                Comment = "Mock bid"
            });

            //Act -> edit bug data

            var bidsController = new BidsController(datalayerMock);
            this.SetupControllerForTesting(bidsController, "bids");

            var httpResponse = bidsController.GetLogedUsersBids()
                .ExecuteAsync(new CancellationToken()).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
 

        }

        [TestMethod]
        public void ListUserBids_Loged_ShouldReturn200OK()
        {
            //Arrange -> create bugs
            var datalayerMock = new BidSystemDataMock();
            var bidsMock = datalayerMock.Bids;
            var offerMock = datalayerMock.Offers;


            offerMock.Add(new Offer()
            {
                Id = 1,
                Title = "Offer #1",
                Description = "Mock Offer",
                SellerId = 1.ToString(),
                InitialPrice = 20,
                DatePublished = DateTime.Now,
                ExpirationDateTime = DateTime.Now.AddMonths(5)
            });

            bidsMock.Add(new Bid()
            {
                Id = 2,
                BidderId = 5.ToString(),
                OfferId = 1,
                DateCreated = DateTime.Now,
                OfferedPrice = 30,
                Comment = "Mock bid"
            });



            //Act -> edit bug data

            var bidsController = new BidsController(datalayerMock);
            this.SetupControllerForTesting(bidsController, "bids");
            

            //var httpResponse = bugsController.EditBug(2, editBugData)
            //    .ExecuteAsync(new CancellationToken()).Result;
            var httpResponse = bidsController.GetLogedUsersBids()
                .ExecuteAsync(new CancellationToken()).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
            //Assert.AreEqual(2, bugsMock.Find(2).Id);
            //Assert.AreEqual(newTitle, bugsMock.Find(2).Title);
            //Assert.AreEqual(newDescription, bugsMock.Find(2).Description);
            //Assert.AreEqual(newStatus, bugsMock.Find(2).Status);


            


        }




        private void SetupControllerForTesting(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
         
    }

}