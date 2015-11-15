namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditMealBindingModel
    {
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int? TypeId { get; set; }
    }
}