namespace ExportCharactersAndPlayersAsJson
{
    using System.IO;
    using System.Linq;

    using EntityFrameworkMappings;

    using Newtonsoft.Json;

    class ExportCharactersAndPlayersAsJson
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    name = c.Name,
                    playedBy = c.UsersGames
                        .Select(ug => ug.User.Username)
                });

            string json = JsonConvert.SerializeObject(characters, Formatting.Indented);
            File.WriteAllText("../../characters.json", json);
        }
    }
}
