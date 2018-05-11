using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    class TestFizzBuzz
    {
        //Print the numbers from 1 to 100

        [Test]
        public void FizzBuzzCanReturnFizzIfNumberDivisibleByThree()
        {
            var actualResult = FizzBuzz.PrintNumber();
            Assert.True(actualResult.Contains("Fizz"));
        }

        [Test]
        public void FizzBuzzCanReturnBuzzIfNumberDivisibleByFive()
        {
            var actualResult = FizzBuzz.PrintNumber();
            Assert.True(actualResult.Contains("Buzz"));
        }

        [Test]
        public void FizzBuzzCanReturnFizzBuzzIfNumberDivisibleByThreeAndByFive()
        {
            var actualResult = FizzBuzz.PrintNumber();
            Assert.True(actualResult.Contains("FizzBuzz"));
        }

        [Test]
        public void FizzBuzzCheckIf30IsFizzBuzz()
        {
            var actualResult = FizzBuzz.PrintNumberSpecific(30);
            Assert.True(actualResult.Contains("FizzBuzz"));
        }
    }
}
