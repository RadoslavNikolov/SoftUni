using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.App.Controllers
{
    using System.Threading.Tasks;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetUsers(string userId)
        {
            if (userId == null)
            {
                var result = this.ApplicationData.Users.All()
                .Select(UserViewModel.Create);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            var user = this.ApplicationData.Users.All().Where(u => u.Id == userId)
                .OrderBy(u => u.UserName)
                .Select(UserViewModel.Create);
            return this.PartialView("_UserInfoPartial", user);
        }
    }
}