using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class RomanNumberConverter
    {
        public RomanNumberConverter()
        {

        }

        public int Convert(string romanString)
        {
            // separar a string em vários pedaços pra poder calcular

            // comparar cada dupla de numeros

            // o primeiro é sempre o maior de todos então esse só se soma com tudo

            // os proximos tem que verificar
            // se for igual ao posterior, soma
            // se for menor do que o posterior, inverte a ordem dos numeros decimais deles e subtrai


            char[] romanArray = romanString.ToCharArray();
            List<int> numbers = new List<int>();

            foreach (var roman in romanArray)
            {
                if (roman == 'I')
                {
                    numbers.Add(1);
                }
                else if (roman == 'V')
                {
                    numbers.Add(5);
                }
                else if (roman == 'X')
                {
                    numbers.Add(10);
                }
                else if (roman == 'L')
                {
                    numbers.Add(50);
                }
                else if (roman == 'C')
                {
                    numbers.Add(100);
                }
                else if (roman == 'D')
                {
                    numbers.Add(500);
                }
                else if (roman == 'M')
                {
                    numbers.Add(1000);
                }
            }

            int firstNumber = 0;
            int nextNumber = 0;

            int total = 0;
            for (int i = numbers.Count - 1; i > 0 ; i--)
            {
                firstNumber = numbers[0];
                nextNumber = numbers[i - 1];
                int currentNumber = numbers[i];

                if (numbers.Count > 2)
                {
                    if (currentNumber < nextNumber)
                    {
                        // inverte a ordem dos numeros e dimunui
                        total += currentNumber + nextNumber;
                    }
                    else
                    {
                        total += nextNumber - currentNumber;
                        
                    }
                }
                else
                {
                    total += currentNumber;
                }
            }

            return total + firstNumber;
        }

        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
