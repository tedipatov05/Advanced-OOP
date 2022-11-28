namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
           
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHP = 55;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            FieldInfo nameField = this.GetField("name");
            string actualName = (string)nameField.GetValue(warrior);

            FieldInfo damageField = this.GetField("damage");
            int actualDamage = (int)damageField.GetValue(warrior);

            FieldInfo hpField = this.GetField("hp");
            int actualHp = (int)hpField.GetValue(warrior);

            Assert.AreEqual(expectedHP,actualHp, "Constructor should intialize the HP on warrior.");
            Assert.AreEqual(expectedName, actualName,
                "Construcotr should initialize the Name of the Warrior");
            Assert.AreEqual(expectedDamage, actualDamage,
                "Constructor should initialize the Damage of the Warrior");
        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 55, 55);
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName, "Getter of the property Name whould return the value");

        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        public void TestNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should net be empty or whitespace!");
        }
        [Test]
        public void TestDamageGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", 55, 55);

            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage, "Getter of the property Damage should return the value of damage!");
        }
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive");
        }
        [Test]
        public void TestHPGetter()
        {
            int expectedHp = 55;
            Warrior warrior = new Warrior("Pedho", 33, expectedHp);
            int actualHp = warrior.HP;
            Assert.AreEqual(expectedHp, actualHp, "Getter of the property should return the value of hp");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void TestHpSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP should not be negative!");
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]

        public void AttackShouldThrowErrorWhileAttackingWarriorIsLow(int startHp)
        {
            Warrior warriorA = new Warrior("Pesho", 70, startHp);
            Warrior warriorD = new Warrior("Gosho", 55, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHp)
        {
            Warrior warriorA = new Warrior("Pesho", 45, 65);
            Warrior warriorD = new Warrior("Gosho", 35, startHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Enemy HP must be greater than 30 in order to attack him! ");
        }

        [TestCase(50, 60)]
        [TestCase(50, 51)]

        public void AttackShouldThtowErrorWhenDefendingWarriorIsStronger(int attackerHp, int defenderDamage)
        {
            Warrior warriorA = new Warrior("Pesho", 50, attackerHp);
            Warrior warriorD = new Warrior("Gosho", defenderDamage, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "You are trying to attack too strong enemy");
        }

        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(60, 60)]
        public void SuccessAttackShouldDecreaseAttackerHp(int atackerHp, int defenderDamage)
        {
            Warrior warriorA = new Warrior("Pesho", 50, atackerHp);
            Warrior warriorD = new Warrior("Gosho", defenderDamage, 55);

            warriorA.Attack(warriorD);

            int actualHp = warriorA.HP;
            int expectedHp = atackerHp - defenderDamage;

            Assert.AreEqual(expectedHp, actualHp, "Successful attack should decrese attacker HP!" );
        }

        [TestCase(70, 40)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void SuccessAttackShoouldHillEnemyMyDamageIsOverTheirHP(int atackerDamage, int defenderHp)
        {
            Warrior warriorA = new Warrior("Pesho", atackerDamage, 100);
            Warrior warriorD = new Warrior("Gosho", 40, defenderHp);

            warriorA.Attack(warriorD);

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Attacker enemy woth lower Hp than attackerDamage should leave them with zero Hp");


        }

        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void SuccesAttackShouldDecreaseEnemyHpIfWeDoNotKillThem(int atackerDamage, int defenderHp)
        {
            Warrior warriorA = new Warrior("Pesho", atackerDamage, 100);
            Warrior warriorD = new Warrior("Gosho", 30, defenderHp);

            warriorA.Attack(warriorD);
            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = defenderHp - atackerDamage;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Attacking enemy with higher Hp than attacker Damage should leave them with correct Hp value!");
        }
        private FieldInfo GetField(string fieldName)
            => typeof(Warrior)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.Name == fieldName);

    }
}