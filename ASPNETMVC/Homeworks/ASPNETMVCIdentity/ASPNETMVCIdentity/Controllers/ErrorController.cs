namespace ASPNETMVCIdentity.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}