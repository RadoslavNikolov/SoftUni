using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BugTracker.Data;
using BugTracker.Data.Models;

namespace BugTracker.RestServices.Controllers
{
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/Bugs")]
    public class BugsController : ApiController
    {

        private readonly IBugTrackerData db;

        public BugsController()
            : this(new BugTrackerData())
        {
        }

        public BugsController(IBugTrackerData data)
        {
            this.db = data;
        }


        // GET: api/Bugs
        [HttpGet]
        public IHttpActionResult GetBugs()
        {
            var bugs = this.db.Bugs.All()
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(b => new BugViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.DateCreated
                });

            return this.Ok(bugs);
        }

        // GET: api/Bugs/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBug(int id)
        {
            var bug = this.db.Bugs.All()
                .Where(b => b.Id == id)
                .Select(b => new BugDetailViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.DateCreated,
                    Comments = b.Comments.OrderByDescending(c => c.DateCreated).ThenByDescending(c => c.Id)
                        .Select(c => new CommentViewModel()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Author = c.Author == null ? null  : c.Author.UserName,
                            DateCreated = c.DateCreated
                        })
                }).FirstOrDefault();

            if (bug == null)
            {
                return this.NotFound();
            }

            return this.Ok(bug);
        }

        // PATCH: api/Bugs/5
        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult EditBug([FromUri]int id, [FromBody] EditBugBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Missing bug data to patch.");
            }

            Bug bug = this.db.Bugs.All().FirstOrDefault(b => b.Id == id);

            if (bug == null)
            {
                return this.NotFound();
            }


            if (model.Title != null)
            {
                bug.Title = model.Title;
            }

            if (model.Description != null)
            {
                bug.Description = model.Description;
            }

            if (model.Status != null)
            {
                bug.Status = model.Status.Value;
            }

            this.db.Bugs.Update(bug);
            this.db.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Bug #{0} patched.", bug.Id)
            });

        }

        // POST: api/bugs
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostBug([FromBody] SubmitBugBindingModel model)
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (model == null)
            {
                return this.BadRequest("Missing bug data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newBug = new Bug()
            {
                Title = model.Title,
                Description = model.Description,
                AuthorId = currentUserId,
                Status = BugStatus.Open,
                DateCreated = DateTime.Now

            };

            this.db.Bugs.Add(newBug);
            this.db.SaveChanges();

            if (currentUserId == null)
            {
                return CreatedAtRoute("DefaultApi",
                    new {id = newBug.Id},
                    new {newBug.Id, Message = "Anonymous bug submitted."});
            }

            return CreatedAtRoute("DefaultApi",
                new { id = newBug.Id },
                new { newBug.Id, Author = this.User.Identity.GetUserName(), Message = "User bug submitted." });
        }

        // DELETE: api/Bugs/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = this.db.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }


            this.db.Bugs.Remove(bug);
            this.db.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Bug #{0} deleted.", id)
            });
        }

        //GET: api/bugs/filet
        [HttpGet]
        [Route("filter")]
        public IHttpActionResult BugsByFilter(
            [FromUri] string keyword = null,
            [FromUri] string statuses = null,
            [FromUri] string author = null)
        {
            var bugs = this.db.Bugs.All()
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(b => new BugViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.DateCreated
                });

            if (keyword != null)
            {
                bugs = bugs.Where(b => b.Title.Contains(keyword));
            }

            if (statuses != null)
            {
                string[] tokens = statuses.Split('|');
                bugs = bugs.Where(b => tokens.Contains(b.Status));
            }

            if (author != null)
            {
                bugs = bugs.Where(b => b.Author == author);
            }

            return this.Ok(bugs);
        }

    }
}