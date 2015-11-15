namespace OnlineShop.Services.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateAdBindingModel
    {
        [MinLength(1, ErrorMessage = "Name must be at least 1 symbol long")]
        [MaxLength(50, ErrorMessage = "Name must not be longer than 50 symbols")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Decription must not be longer than 1000 symbols")]
        public string Description { get; set; }

        [Required(ErrorMessage = "TypeId is required!")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }

        public IEnumerable<int> Categories { get; set; }
    }
}