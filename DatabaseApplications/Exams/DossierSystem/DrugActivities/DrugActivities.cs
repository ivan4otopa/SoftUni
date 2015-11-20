namespace DrugActivities
{
    using System.IO;
    using System.Linq;

    using DossierSystem.Data;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    
    class DrugActivities
    {
        static void Main()
        {
            var context = new DossierSystemContext();
            var individuals = context.Individuals
                .Where(i => i.Activities
                    .Any(a => a.ActivityType.Name == "DrugTrafficking"))
                .OrderBy(i => i.FullName)
                .Select(i => new
                {
                    i.FullName,
                    i.BirthDate,
                    Activities = i.Activities
                        .Where(a => a.ActivityType.Name == "DrugTrafficking")
                        .OrderBy(a => a.ActiveFrom)
                        .Select(a => new
                        {
                            a.Description,
                            a.ActiveFrom,
                            a.ActiveTo
                        })
                });

            var json = JsonConvert.SerializeObject(
                individuals,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText("../../drug-activities.json", json);
        }
    }
}
