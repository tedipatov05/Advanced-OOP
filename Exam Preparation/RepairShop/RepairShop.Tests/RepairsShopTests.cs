using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void GarageNameShouldthrowexceptionWothEmptyOrNullValues(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(name, 10);
                }, "Invalid garage name");
            }

            [Test]
            public void GarageNamePropertyShouldWorkCorrectly()
            {
                const string name = "test";

                var garage = new Garage(name, 10);

                Assert.AreEqual(name, garage.Name);

            }

            [TestCase(0)]
            [TestCase(-2)]
            public void GarageMechanicsPropertyShouldThrownExceptionWithNoMechanicsAvailable(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Pesho", mechanics);
                }, "No mechanic available.");
            }

            [TestCase(2)]
            [TestCase(3)]
            public void GarageMechanicsPropertyShouldWorkCorrectly(int mechanics)
            {
                Garage garage = new Garage("Pesho", mechanics);
                int expecetedMechanics = mechanics;
                int actualMechanics = garage.MechanicsAvailable;

                Assert.AreEqual(expecetedMechanics, actualMechanics);
            }

            [TestCase(1)]
            public void GarageAddCarShouldThrowExceptionWithNoAvailableMechanics(int mechanics)
            {
                var garage = new Garage("Test",mechanics);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
               


                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanic available.");
            }

            [Test]
            public void GarageAddCarShouldIncrementCorrectCarCount()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                int expectedCount = 2;
                int actualCount = garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount);

            }

            [TestCase("Opel")]
            [TestCase("Mazda")]
            public void GarageFixCarShouldThrowExceptionIfCarModeIsMissing(string model)
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(model);
                }, $"The car {model} doesn't exist.");
            }

            [Test]
            public void GarageFixCarShouldReturnTheCarFixed()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                var fixedCar = garage.FixCar("Opel");

                Assert.AreEqual(secondCar, fixedCar);
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
                Assert.AreEqual(true, fixedCar.IsFixed);

                
            }

            [TestCase("Opel")]
            [TestCase("Ford")]

            public void GarageRemoveFixedCarsShouldThrowExceptionIfNoFixedCarAvailable(string model)
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(model, 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();

                }, $"No fixed cars available.");

            }

            [Test]
            public void GarageRemoveFixedCarsShouldRemoveFixedCars()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);
                var thirdCar = new Car("BMV", 50);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar("Opel");
               
                var fixedCars = garage.RemoveFixedCar();

                Assert.AreEqual(1, fixedCars);
                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void ReportShouldShowCorrectResult()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);
                var thirdCar = new Car("BMV", 50);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar("Opel");

                var report = garage.Report();

                Assert.AreEqual("There are 2 which are not fixed: Mercedes, BMV.", report);
            }
        }
    }
}