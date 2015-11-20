namespace ActiveIndividuals
{
    using System.IO;
    using System.Linq;

    using DossierSystem.Data;
    using DossierSystem.Models;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    class ActiveIndividuals
    {
        static void Main()
        {
            var context = new DossierSystemContext();
            var individuals = context.Individuals
                .Where(i => i.Status == Status.Active)
                .OrderBy(i => i.FullName)
                .Select(i => new
                {
                    i.Id,
                    i.FullName,
                    i.Alias
                });

            var json = JsonConvert.SerializeObject(
                individuals,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText("../../active-individuals.json", json);
        }
    }
}
