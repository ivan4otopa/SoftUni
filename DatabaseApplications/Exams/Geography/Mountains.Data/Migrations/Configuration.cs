namespace Mountains.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mountains.Data.MountainsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Mountains.Data.MountainsContext";
        }

        protected override void Seed(Mountains.Data.MountainsContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.Add(new Country()
            {
                CountryCode = "BG",
                CountryName = "Bulgaria"
            });

            context.Countries.Add(new Country()
            {

                CountryCode = "GB",
                CountryName = "Germany"
            });

            context.Mountains.Add(new Mountain()
            {
                Name = "Rila"
            });

            context.Mountains.Add(new Mountain()
            {
                Name = "Pirin"
            });

            context.Mountains.Add(new Mountain()
            {
                Name = "Rhodopes"
            });

            context.SaveChanges();

            foreach (var mountain in context.Mountains)
            {
                var bulgariaCountry = context.Countries.Where(c => c.CountryCode == "BG").FirstOrDefault();

                mountain.Countries.Add(bulgariaCountry);
            }

            context.Peaks.Add(new Peak()
            {
                Name = "Musala",
                Elevation = 2925,
                MountainId = 1
            });

            context.Peaks.Add(new Peak()
            {
                Name = "Malyovitsa",
                Elevation = 2729,
                MountainId = 1
            });

            context.Peaks.Add(new Peak()
            {
                Name = "Vihren",
                Elevation = 2914,
                MountainId = 2
            });

            context.SaveChanges();
        }
    }
}
