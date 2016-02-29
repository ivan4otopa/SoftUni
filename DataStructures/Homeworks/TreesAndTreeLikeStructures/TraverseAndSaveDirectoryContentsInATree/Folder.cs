namespace TraverseAndSaveDirectoryContentsInATree
{
    using System.Collections.Generic;

    class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public long CalculateSize()
        {
            long size = 0;

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in this.ChildFolders)
            {
                size += childFolder.CalculateSize();
            }

            return size;
        }
    }
}
