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

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var model = new HomaPageViewModel();

            var matchesModel = this.SportSystemData.Matches.All()
                .OrderByDescending(m => m.UserMatchBets.Sum(s => s.AwayBet) + m.UserMatchBets.Sum(s => s.HomeBet))
                .Take(3)
                .ProjectTo<MatchViewModel>();

            var teamsModel = this.SportSystemData.Teams.All()
                .OrderByDescending(t => t.Votes.Count)
                .Take(3)
                .ProjectTo<TeamViewModel>();

            model.MatchViewModel = matchesModel;
            model.TeamViewModel = teamsModel;


            return View(model);
        }

    }
}