namespace XPathExtractArtistsandNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class XPathExtractArtistsandNumberOfAlbums
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load("../../catalog.xml");

            var artistsNumberOfAlbums = new Dictionary<string, int>();
            string artistsQuery = "catalog/album/artist";

            XmlNodeList artists = xmlDocument.SelectNodes(artistsQuery);

            foreach (XmlNode artist in artists)
            {
                if (!artistsNumberOfAlbums.ContainsKey(artist.InnerText))
                {
                    artistsNumberOfAlbums.Add(artist.InnerText, 1);
                }
                else
                {
                    artistsNumberOfAlbums[artist.InnerText]++;
                }
            }

            foreach (var artistAlbum in artistsNumberOfAlbums)
            {
                Console.WriteLine("Artist Name: {0}, Artist Number Of Albums: {1}", artistAlbum.Key, artistAlbum.Value);
            }
        }
    }
}
