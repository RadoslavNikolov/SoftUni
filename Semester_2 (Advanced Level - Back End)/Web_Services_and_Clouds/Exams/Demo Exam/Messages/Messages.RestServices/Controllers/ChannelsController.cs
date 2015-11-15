
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Messages.RestServices.Controllers
{
    using System.Data.Entity.Migrations;
    using Data;
    using Data.Models;
    using Models.BindingModels;

    [RoutePrefix("api")]
    public class ChannelsController : ApiController
    {
        private MessagesDbContext db = new MessagesDbContext();

        //GET: api/channels
        [HttpGet]
        [Route("channels")]
        public IHttpActionResult GetAllChannels()
        {
            var channels = db.Channels
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Id,
                    c.Name
                });

            return this.Ok(channels);
        }


        //GET: /api/channels/{id}
        [Route("channels/{id:int}")]
        public IHttpActionResult GetChannelById(int id)
        {
            Channel channel = db.Channels.Find(id);
            if (channel == null)
            {
                return this.NotFound();
            }

            return this.Ok(new
            {
                channel.Id,
                channel.Name
            });
        }

        //POST: /api/channels
        [HttpPost]
        [Route("channels")]
        public IHttpActionResult CreateChannel(ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing channel data");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (db.Channels.Any(c => c.Name == model.Name))
            {
                return this.Content(HttpStatusCode.Conflict,
                    new
                    {
                        Mesaage = "Duplicated channel name: " + model.Name
                    });
            }

            var channel = new Channel()
            {
                Name =  model.Name
            };

            db.Channels.Add(channel);
            db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi",
                new {controller = "channels", id = channel.Id},
                new {channel.Id, channel.Name});
        }

        //PUT: /api/channels/{id}
        [Route("channels/{id:int}")]
        [HttpPut]
        public IHttpActionResult EditChannel(int id, [FromBody] ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing channel data");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = db.Channels.Find(id);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (db.Channels.Any(c => c.Name == model.Name && c.Id != id))
            {
                return this.Content(HttpStatusCode.Conflict,
                    new
                    {
                        Mesaage = "Duplicated channel name: " + model.Name
                    });
            }

            channel.Name = model.Name;
            db.Channels.AddOrUpdate(channel);
            db.SaveChanges();

            return this.Ok(new
            {
                Message = "Channel #" + channel.Id + " edited successfully."
            });
        }

        //DELET: /api/channels/{id}
        [Route("channels/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteChannelById(int id)
        {
            Channel channel = db.Channels.Find(id);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (channel.Messages.Any())
            {
                return this.Content(HttpStatusCode.Conflict,
                    new
                    {
                        Message = "Cannot delete channel #" + channel.Id + " because it is not empty."
                    });
            }

            db.Channels.Remove(channel);
            db.SaveChanges();

            return this.Ok(new
            {
                Message = "Channel #" + id + " deleted."
            });
        }
    }
}
