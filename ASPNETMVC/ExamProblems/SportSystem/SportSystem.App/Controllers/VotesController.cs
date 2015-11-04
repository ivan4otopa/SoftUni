namespace SportSystem.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using SportSystem.Models;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class VotesController : BaseController
    {
        public VotesController(ISportSystemData data) 
            : base(data)
        {
        }
        
        public ActionResult Vote(int id)
        {
            var team = this.Data.Teams.All()
                .FirstOrDefault(t => t.Id == id);
            string userId = this.User.Identity.GetUserId();

            team.Votes.Add(new Vote()
            {
                UserId = userId
            });

            this.Data.SaveChanges();

            return this.Content("Votes: " + team.Votes.Count);
        }
    }
}