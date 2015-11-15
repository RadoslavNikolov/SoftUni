namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Migrations;
    using Twitter.Models;

    public class UserPreviewViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public virtual File UserPhoto { get; set; }

        public static Expression<Func<User, UserPreviewViewModel>> Create
        {
            get
            {
                return u => new UserPreviewViewModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    UserPhoto = u.Files.FirstOrDefault()
                };
            }
        }
    }
}