namespace UsersAndAlbumsAsXML
{
    using System.Linq;

    using EntityFrameworkMappings;
    using System.Xml;

    class UsersAndAlbumsAsXML
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var users = context.Users
                .Where(u => u.Albums.Count >= 1)
                .OrderBy(u => u.FullName)
                .Select(u => new
                {
                    u.Id,
                    u.BirthDate,
                    Albums = u.Albums
                        .Select(a => new
                        {
                            a.Name,
                            a.Description,
                            Photographs = a.Photographs
                                .Select(p => p.Title)
                        }),
                    CameraModel = u.Equipment.Camera.Model,
                    CameraLens = u.Equipment.Lens.Model,
                    CameraMegapixels = u.Equipment.Camera.Megapixels
                });

            var xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                NewLineChars = "\n"
            };

            using (XmlWriter writer = XmlWriter.Create("../../users-and-albums.xml", xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("users");

                foreach (var user in users)
                {
                    writer.WriteStartElement("user");
                    writer.WriteAttributeString("id", user.Id.ToString());
                    writer.WriteAttributeString(
                        "birth-date", 
                        user.BirthDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

                    writer.WriteStartElement("albums");

                    foreach (var album in user.Albums)
                    {
                        writer.WriteStartElement("album");
                        writer.WriteAttributeString("name", album.Name);

                        if (album.Description != null)
                        {
                            writer.WriteAttributeString("description", album.Description);
                        }

                        writer.WriteStartElement("photographs");

                        foreach (var photograph in album.Photographs)
                        {
                            writer.WriteStartElement("photograph");
                            writer.WriteAttributeString("title", photograph);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteStartElement("camera");
                    writer.WriteAttributeString("model", user.CameraModel);
                    writer.WriteAttributeString("lens", user.CameraLens);
                    writer.WriteAttributeString("megapixels", user.CameraMegapixels.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
