namespace SportSystem.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using SportSystem.Models;
    using Microsoft.AspNet.Identity;
    using System.Globalization;

    [Authorize]
    public class BetsController : BaseController
    {
        public BetsController(ISportSystemData data)
            : base(data)
        {
        }
        
        public ActionResult Bet(int id, string bet, decimal betValue)
        {
            var match = this.Data.Matches.All()
                .FirstOrDefault(m => m.Id == id);
            string userId = this.User.Identity.GetUserId();

            Bet newBet = null;

            if (bet == "home")
            {
                newBet = new Bet()
                {
                    HomeTeamBet = betValue,
                    AwayTeamBet = 0,
                    Match = match,
                    UserId = userId
                };
                match.Bets.Add(newBet);

                this.Data.SaveChanges();

                return this.Content(match.Bets.Sum(b => b.HomeTeamBet).ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                newBet = new Bet()
                {
                    HomeTeamBet = 0,
                    AwayTeamBet = betValue,
                    Match = match,
                    UserId = userId
                };
                match.Bets.Add(newBet);

                this.Data.SaveChanges();

                return this.Content(match.Bets.Sum(b => b.AwayTeamBet).ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}