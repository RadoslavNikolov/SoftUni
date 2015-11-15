using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Messages.RestServices.Controllers
{
    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;

    [RoutePrefix("api/user")]
    [Authorize]
    public class UserMessagesController : ApiController
    {
        private MessagesDbContext db = new MessagesDbContext();

        // GET: api/user/personal-messages
        [HttpGet]
        [Route("personal-messages")]
        public IHttpActionResult GetPersonalMessages()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            IQueryable<UserMessage> messages = db.UserMessages
                .Where(m => m.RecipientUser.UserName == currentUser.UserName)
                .OrderByDescending(m => m.DateSent)
                .ThenByDescending(m => m.Id);


            return this.Ok(messages.Select(m => new
            {
                m.Id,
                m.Text,
                m.DateSent,
                Sender = (m.SenderUser == null) ? null : m.SenderUser.UserName
            }));
        }


        // POST: api/user/personal-messages
        [HttpPost]
        [Route("personal-messages")]
        [AllowAnonymous]
        public IHttpActionResult SendPersonalMessage(UserMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing message data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
           
            var recipientUser = this.db.Users.FirstOrDefault(u => u.UserName == model.Recipient);

            if (recipientUser == null)
            {
                return this.BadRequest("Recipient user " + model.Recipient + " does not exists.");
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.db.Users.Find(currentUserId);

            if (currentUserId != null && currentUser == null)
            {
                return this.Unauthorized();
            }
            
            var message = new UserMessage()
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                SenderUser = currentUser,
                RecipientUser = recipientUser
            };

            this.db.UserMessages.Add(message);
            this.db.SaveChanges();



            if (message.SenderUser == null)
            {
                return this.Ok(new
                {
                    message.Id,
                    Message = "Anonymous message sent to channel " + message.RecipientUser.UserName + "."
                });
            }


            return this.Ok(new
            {
                message.Id,
                message.SenderUser.UserName,
                Message = "Message sent successfully to user " + message.RecipientUser.UserName + "."
            });
        }
    }
}
