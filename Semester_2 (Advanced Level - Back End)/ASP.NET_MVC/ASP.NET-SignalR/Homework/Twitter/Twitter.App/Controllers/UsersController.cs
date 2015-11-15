using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using Data.UnitOfWork;
    using Infrastructure;
    using Models.ViewModels;
    using Twitter.Models;

    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }


        // GET: Users
        public ActionResult Index(string username, int pageNum = 0)
        {
            var user = this.TwitterData.Users.All()
                .Where(u => u.UserName == username)
                .Select(UserFullViewModel.Create)
                .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var tweets = this.GetRecordsForPage(user.Id, pageNum);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", tweets);
            }

            var result = new UserWallViewModel
            {
                User = user,
                Tweets = tweets
            };

            return View(result);
        }

        public IEnumerable<TweetViewModel> GetRecordsForPage(string userId, int pageNum)
        {
            IQueryable<Tweet> tweets =
                this.TwitterData.Tweets.All()
                .Where(t => t.AuthorId == userId)
                .OrderByDescending(t => t.CreatedOn);

            var result = tweets
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(TweetViewModel.Create)
                    .AsEnumerable();

            return result;
        }


        public ActionResult Followers(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = this.TwitterData.Users.All().FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return this.HttpNotFound("User does not exist!");
            }


            var userVM = PublicUserViewModel.Create(user);

            return View(userVM);
        }

        public ActionResult Following(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = this.TwitterData.Users.All().FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return HttpNotFound("User does not exist!");
            }

            var userVM = PublicUserViewModel.Create(user);

            return View(userVM);
        }

        public ActionResult Favourites(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = this.TwitterData.UserStore.FindByNameAsync(username).Result;

            if (user == null)
            {
                return HttpNotFound("User does not exist!");
            }

            var userVM = PublicUserViewModel.Create(user);

            return View(userVM);
        }
    }
}