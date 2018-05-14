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
                numbersWithoutDelimiter = RemoveCustomDelimiterPrefix(numbers);
            }

            // crio lista de numeros
            IEnumerable<int> parsedNumbers = ParseStringNumbers(numbersWithoutDelimiter, delimiter);

            //checo se nessa lista tem numeros negativos
            CheckForNegatives(parsedNumbers);

            return parsedNumbers.Sum(n => !IsGreaterThan1000(n) ? n : 0);
        }

        private static IEnumerable<int> ParseStringNumbers(string stringNumbers, string delimiter)
        {
            IEnumerable<int> numbers = stringNumbers.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(n => ParseToValidInt(n));

            return numbers;
        }

        private static string RemoveCustomDelimiterPrefix(string stringNumbers)
        {
            string numbers = "";
            if (stringNumbers.StartsWith("//"))
            {
                string[] numbersArr = stringNumbers.Split('\n');
                numbers = numbersArr[1];
            }

            return numbers;
        }

        private static bool ContainsAny(string numbers, string delimiters)
        {
            return delimiters.ToCharArray().Any(numbers.Contains);
        }

        private static int ParseToValidInt(string n)
        {
            return Convert.ToInt32(n);
        }

        private static bool IsGreaterThan1000(int number)
        {
            return number > 1000;
        }

        private static void CheckForNegatives(IEnumerable<int> numbers)
        {
            List<int> negatives = new List<int>();

            foreach (var number in numbers)
            {
                if (number < 0)
                    negatives.Add(number);
            }

            if (negatives.Count > 0)
                throw new ArgumentException($"{string.Join(",", negatives)} found, negatives not allowed");
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
