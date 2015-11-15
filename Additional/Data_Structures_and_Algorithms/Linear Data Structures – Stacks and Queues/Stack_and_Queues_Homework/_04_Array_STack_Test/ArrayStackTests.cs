namespace _04_Array_STack_Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03_Array_Based_Stack;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void Test_CreateArrayStack_ShouldCreateArrayStack()
        {
            var arrayStack = new ArrayStack<int>();

            Assert.AreEqual(arrayStack.Count, 0, "The queue was not created successfully!");
        }

        [TestMethod]
        public void Test_PushElement_ShoudAddElement()
        {
            var arrayStack = new ArrayStack<int>();
            var elementToAdd = 55;
            arrayStack.Push(elementToAdd);

            Assert.AreEqual(arrayStack.Count, 1);
            Assert.AreEqual(arrayStack.Peek(), elementToAdd);
        }

        [TestMethod]
        public void Test_PopElement_ShouldRemoveLastElement()
        {
            var arrayStack = new ArrayStack<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            arrayStack.Push(firstElelementToAdd);
            arrayStack.Push(secondElementToAdd);
            arrayStack.Push(thirdElementToAdd);

            Assert.AreEqual(arrayStack.Pop(), thirdElementToAdd);
            Assert.AreEqual(arrayStack.Pop(), secondElementToAdd);
            Assert.AreEqual(arrayStack.Pop(), firstElelementToAdd);
            Assert.AreEqual(arrayStack.Count, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PopEmptyStack_ShouldReturnException()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Pop();
        }

        [TestMethod]
        public void Test_PeekElement_ShouldReturnLastElementValue()
        {
            var arrayStack = new ArrayStack<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            arrayStack.Push(firstElelementToAdd);
            arrayStack.Push(secondElementToAdd);
            arrayStack.Push(thirdElementToAdd);

            Assert.AreEqual(arrayStack.Peek(), thirdElementToAdd);
            arrayStack.Pop();
            Assert.AreEqual(arrayStack.Peek(), secondElementToAdd);
            arrayStack.Pop();
            Assert.AreEqual(arrayStack.Peek(), firstElelementToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PeekEmptyStack_ShouldReturnException()
        {
            var arrayStack = new ArrayStack<int>();
            var peek = arrayStack.Peek();
        }

        [TestMethod]
        public void Test_ForEachStack_ShouldItaratesThroughElementFromFirstToLast()
        {
            var arrayStack = new ArrayStack<int>();
            var firstElelementToAdd = 3;
            var secondElementToAdd = 5;
            var thirdElementToAdd = 8;
            arrayStack.Push(firstElelementToAdd);
            arrayStack.Push(secondElementToAdd);
            arrayStack.Push(thirdElementToAdd);

            int wantedSum = firstElelementToAdd + secondElementToAdd + thirdElementToAdd;
            int sum = 0;
            arrayStack.ForEach(x => sum += x);

            Assert.AreEqual(sum, wantedSum);

        }

        
        [TestMethod]
        public void Test_ToArray_ShouldReturnArrayOfElements()
        {
            var arrayStack = new ArrayStack<int>();
            var firstElelementToAdd = 5;
            var secondElementToAdd = 3;
            var thirdElementToAdd = 8;
            arrayStack.Push(firstElelementToAdd);
            arrayStack.Push(secondElementToAdd);
            arrayStack.Push(thirdElementToAdd);

            int[] arr = arrayStack.ToArray();
            Array.Sort(arr);
            Assert.AreEqual(arr[0], secondElementToAdd);
            Assert.AreEqual(arr[2], thirdElementToAdd);
            Assert.IsInstanceOfType(arr, typeof(Array));
        }
    }
}
