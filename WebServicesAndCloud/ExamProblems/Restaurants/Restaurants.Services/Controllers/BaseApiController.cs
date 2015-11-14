namespace Restaurants.Services.Controllers
{
    using Data;
    using Infrastructure;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(RestaurantsContext data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        public BaseApiController()
            : this(new RestaurantsContext(), new AspNetUserIdProvider())
        {
        }

        protected RestaurantsContext Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}
