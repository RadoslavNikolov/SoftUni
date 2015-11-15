using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSystem.App.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using PagedList;

    [Authorize]
    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var match = this.SportSystemData.Matches.All()
                .Where(m => m.Id == id)
                .ProjectTo<MatchDetailsViewModel>()
                .FirstOrDefault();

            return this.View(match);
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var matches = this.SportSystemData.Matches.All()
                .OrderBy(m => m.StartDate)
                .ProjectTo<MatchViewModel>()
                .ToPagedList(pageNumber: page ?? 1, pageSize: 3);

            return this.View(matches);
        }
    }
}