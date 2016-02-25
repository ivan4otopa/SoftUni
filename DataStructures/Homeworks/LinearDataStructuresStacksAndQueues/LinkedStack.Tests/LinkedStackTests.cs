namespace LinkedStack.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedStackTests
    {
        private LinkedStack<int> numbers;

        [TestInitialize]
        public void Initialize()
        {
            this.numbers = new LinkedStack<int>();
        }

        [TestMethod]
        public void PushAndPop_CountChangesCorrectly()
        {
            Assert.AreEqual(0, this.numbers.Count);

            this.numbers.Push(1);

            Assert.AreEqual(1, this.numbers.Count);

            var topNumber = this.numbers.Pop();

            Assert.AreEqual(1, topNumber);
            Assert.AreEqual(0, this.numbers.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrowException()
        {
            this.numbers.Pop();
        }

        [TestMethod]
        public void ToArray_ShouldReturnArrayWithReversedElements()
        {
            this.numbers.Push(3);
            this.numbers.Push(5);
            this.numbers.Push(-2);
            this.numbers.Push(7);

            var array = this.numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { 7, -2, 5, 3 });
        }

        [TestMethod]
        public void ToArray_ShouldReturnEmptyArrayWhenStackIsEmpty()
        {
            var array = this.numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { });
        }
    }
}
