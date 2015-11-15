namespace OnlineShop.Services.Models.ViewModels
{
    using OnlineShop.Models;

    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }

        public UserViewModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
        }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}