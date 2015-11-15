using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using Data.UnitOfWork;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels;
    using Twitter.Models;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }
   
        public ActionResult Index(int pageNum = 0)
        {
            this.ViewBag.IsEndOfRecords = false;
            var tweets = this.GetRecordsForPage(pageNum);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", tweets);
            }

            return this.View("Index", tweets);
        }

        public IEnumerable<TweetViewModel> GetRecordsForPage(int pageNum)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.TwitterData.Users.Find(userId);

            IQueryable<Tweet> tweets =
                this.TwitterData.Tweets.All()
                .OrderByDescending(t => t.CreatedOn);

            ////TODO only tweets of author that follow
            //if (user != null)
            //{
            //    tweets = tweets.Where(t => t.Author.Following.Any(f => f.Id == userId));
            //}

            var result = tweets
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(TweetViewModel.Create)
                    .AsEnumerable();

            return result;
        }       
    }
}