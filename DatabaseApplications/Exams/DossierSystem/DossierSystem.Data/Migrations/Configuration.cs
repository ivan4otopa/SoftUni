namespace DossierSystem.Data.Migrations
{
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DossierSystem.Data.DossierSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DossierSystem.Data.DossierSystemContext";
        }

        protected override void Seed(DossierSystem.Data.DossierSystemContext context)
        {
            if (context.Individuals.Any())
            {
                return;
            }

            var serializer = new JavaScriptSerializer();
            var activityTypesFile = File.ReadAllText("../../activity-types.json");
            var activityTypes = serializer.Deserialize<List<ActivityType>>(activityTypesFile);

            foreach (var activityType in activityTypes)
            {
                context.ActivityTypes.Add(new ActivityType()
                {
                    Name = activityType.Name
                });
            }

            var xmlDocument = XDocument.Load("../../cities.xml");
            var cities =
                from city in xmlDocument.Descendants("city")
                select city.Attribute("name").Value;

            foreach (var city in cities)
            {
                context.Cities.Add(new City()
                {
                    Name = city
                });
            }

            context.SaveChanges();

            var individualsFile = File.ReadAllText("../../individuals.json");
            dynamic individuals = JsonConvert.DeserializeObject(individualsFile);

            foreach (var individual in individuals)
            {
                string birthDate = individual.birthDate == null ? null : individual.birthDate.ToString();

                DateTime? birthDateAsDate = null;

                if (birthDate != null)
                {
                    birthDateAsDate = DateTime.ParseExact(
                        birthDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }

                context.Individuals.Add(new Individual()
                {
                    Id = individual.id,
                    FullName = individual.fullName,
                    Alias = individual.alias,
                    BirthDate = birthDateAsDate,
                    Status = individual.status
                });

                foreach (var activity in individual.activities)
                {
                    var activeToDate = activity.activeTo == null ? null : activity.activeTo.ToString();

                    DateTime? activeToAsDate = null;

                    if (activeToDate != null)
                    {
                        activeToAsDate = DateTime.ParseExact(
                            activeToDate,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture);
                    }

                    string activityTypeName = activity.activityType.ToString();

                    context.Activities.Add(new Activity()
                    {
                        Description = activity.description,
                        ActiveFrom = DateTime.ParseExact(
                            activity.activeFrom.ToString(),
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture),
                        ActiveTo = activeToAsDate,
                        IndividualId = individual.id,
                        ActivityTypeId = context.ActivityTypes.FirstOrDefault(at => at.Name == activityTypeName).Id
                    });
                }

                foreach (var location in individual.locations)
                {
                    string cityName = location.city.ToString();

                    context.Locations.Add(new Location()
                    {
                        LastSeen = DateTime.ParseExact(
                            location.lastSeen.ToString(),
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture),
                        IndividualId = individual.id,
                        CityId = context.Cities.FirstOrDefault(c => c.Name == cityName).Id
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
