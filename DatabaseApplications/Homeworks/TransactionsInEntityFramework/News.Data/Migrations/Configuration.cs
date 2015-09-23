namespace News.Data.Migrations
{
    using News.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<News.Data.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "News.Data.NewsContext";
        }

        protected override void Seed(News.Data.NewsContext context)
        {
            if (context.News.Count() > 0)
            {
                return;
            }
                
            context.News.Add(new NewsEntity()
            {
                Content = "Konia se gutna."
            });

            context.News.Add(new NewsEntity()
            {
                Content = "Mari Peno, Genka se ojeni."
            });

            context.News.Add(new NewsEntity()
            {
                Content = "Shte hodim da berem slivi."
            });

            context.News.Add(new NewsEntity()
            {
                Content = "Navun vali"
            });

            context.SaveChanges();
        }
    }
}
