namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using Restaurants.Models;

    public class RestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        public int TownId { get; set; }
    }
}