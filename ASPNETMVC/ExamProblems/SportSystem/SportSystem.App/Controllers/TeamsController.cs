namespace SportSystem.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using AutoMapper;
    using SportSystem.Models;
    using Models.ViewModels;
    using Microsoft.AspNet.Identity;
    using Models;
    using Models.BindingModels;
    using System.Collections.Generic;

    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data)
            : base(data)
        {
        }
        
        public ActionResult Details(int id)
        {
            var team = this.Data.Teams.All()
                .FirstOrDefault(t => t.Id == id);
            var teamModel = Mapper.Map<Team, TeamDetailsViewModel>(team);
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .First(u => u.Id == userId);
            var vote = this.Data.Votes.All()
                .FirstOrDefault(v => v.TeamId == team.Id && v.User.Id == userId);
            bool hasVoted = vote == null;
            this.ViewData["userHasVoted"] = hasVoted;

            return View(teamModel);
        }

        public ActionResult Create()
        {
            var players = this.Data.Players.All()
                .Select(p =>
                new SelectListItem()
                {
                    Text = p.Name
                });
            var createTeamModel = new CreateTeamModel();

            createTeamModel.TeamBindingModel = new TeamBindingModel();
            createTeamModel.Players = players;
            createTeamModel.TeamBindingModel.Players = new List<PlayerBindingModel>();

            return this.View(createTeamModel);
        }

        [HttpPost]
        public ActionResult Create(CreateTeamModel model)
        {
            return View();
        }
    }
}