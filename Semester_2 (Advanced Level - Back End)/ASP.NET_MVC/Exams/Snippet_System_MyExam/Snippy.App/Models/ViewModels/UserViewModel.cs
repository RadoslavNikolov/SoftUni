namespace Snippy.App.Models.ViewModels
{
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}