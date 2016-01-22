using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomGenericList.Test
{
    using GenericList;

    [TestClass]
    public class GenericListTests
    {
        private GenericList<int> List;

        [TestInitialize]
        public void InitializeList()
        {
            this.List = new GenericList<int>();
        }

        [TestMethod]
        public void ListCount_OnInitialize_ExpectedZero()
        {
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, this.List.Count, "Initialized list should be empty");
        }

        [TestMethod]
        public void ListCapacity_OnInitialize_ExpectedDefault()
        {
            var expectedCapacity = 16;
            Assert.AreEqual(expectedCapacity, this.List.Capacity, "Initialized list should with default capacity");
        }

        [TestMethod]
        public void ListInsertAtLastIndex_ExpectedSuccess()
        {
            
            var value = 5;
            var capacity = 16;

            for (int i = 0; i < capacity; i++)
            {
                this.List.Add(i);
            }

            this.List.InsertAt(value, capacity - 1); 

            
            Assert.AreEqual(value, this.List[capacity - 1]);
        }
    }
}
