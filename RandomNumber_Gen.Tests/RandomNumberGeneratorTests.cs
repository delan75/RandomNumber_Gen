using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomNumber_Gen;

namespace RandomNumber_Gen.Tests
{
    [TestClass]
    public class RandomNumberGeneratorTests
    {
        private RandomNumberGenerator _generator;

        [TestInitialize]
        public void Setup()
        {
            _generator = new RandomNumberGenerator();
        }

        [TestMethod]
        public void Generate_ReturnsCorrectCount()
        {
            var result = _generator.Generate(10, 1000, 2000);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void Generate_NumbersWithinRange()
        {
            var result = _generator.Generate(100, 1000, 2000);
            Assert.IsTrue(result.All(n => n >= 1000 && n <= 2000));
        }

        [TestMethod]
        public void Generate_EmptyListForZeroCount()
        {
            var result = _generator.Generate(0, 1000, 2000);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Generate_ProducesVariety()
        {
            var result = _generator.Generate(50, 1000, 2000);
            var uniqueCount = result.Distinct().Count();
            Assert.IsTrue(uniqueCount > 1, "Should generate varied numbers");
        }
    }
}
