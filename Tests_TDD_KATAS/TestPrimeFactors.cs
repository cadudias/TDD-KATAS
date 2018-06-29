using NUnit.Framework;
using System.Collections.Generic;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    [TestFixture]
    class TestPrimeFactors
    {
        [TestCase(1, new int[0])]
        [TestCase(2, new[] { 2 })]
        [TestCase(3, new[] { 3 })]
        [TestCase(4, new[] { 2, 2 })]
        [TestCase(6, new[] { 2, 3 })]
        [TestCase(8, new[] { 2, 2, 2 })]
        [TestCase(9, new[] { 3, 3 })]
        public void ShouldFactor(int number, int[] primes)
        {
            var result = number.Primes();
            Assert.AreEqual(primes, result);
        }
    }
}
