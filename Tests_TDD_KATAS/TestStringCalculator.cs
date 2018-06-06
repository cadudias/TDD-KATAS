using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    class TestStringCalculator
    {
        [Test]
        public void ShouldReturn0WhenIsEmptyString()
        {
            var sut = StringCalculator.Add("");

            Assert.AreEqual(0, sut);
        }

        [TestCase(10, "2,8")]
        [TestCase(2, "2")]
        [TestCase(4, "2,2")]
        [TestCase(5, "0,5")]
        [Test]
        public void ShouldReturnNumberIfOneNumberGiven(int expectedResult, string numbers)
        {
            var sut = StringCalculator.Add(numbers);

            Assert.AreEqual(expectedResult, sut);
        }

        [TestCase(6, "1\n2,3")]
        [Test]
        public void ShouldReturnNumberSumWithNewLineInsteadOfComma(int expectedResult, string numbers)
        {
            var sut = StringCalculator.Add(numbers);

            Assert.AreEqual(expectedResult, sut);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(3, "//.\n1.2")]
        [Test]
        public void ShouldReturnSumWithDifferentDelimiter(int expectedResult, string numbers)
        {
            var sut = StringCalculator.Add(numbers);

            Assert.AreEqual(expectedResult, sut);
        }

        [Test]
        public void ShouldThrowErrorIfNegativesNumbersArePassed()
        {
            Exception ex = Assert.Throws<Exception>(() => StringCalculator.Add("//;\n1;-2"));

            Assert.That(ex.Message, Is.EqualTo("Negatives found, -2. Not allowed!"));
        }

        // Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2
        [TestCase(2, "//;\n2;1001")]
        [TestCase(1002, "//;\n2;1000")]
        public void ShouldIgnoreNumbersGreaterThan1000(int expectedResult, string numbers)
        {
            var sut = StringCalculator.Add(numbers);

            Assert.AreEqual(expectedResult, sut);
        }
    }
}
