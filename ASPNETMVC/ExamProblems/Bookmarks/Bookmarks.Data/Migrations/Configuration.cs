namespace Bookmarks.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

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
            var user = new User()
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com"
            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));            
            var userManager = new UserManager<User>(new UserStore<User>(context));
            
            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 3
            };
            userManager.Create(pesho, "123");
            userManager.Create(gosho, "123");
            userManager.Create(user, "123");

            var roleCreateResult = roleManager.Create(new IdentityRole("Admin"));

            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var adminUser = context.Users
                .FirstOrDefault(u => u.UserName == "admin@admin.com");
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, "Admin");

            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }

            context.Categories.Add(new Category()
            {
                Name = "Funny"
            });
            context.Categories.Add(new Category()
            {
                Name = "Games"
            });
            context.Categories.Add(new Category()
            {
                Name = "Work"
            });
            context.Categories.Add(new Category()
            {
                Name = "Videos"
            });
            context.Categories.Add(new Category()
            {
                Name = "Music"
            });
            context.Categories.Add(new Category()
            {
                Name = "Sport"
            });
            context.SaveChanges();
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Youtube",
                URL = "https://www.youtube.com/",
                Description = "Watch videos",
                CategoryId = 4,
                UserId = pesho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "SoftUni",
                URL = "https://softuni.bg/",
                Description = "Достъпно и качествено софтуерно образование",
                CategoryId = 3,
                UserId = gosho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Judge",
                URL = "https://judge.softuni.bg/",
                Description = "SoftUni exams",
                CategoryId = 3,
                UserId = gosho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Transfermarkt",
                URL = "http://www.transfermarkt.co.uk/",
                Description = "Football transfer news",
                CategoryId = 6,
                UserId = pesho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Sportal",
                URL = "http://www.sportal.bg/",
                Description = "Sport news",
                CategoryId = 6,
                UserId = pesho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "9GAG",
                URL = "http://9gag.com/",
                Description = "Funny (sometimes) pictures",
                CategoryId = 1,
                UserId = gosho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Fortegames",
                URL = "http://www.fortegames.com/",
                Description = "Card games",
                CategoryId = 2,
                UserId = gosho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "Bloons Tower Defence 5",
                URL = "http://ninjakiwi.com/Games/Tower-Defense/Play/Bloons-Tower-Defense-5.html#.VjDKCfkrKhc",
                CategoryId = 2,
                UserId = pesho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "GitHub",
                URL = "https://github.com/",
                Description = "Post your code here",
                CategoryId = 3,
                UserId = gosho.Id
            });
            context.Bookmarks.Add(new Bookmark()
            {
                Title = "VBox7",
                URL = "http://vbox7.com/",
                Description = "Гледай клипове",
                CategoryId = 4,
                UserId = pesho.Id
            });
            context.SaveChanges();
            context.Votes.Add(new Vote()
            {
                BookmarkId = 1,
                UserId = pesho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 2,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 2,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 3,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 3,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 4,
                UserId = pesho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 5,
                UserId = pesho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 6,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 6,
                UserId = pesho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 7,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 8,
                UserId = pesho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 8,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 9,
                UserId = gosho.Id
            });
            context.Votes.Add(new Vote()
            {
                BookmarkId = 10,
                UserId = pesho.Id
            });
            context.SaveChanges();
            context.Comments.Add(new Comment()
            {
                Text = "Готин сайт",
                BookmarkId = 4,
                AuthorId = gosho.Id
            });
            context.Comments.Add(new Comment()
            {
                Text = "Определено",
                BookmarkId = 4,
                AuthorId = pesho.Id
            });
            context.Comments.Add(new Comment()
            {
                Text = "Забавно",
                BookmarkId = 6,
                AuthorId = gosho.Id
            });
            context.SaveChanges();
        }
    }
}
