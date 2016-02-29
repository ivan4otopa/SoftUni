namespace TraverseAndSaveDirectoryContentsInATree
{
    using System;
    using System.IO;

    class TraverseAndSaveDirectoryContentsInATree
    {
        private const string StartDirectory = @"C:/Windows";

        static void Main()
        {
            Folder root = new Folder(StartDirectory);

            TraverseFilesAndFolders(StartDirectory, root);

            Console.WriteLine("Size: {0}", root.CalculateSize());
        }

        static void TraverseFilesAndFolders(string path, Folder folder)
        {
            try
            {
                foreach (var fileName in Directory.GetFiles(path))
                {
                    int fileSize = (int)(new FileInfo(fileName)).Length;

                    File file = new File(fileName, fileSize);

                    folder.Files.Add(file);
                }

                foreach (var directoryName in Directory.GetDirectories(path))
                {
                    folder.ChildFolders.Add(new Folder(directoryName));

                    TraverseFilesAndFolders(directoryName, folder.ChildFolders[folder.ChildFolders.Count - 1]);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
