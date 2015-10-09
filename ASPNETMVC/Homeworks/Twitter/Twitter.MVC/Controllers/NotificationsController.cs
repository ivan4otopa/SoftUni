namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        // GET: Notifications
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}