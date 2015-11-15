namespace _08_LinkedQueueTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _07_Linked_Queue;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void Test_CreateQueue_ShouldCreateQueue()
        {
            var linkedQueue = new LinkedQueue<int>();

            Assert.AreEqual(linkedQueue.Count, 0, "The queue was not created successfully!");
        }

        [TestMethod]
        public void Test_EnqueueElement_ShoudAddElement()
        {
            var linkedQueue = new LinkedQueue<int>();
            var elementToAdd = 55;
            linkedQueue.Enqueue(elementToAdd);

            Assert.AreEqual(linkedQueue.Count, 1);
            Assert.AreEqual(linkedQueue.Peek(), elementToAdd);
        }

        [TestMethod]
        public void Test_DequeueElement_ShouldRemoveFirstElement()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);
            linkedQueue.Enqueue(thirdElementToAdd);

            Assert.AreEqual(linkedQueue.Dequeue(), firstElelementToAdd);
            Assert.AreEqual(linkedQueue.Dequeue(), secondElementToAdd);
            Assert.AreEqual(linkedQueue.Dequeue(), thirdElementToAdd);
            Assert.AreEqual(linkedQueue.Count, 0);
            
        }

        [TestMethod]
        public void Test_PeekElement_ShouldReturnFirstElementValue()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);
            linkedQueue.Enqueue(thirdElementToAdd);

            Assert.AreEqual(linkedQueue.Peek(), firstElelementToAdd);
            linkedQueue.Dequeue();
            Assert.AreEqual(linkedQueue.Peek(), secondElementToAdd);
            linkedQueue.Dequeue();
            Assert.AreEqual(linkedQueue.Peek(), thirdElementToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PeekEmptyQueue_ShouldReturnException()
        {
            var linkedQueue = new LinkedQueue<int>();
            var peek = linkedQueue.Peek();
        }

        [TestMethod]
        public void Test_ForEachQueue_ShouldItaratesThroughElementFromHeadToTail()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);
            linkedQueue.Enqueue(thirdElementToAdd);

            int wantedSum = firstElelementToAdd + secondElementToAdd + thirdElementToAdd;
            int sum = 0;
            linkedQueue.ForEach(x => sum += x);

            Assert.AreEqual(sum, wantedSum);

        }

        [TestMethod]
        public void Test_IndexOfElement_ShouldReturnIndexOrMinusOne()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);
            linkedQueue.Enqueue(thirdElementToAdd);

            Assert.AreEqual(linkedQueue.IndexOf(3), 0);
            Assert.AreEqual(linkedQueue.IndexOf(5), 1);
            Assert.AreEqual(linkedQueue.IndexOf(8), 2);
            linkedQueue.Dequeue();
            Assert.AreEqual(linkedQueue.IndexOf(5), 0);
            linkedQueue.Dequeue();
            Assert.AreEqual(linkedQueue.IndexOf(8), 0);
            Assert.AreEqual(linkedQueue.IndexOf(55), -1);
        }

        [TestMethod]
        public void Test_ContainsElement_ShouldReturnTrueOrFalse()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);

            Assert.AreEqual(linkedQueue.Contains(firstElelementToAdd), true);
            Assert.AreEqual(linkedQueue.Contains(secondElementToAdd), true);
            Assert.AreEqual(linkedQueue.Contains(8), false);

        }

        [TestMethod]
        public void Test_ToArray_ShouldReturnArrayOfElements()
        {
            var linkedQueue = new LinkedQueue<int>();
            var firstElelementToAdd = 5;
            var secondElementToAdd = 3;
            var thirdElementToAdd = 8;
            linkedQueue.Enqueue(firstElelementToAdd);
            linkedQueue.Enqueue(secondElementToAdd);
            linkedQueue.Enqueue(thirdElementToAdd);

            int[] arr = linkedQueue.ToArray();
            Array.Sort(arr);
            Assert.AreEqual(arr[0], secondElementToAdd);
            Assert.AreEqual(arr[2], thirdElementToAdd);
            Assert.IsInstanceOfType(arr, typeof(Array));
        }
    }
}
