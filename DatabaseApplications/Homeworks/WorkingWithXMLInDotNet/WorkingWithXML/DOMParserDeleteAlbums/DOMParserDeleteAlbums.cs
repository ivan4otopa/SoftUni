namespace DOMParserDeleteAlbums
{
    using System.Xml;

    class DOMParserDeleteAlbums
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
                    if (childNode.Name == "price" && decimal.Parse(childNode.InnerText) > 20)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
            }

            xmlDocument.Save("../../cheap-albums-catalog.xml");
        }
    }
}
