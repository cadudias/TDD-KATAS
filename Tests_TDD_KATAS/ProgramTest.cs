using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    [TestFixture]
    public class ProgramTest
    {
        // symbols are placed in order of value starting with the largest values
        // EX: VI = 4

        // When smaller values precede larger values, the smaller values are subtracted from the larger values, and the result is added to the total

        [Test]
        public void Should_Convert_Roman_To_Number()
        {
            // arrange
            RomanNumberConverter rtn = new RomanNumberConverter();

            // act
            int number1 = rtn.Convert("MMVI");

            // assert
            Assert.AreEqual(4, number1);
        }
    }
}
