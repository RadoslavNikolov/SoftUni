namespace Restaurant.Tests.Models
{
    using Restaurants.Services.Models.ViewModels;

    public class RestaurantModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Rating { get; set; }

        public TownViewModel Town { get; set; } 
    }
}