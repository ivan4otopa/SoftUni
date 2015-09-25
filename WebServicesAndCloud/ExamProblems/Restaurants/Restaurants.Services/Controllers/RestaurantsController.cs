namespace Restaurants.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Web.Http;
    using System.Linq;
    using Restaurants.Models;

    public class RestaurantsController : BaseApiController
    {
        public IHttpActionResult GetAllByTown(int townId)
        {
            var restaurants = this.Data.Restaurants
                .Where(r => r.TownId == townId)
                .OrderByDescending(r => r.Ratings.Average(ra => ra.Stars))
                .ThenBy(r => r.Name)
                .Select(RestaurantViewModel.Create);

            return this.Ok(restaurants);
        }

        [Authorize]
        public IHttpActionResult Create([FromBody]RestaurantBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = this.Data.Users
                .FirstOrDefault(u => u.Id == userId);
            var town = this.Data.Towns
                .FirstOrDefault(t => t.Id == model.TownId);
            var newRestaurant = new Restaurant()
            {
                Name = model.Name,
                Town = town,
                Owner = user
            };

            this.Data.Restaurants.Add(newRestaurant);
            this.Data.SaveChanges();

            var restaurantViewModel = this.Data.Restaurants
                .Where(r => r.Id == newRestaurant.Id)
                .Select(RestaurantViewModel.Create);

            return this.CreatedAtRoute("DefaultApi", new { id = newRestaurant.Id }, restaurantViewModel);
        }

        [Route("api/restaurants/{id}/rate")]
        [Authorize]
        public IHttpActionResult Rate(int id, [FromBody]RatingBindingModel model)
        {
            var restaurant = this.Data.Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            string userId = this.User.Identity.GetUserId();                        

            if (restaurant.OwnerId == userId)
            {
                return this.BadRequest();
            }

            var rating = this.Data.Ratings
                .FirstOrDefault(r => r.UserId == userId && r.RestaurantId == id);

            if (rating == null)
            {
                var newRating = new Rating()
                {
                    Stars = model.Stars,
                    UserId = userId,
                    RestaurantId = id
                };

                this.Data.Ratings.Add(newRating);
            }
            else
            {
                rating.Stars = model.Stars;
            }
            
            this.Data.SaveChanges();

            return this.Ok();
        }

        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetMealsByRestaurantId(int id)
        {
            var restaurant = this.Data.Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = this.Data.Meals
                .Where(m => m.RestaurantId == id)
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Name)
                .Select(MealViewModel.Create);

            return this.Ok(meals);
        }
    }
}
