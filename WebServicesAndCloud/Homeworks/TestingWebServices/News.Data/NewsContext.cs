namespace News.Data
{
    using Models;
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("NewsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }

        public virtual IDbSet<NewsModel> News { get; set; }
    }
}