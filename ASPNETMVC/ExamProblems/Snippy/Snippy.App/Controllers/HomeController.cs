namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using Models;
    using AutoMapper;
    using System.Collections.Generic;
    using Snippy.Models;

    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var latestSnippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime)
                .Take(5);
            var latestComments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreationTime)
                .Take(5);
            var bestLabels = this.Data.Labels.All()
                .OrderByDescending(l => l.Snippets.Count)
                .Take(5);
            var latestSnippetsModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(latestSnippets);
            var latestCommentsModels = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(latestComments);
            var bestLabelsModels = Mapper.Map<IEnumerable<Label>, IEnumerable<LabelViewModel>>(bestLabels);
            var homeViewModel = new HomeViewModel();

            homeViewModel.Snippets = latestSnippetsModels;
            homeViewModel.Comments = latestCommentsModels;
            homeViewModel.Labels = bestLabelsModels;

            return View(homeViewModel);
        }
    }
}