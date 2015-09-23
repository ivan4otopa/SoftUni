namespace XElementDirectoryContentsAsXML
{
    using System.IO;
    using System.Xml.Linq;

    class XElementDirectoryContentsAsXML
    {
        private const string StartDirectory = @"../../";

        static void Main(string[] args)
        {
            var startDirectory = new DirectoryInfo(StartDirectory);
            var xmlDirectoryTree = BuildTree(startDirectory);
            var xDocument = new XDocument(xmlDirectoryTree);

            xDocument.Save("../../directory-contents.xml");
        }

        static XElement BuildTree(DirectoryInfo startDirectory)
        {
            var rootDir = new XElement("root-dir");
            var node = BuildXml(startDirectory);

            rootDir.Add(node);

            return rootDir;
        }

        static XElement BuildXml(DirectoryInfo startDirectory)
        {
            var directoryElement = new XElement("dir", new XAttribute("name", startDirectory.Name));
            
            foreach (var file in startDirectory.GetFiles())
            {
                var fileElement = new XElement("file", new XAttribute("name", file.Name));

                directoryElement.Add(fileElement);
            }

            foreach (var directory in startDirectory.GetDirectories())
            {
                directoryElement.Add(BuildXml(directory));
            }

            return directoryElement;
        }
    }
}
