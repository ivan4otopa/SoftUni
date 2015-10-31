namespace Bookmarks.App.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public BaseController(IBookmarksData data)
        {
            this.Data = data;
        }

        protected IBookmarksData Data { get; }
    }
}