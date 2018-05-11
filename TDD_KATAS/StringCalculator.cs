using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class StringCalculator
    {
        

        public static int Add(string numbers)
        {
            // split da string e soma os valores 
            return string.IsNullOrEmpty(numbers) ? 0 : GetSum(numbers);
        }

        private static int GetSum(string numbers)
        {
            var delimiter = GetPossibleDelimiter();
            var numbersWithoutDelimiter = numbers;

            if (HasSpecificDelimiter(numbers))
            {
                delimiter = GetSpecificDelimiter(numbers);
                numbersWithoutDelimiter = GetNumbersWithoutDelimiter(numbers);
            }

            return ContainsAny(numbers, delimiter) 
                ? numbersWithoutDelimiter.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Sum(n => ParseToValidInt(n))
                : ParseToValidInt(numbers);
        }

        private static bool ContainsAny(string numbers, string delimiters)
        {
            return delimiters.ToCharArray().Any(numbers.Contains);
        }

        private static int ParseToValidInt(string n)
        {
            int number = Convert.ToInt32(n);

            CheckForNegative(number);

            return !IsGreaterThan1000(number) ? number : 0;
        }

        private static bool IsGreaterThan1000(int number)
        {
            return number > 1000;
        }

        private static void CheckForNegative(int number)
        {
            if (number < 0)
            {
                //negatives.Add(number);
                throw new ArgumentException($"{number} found, negatives not allowed");
            }
        }

        private static int NotGreaterThan1000(int v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the delimiter part from the string
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static string GetNumbersWithoutDelimiter(string numbers)
        {
            return numbers.Substring(numbers.IndexOf("\n") + 1, numbers.Length - numbers.IndexOf("\n") - 1);
        }

        private static bool HasSpecificDelimiter(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static string GetSpecificDelimiter(string numbers)
        {
            return numbers.Substring(2, numbers.IndexOf("\n") - 1);
        }

        private static string GetPossibleDelimiter()
        {
            return ",\n";
        }
    }
}
