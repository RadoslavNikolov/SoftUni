﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    using Data;
    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        protected EventsDbContext db = new EventsDbContext();

        public bool IsAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = (currentUserId != null && this.User.IsInRole("Admin"));
            return isAdmin;
        }
    }
}