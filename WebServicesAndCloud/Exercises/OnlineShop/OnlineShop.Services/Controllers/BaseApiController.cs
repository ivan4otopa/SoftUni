namespace OnlineShop.Services.Controllers
{
    using OnlineShop.Data;
    using Infrastructure;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IOnlineShopData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected IOnlineShopData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}
