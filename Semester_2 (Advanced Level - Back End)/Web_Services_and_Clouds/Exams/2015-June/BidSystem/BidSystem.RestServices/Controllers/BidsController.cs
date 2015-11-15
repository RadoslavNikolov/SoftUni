using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BidSystem.RestServices.Controllers
{
    using Data;
    using Data.Models;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Providers;

    [RoutePrefix("api")]
    [Authorize]
    public class BidsController : BaseApiController
    {
        public BidsController()
        {
        }

         public BidsController(IBidSystemData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        // GET: api/bids/my
        [Route("bids/my")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetLogedUsersBids()
        {
            var currentUserId = this.UserProvider.GetUserId();
            var loggedUser = this.Db.Users.Find(currentUserId);

            if (loggedUser == null)
            {
                return this.Unauthorized();
            }

            var bids = this.Db.Bids.All()
                .Where(b => b.BidderId == currentUserId)
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(BidOutputViewModel.FromBid);

            return this.Ok(bids);
        }


        // GET: api/bids/won
        [HttpGet]
        [Route("bids/won")]
        public IHttpActionResult GetLogedUserWonBids()
        {
            var currentUserId = this.UserProvider.GetUserId();
            var loggedUser = this.Db.Users.Find(currentUserId);

            if (loggedUser == null)
            {
                return this.Unauthorized();
            }


            var wonBids = this.Db.Bids.All()
                .Where(b => b.BidderId == currentUserId)
                .Where(b => b.Offer.ExpirationDateTime < DateTime.Now)
                .Where(b => b.OfferedPrice == b.Offer.Bids.Max(bid => bid.OfferedPrice))
                .OrderBy(b => b.DateCreated)
                .ThenBy(b => b.Id)
                .Select(BidOutputViewModel.FromBid);

            return this.Ok(wonBids);
        }


        // POST: api/offers/{id}/bid
        [HttpPost]
        [Route("offers/{id:int}/bid")]
        public IHttpActionResult BidForOfferById(int id, [FromBody] BidBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing bid data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentUserId = this.UserProvider.GetUserId();
            var loggedUser = this.Db.Users.Find(currentUserId);

            if (loggedUser == null)
            {
                return this.Unauthorized();
            }

            var currentOffer = this.Db.Offers.Find(id);

            if (currentOffer == null)
            {
                return this.NotFound();
            }

            if (currentOffer.ExpirationDateTime < DateTime.Now)
            {
                return this.Content(HttpStatusCode.BadRequest, new
                {
                    Message = "Offer has expired."
                });
            }

            if (currentOffer.InitialPrice >= model.BidPrice ||
                currentOffer.Bids.Any(b => b.OfferedPrice >= model.BidPrice))
            {
                var minBid = currentOffer.InitialPrice;

                if (currentOffer.Bids.Any())
                {
                    minBid = Math.Max(minBid, currentOffer.Bids.Max(b => b.OfferedPrice));
                    
                }

                return this.Content(HttpStatusCode.BadRequest, new
                {
                    Message =
                        string.Format("Your bid should be > {0}", minBid)
                });
            }

            var bidder = this.Db.Users.Find(currentUserId);

            if (bidder == null)
            {
                return this.Unauthorized();
            }

            var newBid = new Bid()
            {
                OfferId = id,
                BidderId = currentUserId,
                OfferedPrice = model.BidPrice,
                Comment = model.Comment,
                DateCreated = DateTime.Now
            };

            this.Db.Bids.Add(newBid);
            this.Db.SaveChanges();

            return this.Ok(
                new {newBid.Id, Bidder = bidder.UserName, Message = "Bid created."});

        }
    }
}
