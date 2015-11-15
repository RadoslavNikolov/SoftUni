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

    [Authorize]
    public class PlayersController : BaseController
    {
        public PlayersController(ISportSystemData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult GetAllPlayers()
        {
            var players = this.SportSystemData.Players.All()
                .Where(p => p.TeamId == null)
                .OrderBy(p => p.FullName)
                .ProjectTo<PlayerViewModel>();

            return this.PartialView("Partial/_MultipleSelectPartial", players);
        }
    }
}