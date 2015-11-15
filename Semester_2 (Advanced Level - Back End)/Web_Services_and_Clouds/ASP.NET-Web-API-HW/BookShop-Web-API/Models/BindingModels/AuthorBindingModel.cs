namespace BookShop_Web_API.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorBindingModel
    {
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } 
    }
}