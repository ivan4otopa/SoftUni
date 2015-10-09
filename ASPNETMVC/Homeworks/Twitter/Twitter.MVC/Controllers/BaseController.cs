namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class BaseController : Controller
    {
        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        public ITwitterData Data { get; }
    }
}