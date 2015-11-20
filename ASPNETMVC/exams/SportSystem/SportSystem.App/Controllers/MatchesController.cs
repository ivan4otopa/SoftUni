namespace SportSystem.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using AutoMapper;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SportSystem.Models;
    using PagedList;
    using PagedList.Mvc;
    using System.Linq;

    [Authorize]
    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data) 
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Matches(int? page)
        {
            var matches = this.Data.Matches.All();
            var matchModels = Mapper.Map<IEnumerable<Match>, IEnumerable<MatchViewModel>>(matches)
                .ToPagedList(page ?? 1, 3);

            return this.View(matchModels);
        }

        public ActionResult Details(int id)
        {
            var match = this.Data.Matches.All()
                .FirstOrDefault(m => m.Id == id);
            var matchModel = Mapper.Map<Match, MatchDetailsViewModel>(match);

            return this.View(matchModel);
        }
    }
}