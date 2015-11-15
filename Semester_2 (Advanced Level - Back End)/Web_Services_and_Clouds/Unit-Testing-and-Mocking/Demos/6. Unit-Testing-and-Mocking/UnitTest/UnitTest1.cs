using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    using System.Linq;
    using DirectoryTraversal;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDirectoryTraversal()
        {
            string path =
                @"C:\Users\toshiba\Desktop\Web Services Cloud\Unit-Testing-and-Mocking\Demos\6. Unit-Testing-and-Mocking";

            var mock = new DirectoryProviderMock();
            var traverser = new DirectoryTraverser(mock.DirectoryProvider(), path);

            var children = traverser.GetChildDirectories();
            
            Assert.AreEqual(7, children.Count());
        }

    }
}
