namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [TestCase("Riba1", 1)]
        [TestCase("Riba2", 10)]
        [TestCase("Riba3", 999)]

        public void TestIfConstructorWorksCorrectly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name );
            Assert.AreEqual(capacity, aquarium.Capacity );
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 1);
            }, "Invalid aquarium name!");
        }
        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(int.MinValue)]
        public void TestWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Riba", capacity);
            }, "Invalid aquarium capacity!");
        }

        [TestCase(1)]
        [TestCase(5)]
        public void TestAddingFishWhenFree(int capacity)
        {
            var aquarium = new Aquarium("ImeRibka", capacity);
            Fish fish = new Fish("Riba");
            aquarium.Add(fish);
            int expCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expCount, actualCount);
        }

        [Test]
        public void TestAddingFishWhenAquariumIsFull()
        {
            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish("Ime1");
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(f1);
            }, "Aquarium is full!");
        }
        [Test]
        public void TestIfRemovingExistingFishWorks()
        {
            Aquarium aquarium = new Aquarium("Ime", 2);
            string name = "Ime1";
            Fish f1 = new Fish(name);
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);

            aquarium.RemoveFish(name);

            int expCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expCount, actualCount);

        }
        [Test]
        public void TestRemovingNonExistingFish()
        {
            string fishName = "nonExist";

            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish("Ime1");
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishName);
            }, $"Fish with the name {fishName} doesn't exist!");


        }
        [Test]
        public void TestSellingExistingFish()
        {
            string name = "Ime1";
            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish(name);
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);

            Fish fish = aquarium.SellFish(name);

            Assert.IsFalse(fish.Available);
        }
        [Test]
        public void TestSellingNonExistingFish()
        {
            string name = "NonExist";
            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish("Ime1");
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish fish = aquarium.SellFish(name);
            }, $"Fish with the name {name} doesn't exist!");

            
        }
        [Test]
        public void TestingReportWithLikeManyFishes()
        {
            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish("Ime1");
            Fish f2 = new Fish("Ime2");

            aquarium.Add(f1);
            aquarium.Add(f2);

            string actReport = aquarium.Report();
            string expReport = $"Fish available at Ime: Ime1, Ime2";

            Assert.AreEqual(expReport, actReport);
        }
        [Test]
        public void TestingReportWithOneFishe()
        {
            Aquarium aquarium = new Aquarium("Ime", 2);
            Fish f1 = new Fish("Ime1");
           

            aquarium.Add(f1);
           

            string actReport = aquarium.Report();
            string expReport = $"Fish available at Ime: Ime1";

            Assert.AreEqual(expReport, actReport);
        }
        [Test]
        public void TestingReportWithEmptyAquarium()
        {
            Aquarium aquarium = new Aquarium("Ime", 3);
            Fish f1 = new Fish("Ime1");


            string actReport = aquarium.Report();
            string expReport = $"Fish available at Ime: ";

            Assert.AreEqual(expReport, actReport);
        }



    }
}
