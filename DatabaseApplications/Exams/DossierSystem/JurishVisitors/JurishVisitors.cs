namespace JurishVisitors
{
    using System.IO;
    using System.Linq;

    using DossierSystem.Data;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    
    class JurishVisitors
    {
        static void Main()
        {
            var context = new DossierSystemContext();
            var visitors = context.Individuals
                .Where(i => i.Locations
                    .Any(l => l.City.Name == "Jurish" && l.LastSeen.Year < 2005))
                .Select(i => new
                {
                    i.FullName,
                    Locations = i.Locations
                        .Where(l => l.City.Name == "Jurish" && l.LastSeen.Year < 2005)
                        .Select(lc => new
                        {
                            Seen = lc.LastSeen
                        })
                });

            var json = JsonConvert.SerializeObject(
                visitors,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText("../../jurish-visitors.json", json);
        }
    }
}
