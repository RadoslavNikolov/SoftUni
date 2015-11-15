namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using OnlineShop.Models;

    [Authorize]
    [RoutePrefix("api/ads")]
    public class AdsController : BaseApiController
    {
        public AdsController()
            : base()
        {
            
        }

        public AdsController(
            IOnlineShopData data,
            IUserIdProvider userIdProvider)
            :base(data,userIdProvider)
        {
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.All().Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.PostedOn)
                .ToList();

            List<AdViewModel> viewModelAd = new List<AdViewModel>();

            foreach (var ad in ads)
            {
                viewModelAd.Add(new AdViewModel(ad));
            }

            return this.Ok(viewModelAd);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all")]
        public IHttpActionResult GetAllAds()
        {
            var ads = this.Data.Ads.All().ToList();

            List<AdViewModel> viewModelAd = new List<AdViewModel>();

            foreach (var ad in ads)
            {
                viewModelAd.Add(new AdViewModel(ad));
            }

            return this.Ok(viewModelAd);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("closed")]
        public IHttpActionResult GetClosedAds()
        {
            var ads = this.Data.Ads.All().Where(a => a.Status == AdStatus.Closed)
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.ClosedOn)
                .ToList();

            List<ClosedAdViewModel> viewModelAd = new List<ClosedAdViewModel>();

            foreach (var ad in ads)
            {
                viewModelAd.Add(new ClosedAdViewModel(ad));
            }

            return this.Ok(viewModelAd);
        }

        [HttpPost]
        public IHttpActionResult CreateAd([FromBody] CreateAdBindingModel model)
        {
            var userId = this.UserIdProvider;

            if (userId == null)
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model.Categories.Count() > 3)
            {
                return this.BadRequest("To manu categorie!");
            }

            if (model.Categories.Count() == 0)
            {
                return this.BadRequest("At least 1 category needed!");
            }

            var type = this.Data.AdTypes.All().FirstOrDefault(t => t.Id == model.TypeId);

            if (type == null)
            {
                return this.BadRequest("Type Id is not real");
            }

            var categoryList = new List<Category>();

            foreach (var category in model.Categories)
            {
                var categoryDB = this.Data.Categories.All().FirstOrDefault(c => c.Id == category);

                if (categoryDB == null)
                {
                    return this.BadRequest("Category Id is not real!");
                }
                
                categoryList.Add(categoryDB);              
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                TypeId = model.TypeId,
                Price = model.Price,
                Status = AdStatus.Open,
                OwnerId = userId.ToString(),
                PostedOn = DateTime.Now,
                Categories = categoryList
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }


        [HttpPut]
        [Route("{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            Ad ad = this.Data.Ads.All()
                .FirstOrDefault(a => a.Id == id);

            if (ad == null)
            {
                return this.NotFound();
            }

            string userId = this.UserIdProvider.ToString();

            if (ad.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            if (ad.Status == AdStatus.Closed)
            {
                return this.BadRequest("Ad is already closed");
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            return this.Ok(new AdViewModel(ad));
        }
    }
}