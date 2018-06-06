using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_KATAS
{
    public class StringCalculator
    {
        public static List<int> negatives = new List<int>();
 
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : GetSum(numbers);           
        }

        private static int GetSum(string numbers)
        {
            var delimiter = GetPossibleDelimiter();

            string numbersWithoutDelimiterPart = numbers;

            // check if there's any costumized delimiter
            if (HasSpecificDelimiter(numbers))
            {
                delimiter = GetDelimiter(numbers);
                numbersWithoutDelimiterPart = RemoveDelimiter(numbers, delimiter);
            }

            return numbersWithoutDelimiterPart.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(n => ParseToValidInt(n)).Sum();
        }

        private static bool HasSpecificDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }

        private static string GetPossibleDelimiter()
        {
            return ",\n";
        }

        private static int ParseToValidInt(string number)
        {
            int n = Convert.ToInt32(number);

            if (n < 0)
            {
                NegativesNotAllowed(n);
            }

            return !IsGreaterThan1000(n) ? n : 0;
        }

        private static bool IsGreaterThan1000(int n)
        {
            return n > 1000;
        }

        private static void NegativesNotAllowed(int n)
        {
            negatives.Add(n);

            throw new Exception($"Negatives found, {string.Join(",", negatives)}. Not allowed!");
        }

        private static string RemoveDelimiter(string numbers, string delimiter)
        {
            return numbers.Substring(numbers.IndexOf("\n") + 1, numbers.Length - (numbers.IndexOf("\n") + 1));
        }

        private static string GetDelimiter(string numbers)
        {
            return numbers.Substring(2, 1);
        }
    }
}
