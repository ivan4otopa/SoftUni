namespace ExtractArtistsAndNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractArtistsAndNumberOfAlbums
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load("../../catalog.xml");

            var artistsNumberOfAlbums = new Dictionary<string, int>();
            var rootNode = xmlDocument.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "artist")
                    {
                        if (!artistsNumberOfAlbums.ContainsKey(childNode.InnerText))
                        {
                            artistsNumberOfAlbums.Add(childNode.InnerText, 1);
                        }
                        else
                        {
                            artistsNumberOfAlbums[childNode.InnerText]++;
                        }
                    }
                }   
            }

            foreach (var artistAlbum in artistsNumberOfAlbums)
            {
                Console.WriteLine("Artist Name: {0}, Artist Number Of Albums: {1}", artistAlbum.Key, artistAlbum.Value);
            }
        }
    }
}
