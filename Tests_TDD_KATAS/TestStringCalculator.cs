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
        [TestCase("10,20,30", 60)]
        [TestCase("1,2,3", 6)]
        [TestCase("1", 1)]
        [TestCase("0", 0)]
        [Test]
        public void StringCalculator_ShouldAddNumbers(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void StringCalculator_ShouldReturn0WhenEmptyString()
        {
            var result = StringCalculator.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void StringCalculator_ShouldHandleNewLineBetweenNumbers()
        {
            var result = StringCalculator.Add("1\n2,3");

            Assert.That(result, Is.EqualTo(6));
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//.\n1.4", 5)]
        [Test]
        public void StringCalculator_ShouldAddWithDifferentDelimiter(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        
        [TestCase("//;\n1;2;-10", -10)]
        [TestCase("1,-1", -1)]
        [Test]
        public void StringCalculator_ShouldRejectNegativeNumbers(string numbers, int expectedResult)
        {
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));

            Assert.That(exception.Message, Is.EqualTo($"{expectedResult} found, negatives not allowed"));
        }

        [TestCase("1,1030", 1)]
        [TestCase("1,1000", 1001)]
        public void StringCalculator_ShouldNotAddNumbersGreaterThan1000(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("//[***]\n1***2***3", 6)]
        public void StringCalculator_ShouldAddWithMultipleDelimiters(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
