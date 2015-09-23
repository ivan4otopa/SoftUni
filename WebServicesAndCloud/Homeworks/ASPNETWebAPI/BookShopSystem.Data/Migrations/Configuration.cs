namespace BookShopSystem.Data.Migrations
{
    using BookShopSystem.Data.Properties;
    using BookShopSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookShopSystem.Data.BookShopSystemContext";
        }

        protected override void Seed(BookShopSystem.Data.BookShopSystemContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            using (var reader = new StringReader(Resources.authors))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' });
                    string firstName = data[0];
                    string lastName = data[1];

                    context.Authors.Add(new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });

                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();

            var randomNumberGenerator = new Random();
            var authors = context.Authors.ToList();

            using (var reader = new StringReader(Resources.books))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = randomNumberGenerator.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        Edition = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }
            }

            using (var reader = new StringReader(Resources.categories))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    string name = line;

                    if (name != "")
                    {
                        context.Categories.Add(new Category()
                        {
                            Name = name
                        });
                    }

                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();

            int booksCount = context.Books.Count();
            int categoriesCount = context.Categories.Count();

            for (int i = 0; i < 600; i++)
            {
                var currentBook = context.Books.Find(randomNumberGenerator.Next(1, booksCount + 1));
                var currentCategory = context.Categories.Find(randomNumberGenerator.Next(1, categoriesCount + 1));

                currentBook.Categories.Add(currentCategory);
            }

            context.SaveChanges();
        }
    }
}
