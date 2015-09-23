namespace LINQToXMLOldAlbums
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class LINQToXMLOldAlbums
    {
        static void Main(string[] args)
        {
            var xmlDocument = XDocument.Load("../../catalog.xml");

            var albums =
                from album in xmlDocument.Descendants("album")
                where int.Parse(album.Element("year").Value) > DateTime.Now.Year - 5
                select new
                {
                    Name = album.Element("name").Value,
                    Price = album.Element("price").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine("Album Name: {0}, Album Price: {1}", album.Name, album.Price);
            }
        }
    }
}
