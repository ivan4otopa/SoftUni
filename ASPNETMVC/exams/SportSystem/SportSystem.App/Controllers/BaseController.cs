namespace SportSystem.App.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected ISportSystemData Data { get; private set; }
    }
}