using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.App.Controllers
{
    using System.Net;
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using Models.ViewModels;
    using Snippy.Models;

    public class CommentsController : BaseController
    {
        public CommentsController(ISnippyData data) : base(data)
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
                    SnippetId = model.SnippetId,
                    AuthorId = this.UserProfile.Id,
                    CreatedOn = DateTime.Now,
                    Content = model.Content
                };

                this.SnippyData.Comments.Add(newComment);
                this.SnippyData.SaveChanges();

                var commentViewModel = this.SnippyData.Comments.All()
                    .Where(c => c.Id == newComment.Id)
                    .ProjectTo<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentViewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid comment!");
        }
    }
}