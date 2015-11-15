using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.App.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Infrastructure;
    using Models.ViewModels;
    using PagedList;

    public class UsersController : BaseController
    {
        public UsersController(IApplicationData data) : base(data)
        {
        }

        // GET: Users/page
        [OutputCache(Duration = 3600, SqlDependency = "DefaultConnection:AspNetUsers", VaryByParam = "none")]
        public ActionResult Index(int? page)
        {
            var users = this.ApplicationData.Users.All()
                .OrderBy(u => u.UserName)
                .ProjectTo<UserViewModel>()
                .ToPagedList(pageNumber: page ?? 1, pageSize: AppConfig.PageSize);

            return View(users);
        }
    }
}