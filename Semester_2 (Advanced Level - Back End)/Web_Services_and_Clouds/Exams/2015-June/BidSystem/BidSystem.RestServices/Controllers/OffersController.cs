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
using BidSystem.Data;
using BidSystem.Data.Models;

namespace BidSystem.RestServices.Controllers
{
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Providers;

    [RoutePrefix("api/offers")]
    public class OffersController : BaseApiController
    {
        public OffersController()
        {
        }

        public OffersController(IBidSystemData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }
  
        // GET: api/offers/all
        [HttpGet]
        [Route("all")]
        public IQueryable<OfferViewModel> GetAllOffers()
        {
            var offers = this.Db.Offers.All()
                .OrderByDescending(o => o.DatePublished)
                .ThenByDescending(o => o.Id)
                .Select(OfferViewModel.FromOffer);
                
            return offers;
        }

        // GET: api/offers/active
        [HttpGet]
        [Route("active")]
        public IQueryable<OfferViewModel> GetAllActiveOffers()
        {
            var offers = this.Db.Offers.All()
                .Where(o => o.ExpirationDateTime > DateTime.Now)
                .OrderBy(o => o.ExpirationDateTime)
                .ThenBy(o => o.Id)
                .Select(OfferViewModel.FromOffer);

            return offers;
        }


        // GET: api/offers/expired
        [HttpGet]
        [Route("expired")]
        public IQueryable<OfferViewModel> GetAllExpiredOffers()
        {
            var offers = this.Db.Offers.All()
                .Where(o => o.ExpirationDateTime <= DateTime.Now)
                .OrderBy(o => o.ExpirationDateTime)
                .ThenBy(o => o.Id)
                .Select(OfferViewModel.FromOffer);

            return offers;
        }

        // GET: api/Offers/5
        [HttpGet]
        [Route("details/{id:int}", Name = "OfferDetails")]
        public IHttpActionResult GetOfferDetailsById(int id)
        {
            var offer = this.Db.Offers.All()
                .Where(o => o.Id == id)
                .Select(OfferDetailViewModel.FromOffer)
                .FirstOrDefault();

            if (offer == null)
            {
                return this.NotFound();
            }

            return this.Ok(offer);
        }

        //GET: api/offers/my
        [HttpGet]
        [Route("my")]
        [Authorize]
        public IHttpActionResult GetUsersOffers()
        {
            var userId = this.UserProvider.GetUserId();

            if (userId == null)
            {
                return this.Unauthorized();
            }

            var offers = this.Db.Offers.All()
                .Where(o => o.SellerId == userId)
                .OrderBy(o => o.DatePublished)
                .ThenBy(o => o.Id)
                .Select(OfferViewModel.FromOffer);

            return this.Ok(offers);
        }


        // POST: api/offers
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostOffer([FromBody]OfferBindingModel model)
        {
            var currentUserId = this.UserProvider.GetUserId();

            if (currentUserId == null)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Missing offer data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var seller = this.Db.Users.Find(currentUserId);

            if (seller == null)
            {
                return this.Unauthorized();
            }

            Offer newOffer = new Offer()
            {
                Title = model.Title,
                Description = model.Description,
                SellerId = currentUserId,
                InitialPrice = model.InitialPrice,
                DatePublished = DateTime.Now,
                ExpirationDateTime =  model.ExpirationDateTime
            };

            this.Db.Offers.Add(newOffer);
            this.Db.SaveChanges();

            return this.CreatedAtRoute("OfferDetails", 
                new { id = newOffer.Id },
                new {newOffer.Id, Seller = seller.UserName, Message = "Offer created"});
        }

    }
}