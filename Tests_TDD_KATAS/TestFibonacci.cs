using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    class TestFibonacci
    {
        //[TestCase(0, 0)]
        //[TestCase(1, 1)]
        //[TestCase(2, 1)]
        //[TestCase(3, 2)]
        //[TestCase(4, 3)]
        //[TestCase(5, 5)]
        //[TestCase(6, 8)]
        //[TestCase(7, 13)]
        [TestCase(8, 21)]
        public void TestFib(int pos, int expectedResult)
        {
            Fibonacci fib = new Fibonacci();
            Assert.AreEqual(expectedResult, fib.F(pos));
        }

    }
}
