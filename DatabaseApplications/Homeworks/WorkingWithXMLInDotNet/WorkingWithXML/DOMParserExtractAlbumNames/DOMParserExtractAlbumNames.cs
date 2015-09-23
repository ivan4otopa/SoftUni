namespace DOMParserExtractAlbumNames
{
    using System;
    using System.Xml;

    class DOMParserExtractAlbumNames
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load("../../catalog.xml");

            var rootNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "name")
                    {
                        Console.WriteLine(childNode.InnerText);
                    }
                }
            }
        }
    }
}
