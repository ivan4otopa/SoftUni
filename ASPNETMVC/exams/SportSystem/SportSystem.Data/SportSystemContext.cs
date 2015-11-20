namespace SportSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Migrations;

    public class SportSystemContext : IdentityDbContext<User>, ISportSystemContext
    {
        public SportSystemContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportSystemContext, Configuration>());
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static SportSystemContext Create()
        {
            return new SportSystemContext();
        }
    }
}
