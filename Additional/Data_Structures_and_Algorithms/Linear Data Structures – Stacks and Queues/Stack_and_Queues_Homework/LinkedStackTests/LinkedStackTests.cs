namespace LinkedStackTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _05_Linked_Stack;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void Test_CreateStack_ShouldCreateStack()
        {
            var linkedStack = new LinkedStack<int>();

            Assert.AreEqual(linkedStack.Count, 0, "The stack was now created successfully.");
        }

        [TestMethod]
        public void Test_PushSingleElement_Shoud()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(3);

            Assert.AreEqual(linkedStack.Count, 1);
            Assert.AreEqual(linkedStack.Pop(), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PopElement_EmptyStack_ShouldReturnException()
        {
            var stack = new LinkedStack<int>();
            stack.Pop();
        }

    }
}
