namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using Models;
    using Snippy.Models;

    public class SnippetsController : BaseController
    {
        public SnippetsController(ISnippyData data)
            : base(data)
        {
        }
        
        public ActionResult All()
        {
            var snippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime);
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return View(snippetModels);
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.All()
                .FirstOrDefault(s => s.Id == id);
            var snippetModel = Mapper.Map<Snippet, SnippetDetailsViewModel>(snippet);

            snippetModel.Comments = snippetModel.Comments
                .OrderByDescending(c => c.CreationTime);

            return this.View(snippetModel);
        }
    }
}