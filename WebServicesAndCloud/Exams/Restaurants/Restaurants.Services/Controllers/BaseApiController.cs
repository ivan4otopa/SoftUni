namespace Restaurants.Services.Controllers
{
    using Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(RestaurantsContext data)
        {
            this.Data = data;
        }

        public BaseApiController()
            : this(new RestaurantsContext())
        {
        }

        protected RestaurantsContext Data { get; set; }
    }
}
