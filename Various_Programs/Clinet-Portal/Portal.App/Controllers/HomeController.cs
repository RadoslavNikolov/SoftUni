using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.App.Controllers
{
    using Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}