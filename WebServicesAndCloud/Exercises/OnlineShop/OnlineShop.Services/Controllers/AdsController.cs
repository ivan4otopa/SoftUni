namespace OnlineShop.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Web.Http;
    using System.Linq;
    using OnlineShop.Models;
    using System;
    using System.Collections.Generic;
    using Data;
    using Infrastructure;

    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController(IOnlineShopData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var ads = this.Data.Ads.All()
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        public IHttpActionResult Post(CreateAdBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("No data sent.");
            }

            if (model.Categories.Count() < 1 || 3 < model.Categories.Count())
            {
                return this.BadRequest("The number of categories should be in the range [1...3]");
            }

            if (model.TypeId < 1 || 3 < model.TypeId)
            {
                return this.BadRequest("The type id should be in the range [1...3]");
            }

            foreach (var categoryId in model.Categories)
            {
                if (categoryId < 1 || 6 < categoryId)
                {
                    return this.BadRequest("All category ids should be in the range [1...6]");
                }
            }

            var categories = new HashSet<Category>();
            foreach (var categoryId in model.Categories)
            {
                var category = ConvertToCategory(categoryId);

                categories.Add(category);
            }


            var loggedUserId = this.UserIdProvider.GetUserId();
            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                TypeId = model.TypeId,
                Price = model.Price,
                PostedOn = DateTime.Now,
                OwnerId = loggedUserId,
                Categories = categories,
                Status = AdStatus.Open
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        [Route("api/ads/{id}/close")]
        [HttpPut]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.All().FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return this.BadRequest("Ad does not exist");
            }

            var userId = this.UserIdProvider.GetUserId();
            if (userId != ad.OwnerId)
            {
                return this.Unauthorized();
            }

            ad.ClosedOn = DateTime.Now;
            ad.Status = AdStatus.Closed;

            this.Data.SaveChanges();
            var changedAd = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(changedAd);
        }

        private Category ConvertToCategory(int categoryId)
        {
            return this.Data.Categories.All().FirstOrDefault(c => c.Id == categoryId);
        }
    }
}
