namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();    
        }

        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarriors()
        {
            Arena testArena = new Arena();
            List<Warrior> actualCollection = testArena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectedCollection, actualCollection, "Arena constructor should initialize an empty collections of Warriors");
        }
        [Test]
        public void TestIsWarriorsCollectionIsEncapsulatedProperly()
        {
            string actualType = typeof(Arena).GetProperties().First(pi => pi.Name == "Warriors")
                .PropertyType.Name;

            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectedType, actualType, "Property for the enrolled Warriors should be of type IReadonlyCollection<Warrior>");
        }
        [Test]
        public void CountSHouldReturnZeroOnEmptyArena()
        {
            int actualCount = arena.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount, "Count should return zero when there are no enrolled Warriors!");
        }

        [Test]
        public void CountShouldReturnCollectValueWhenTereAreEnrolledWarriors()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            int actualCount = arena.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount, "Count should return the count of the enrolled Warriors!");
        }

        [Test]
        public void EnrollShouldThrowAnExceptionWhenEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }


        [Test]
        public void TestEnrollAddsWarriorsToTheArena()
        {
            Warrior pesho = new Warrior("Pesho", 30, 100);
            Warrior gosho = new Warrior("Gosho", 35, 85);

            arena.Enroll(gosho);
            arena.Enroll(pesho);

            List<Warrior> actualCollection = arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>() { gosho, pesho};

            CollectionAssert.AreEqual(expectedCollection, actualCollection, "Warriors collection getter should return enrolled warriors!");
        }
        [Test]
        public void FightBetweenInExistingAttackerShouldThtowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Invalid", "Pesho");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenInExistirngDefenderShouldThrowAnException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Invalid");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenExistingWarriorShouldSucceed()
        {
            Warrior warriorA = new Warrior("Pesho", 40, 100);
            Warrior warriorD = new Warrior("Gosho", 55, 100);

            arena.Enroll(warriorA);
            arena.Enroll(warriorD);

            arena.Fight("Pesho", "Gosho");

            int attackerActualHp = warriorA.HP;
            int expectedAttackerHp = 100 - warriorD.Damage;

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 100 - warriorA.Damage;

            Assert.AreEqual(expectedAttackerHp, attackerActualHp, "Fight between existing Warriors should decrease attacker HP!");
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Fight between existing Warriors should decrease defender HP!");
        }
    }
}
