namespace BookShop_Web_API.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryBindingModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Name")]
        public string Name { get; set; } 
    }
}