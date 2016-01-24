using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedQueue.Test
{
    using _01.LinkedQueue;

    [TestClass]
    public class LinkedQueueTests
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void TestInitialize()
        {
            this.queue = new LinkedQueue<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeEmptyQueue_ShoulThrow()
        {
            var element = this.queue.Dequeue();
        }

        [TestMethod]
        public void TestInitilizeEmptyQueue_ShouldReturnZeroCount()
        {
            Assert.AreEqual(0, this.queue.Count, "Empty queue count must be zero");
        }

        [TestMethod]
        public void TestEnqueEmptyQueue_ShouldReturnProperCount()
        {
            this.queue.Enqueue(5);
            Assert.AreEqual(1, this.queue.Count, "Expected count of queue with one element is one");
        }

        [TestMethod]
        public void TestClearQueue_ShouldClear()
        {
            this.queue.Enqueue(5);
            Assert.AreEqual(1, this.queue.Count, "Expected count of queue with one element is one");

            this.queue.Clear();
            Assert.AreEqual(0, this.queue.Count, "Cleared queue must have count of one ");
        }

        [TestMethod]
        public void TestEnqueSeveralElements_ShouldAdd()
        {
            var element1 = 5;
            var element2 = 10;
            var element3 = 15;
            this.queue.Enqueue(element1);
            this.queue.Enqueue(element2);
            this.queue.Enqueue(element3);

            Assert.AreEqual(3, this.queue.Count, "Expected count of queue with 3 element is 3");
            var peekedElement = this.queue.Peek();
            Assert.AreEqual(element1, peekedElement, "Peeked first element value should be 5");
        }
    }
}
