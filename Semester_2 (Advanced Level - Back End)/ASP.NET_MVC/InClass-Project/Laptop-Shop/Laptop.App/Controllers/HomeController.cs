using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop.App.Controllers
{
    using Data;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            var context  = new LaptopDbContext();

            
            var allLaptops = context.Laptops
                .OrderBy(l => l.Id);

            return View(allLaptops);
            
            
        }

    }
}