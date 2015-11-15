namespace Restaurant.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using Restaurants.Data;
    using Restaurants.Models;
    using Restaurants.Services;
    using Restaurants.Services.Models.BindingModels;


    [TestClass]
    public class MealsIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                //appBuilder.UseWebApi(config);
            });
            this.httpClient = this.httpTestServer.HttpClient;

            //Clean Users and News tables from Db
            CleanDatabase();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void EditExistingMeal_ShouldReturn_200OK()
        {
            // Arrange
            var dbMeal = this.CreateMeal();

            var meal = new CreateMealBindingModel()
            {
                Name = "Musaka1",
            };


            // Act
            //var httpResponse = this.httpClient.PutAsync("api/meal/" + dbMeal.Id).Result;
            Assert.AreEqual("Musaka", dbMeal.Name);

            // Assert
            //Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }



        private Meal CreateMeal()
        {
            var restaurant = new RestaurantBindingModel()
            {
                Name = "Sofia",
                TownId = 1           
            };

            var restaurantContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", restaurant.Name),
                new KeyValuePair<string, string>("townId", restaurant.TownId.ToString()),

            });

            var meal = new CreateMealBindingModel()
            {
                Name = "Musaka",
                Price = (decimal) 5.5,
                TypeId = 2,
                RestaurantId = 1
            };

            var mealContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", meal.Name),
                new KeyValuePair<string, string>("price", meal.Price.ToString()),
                new KeyValuePair<string, string>("typeId", meal.TypeId.ToString()),
                new KeyValuePair<string, string>("restaurantId", meal.RestaurantId.ToString()),

            });


            // Act
            var httpResponse = this.httpClient.PostAsync("api/restaurants", restaurantContent).Result;


            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }

            var httpResponseMessage = this.httpClient.PostAsync("api/meals", mealContent).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }

           
            var dbMeal = httpResponse.Content.ReadAsAsync<Meal>().Result;

            return dbMeal;
        }

        private static void CleanDatabase()
        {
            // Clean all data in all database tables
            var dbContext = new RestaurantsContext();
            dbContext.Meals.Delete();
            dbContext.MealTypes.Delete();
            dbContext.Orders.Delete();
            dbContext.Ratings.Delete();
            dbContext.Restaurants.Delete();
            dbContext.Towns.Delete();
            dbContext.Users.Delete();
            dbContext.SaveChanges();
        }
    }
}