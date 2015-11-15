namespace Restaurant.Tests.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Restaurants.Data.UnitOfWork;
    using Restaurants.Services.Controllers;
    using Restaurants.Services.Models.ViewModels;
    using Restaurants.Services.Providers;

    [TestClass]
    public class RestaurantsControllerTests
    {
        private MockContainer mocks;

        private Mock<IRestaurantData> mockContext;

        private Mock<IUserProvider> mockUserProvider;

        private RestaurantsController controller;


        
        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
            this.mockContext = new Mock<IRestaurantData>();
            this.PrepareMockContext();
            this.mockUserProvider = new Mock<IUserProvider>();
            this.PrepareMockUserProvider();

            this.controller = new RestaurantsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);
        }


        [TestMethod]
        public void GetChannelsById_ShouldReturnChannel_200OK()
        {
            var fakeTowns = this.mocks.TownRepositoryMock.Object.All().FirstOrDefault();

            var response = this.controller.GetReastaurantByTownId(fakeTowns.Id)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);          
        }



        private void PrepareMockContext()
        {
            this.mockContext.Setup(c => c.Restaurants)
                .Returns(this.mocks.RestaurantRepositoryMock.Object);
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


        private void SetupController(RestaurantsController restaurantsController)
        {
            string serverUrl = "http://sample-url.com";

            restaurantsController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(serverUrl)
            };

            restaurantsController.Configuration = new HttpConfiguration();
            restaurantsController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = RouteParameter.Optional, id = RouteParameter.Optional });
        }
    }   
}