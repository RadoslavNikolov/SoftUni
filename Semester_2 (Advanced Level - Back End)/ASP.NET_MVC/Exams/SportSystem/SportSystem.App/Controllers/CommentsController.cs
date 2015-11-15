using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSystem.App.Controllers
{
    using System.Net;
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Model;
    using Models.BindigModels;
    using Models.ViewModels;

    public class CommentsController : BaseController
    {
        public CommentsController(ISportSystemData data) : base(data)
        {
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommentBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var newComment = new Comment()
                {
                    MatchId = model.MatchId,
                    OwnerId = this.UserProfile.Id,
                    PostedOn = DateTime.Now,
                    Text = model.Content
                };

                this.SportSystemData.Comments.Add(newComment);
                this.SportSystemData.SaveChanges();

                var commentViewModel = this.SportSystemData.Comments.All()
                    .Where(c => c.Id == newComment.Id)
                    .ProjectTo<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentViewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid comment!");
        }
    }
}