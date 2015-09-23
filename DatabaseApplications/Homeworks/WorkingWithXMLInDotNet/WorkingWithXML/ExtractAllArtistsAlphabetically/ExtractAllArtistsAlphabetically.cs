namespace ExtractAllArtistsAlphabetically
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractAllArtistsAlphabetically
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load("../../catalog.xml");

            var artists = new SortedSet<string>();
            var rootNode = xmlDocument.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "artist")
                    {
                        artists.Add(childNode.InnerText);
                    }
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine(artist);
            }
        }
    }
}
