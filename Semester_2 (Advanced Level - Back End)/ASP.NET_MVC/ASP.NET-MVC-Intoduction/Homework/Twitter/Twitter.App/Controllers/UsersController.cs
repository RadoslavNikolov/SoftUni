using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using System.Net;
    using Data.UnitOfWork;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Twitter.Models;

    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }


        // GET: Users and Tweets
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


        // GET: Users review info
        public ActionResult UsersPreview(int pageNum = 0)
        {
            var currentUserName = this.User.Identity.GetUserName();
            IQueryable<User> users = this.TwitterData.Users.All()
                .Where(u => u.UserName != currentUserName)
                .OrderBy(u => u.UserName);

            if (!users.Any())
            {
                this.TempData["error"] = new[] { "No users found!" };
                return this.RedirectToAction("Index", "Home");
            }

            var result = users
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(UserPreviewViewModel.Create)
                    .AsEnumerable();
         

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/UserPreviewViewModel", users);
            }

            return View(result);
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




        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            var userName = this.User.Identity.Name;
            User user = this.TwitterData.Users.All().FirstOrDefault(u => u.UserName == userName);

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditBindingModel model, HttpPostedFileBase upload)
        {
            if (!this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.TwitterData.Users.Find(userId);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;

            if (upload != null && upload.ContentLength > 0)
            {
                var photo = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = FileType.Photo,
                    ContentType = upload.ContentType,
                    UserId = user.Id
                };

                using (var render = new System.IO.BinaryReader(upload.InputStream))
                {
                    photo.Content = render.ReadBytes(upload.ContentLength);
                }

                if (user.Files.Any())
                {
                    user.Files.Remove(user.Files.FirstOrDefault());
                }

                user.Files.Add(photo);
            }

            this.TwitterData.Users.Update(user);
            this.TwitterData.SaveChanges();
            this.TempData["success"] = new[] { "Successfully update your profile!" };

            return View(user);
        }
    }
}