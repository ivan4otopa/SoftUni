namespace Twitter.MVC.Controllers    
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class UserHomePageController : BaseController
    {
        public UserHomePageController(ITwitterData data)
            : base(data)
        {
        }

        // GET: UserHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}