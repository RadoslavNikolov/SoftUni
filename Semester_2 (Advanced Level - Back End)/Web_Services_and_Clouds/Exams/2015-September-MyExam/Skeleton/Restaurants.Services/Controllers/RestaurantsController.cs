using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Restaurants.Data;
using Restaurants.Models;

namespace Restaurants.Services.Controllers
{
    using System.Data.Entity.Migrations;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Providers;

    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : BaseApiController
    {
        public RestaurantsController()
        {
        }

        public RestaurantsController(IRestaurantData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        // GET: api/restaurants/{TownId}
        [HttpGet]
        public IHttpActionResult GetReastaurantByTownId(int townId)
        {
            var restaurants = this.Db.Restaurants.All()
                .Where(r => r.Town.Id == townId)
                .OrderByDescending(r => r.Ratings.Average(ra => ra.Stars))
                .ThenBy(r => r.Name)
                .Select(r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = (int)r.Ratings.Average(ra => ra.Stars),
                    Town = new TownViewModel()
                    {
                        Id = r.TownId,
                        Name = r.Name
                    }
                }).OrderBy(r => r.Rating);


            return this.Ok(restaurants);
        }
      

        // POST: api/Restaurants
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostRestaurant(RestaurantBindingModel model)
        {
         
            if (model == null)
            {
                return this.BadRequest("Missing restaurant data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Db.Towns.Find(model.TownId);

            if (town == null)
            {
                return this.BadRequest(string.Format("Town witd id: {0} does not exists.", model.TownId));
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            var newRestaurant = new Restaurant()
            {
                Name = model.Name,
                Town = town,
                Owner = currentUser
            };

            this.Db.Restaurants.Add(newRestaurant);
            this.Db.SaveChanges();

            int? restaurantRating = newRestaurant.Ratings.Any() ? (int)newRestaurant.Ratings.Average(r => r.Stars) : (int?) null;
            
            return this.CreatedAtRoute("DefaultApi", new { controller = "restaurants", id = newRestaurant.Id },
                new
                {
                    newRestaurant.Id,
                    newRestaurant.Name,
                    rating = restaurantRating,
                    town = new
                    {
                        newRestaurant.Town.Id,
                        newRestaurant.Town.Name
                    }
                });
        }


        // POST: api/restaurants/{id}/rate
        [HttpPost]
        [Authorize]
        [Route("{id}/rate")]
        public IHttpActionResult RateExistingRestaurant([FromUri] int id, [FromBody]RateRestaurantBindingModel model)
        {

            if (model == null)
            {
                return this.BadRequest("Missing restaurant data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            if (restaurant.OwnerId == currentUserId)
            {
                return this.BadRequest("You can not rate your own restaurant.");

            }

            var rate = restaurant.Ratings.FirstOrDefault(r => r.UserId == currentUserId);

            if (rate != null)
            {
                rate.Stars = model.Stars;
                rate.UserId = currentUserId;
                rate.Restaurant = restaurant;
            }
            else
            {
                rate = new Rating()
                {
                    Stars = model.Stars,
                    UserId = currentUserId,
                    Restaurant = restaurant
                };
            }

            this.Db.Ratings.Update(rate);
            this.Db.SaveChanges();

            return this.Ok();
        }


        // GET: api/restaurants/{id}/meals
        [HttpGet]
        [Route("{id}/meals")]
        [AllowAnonymous]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.Db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = this.Db.Meals.All()
                .Where(m => m.Restaurant.Id == id)
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Name)
                .Select(m => new MealViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                });

            return this.Ok(meals);
        }       
    }
}