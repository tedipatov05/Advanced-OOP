using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TestIfWeaponComstructorInitializeDataCorrectly()
            {
                string name = "nuclear";
                int destruction = 10;
                double priceWeapon = 100;

                Weapon weapon = new Weapon(name, priceWeapon, destruction);

                Assert.AreEqual(name, weapon.Name);
                Assert.AreEqual(priceWeapon, weapon.Price);
                Assert.AreEqual(destruction, weapon.DestructionLevel);
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PriceShouldThrowAnExceptionIfItsLowerThanZero(int price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Weapon weapon = new Weapon("Avangard", price, 100);
            }, "Price cannot be negative.");
        }

        [Test]
        public void IncreaseDestructionLevelShouldIncreaseDestructionLevel()
        {
            Weapon weapon = new Weapon("Test", 10, 4);

            weapon.IncreaseDestructionLevel();
            int expectedDestructioonLevel = 5;
            int actualDestructionLevel = weapon.DestructionLevel;

            Assert.AreEqual(expectedDestructioonLevel, actualDestructionLevel);
        }

        [Test]
        public void WeaponIsNuclearShouldReturnTrueIfDestructionLeveIsBiggerOrEqualToTen()
        {
            Weapon weapon = new Weapon("Nuclear", 100, 10);
            Assert.IsTrue(weapon.IsNuclear);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PlanetNameSetterValidationShouldThrowAnExceptionWithNullOrEmptyName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet(name, 100);
            }, "Invalid planet Name");
        }
        [Test]
        public void PlanetNameShouldBeIntializesCorrectly()
        {
            string name = "Earth";
            Planet planet = new Planet(name, 100);

            Assert.AreEqual(name, planet.Name);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        public void PlanetBudgetSetterValidationShouldThrowAnExceptionWithLowerThanZeroBudget(int budget)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet("Earth", budget);
            }, "Budget cannot drop below Zero!");
        }
        [Test]
        public void ConstructorShouldInitializePlanetBudgetCorrectly()
        {
            Planet planet = new Planet("Teodor", 10);
            double expectedBudget = 10;
            double actualBudget = planet.Budget;

            Assert.AreEqual(expectedBudget, actualBudget);
        }
        [Test]
        public void ProfitShouldIncreaseBudget()
        {
            double budget = 10;
            Planet planet = new Planet("Teodor", budget);
            planet.Profit(10);

            double expectedBudget = 20;
            double actualBudget = planet.Budget;

            Assert.AreEqual(expectedBudget, actualBudget);
        }

        [Test]
        public void SpendFundsShouldThrowAnExceptionIfFundesAreBiggerThanBudget()
        {
            Planet planet = new Planet("Earth", 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.SpendFunds(20);
            }, "Not enough funds to finalize the deal.");
        }

        [Test]
        public void SpendFundsShouldDecreaseTheBudget()
        {
            Planet planet = new Planet("Earth", 10);

            
            planet.SpendFunds(3);

            double expectedBudget = 7;
            double actualBudget = planet.Budget;

            Assert.AreEqual(expectedBudget, actualBudget);

          
        }

        [Test]
        public void AddWeaponShouldThrowAnExceptionWithExistingWeapon()
        {
            Planet planet = new Planet("Earth", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.AddWeapon(weapon);
            }, $"There is already a {weapon.Name} weapon.");
        }
        [Test]
        public void AddWeaponShouldIncreaseTheCountOfWeapons()
        {
            Planet planet = new Planet("Earth", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            int expectedCount = 1;
            int actualCount = planet.Weapons.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddWeaponShouldPhysicallyAddWeaponToThePlanetWeapons()
        {
            Planet planet = new Planet("Earth", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            List<Weapon> list = new List<Weapon>() { weapon };

            CollectionAssert.AreEqual(list, planet.Weapons);
        }

        [Test]
        public void RemoveWeaponShouldPhysicallyRemoveWeaponToThePlanetWeapons()
        {
            Planet planet = new Planet("Earth", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            Weapon weapon1 = new Weapon("Nuclear1", 22, 13);
            planet.AddWeapon(weapon1);


            List<Weapon> list = new List<Weapon>() { weapon, weapon1 };

            planet.RemoveWeapon("Nuclear");
            list.Remove(weapon);

            CollectionAssert.AreEqual(list, planet.Weapons);
        }

        [Test]
        public void UpgrateWeaponShouldThrowAnExceptionWithNonExistingWeapon()
        {
            Planet planet = new Planet("Earth", 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.UpgradeWeapon("Ivan");
            }, $"Ivan does not exist in the weapon repository of {planet.Name}");
        }
        [Test]
        public void UpgrateWeponShouldIncreaseDestructionLevel()
        {
            Planet planet = new Planet("Earth", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            planet.UpgradeWeapon("Nuclear");

            int expectedDestructionLevel = 24;
            int actualDestructionLevel = weapon.DestructionLevel;

            Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
        }
        [Test]
        public void TestMilitaryPowerRatio()
        {
            Planet planet = new Planet("Earth", 10);
            Weapon weapon = new Weapon("Nuclear", 29, 23);
            planet.AddWeapon(weapon);

            double expectedMilitaryPowerRatio = 23;
            double actualMilitaryPowerRation = planet.MilitaryPowerRatio;

            Assert.AreEqual(expectedMilitaryPowerRatio, actualMilitaryPowerRation) ;
        }
        [Test]
        public void DestructOpponentShouldthrowAnExceptionTryingToAttackStrongerPlanet()
        {
            Planet planetDefent = new Planet("Earth", 20);
            Planet planetAttack = new Planet("Mars", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            Weapon weapon2 = new Weapon("Nuclear", 29, 10);

            planetDefent.AddWeapon(weapon);
            planetAttack.AddWeapon(weapon2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                planetAttack.DestructOpponent(planetDefent);
            }, $"{planetDefent.Name} is too strong to declare war to!");
        }

        [Test]
        public void DestructOpponentShouldDestructOpponent()
        {
            Planet planetDefent = new Planet("Earth", 20);
            Planet planetAttack = new Planet("Mars", 10);

            Weapon weapon = new Weapon("Nuclear", 29, 23);
            Weapon weapon2 = new Weapon("Nuclear", 29, 10);

            planetDefent.AddWeapon(weapon2);
            planetAttack.AddWeapon(weapon);

            
            string ActualOutput = planetAttack.DestructOpponent(planetDefent);
            string expectedOutput = $"{planetDefent.Name} is destructed!";

            Assert.AreEqual(expectedOutput, ActualOutput);




        }

    }
}
