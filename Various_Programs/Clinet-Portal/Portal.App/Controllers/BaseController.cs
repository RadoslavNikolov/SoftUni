namespace Portal.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Infrastructure;
    using Infrastructure.UserIdProvider;
    using Portal.Models.IdentityModels;

    public class BaseController : Controller
    {
        public BaseController(IApplicationData data)
            : this(data, new AspNetUserIdProvider())
        {
            this.ApplicationData = data;
        }

        public BaseController(IApplicationData data, IUserIdProvider userIdProvider)
        {
            this.ApplicationData = data;
            this.UserIdProvider = userIdProvider;
            this.UserProfile = new ApplicationUser();
        }

        public IApplicationData ApplicationData { get; private set; }

        public ApplicationUser UserProfile { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.ApplicationData.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;

            }

            return base.BeginExecute(requestContext, callback, state);
        }

        protected bool IsAdmin()
        {
            return this.User.IsInRole(AppConfig.AdminRole);
        }

        protected ICollection<ApplicationUser> GetUsers(ICollection<string> usersId)
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            if (usersId != null)
            {
                foreach (string id in usersId)
                {
                    ApplicationUser wantedUser = this.ApplicationData.Users.Find(id);
                    if (wantedUser == null)
                    {
                        throw new NullReferenceException();
                    }

                    users.Add(wantedUser);
                }
            }

            return users;
        }
    }
}