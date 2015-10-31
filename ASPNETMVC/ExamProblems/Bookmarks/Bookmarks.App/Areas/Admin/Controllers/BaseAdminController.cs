namespace Bookmarks.App.Areas.Admin.Controllers
{
    using App.Controllers;
    using Data.UnitOfWork;

    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IBookmarksData data)
            : base(data)
        {
        }
    }
}