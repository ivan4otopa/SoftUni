namespace ArrayStack.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PopAndPush_1Element_PopReturnsCorrectElement_CountChangesCorrectly()
        {
            var numbers = new ArrayStack<int>();

            Assert.AreEqual(0, numbers.Count);

            numbers.Push(1);

            Assert.AreEqual(1, numbers.Count);

            int topElement = numbers.Pop();

            Assert.AreEqual(1, topElement);
            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void PopAndPush_1000Elements_CountChangesCorrectly_PopReturnsCorrectElement()
        {
            var strings = new ArrayStack<string>();

            Assert.AreEqual(0, strings.Count);

            for (int i = 0; i < 1000; i++)
            {
                strings.Push(string.Format("{0}", i));
            }

            Assert.AreEqual(1000, strings.Count);

            for (int i = 999; i >= 0; i--)
            {
                string element = strings.Pop();

                Assert.AreEqual(string.Format("{0}", i), element);
            }

            Assert.AreEqual(0, strings.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrowException()
        {
            var numbers = new ArrayStack<int>();

            numbers.Pop();
        }

        [TestMethod]
        public void PushAndPop_InitialCapacity1_CountChangesCorrectly()
        {
            var numbers = new ArrayStack<int>();

            Assert.AreEqual(0, numbers.Count);

            numbers.Push(1);

            Assert.AreEqual(1, numbers.Count);

            numbers.Push(2);

            Assert.AreEqual(2, numbers.Count);

            int topElement = numbers.Pop();

            Assert.AreEqual(2, topElement);
            Assert.AreEqual(1, numbers.Count);

            topElement = numbers.Pop();

            Assert.AreEqual(1, topElement);
            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void ToArray_ReturnsReversedArray()
        {
            var numbers = new ArrayStack<int>();

            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(-2);
            numbers.Push(7);

            var array = numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { 7, -2, 5, 3 });
        }

        [TestMethod]
        public void ToArray_EmptyStack_ShouldReturnEmptyArray()
        {
            var numbers = new ArrayStack<int>();
            var array = numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { });
        }
    }
}
