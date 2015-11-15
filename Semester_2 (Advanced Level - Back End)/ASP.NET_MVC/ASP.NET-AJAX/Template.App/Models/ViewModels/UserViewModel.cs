namespace Template.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Template.Models;

    public class UserViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhotoUrl { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhotoUrl = "http://i.imgur.com/u5c8E.gif"
                };
            }
        }
         
    }
}