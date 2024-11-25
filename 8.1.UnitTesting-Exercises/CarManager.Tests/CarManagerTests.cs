using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string testMake = GenerateRandomString();
        private string testModel = GenerateRandomString();
        private double testFuelConsumption = 1 + Random.Shared.NextDouble() * 10;
        private double testFuelCapacity = 1 + Random.Shared.NextDouble() * 100;
        private const double startingFuelAmount = 0;
        private Car car;
        private const double lessThanZero = -7.0;
        private const double AmountToRefuel = 10;
        [SetUp]
        public void SetUp()
        {
            car = new Car(testMake, testModel, testFuelConsumption, testFuelCapacity);
        }

        [Test]
        public void CarCtorIsNotNull()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void MakePropertyIsCorrectlyAdded()
        {
            Assert.IsNotNull(car.Make);
            Assert.AreEqual(car.Make, testMake);
        }

        [TestCase(null), TestCase("")]
        public void MakePropertyThrowsExceptionIfZeroOrNull(string invalidMake)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(invalidMake, testModel, testFuelConsumption, testFuelCapacity));

        }

        [Test]
        public void ModelPropertyIsCorrectlyAdded()
        {
            Assert.IsNotNull(car.Model);
            Assert.AreEqual(car.Model, testModel);
        }

        [TestCase(null), TestCase("")]
        public void ModelPropertyThrowsExceptionIfZeroOrNull(string invalidModel)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(testModel, invalidModel, testFuelConsumption, testFuelCapacity));

        }

        [Test]
        public void FuelConsumptionPropertyIsCorrectlyAdded()
        {
            Assert.IsNotNull(car.FuelConsumption);
            Assert.AreEqual(car.FuelConsumption, testFuelConsumption);
        }

        [TestCase(0), TestCase(lessThanZero)]
        public void FuelConsumptionPropertyThrowsExceptionIfLessThanZeroOrZero(double invalidConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(testModel, testModel, invalidConsumption, testFuelCapacity));

        }

        [Test]
        public void FuelCapacityPropertyIsCorrectlyAdded()
        {
            Assert.IsNotNull(car.FuelCapacity);
            Assert.AreEqual(car.FuelCapacity, testFuelCapacity);
        }

        [TestCase(0), TestCase(lessThanZero)]
        public void FuelCapacityThrowsExceptionIfLessThanZeroOrZero(double invalidConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(testModel, testModel, testFuelConsumption, invalidConsumption));

        }


        [Test]
        public void FuelAmountPropertyIsCorrectlyAdded()
        {
            Assert.IsNotNull(car.FuelAmount);
            Assert.AreEqual(car.FuelAmount, startingFuelAmount);
        }

        [Test]
        public void RefuelingHappyPath()
        {
            double fuelToRefuel = testFuelCapacity / 10;

            car.Refuel(fuelToRefuel);
            Assert.AreEqual(car.FuelAmount,fuelToRefuel);
        }

        [Test]
        public void RefuelingHappyPathFuelDoesNotOverflow()
        {
            double fuelToRefuel = testFuelCapacity * 10;
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(car.FuelAmount, testFuelCapacity);
        }

        [TestCase(0), TestCase(lessThanZero)]
        public void RefuelingWithZeroOrLessThanZeroShouldThrowException(double fuelToRefuel)
        {
           Assert.Throws<ArgumentException>(()=> car.Refuel(fuelToRefuel));
        }

        [Test]
        public void DriveShouldCorrectlySubtractFuelFromFuelAmount()
        {
            car.Refuel(AmountToRefuel);
            double distance = testFuelCapacity / AmountToRefuel;
            double fuelNeeded = (distance / 100) * testFuelConsumption;
            double fuelAmountLeft = car.FuelAmount - fuelNeeded;

            car.Drive(distance);

            Assert.AreEqual(car.FuelAmount,fuelAmountLeft);
        }

        [Test]
        public void DriveShouldThrowExceptionWhenDistanceTooLong()
        {
            car.Refuel(AmountToRefuel);
            double distance = testFuelCapacity * 1000;

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
        private static readonly (char Begin, int Length)[] _characterGroups = { ('a', 26), ('A', 26), ('0', 10) };                                  // Random string generator

        private static string GenerateRandomString()
        {
            char[] content = new char[Random.Shared.Next(5, 30)];

            for (int i = 0; i < content.Length; i++)
            {
                int randomGroupIndex = Random.Shared.Next(_characterGroups.Length);
                content[i] = (char)(_characterGroups[randomGroupIndex].Begin + Random.Shared.Next(_characterGroups[randomGroupIndex].Length));
            }

            return new string(content);
        }
    }
}