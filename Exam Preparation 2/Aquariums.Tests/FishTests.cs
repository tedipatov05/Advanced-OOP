using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Aquariums.Tests
{
    [TestFixture]
    public class FishTests
    {
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestIfConstructorSetsTheNameCorrectly(string name)
        {
            Fish fish = new Fish(name);

            Assert.AreEqual(fish.Name, name);
        }

        [Test]
        public void TestIfConstructorSetAvailableCorrectly()
        {
            string expname = "Riba33";
            Fish fish = new Fish(expname);

            Assert.AreEqual(expname, fish.Name);
            Assert.IsTrue(fish.Available);
        }

    }
}
