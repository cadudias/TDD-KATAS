using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class FizzBuzz
    {
        public static string PrintNumber()
        {
            var number = string.Empty;
            for (var i = 1; i < 100; i++)
                number += " " + (IsFizzBuzz(i) ? "FizzBuzz" :
                    (IsFizz(i) ? "Fizz" : 
                    IsBuzz(i) ? "Buzz" :
                    i+""));

            return number.Trim();
        }

        public static string PrintNumberSpecific(int number)
        {

            return (IsFizzBuzz(number) ? "FizzBuzz" :
                    (IsFizz(number) ? "Fizz" :
                    IsBuzz(number) ? "Buzz" :
                    number + "")).Trim();
        }

        private static bool IsFizzBuzz(int i)
        {
            return i % 3 == 0 && i % 5 == 0 ? true : false;
        }

        private static bool IsBuzz(int i)
        {
            return i % 5 == 0 ? true : false;
        }

        private static bool IsFizz(int i)
        {
            return i % 3 == 0 ? true : false;
        }
    }
}
