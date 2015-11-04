namespace SportSystem.Data
{
    using System.Data.Entity;

    using Models;

    public interface ISportSystemContext
    {
        IDbSet<Team> Teams { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Bet> Bets { get; set; }

        IDbSet<Vote> Votes { get; set; }
    }
}
