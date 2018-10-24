using System;
using System.Collections.Generic;
using System.Threading;

namespace Recursion
{
    class Program
    {
        static void Main()
        {
            var recursion = new RecursionExample();
            var sum = recursion.SumLength(5, 25);
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine();

            const int stackSize = int.MaxValue;
            var thread = new Thread(() =>
            {
                var primeNumbers = recursion.FindPrimeNumbers(10000000, new List<int>());
                foreach (var primeNumber in primeNumbers)
                    Console.WriteLine($"Prim: {primeNumber}");

            }, stackSize);

            thread.Start();
            Console.ReadKey();
        }
    }
}
