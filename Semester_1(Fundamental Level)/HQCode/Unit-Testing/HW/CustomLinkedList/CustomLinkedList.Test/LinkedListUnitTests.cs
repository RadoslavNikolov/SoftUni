﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Test
{
    [TestClass]
    public class LinkedListUnitTests
    {
        private DynamicList<int> linkedList;

        [TestInitialize]
        public void InitLinkedList()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestCount_ShouldIncrement()
        {
            Assert.AreEqual(0, this.linkedList.Count);

            this.linkedList.Add(1);

            Assert.AreEqual(1, this.linkedList.Count);
        }

        [TestMethod]
        public void TestAddWhenEmpty_ShouldAddItem()
        {
            const int ItemsCount = 1000;
            for (int i = 0; i < ItemsCount; i++)
            {
                this.linkedList.Add(i);
            }

            Assert.AreEqual(ItemsCount, this.linkedList.Count);
        }

        [TestMethod]
        public void TestRemoveWhenNotEmpty_ShouldRemoveItem()
        {
            const int ItemsCount = 1000;
            for (int i = 0; i < ItemsCount; i++)
            {
                this.linkedList.Add(i);
            }

            for (int i = ItemsCount - 1; i >= 0; i--)
            {
                this.linkedList.Remove(i);
                Assert.AreEqual(i, this.linkedList.Count);
            }

            Assert.AreEqual(0, this.linkedList.Count);
        }

        [TestMethod]
        public void TestRemoveWhenEmpty_ShouldReturnFlag()
        {
            var removed = this.linkedList.Remove(5);

            Assert.AreEqual(-1, removed);
        }

        [TestMethod]
        public void TestRemoveAtWhenNotEmpty_ShouldRemoveItem()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(1);
            var removed = this.linkedList.RemoveAt(1);

            Assert.AreEqual(10, removed);
            Assert.AreEqual(2, this.linkedList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAtWhenEmpty_ShouldThrow()
        {
            var removed = this.linkedList.RemoveAt(1);
        }

        [TestMethod]
        public void TestGetIndexWhenNotEmpty()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(1);

            Assert.AreEqual(10, this.linkedList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetIndexWhenEmpty_ShouldThrow()
        {
            var item = this.linkedList[1];
        }

        [TestMethod]
        public void TestSetIndexWhenNotEmpty()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(1);
            this.linkedList[2] = 50;

            Assert.AreEqual(50, this.linkedList[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetIndexWhenEmpty_ShoudThrow()
        {
            this.linkedList[1] = 5;
        }

        [TestMethod]
        public void TestIndexOfWhenHasIt()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(1);

            Assert.AreEqual(1, this.linkedList.IndexOf(10));
        }

        [TestMethod]
        public void TestIndexOfWhenHasMany_ShouldReturnIndex()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(10);
            this.linkedList.Add(10);
            this.linkedList.Add(1);

            Assert.AreEqual(1, this.linkedList.IndexOf(10));
        }

        [TestMethod]
        public void TestIndexOfWhenDontHaveIt_ShouldReturnFlag()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(1);

            Assert.AreEqual(-1, this.linkedList.IndexOf(10));
        }

        [TestMethod]
        public void TestContainsWhenHasIt_ShouldReturnFlag()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(1);

            Assert.IsTrue(this.linkedList.Contains(10));
        }

        [TestMethod]
        public void TestContainsWhenHasMany_ShouldReturnFlag()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(10);
            this.linkedList.Add(10);
            this.linkedList.Add(10);
            this.linkedList.Add(1);

            Assert.IsTrue(this.linkedList.Contains(10));
        }

        [TestMethod]
        public void TestContainsWhenDontHaveIt_ShouldReturnFlag()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(1);

            Assert.IsFalse(this.linkedList.Contains(10));
        }
    }
}
