using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using System.Net;
    using System.Web.Routing;
    using Data;
    using Data.UnitOfWork;
    using Infrastructure;
    using Twitter.Models;

    public class BaseController : Controller
    {
        public BaseController(ITwitterData data)
        {
            this.TwitterData = data;
        }

        public BaseController(ITwitterData data, User user)
            :this(data)
        {
            this.UserProfile = user;
        }

        public ITwitterData TwitterData { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.TwitterData.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}