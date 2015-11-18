namespace BugTracker.RestServices.Controllers
{
    using BugTracker.Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(BugTrackerDbContext data)
        {
            this.Data = data;
        }

        public BaseApiController()
            : this(new BugTrackerDbContext())
        {
        }

        protected BugTrackerDbContext Data { get; set; }
    }
}
