using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.RestServices.Controllers
{
    using Data;
    using Data.Models;
    using Data.Repositories;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api")]
    public class CommentsController : ApiController
    {
        private readonly IBugTrackerData db;

        public CommentsController()
            : this(new BugTrackerData())
        {
        }

        public CommentsController(IBugTrackerData data)
        {
            this.db = data;
        }

        //GET: api/comments
        [Route("comments")]
        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            var comments = this.db.Comments.All()
                .OrderByDescending(c => c.DateCreated)
                .ThenBy(c => c.Id)
                .Select(c => new CommentDetailViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated,
                    BugId = c.BugId,
                    BugTitle = c.Bug.Title
                });

            return this.Ok(comments);
        }

        //GET: api/bugs/{id}/comments
        [HttpGet]
        [Route("bugs/{id:int}/comments")]
        public IHttpActionResult GetCommentsByBugId([FromUri]int id)
        {
            var bug = this.db.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments
                .OrderByDescending(c => c.DateCreated)
                .ThenByDescending(c => c.Id)
                .Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated
                });

            return this.Ok(comments);
        }

        //POST: api/bugs/{id}/comments
        [HttpPost]
        [Route("bugs/{id:int}/comments")]
        public IHttpActionResult PostCommentForGivenBug([FromUri]int id, [FromBody] SubmitCommentBindingModel model)
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (model == null)
            {
                return this.BadRequest("Missing comment data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = this.db.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var newComment = new Comment()
            {
                Text = model.Text,
                AuthorId = currentUserId,
                BugId = id,
                DateCreated = DateTime.Now

            };

            this.db.Comments.Add(newComment);
            this.db.SaveChanges();

            if (currentUserId == null)
            {
                return this.Ok(new
                {
                    Id = newComment.Id,
                    Message = string.Format("Added Anonymous comment for bug #{0}", bug.Id)
                });
            }


            return this.Ok(new
            {
                Id = newComment.Id,
                Author = this.User.Identity.GetUserName(),
                Message = string.Format("User comment added for bug #{0}", bug.Id)
            });
        }     
    }
}
