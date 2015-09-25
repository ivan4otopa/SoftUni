namespace Restaurants.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using Restaurants.Models;
    using Restaurants.Services.Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class MealsController : BaseApiController
    {
        [Authorize]
        public IHttpActionResult Create([FromBody]CreateMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes
                .FirstOrDefault(mt => mt.Id == model.TypeId);

            if (type == null)
            {
                return this.BadRequest();
            }

            var restaurant = this.Data.Restaurants
                .FirstOrDefault(r => r.Id == model.RestaurantId);

            if (restaurant == null)
            {
                return this.BadRequest();
            }

            string userId = this.User.Identity.GetUserId();

            if (restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            var newMeal = new Meal()
            {
                Name = model.Name,
                Price = model.Price,
                TypeId = model.TypeId,
                RestaurantId = model.RestaurantId
            };

            this.Data.Meals.Add(newMeal);
            this.Data.SaveChanges();

            var mealViewModel = this.Data.Meals
                .Where(m => m.Id == newMeal.Id)
                .Select(MealViewModel.Create);

            return this.CreatedAtRoute("DefaultApi", new { id = newMeal.Id }, mealViewModel);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]EditMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes
                .FirstOrDefault(mt => mt.Id == model.TypeId);

            if (type == null)
            {
                return this.BadRequest();
            }

            var meal = this.Data.Meals
                .FirstOrDefault(m => m.Id == id);

            if (meal == null)
            {
                return this.NotFound();
            }

            string userId = this.User.Identity.GetUserId();

            if (meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.TypeId = model.TypeId;

            this.Data.SaveChanges();

            var mealViewModel = this.Data.Meals
                .Where(m => m.Id == id)
                .Select(MealViewModel.Create);

            return this.Ok(mealViewModel);
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var meal = this.Data.Meals
                .FirstOrDefault(m => m.Id == id);

            if (meal == null)
            {
                return this.NotFound();
            }

            string userId = this.User.Identity.GetUserId();

            if (meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Remove(meal);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Meal #{0} deleted.", id)
            });
        }

        [Authorize]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult CreateOrder(int id, [FromBody]OrderBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                return this.Unauthorized();
            }

            var meal = this.Data.Meals
                .FirstOrDefault(m => m.Id == id);

            if (meal == null)
            {
                return this.NotFound();
            }

            var newOrder = new Order()
            {
                Quantity = model.Quantity,
                OrderStatus = OrderStatus.Pending,
                CreatedOn = DateTime.Now,
                MealId = id,
                UserId = userId
            };

            this.Data.Orders.Add(newOrder);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
