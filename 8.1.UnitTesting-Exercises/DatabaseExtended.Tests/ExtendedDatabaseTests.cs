using System.Collections.Generic;
using System.Linq;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private static readonly (char Begin, int Length)[] CharacterGroups = { ('a', 26), ('A', 26), ('0', 10) };
        private const int MaxElements = 16;
        private const int MinElement = 1;
        private Person[] Persons;
        private Database FullDb;
        private Database randomisedDatabase;
        [SetUp]
        public void SetUp()
        {
            Persons = new Person[MaxElements];

            for (int i = 0; i < MaxElements; i++)
            {
                Persons[i] = new Person(Random.Shared.NextInt64(), GenerateRandomString());
            }
            FullDb = new Database(Persons);

        }


        [Test]
        public void AddRangeWithCountBiggerThanMaxThrowsException()
        {
            Person[] exceedingPersons = new Person[MaxElements + Random.Shared.Next(1, 3)];

            for (int i = 0; i < exceedingPersons.Length; i++)
            {
                exceedingPersons[i] = new Person(Random.Shared.NextInt64(), GenerateRandomString());
            }

            Assert.Throws<ArgumentException>(() => FullDb = new Database(exceedingPersons), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void DatabaseIsNotNull()
        {
            Assert.That(FullDb, Is.Not.Null);
        }

        [Test]
        public void CountIsCorrectlyWorking()
        {
            Assert.AreEqual(FullDb.Count, Persons.Length);
        }

        [Test]
        public void RemoveIsWorkingCorrect()
        {
            int removeElementsAmount = Random.Shared.Next(1, Persons.Length);
            Stack<Person> copyOfPersons = new Stack<Person>(Persons);
            for (int i = 0; i < removeElementsAmount; i++)
            {
                FullDb.Remove();
                copyOfPersons.Pop();
            }

            Assert.AreEqual(FullDb.Count, copyOfPersons.Count);
        }
        [Test]
        public void RemoveWhenDatabaseNullThrowsException()
        {
            int removeElementsAmount = Persons.Length;

            for (int i = 0; i < removeElementsAmount; i++)
            {
                FullDb.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => FullDb.Remove());
        }

        [Test]
        public void AddingPersonExceedingMaxCountThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                FullDb.Add(new Person(Random.Shared.NextInt64(), GenerateRandomString())), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddExistingNameOfPersonInDatabaseThrowsException()
        {

            int amountOfPersons = Random.Shared.Next(MinElement, MaxElements);

            Persons = new Person[amountOfPersons];

            for (int i = 0; i < Persons.Length; i++)
            {
                Persons[i] = new Person(Random.Shared.NextInt64(), GenerateRandomString());
            }

            randomisedDatabase = new Database(Persons);
     
            Assert.Throws<InvalidOperationException>(() =>
                randomisedDatabase.Add(new Person(Random.Shared.NextInt64(), Persons.FirstOrDefault()!.UserName)));
        }
        [Test]
        public void AddExistingIdOfPersonInDatabaseThrowsException()
        {

            int amountOfPersons = Random.Shared.Next(MinElement, MaxElements);

            Persons = new Person[amountOfPersons];

            for (int i = 0; i < Persons.Length; i++)
            {
                Persons[i] = new Person(Random.Shared.NextInt64(), GenerateRandomString());
            }

            randomisedDatabase = new Database(Persons);

            Assert.Throws<InvalidOperationException>(() =>
                randomisedDatabase.Add(new Person(Persons.FirstOrDefault()!.Id, GenerateRandomString())));
        }

        [Test]
        public void FindByIdReturnsTheCorrectPersonInstance()
        {
            Person foundById = FullDb.FindById(Persons.Last().Id);

            Assert.AreEqual(foundById, Persons.Last());
        }

        [Test]
        public void FindByNameReturnsTheCorrectPersonInstance()
        {
            Person foundByUserName = FullDb.FindByUsername(Persons.Last().UserName);

            Assert.AreEqual(foundByUserName, Persons.Last());
        }

        [TestCase(null),TestCase("")]
        public void FindByNameThrowsExceptionIfUsernameZeroOrEmpty(string incorrectName)
        {
            Assert.Throws<ArgumentNullException>(() => FullDb.FindByUsername(incorrectName), "Username parameter is null!");
        }

        [Test]
        public void FindByNameThrowsExceptionIfUsernameDoesNotExist()
        {
            InvalidOperationException thrownException = Assert.Throws<InvalidOperationException>(() 
                => FullDb.FindByUsername(GenerateRandomString()));

            Assert.That(thrownException.Message,Is.EqualTo("No user is present by this username!"));
        }

        
        [Test]
        public void FindByIdShouldThrowExceptionIfIdLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FullDb.FindById(Random.Shared.NextInt64(1,long.MaxValue) * -1), "Id should be a positive number!");
        }

        [Test]
        public void FindByIdShouldThrowExceptionNonExistingId()
        {

            InvalidOperationException thrownException =
                Assert.Throws<InvalidOperationException>(() => FullDb.FindById(Random.Shared.NextInt64()));
            Assert.That(thrownException.Message,Is.EqualTo("No user is present by this ID!"));
        }
        private static Person GeneratePerson()
        {
            Person personGenerated = new Person(Random.Shared.NextInt64(), GenerateRandomString());
            return personGenerated;
        }
        private static string GenerateRandomString()
        {
            char[] content = new char[Random.Shared.Next(5, 30)];

            for (int i = 0; i < content.Length; i++)
            {
                int randomGroupIndex = Random.Shared.Next(CharacterGroups.Length);
                content[i] = (char)(CharacterGroups[randomGroupIndex].Begin + Random.Shared.Next(CharacterGroups[randomGroupIndex].Length));
            }

            return new string(content);
        }
    }
}