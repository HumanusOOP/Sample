using System;
using System.Collections.Generic;

namespace Recursion
{
    public class RecursionExample
    {
        /// <summary>
        /// Sums numbers in a length
        /// </summary>
        /// <param name="a">Initial number</param>
        /// <param name="length">Amount of incremental numbers to add</param>
        /// <returns>Sum</returns>
        public int SumLength(int a, int length)
        {
            if (length <= 0) return a;
            length -= 1;
            return SumLength(a + 1, length);
        }

        public List<int> FindPrimeNumbers(int length, List<int> primeNumbers)
        {
            if(length == 2)
            {
                primeNumbers.Add(2);
                return primeNumbers;
            }

            if(IsPrime(length))
                primeNumbers.Add(length);

            length -= 1;
            return FindPrimeNumbers(length, primeNumbers);
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (var i = 3; i <= boundary; i += 2)
                if (number % i == 0) return false;
            return true;
        }
    }
}