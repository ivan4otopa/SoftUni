namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}