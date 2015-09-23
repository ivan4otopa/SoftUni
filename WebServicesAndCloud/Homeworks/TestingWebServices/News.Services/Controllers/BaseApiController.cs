namespace News.Services.Controllers
{
    using Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(INewsData data)
        {
            this.Data = data;
        }

        public BaseApiController()
            : this(new NewsData(new NewsContext()))
        {
        }

        protected INewsData Data { get; set; }
    }
}
