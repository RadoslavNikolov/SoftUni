using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(
            IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {

            var model = new HomePageViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentGreeting = _greeter.GetGreeting()
            };

            return View(model);

            //return new ObjectResult(model);

            //return Content("Hello from the controller!");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Add(restaurant);
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant != null && ModelState.IsValid)
            {
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = restaurant.Id });

            }

            return View(restaurant);
        }

        public IActionResult Details(int id)
        {

            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
