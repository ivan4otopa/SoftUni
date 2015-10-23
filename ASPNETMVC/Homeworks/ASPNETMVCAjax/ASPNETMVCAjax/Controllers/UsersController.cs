namespace ASPNETMVCAjax.Controllers
{
    using Models;
    using System.Linq;
    using System.Web.Mvc;

    public class UsersController : Controller
    {
        public JsonResult CheckUsername(string username)
        {
            var db = new ApplicationDbContext();
            var data = db.Users
                .FirstOrDefault(u => u.UserName == username);

            return Json(data == null, JsonRequestBehavior.AllowGet);
        }
    }
}