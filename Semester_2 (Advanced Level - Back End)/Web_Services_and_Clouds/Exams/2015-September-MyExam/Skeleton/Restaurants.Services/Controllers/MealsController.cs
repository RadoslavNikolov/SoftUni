using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Restaurants.Services.Controllers
{

    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Providers;
    using Restaurants.Models;

    [RoutePrefix("api")]
    public class MealsController : BaseApiController
    {
        private const int PAGE_SIZE = 10;
        private const int PAGE = 1;

        public MealsController()
        {
        }

        public MealsController(IRestaurantData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        // POST: api/melas
        [HttpPost]
        [Authorize]
        [Route("meals")]
        public IHttpActionResult CreateMeal(CreateMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing meal data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Db.Restaurants.Find(model.RestaurantId);

            if (restaurant == null)
            {
                return this.BadRequest(string.Format("Restaurant with id: {0} does not ecists.", model.RestaurantId));
            }

            var type = this.Db.MealTypes.Find(model.TypeId);

            if (type == null)
            {
                return this.BadRequest(string.Format("Meal type with id: {0} does not ecists.", model.TypeId));
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            var newMeal = new Meal()
            {
                Name = model.Name,
                Price = model.Price,
                Restaurant = restaurant,
                Type = type
            };

            this.Db.Meals.Add(newMeal);
            this.Db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new {controller = "meals", id = newMeal.Id},
                new
                {
                    newMeal.Id,
                    newMeal.Name,
                    newMeal.Price,
                    Type = newMeal.Type.Name
                });
        }

        // PUT: api/melas/{id}
        [HttpPut]
        [Authorize]
        [Route("meals/{id}")]
        public IHttpActionResult EditExistingMeal([FromUri] int id, [FromBody] EditMealBindingModel model)
        {

            if (model == null)
            {
                return this.BadRequest("Missing meal data to edit.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentMeal = this.Db.Meals.Find(id);

            if (currentMeal == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new
                    {
                        Message = string.Format("Meal with id: {0} does not ecists.", id)
                    });
            }


            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            if (currentMeal.Restaurant.OwnerId != currentUserId)
            {
                return this.Content(HttpStatusCode.Unauthorized,
                    new
                    {
                        Message =
                            string.Format("{0} is not the owner of the restaurant: {1}", currentUser.UserName,
                                currentMeal.Restaurant.Name)
                    });
            }

            if (model.TypeId != null)
            {
                var type = this.Db.MealTypes.Find(model.TypeId);

                if (type == null)
                {
                    return this.BadRequest(string.Format("Meal type with id: {0} does not ecists.", model.TypeId));
                }

                currentMeal.Type = type;
            }

            if (model.Price != null)
            {
                currentMeal.Price = (decimal) model.Price;
            }

            if (model.Name != null)
            {
                currentMeal.Name = model.Name;
            }

            this.Db.Meals.Update(currentMeal);
            this.Db.SaveChanges();

            return this.Ok();
        }



        // DELETE: api/melas/{id}
        [HttpDelete]
        [Authorize]
        [Route("meals/{id}")]
        public IHttpActionResult DeleteExistingMeal([FromUri] int id)
        {
            var currentMeal = this.Db.Meals.Find(id);

            if (currentMeal == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new
                    {
                        Message = string.Format("Meal with id: {0} does not ecists.", id)
                    });
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            if (currentMeal.Restaurant.OwnerId != currentUserId)
            {
                return this.Content(HttpStatusCode.Unauthorized,
                    new
                    {
                        Message =
                            string.Format("{0} is not the owner of the restaurant: {1}", currentUser.UserName,
                                currentMeal.Restaurant.Name)
                    });
            }

            this.Db.Meals.Remove(currentMeal);
            this.Db.SaveChanges();

            return this.Content(HttpStatusCode.OK, new
            {
                Message = string.Format("Meal #{0} deleted.", id)
            });

        }


        // POST: api/melas/{id}/order
        [HttpPost]
        [Authorize]
        [Route("meals/{id}/order")]
        public IHttpActionResult CreateNewOrder([FromUri] int id, [FromBody] CreateOrderBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing order data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentMeal = this.Db.Meals.Find(id);

            if (currentMeal == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new
                    {
                        Message = string.Format("Meal with id: {0} does not ecists.", id)
                    });
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }


            var newOrder = new Order()
            {
                CreatedOn = DateTime.Now,
                Meal = currentMeal,
                OrderStatus = OrderStatus.Pending,
                Quantity = model.Quantity,
                UserId = currentUserId
            };

            this.Db.Orders.Add(newOrder);
            this.Db.SaveChanges();

            return this.Ok();
        }

        // GET api/orders/{startPage}{limit}{mealId}
        [HttpGet]
        [Route("orders/")]
        public IHttpActionResult ViewPendingOrders(int? startPage, int? limit, int? mealId)
        {
            int pageSize = limit ?? PAGE_SIZE;
            int page = startPage ?? PAGE;

            if (page == 0)
            {
                page = PAGE;
            }

            if (pageSize == 0)
            {
                pageSize = PAGE_SIZE;
            }

            var skip = pageSize*(page - 1);
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            IQueryable<Order> orders = this.Db.Orders.All()
                .Where(o => o.User.Id == currentUserId && o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn);

            if (mealId != null)
            {
                orders = orders.Where(o => o.MealId == mealId);             
            }

            //paging using pageSize and Page variables
            if (skip > orders.Count())
            {
                orders = orders.Take(PAGE_SIZE);
                skip = 0;
            }
            else
            {
                orders = orders.Skip(skip).Take(pageSize);
            }

            return this.Ok(orders
                .Select(o => new
                {
                    o.Id,
                    meal = new
                    {
                        Id = o.MealId,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    o.Quantity,
                    o.OrderStatus,
                    o.CreatedOn
                }));
        }
    }
}
