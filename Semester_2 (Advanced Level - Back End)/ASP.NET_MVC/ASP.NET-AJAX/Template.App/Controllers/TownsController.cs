using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.App.Controllers
{
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class TownsController : BaseController
    {
        public TownsController(IApplicationData data) : base(data)
        {
        }

        // GET: Towns
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTowns(string search)
        {
            var towns = this.ApplicationData.Towns.All()
                .Where(t => t.Name.Contains(search))
                .Select(TownViewModel.Create);

            return this.PartialView("_SearchResultPartial", towns);
        }
    }
}