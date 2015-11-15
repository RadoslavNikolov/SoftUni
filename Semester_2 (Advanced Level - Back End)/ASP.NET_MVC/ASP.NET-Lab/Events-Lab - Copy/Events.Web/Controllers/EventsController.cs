using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    using Data;
    using Extensions;
    using Microsoft.AspNet.Identity;
    using Models;

    public class EventsController : BaseController
    {
        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var loggedUser = this.db.Users.Find(loggedUserId);

            if (model != null && this.ModelState.IsValid)
            {
                var newEvent = new Event()
                {
                    AuthorId = loggedUserId,
                    Author = loggedUser,
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };

                this.db.Events.Add(newEvent);
                this.db.SaveChanges();
                this.AddNotification("Event created", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return View(model);
        }


        // GET: Events/My
        public ActionResult My()
        {
            return View();
        }
    }
}