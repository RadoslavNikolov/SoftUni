namespace Template.App.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Template.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}