namespace Twitter.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditTweetBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(140, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Content { get; set; }  
    }
}