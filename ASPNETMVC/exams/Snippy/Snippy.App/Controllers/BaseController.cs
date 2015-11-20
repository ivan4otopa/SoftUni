namespace Snippy.App.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        protected ISnippyData Data { get; private set; }
    }
}