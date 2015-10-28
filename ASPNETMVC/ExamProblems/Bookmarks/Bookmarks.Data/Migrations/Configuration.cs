namespace Bookmarks.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bookmarks.Data.BookmarksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Bookmarks.Data.BookmarksContext";
        }

        protected override void Seed(Bookmarks.Data.BookmarksContext context)
        {
            if (context.Bookmarks.Any())
            {
                return;
            }

            var pesho = new User()
            {
                UserName = "pesho@goshov.com",
                Email = "pesho@goshov.com"
            };
            var gosho = new User()
            {
                UserName = "gosho@peshev.com",
                Email = "gosho@peshev.com"
            };
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.Create(pesho, "123");
            userManager.Create(gosho, "123");

            context.SaveChanges();
        }
    }
}
