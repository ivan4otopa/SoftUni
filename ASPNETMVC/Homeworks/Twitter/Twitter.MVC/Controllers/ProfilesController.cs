namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class ProfilesController : BaseController
    {
        public ProfilesController(ITwitterData data)
            : base(data)
        {
        }

        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }
    }
}