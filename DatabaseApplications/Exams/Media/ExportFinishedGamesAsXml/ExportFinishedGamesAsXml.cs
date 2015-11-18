namespace ExportFinishedGamesAsXml
{
    using System.Linq;
    using System.Xml;

    using EntityFrameworkMappings;
    
    class ExportFinishedGamesAsXml
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var games = context.Games
                .Where(g => g.IsFinished == true)
                .OrderBy(g => g.Name)
                .Select(g => new
                {
                    g.Name,
                    g.Duration,
                    Users = g.UsersGames
                        .Select(ug => new
                        {
                            ug.User.Username,
                            ug.User.IpAddress
                        })
                });

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                NewLineChars = "\n"
            };

            using (XmlWriter writer = XmlWriter.Create("../../finished-games.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("games");

                foreach (var game in games)
                {
                    writer.WriteStartElement("game");
                    writer.WriteAttributeString("name", game.Name);

                    if (game.Duration != null)
                    {
                        writer.WriteAttributeString("duration", game.Duration.ToString());
                    }

                    writer.WriteStartElement("users");

                    foreach (var user in game.Users)
                    {
                        writer.WriteStartElement("user");
                        writer.WriteAttributeString("username", user.Username);
                        writer.WriteAttributeString("ip-address", user.IpAddress);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
