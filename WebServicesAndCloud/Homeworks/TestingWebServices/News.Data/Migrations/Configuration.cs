namespace News.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<News.Data.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "News.Data.NewsContext";
        }

        protected override void Seed(News.Data.NewsContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            context.News.Add(new NewsModel()
            {
                Title = "Selski subor na ploshtada ot 17:30",
                Content = "Shte ima kliu - kliu za babichkite",
                PublishDate = new DateTime(2015, 9, 1)
            });

            context.News.Add(new NewsModel()
            {
                Title = "Razprodajba na kone i muleta subota ot 12:00",
                Content = "Purvite zakupili poluchavat podaruk - kilimche za pred banqta",
                PublishDate = new DateTime(2015, 9, 2)
            });

            context.News.Add(new NewsModel()
            {
                Title = "Predstavlenie na cirkova trupa 'Keleshite' ponedelnik ot 17:00",
                Content = "Na centura",
                PublishDate = new DateTime(2015, 9, 2)
            });
        }
    }
}
