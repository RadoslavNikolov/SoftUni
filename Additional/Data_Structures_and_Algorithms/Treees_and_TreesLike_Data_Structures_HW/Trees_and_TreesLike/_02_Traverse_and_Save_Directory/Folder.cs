namespace _02_Traverse_and_Save_Directory
{
    using System.Collections.Generic;

    public class Folder
    {
        private long? size;

        public Folder(string name)
        {
            this.Name = name;
            this.Folders = new List<Folder>();
            this.Files = new List<File>();
        }

        public string Name { get; set; }

        public List<Folder> Folders { get; set; }

        public List<File> Files { get; set; }

        public long? Size
        {
            get
            {
                if (this.size != null)
                {
                    return this.size;
                }

                this.size = 0;

                foreach (var folder in this.Folders)
                {
                    this.size += folder.Size;
                }

                foreach (var file in this.Files)
                {
                    this.size += file.Size;
                }

                return this.size;
            }
        }
    }
}