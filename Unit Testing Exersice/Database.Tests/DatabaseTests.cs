namespace Database.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }



        //Valid functionality of the ctor
        // 1-> edge case(no data); 2,3 -> Valid Data (success), 4 -> edge case(max data)
        //This test is meant to test only the constructor and nothing more!
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Act
            Database testDb = new Database(elementsToAdd);
            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData, "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set initial value for count field");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]

        public void ConstructorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers");
        }

        //Valid founctionality of count
        //I assume the the ctor is working fine
        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount, "Count should return the count of the added elements!");

        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            foreach (int el in elementsToAdd)
            {
                this.database.Add(el);
            }

            int[] actualData = database.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.database.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Add should physically add the elements to the field.");
            Assert.AreEqual(expectedCount, actualCount, "Add should change the elements count after adding!");
        }
        [Test]
        public void AddShouldThrowAnExceptionWhenAddingMoreThan16Elements()
        {
            //Act
            for (int i = 1; i <= 16; i++)
            {
                this.database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            }, "You should add exactly 16 elements to the database");
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElementSuccesfullyOnce(int[] startElements)
        {
            //Act
            foreach (int ele in startElements)
            {
                this.database.Add(ele);
            }
            this.database.Remove();

            List<int> list = new List<int>(startElements);
            list.RemoveAt(list.Count - 1);

            int[] actualData = this.database.Fetch();

            int[] expectedData = list.ToArray();

            int actualCount = this.database.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physically remove the element in the data field!");

            Assert.AreEqual(expectedCount, actualCount, "Remove should reduce the count of the data field.");

        }
        [Test]
        public void RemoveShouldThrowErrorWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }
        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (int ele in initData)
            {
                this.database.Add(ele);
            }
            for (int i = 0; i < initData.Count; i++)
            {
                database.Remove();
            }

            int[] actualData = database.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = actualData.Length;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physically remove the ele,ent in the data field.");
            Assert.AreEqual(expectedCount, actualCount, "Remove should decrement the count of the Database!");
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] initData)
        {
            //Act
            foreach(int el in initData)
            {
                database.Add(el);
            }
            int[] actualResult = this.database.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult, "Fetch should return copy of the existing data!");
        }

    }
}
