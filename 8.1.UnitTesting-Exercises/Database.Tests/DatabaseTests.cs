using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int MaxElements = 16;
        private Database db;
        private int[] data;

        [SetUp]
        public void SetUp()
        {
            data = new int[MaxElements];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            db = new Database(data);
        }

        [Test]
        public void ValidateCtorIsNotNull()
        {
            db = new Database();
            Assert.That(db, Is.Not.Null);
        }

        [Test]
        public void ValidateCountIsZero()
        {
            db = new Database();
            Assert.That(db.Count, Is.Zero);
        }

        [Test]
        public void ValidateCountIsNull()
        {
            db = new Database();
            Assert.That(db.Count, Is.Not.Null);
        }

        [Test]
        public void ValidateCorrectInitialisationOfCtor()
        {
            Assert.That(db.Count, Is.EqualTo(data.Length));
        }

        [Test]
        public void ValidateThatIfDatabaseExceedsMaxCapacityThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => db.Add(Random.Shared.Next(100)), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void FetchShouldWorkCorrectly()
        {
            Database newDatabase = new Database();
            int[] array = new int[MaxElements];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Shared.Next(1, 100);
            }

            foreach (int num in array)
            {
                newDatabase.Add(num);
            }

            int[] fetchResult = newDatabase.Fetch();
            Assert.That(fetchResult, Is.EqualTo(array));
            //Assert.That(fetchResult,Has.Length.EqualTo(array.Length));
            //Assert.That(fetchResult, Is.Not.SameAs(array));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            Database newDatabase = new Database();

            Assert.Throws<InvalidOperationException>(() => newDatabase.Remove(), "The collection is empty!");
        }

        [Test]
        public void RemoveMethodShouldShouldRemoveTheLastElementInDatabaseAndMakeItZero()
        {
            for (int i = 0; i < data.Length; i++)
            {
                db.Remove();

                var expectedCount = data.Length - (i + 1);
                Assert.AreEqual(db.Count,expectedCount);
                Assert.AreEqual(data.Take(expectedCount),db.Fetch());
            }
        }
    }
}
