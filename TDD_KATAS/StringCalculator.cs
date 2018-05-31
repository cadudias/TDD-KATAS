using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class StringCalculator
    {
        private static string delimiter = ",";

        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : GetSum(numbers);           
        }

        private static int GetSum(string numbers)
        {
            string numbersWihtoutDelimiterPart = string.Empty;

            // ver se tem um delimitador customizado
            if (numbers.Contains("//"))
            {
                delimiter = GetDelimiter(numbers);
                numbersWihtoutDelimiterPart = RemoveDelimiter(numbers, delimiter);
            }

            // se sim, extrai o delimitador
            // passa o delimitador na lista pra dar split

            return numbers.Split(new char[] { delimiter.ToCharArray(), '\n' }).Select(n => Convert.ToInt32(n)).Sum();
        }

        private static string RemoveDelimiter(string numbers, string delimiter)
        {
            throw new NotImplementedException();
        }

        private static string GetDelimiter(string numbers)
        {
            return numbers.Substring(2, 1);
        }
    }
}
