using System;
using System.Linq;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            var notOver = 10000;
            var primes = MyClass.Primes().TakeWhile(x => x < notOver);
            Console.WriteLine("[{0}]", string.Join(", ", primes.Select(x => x.ToString())));
            var sumPrimes = primes.Aggregate((x, y) => x + y);

            Console.WriteLine("P10 (sum prime below {1})Result = {0}", sumPrimes, notOver);

            foreach (var prime in MyClass.Primes())
            {
                Console.Write("{0}, ", prime);
            }
        }
    }
}