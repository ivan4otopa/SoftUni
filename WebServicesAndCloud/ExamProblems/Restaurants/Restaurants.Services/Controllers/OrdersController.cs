namespace Restaurants.Services.Controllers
{
    using Restaurants.Models;
    using Restaurants.Services.Models;
    using System.Linq;
    using System.Web.Http;

    public class OrdersController : BaseApiController
    {
        [Authorize]
        [Route("api/orders/{startPage?}/{limit?}/{mealId?}")]
        public IHttpActionResult GetByFilter([FromUri]int startPage, [FromUri]int limit, [FromUri]string mealId = null)
        {
            if (2 > limit || limit > 10)
            {
                return this.BadRequest();
            }

            var orders = this.Data.Orders
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(startPage * limit)
                .Take(limit)
                .Select(OrderViewModel.Create);

            if (mealId != null)
            {
                int idOfMeal = int.Parse(mealId);

                orders = orders
                    .Where(o => o.Meal.Id == idOfMeal);
            }

            return this.Ok(orders);
        }
    }
}
