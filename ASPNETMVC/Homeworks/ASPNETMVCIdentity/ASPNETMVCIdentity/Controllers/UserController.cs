namespace ASPNETMVCIdentity.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}