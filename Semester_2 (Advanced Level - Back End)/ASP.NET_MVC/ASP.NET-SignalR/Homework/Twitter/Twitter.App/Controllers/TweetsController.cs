using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.App.Controllers
{
    using System.IO.MemoryMappedFiles;
    using AutoMapper;
    using Data.UnitOfWork;
    using Hubs;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize]
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        // GET: Tweets
        public ActionResult Index()
        {
            var tweets = this.TwitterData.Tweets.All().Include(t => t.Files);
            var isAdmin = this.User.IsInRole("Admin");

            if (!isAdmin)
            {
                tweets = tweets.Where(t => t.AuthorId == this.UserProfile.Id);
            }

            return View(tweets.ToList());
        }

        // GET: Tweets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.TwitterData.Tweets.Find(id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }

        [HttpGet]
        public ActionResult TweetById(int tweetId)
        {
            var tweet =
                this.TwitterData.Tweets.All().Where(t => t.Id == tweetId).Select(TweetViewModel.Create).AsEnumerable();

            return this.PartialView("DisplayTemplates/TweetViewModel", tweet);
        }

        // GET: Tweets/Create
        public ActionResult Create()
        {
            ViewBag.WallOwnerId = new SelectList(this.TwitterData.Users.All(), "Id", "ProfilePictureUrl");
            return View();
        }

        // POST: Tweets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetBindingModel tweet, HttpPostedFileBase upload)
        {
            if (tweet == null || !this.ModelState.IsValid)
            {
                //                this.TempData["error"] = this.ModelState.Values
                //                                        .SelectMany(x => x.Errors)
                //                                        .Select(x => x.ErrorMessage)
                //                                        .AsEnumerable();

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            var authorId = this.User.Identity.GetUserId();
            var author = this.TwitterData.Users.Find(authorId);

            if (author == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            var newTweet = new Tweet
            {
                Content = tweet.Content,
                AuthorId = authorId,
                Author = author,
                WallOwnerId = authorId,
                WallOwner = author,
                CreatedOn = DateTime.Now
            };

            this.TwitterData.Tweets.Add(newTweet);
            this.TwitterData.SaveChanges();

            if (upload != null && upload.ContentLength > 0)
            {
                var photo = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = FileType.Photo,
                    ContentType = upload.ContentType,
                    TweetId = newTweet.Id
                };

                using (var render = new System.IO.BinaryReader(upload.InputStream))
                {
                    photo.Content = render.ReadBytes(upload.ContentLength);
                }

                newTweet.Files = new List<File> { photo };
            }

            this.TwitterData.Tweets.Update(newTweet);
            this.TwitterData.SaveChanges();
            var dbTweet =
                this.TwitterData.Tweets.All().Where(t => t.Id == newTweet.Id).Select(TweetViewModel.Create).AsEnumerable();

            var tweetHubContext = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();
            tweetHubContext.Clients.All.receiveTweet(newTweet.Id);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", dbTweet);
            }

            return this.RedirectToAction("Index", "Users", routeValues: new { this.User.Identity.Name });
        }

        // GET: Tweets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.TwitterData.Tweets.Find(id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            ViewBag.WallOwnerId = new SelectList(this.TwitterData.Users.All(), "Id", "ProfilePictureUrl", tweet.WallOwnerId);

            return View(tweet);
        }

        // POST: Tweets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditTweetBindingModel tweet, HttpPostedFileBase upload)
        {
            if (this.ModelState.IsValid)
            {
                var foundTweet = this.TwitterData.Tweets.Find(tweet.Id);

                if (foundTweet == null)
                {
                    return this.HttpNotFound();
                }
                //foundTweet = Mapper.Map<Tweet, Tweet>(tweet);

                foundTweet.Content = tweet.Content;
                foundTweet.CreatedOn = DateTime.Now;

                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload.ContentType,
                        TweetId = tweet.Id
                    };

                    using (var render = new System.IO.BinaryReader(upload.InputStream))
                    {
                        photo.Content = render.ReadBytes(upload.ContentLength);
                    }

                    foundTweet.Files = new List<File> { photo };
                }

                this.TwitterData.Tweets.Update(foundTweet);
                this.TwitterData.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: Tweets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = this.TwitterData.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = this.TwitterData.Tweets.Find(id);
            this.TwitterData.Tweets.Remove(tweet);
            this.TwitterData.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
