namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using AutoMapper;
    using Snippy.Models;
    using System.Collections.Generic;
    using Models;

    public class LabelsController : BaseController
    {
        public LabelsController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Snippets(int id)
        {
            var label = this.Data.Labels.All()
                .FirstOrDefault(l => l.Id == id);
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(label.Snippets);

            this.ViewBag.LabelText = label.Text;

            return View(snippetModels);
        }
    }
}