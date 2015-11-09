namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using Snippy.Models;
    using Models;

    public class LanguagesController : BaseController
    {
        public LanguagesController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Snippets(string name)
        {
            var language = this.Data.Languages.All()
                .FirstOrDefault(l => l.Name == name);
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(language.Snippets);

            this.ViewBag.LanguageName = language.Name;

            return View(snippetModels);
        }
    }
}