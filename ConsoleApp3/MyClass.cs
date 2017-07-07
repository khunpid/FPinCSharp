﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProblemSolving
{
    public static class MyClass
    {

        public static IEnumerable<BigInteger> Primes()
        {
            Func<IEnumerable<BigInteger>> seedThunk = () => new BigInteger[] { 2, 3 };
            Func<IEnumerable<BigInteger>> sieveThunk = () => Sieve(Primes().Skip(1), Utility.OddFrom(5));

            return seedThunk.LazyConcat(sieveThunk);
        }
        /*
              sieve (p:ps) xs = h ++ sieve ps [x | x <- t, rem x p /= 0]  
                      where (h,t) = span (< p*p) xs
         */
        private static IEnumerable<BigInteger> Sieve(IEnumerable<BigInteger> enumerable, IEnumerable<BigInteger> theRest)
        {
            var first = enumerable.First();
            var (h, t) = Utility.Span(x => x < (first * first), theRest);
            return h.LazyConcat(() => Sieve(enumerable.Skip(1), t().Where(x => x % first != 0)));
        }

        /*
         fibs = 0 : 1 : zipWith (+) (fibs) (tail (fibs))
         */
        public static IEnumerable<BigInteger> Fibs()
        {
            IEnumerable<BigInteger> fib = null;
            Func<IEnumerable<BigInteger>> seedThunk = () => new BigInteger[] { 0, 1 };
            Func<IEnumerable<BigInteger>> zipThunk = () => fib.Zip(fib.Skip(1), (x, y) => x + y);

            fib = seedThunk.LazyConcat(zipThunk);
            foreach (var item in fib)
            {
                System.Console.Write($"{item}, ");
                yield return item;
            }

        }

        public static IEnumerable<(BigInteger index, BigInteger value)> IndexFibo()
        {
            for (BigInteger i = 0; ; i++)
            {
                yield return (i, Fibonacci(i));
            }
        }

        public static IEnumerable<BigInteger> Fibo()
        {
            for (BigInteger i = 0; ; i++)
            {
                yield return Fibonacci(i);
            }
        }



        private static Dictionary<BigInteger, BigInteger> FibDict = new Dictionary<BigInteger, BigInteger>();
       
        public static BigInteger Fibonacci(BigInteger current)
        {
            if (current >= 0 && current < 2)
            {
                if (!FibDict.ContainsKey(current)) FibDict.Add(current, current);
            }
            else
            {
                if (!FibDict.ContainsKey(current)) FibDict.Add(current, FibDict[current - 1] + FibDict[current - 2]);
            }

            return FibDict[current];
        }

        public static IEnumerable<BigInteger> MultipliesOf(BigInteger number)
        {
            return Utility.SeqFrom(number, number);
        }

        public static BigInteger Power(BigInteger n, BigInteger expo)
        {
            if (expo == 1) return n;

            return n * Power(n, expo - 1);

        }
    }

}
