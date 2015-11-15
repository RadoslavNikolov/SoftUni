namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RateRestaurantBindingModel
    {
        [Required]
        [Range(1, 10, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Stars { get; set; } 
    }
}