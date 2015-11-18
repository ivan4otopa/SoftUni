namespace Mountains.Data
{
    using Models;
    using Mountains.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainsContext : DbContext
    {
        public MountainsContext()
            : base("name=MountainsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Mountain> Mountains { get; set; }

        public IDbSet<Peak> Peaks { get; set; }
    }
}