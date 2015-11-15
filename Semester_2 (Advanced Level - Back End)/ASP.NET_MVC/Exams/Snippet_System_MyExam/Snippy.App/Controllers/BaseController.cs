using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.App.Controllers
{
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Snippy.Models;

    public class BaseController : Controller
    {
        public BaseController(ISnippyData data)
        {
            this.SnippyData = data;
        }

        public BaseController(SnippyData data, User user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public ISnippyData SnippyData { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.SnippyData.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}