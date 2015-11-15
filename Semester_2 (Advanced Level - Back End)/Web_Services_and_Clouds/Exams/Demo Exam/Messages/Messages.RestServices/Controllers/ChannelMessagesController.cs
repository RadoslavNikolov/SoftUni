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
    using Models.ViewModels;

    [RoutePrefix("api")]
    public class ChannelMessagesController : ApiController
    {
        private MessagesDbContext db = new MessagesDbContext();

        [HttpGet]
        [Route("channel-messages/{channelName}")]
        public IHttpActionResult GetChannelMessages(string channelName, [FromUri] string limit = null)
        {
            var channel = db.Channels.FirstOrDefault(c => c.Name == channelName);

            if (channel == null)
            {
                return this.NotFound();
            }

            IQueryable<ChannelMessage> messages = db.ChannelMessages
                .Where(c => c.Channel.Id == channel.Id)
                .OrderByDescending(m => m.DateSent)
                .ThenByDescending(m => m.Id);

            if (limit != null)
            {
                int limitCount = 0;
                int.TryParse(limit, out limitCount);
                if (limitCount < 1 || limitCount > 1000)
                {
                    return this.BadRequest("The limit should be in the range [1…1000] inclusively");
                }
                else
                {
                    messages = messages.Take(limitCount);
                }
            }


            return this.Ok(messages.Select(m => new MessageViewModel()
            {
                Id = m.Id,
                Text = m.Text,
                DateSent = m.DateSent,
                Sender = (m.Sender == null) ? null : m.Sender.UserName
            }));
        }


        // POST: api/channel-messages/channelName
        [HttpPost]
        [Route("channel-messages/{channelName}")]
        public IHttpActionResult SendChannelMessage(string channelName, [FromBody] ChannelMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing message data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = this.db.Channels.FirstOrDefault(c => c.Name == channelName);

            if (channel == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentuser = this.db.Users.Find(currentUserId);

            if (currentUserId != null && currentuser == null)
            {
                return this.BadRequest("Loged user does not exists int the data base.");
            }

            var message = new ChannelMessage()
            {
                Channel = channel,
                DateSent = DateTime.Now,
                Text = model.Text,
                Sender = currentuser
            };

            this.db.ChannelMessages.Add(message);
            this.db.SaveChanges();


            if (message.Sender == null)
            {
                return this.Ok(new
                {
                    message.Id,
                    Message = "Anonymous message sent to channel " + message.Channel.Name + "."
                });
            }


            return this.Ok(new
            {
                message.Id,
                message.Sender.UserName,
                Message = "Message sent successfully to channel " + message.Channel.Name + "."
            });

            
        }
    }
}
