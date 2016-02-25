using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LinkedQueue.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class LinkedQueueTests
    {
        private LinkedQueue<int> numbers;

        [TestInitialize]
        public void Initialize()
        {
            this.numbers = new LinkedQueue<int>();
        }

        [TestMethod]
        public void EnqueueAndDequeue_ShouldChangeCountCorrectly_DequeueShouldReturnFirstElement()
        {
            Assert.AreEqual(0, this.numbers.Count);

            this.numbers.Enqueue(1);
            this.numbers.Enqueue(2);

            Assert.AreEqual(2, this.numbers.Count);

            var firstElement = this.numbers.Dequeue();

            Assert.AreEqual(1, firstElement);
            Assert.AreEqual(1, this.numbers.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldThrowError()
        {
            this.numbers.Dequeue();
        }

        [TestMethod]
        public void ToArray_ShouldReturnArray()
        {
            this.numbers.Enqueue(3);
            this.numbers.Enqueue(5);
            this.numbers.Enqueue(-2);
            this.numbers.Enqueue(7);

            var array = this.numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { 3, 5, -2, 7 });
        }

        [TestMethod]
        public void ToArray_EmptyQueue_ShoulReturnEmptyArray()
        {
            var array = this.numbers.ToArray();

            CollectionAssert.AreEqual(array, new int[] { });
        }
    }
}
