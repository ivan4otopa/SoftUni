namespace ASPNETMVCIdentity.Controllers
{
    using Filters;
    using System.Web.Mvc;

    [AuthorizeRedirect(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}