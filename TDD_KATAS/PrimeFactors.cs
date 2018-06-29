using System.Collections.Generic;

namespace TDD_KATAS
{
    public static class PrimeFactors
    {
        public static IList<int> Primes(this int number)
        {
            var primes = new List<int>();
            var divisor = 2;
            while (number > 1)
            {
                while (number % divisor == 0)
                {
                    primes.Add(divisor);
                    number /= divisor;
                }

                divisor++;
            }

            if (number > 1)
            {
                primes.Add(number);
            }

            return primes;
        }


        #region My First Attempt
        //public List<int> GetFactors(int number)
        //{   
        //    int possibleFactor = 2;
        //    int numberToCheck = number;
        //    double product = .0;

        //    do
        //    {
        //        product = (double)numberToCheck/possibleFactor;

        //        if ((product % 1) == 0 || product == 1 && product > 0)
        //        {
        //            factors.Add(possibleFactor);
        //            possibleFactor = 2;
        //            numberToCheck = (int)product;
        //        }
        //        else
        //        {
        //            possibleFactor++;
        //        }

        //    } while (!IsPrime(product) && product >= 1);

        //    if (IsPrime(product))
        //        factors.Add((int)product);

        //    return factors;
        //}

        //public bool IsPrime(double number)
        //{
        //    int i;
        //    for (i = 2; i <= number - 1; i++)
        //    {
        //        if (number % i == 0)
        //        {
        //            return false;
        //        }
        //    }
        //    if (i == number)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        #endregion
    }
}
