namespace DOMParserAndXPathOldAlbums
{
    using System;
    using System.Xml;

    class DOMParserAndXPathOldAlbums
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load("../../catalog.xml");

            string albumsQuery = "catalog/album";
            XmlNodeList albums = xmlDocument.SelectNodes(albumsQuery);

            foreach (XmlNode node in albums)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "year" && int.Parse(childNode.InnerText) > DateTime.Now.Year - 5)
                    {
                        Console.WriteLine("Album Name: {0}, Album Price: {1}", node["name"].InnerText, node["price"].InnerText);
                    }
                }
            }
        }
    }
}
