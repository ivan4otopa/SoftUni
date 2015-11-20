namespace DossierSystem.Data
{
    using Migrations;
    using Models;
    using System.Data.Entity;

    public class DossierSystemContext : DbContext
    {
        public DossierSystemContext()
            : base("DossierSystemContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                    DossierSystemContext,
                    Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.Individuals)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("IndividualId");
                    x.MapRightKey("RelatedId");
                    x.ToTable("RelatedIndividuals");
                });

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Individual> Individuals { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Activity> Activities { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<ActivityType> ActivityTypes { get; set; }
    }
}