namespace ExportAlbumsAsJSON
{
    using System.Linq;
    using System.IO;

    using EntityFrameworkMappings;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    class ExportAlbumsAsJSON
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var albums = context.Albums
                .Where(a => a.Photographs.Count >= 1)
                .OrderBy(a => a.Photographs.Count)
                .ThenBy(a => a.Id)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    Owner = a.User.FullName,
                    PhotoCount = a.Photographs.Count
                });

            var json = JsonConvert.SerializeObject(
                albums,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText("../../albums.json", json);
        }
    }
}
