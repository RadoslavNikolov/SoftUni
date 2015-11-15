namespace DirectoryTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Moq;

    public class DirectoryTraverser 
    {
        public DirectoryTraverser(IDirectoryProvider direcoryProvider, string currentDirecotry)
        {
            this.DirecoryProvider = direcoryProvider;
            this.CurrentDirectory = currentDirecotry;
        }

        public IDirectoryProvider DirecoryProvider { get; set; }

        public string CurrentDirectory { get; set; }

        public IEnumerable<string> GetChildDirectories()
        {
            var directories = this.DirecoryProvider.GetDirectories(this.CurrentDirectory);

            var directoryNames = new List<string>(directories.Count());
            foreach (var directory in directories)
            {
                int lastBackSlash = directory.LastIndexOf("\\");
                string directoryName = directory.Substring(lastBackSlash);

                directoryNames.Add(directoryName);
            }

            directoryNames.Sort();

            return directoryNames;
        }
    }

    public class DirectoryProviderMock
    {
        public DirectoryProviderMock()
        {
            this.GetDirectories();
        }

        public IDirectoryProvider DirectoryProvider { get; set; }
      

        public void GetDirectories()
        {
            
            var mock = new Mock<IDirectoryProvider>();
            mock.Setup(p => p.GetDirectories(It.IsAny<string>()))
                .Returns(new[] {"ad", "aff","adddd"});

            this.DirectoryProvider = mock.Object;
        }
    }

    public interface IDirectoryProvider
    {
        IEnumerable<string> GetDirectories(string path);
    }
}
