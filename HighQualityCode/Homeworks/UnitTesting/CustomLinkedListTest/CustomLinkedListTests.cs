using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CustomLinkedListTest
{
    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        public void InitDynamicList()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestCountIncreaseWhenAddingElement()
        {
            dynamicList.Add(2);
            dynamicList.Add(3);

            Assert.AreEqual(2, dynamicList.Count, "Elements count isn't equal to the expected amount.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingWhenIndexIsGreaterThanLength()
        {
            dynamicList.Add(2);
            dynamicList.RemoveAt(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingAtPositionWhenIndexIsLowerThanZero()
        {
            dynamicList.Add(2);
            dynamicList.RemoveAt(-1);
        }

        [TestMethod]
        public void TestRemovingAtPosition()
        {
            dynamicList.Add(2);
            dynamicList.Add(4);
            dynamicList.Add(3);

            Assert.AreEqual(4, dynamicList.RemoveAt(1), "Removed item at index isn't equal to the expected item.");
        }

        [TestMethod]
        public void TestRemovingItem()
        {
            dynamicList.Add(2);

            Assert.AreEqual(0, dynamicList.Remove(2), "Removed items` index isnt' equal to the expected index.");
        }

        [TestMethod]
        public void TestRemovingItemShouldReturnMinusOne()
        {
            dynamicList.Add(2);

            Assert.AreEqual(-1, dynamicList.Remove(3), "Removing a non - existing item doesn't return -1.");
        }

        [TestMethod]
        public void TestGettingPositionOfGivenElement()
        {
            dynamicList.Add(2);

            Assert.AreEqual(0, dynamicList.IndexOf(2), "Position of given element isn't equal to the expected position.");
        }

        [TestMethod]
        public void TestGettingPositionShouldReturnMinusOne()
        {
            dynamicList.Add(2);

            Assert.AreEqual(-1, dynamicList.IndexOf(3), "Getting a non - existing item doesn't return -1.");
        }

        [TestMethod]
        public void TestContainingItem()
        {
            dynamicList.Add(2);

            Assert.IsTrue(dynamicList.Contains(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGettingElementWhenIndexIsGreaterThanOrEqualToLength()
        {
            dynamicList.Add(2);

            int number = dynamicList[5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGettingElementIndexIsLowerThanZero()
        {
            dynamicList.Add(2);

            int number = dynamicList[-1];
        }

        [TestMethod]
        public void TestGettingAnElement()
        {
            dynamicList.Add(2);
            dynamicList.Add(3);
            dynamicList.Add(4);

            Assert.AreEqual(3, dynamicList[1], "Getting element at position isn't equal to expected element.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementWhenIndexIsGreaterThanOrEqualToLength()
        {
            dynamicList[1] = 55;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementWhenIndexIsLowerThanZero()
        {
            dynamicList[-1] = 55;
        }

        [TestMethod]
        public void TestSettingAnElement()
        {
            dynamicList.Add(0);
            dynamicList.Add(1);
            dynamicList.Add(2);

            dynamicList[1] = 2;

            Assert.AreEqual(2, dynamicList[1], "Setting element at position doesn't set the expected element.");
        }
    }
}
