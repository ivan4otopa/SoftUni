namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class ApplicationHomePageController : BaseController
    {
        public ApplicationHomePageController(ITwitterData data)
            : base(data)
        {
        }

        // GET: ApplicationHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}