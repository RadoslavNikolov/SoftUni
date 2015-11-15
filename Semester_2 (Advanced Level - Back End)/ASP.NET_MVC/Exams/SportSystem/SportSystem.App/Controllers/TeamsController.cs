using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSystem.App.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Model;
    using Models.BindigModels;
    using Models.ViewModels;

    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var team = this.SportSystemData.Teams.All()
                .Where(t => t.Id == id)
                .ProjectTo<TeamDetailsViewModel>()
                .FirstOrDefault();

            return this.View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            if (this.SportSystemData.Teams.All().Any(t => t.Id == id))
            {
                var userId = this.UserProfile.Id;

                if (!this.SportSystemData.Votes.All().Any(v => v.TeamId == id && v.UserId == userId))
                {
                    var vote = new Vote()
                    {
                        TeamId = id,
                        UserId = userId,
                        Value = 1
                    };

                    this.SportSystemData.Votes.Add(vote);
                    this.SportSystemData.SaveChanges();

                    var newVotes = this.SportSystemData.Votes.All()
                        .Where(v => v.TeamId == id)
                        .Sum(x => x.Value);
                    return this.Json(newVotes);
                }
            }

            var votes = this.SportSystemData.Votes.All()
                        .Where(v => v.TeamId == id)
                        .Sum(x => x.Value);
            return this.Json(votes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                ICollection<Player> players = this.GetPlayers(model.Players);

                var newTeam = new Team()
                {
                    Name = model.Name,
                    NickName = model.NickName,
                    WebSite = model.WebSite,
                    DateFounded = DateTime.Now
                };

                this.SportSystemData.Teams.Add(newTeam);
                this.SportSystemData.SaveChanges();

                foreach (Player player in players)
                {
                    player.TeamId = newTeam.Id;
                }

                this.SportSystemData.SaveChanges();



                return this.RedirectToAction("Details", new { id = newTeam.Id });

            }


            return this.View();
        }
     
    }
}