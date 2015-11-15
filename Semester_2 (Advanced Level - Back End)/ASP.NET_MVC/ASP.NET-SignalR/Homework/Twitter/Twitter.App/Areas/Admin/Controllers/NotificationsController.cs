using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Areas.Admin.Controllers
{
    using Hubs;
    using Microsoft.AspNet.SignalR;

    public class NotificationsController : Controller
    {
        // GET: Admin/Notifications
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SendNotification(string type, string notification)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
            hubContext.Clients.All.receiveNotification(type, notification);
            return this.Content("Notification sent.</br>");
        }
    }
}