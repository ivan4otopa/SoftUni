namespace Movies.Data
{
    using Models;
    using Movies.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("name=MoviesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Rating> Ratings { get; set; }
    }
}