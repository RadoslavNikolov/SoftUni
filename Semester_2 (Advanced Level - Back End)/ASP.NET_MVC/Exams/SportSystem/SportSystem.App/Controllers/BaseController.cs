using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSystem.App.Controllers
{
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Model;

    public class BaseController : Controller
    {
        public BaseController(ISportSystemData data)
        {
            this.SportSystemData = data;
        }

        public BaseController(ISportSystemData data, User user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public ISportSystemData SportSystemData { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.SportSystemData.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        protected ICollection<Player> GetPlayers(ICollection<string> playersId)
        {
            ICollection<Player> players = new HashSet<Player>();

            if (playersId != null)
            {
                foreach (string id in playersId)
                {
                    Player wantedPlayer = this.SportSystemData.Players.Find(int.Parse(id));
                    if (wantedPlayer == null)
                    {
                        throw new NullReferenceException();
                    }

                    players.Add(wantedPlayer);
                }
            }

            return players;
        }
    }
}