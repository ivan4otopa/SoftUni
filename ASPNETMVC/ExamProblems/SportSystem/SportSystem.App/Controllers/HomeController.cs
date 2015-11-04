using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportSystem.Data.UnitOfWork;
using AutoMapper;
using SportSystem.App.Models.ViewModels;
using SportSystem.Models;

namespace SportSystem.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var matches = this.Data.Matches.All()
                .OrderByDescending(m => m.Bets.Count)
                .Take(3);
            var teams = this.Data.Teams.All()
                .OrderByDescending(t => t.Votes.Count)
                .Take(3);
            var matchModels = Mapper.Map<IEnumerable<Match>, IEnumerable<MatchViewModel>>(matches);
            var teamModels = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(teams);
            var homeViewModel = new HomeViewModel();

            homeViewModel.Matches = matchModels;
            homeViewModel.Teams = teamModels;

            return View(homeViewModel);
        }
    }
}