using System;
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
        public static IEnumerable<BigInteger> Primes2()
        {
            Func<IEnumerable<BigInteger>> seedThunk = () => new BigInteger[] { 2, 3 };
            Func<IEnumerable<BigInteger>> sieveThunk = () => Sieve2(() => Primes2().Skip(1), () => Utility.OddFrom(5));

            return seedThunk.LazyConcat(sieveThunk);
        }
        private static IEnumerable<BigInteger> Sieve2(Func<IEnumerable<BigInteger>> enumerable, Func<IEnumerable<BigInteger>> theRest)
        {
            var first = enumerable().First();
            var (h, t) = Utility.Span(x => x < (first * first), theRest());
            //Console.WriteLine("--{0}--, ", string.Join(",", h().Select(x => x.ToString())));
            return h.LazyConcat(() => Sieve2(() => enumerable().Skip(1), () => t().Where(x => x % first != 0)));
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

        public static IEnumerable<(BigInteger index, BigInteger value)> IndexFibo2()
        {
            yield return (0, 0);
            for (BigInteger i = 1; ; i++)
            {
                yield return (i, Fibonacci2(i).current);
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

        public static IEnumerable<BigInteger> Fibo2()
        {
            yield return 0;
            for (BigInteger i = 1; ; i++)
            {
                yield return Fibonacci2(i).current;
            }
        }
        /*
         * 
            fib :: Integer -> (Integer, Integer) 
            fib 0 = (0, 1)
            fib n =
	            let (a, b) = fib (div n 2)
	                c = a * (b * 2 - a)
	                d = a * a + b * b
	            in if mod n 2 == 0
		            then (c, d)
		            else (d, c + d)
         */
        public static (BigInteger current, BigInteger prev) Fibonacci2(BigInteger n)
        {
            if (n == 0)
            {
                if (!FibDict.ContainsKey(0)) FibDict[0] = 0;
                if (!FibDict.ContainsKey(1)) FibDict[1] = 1;
                return (0, 1);
            }

            if (n == 1)
            {
                if (!FibDict.ContainsKey(2)) FibDict[2] = 1;
                return (1, 1);
            }

            if (FibDict.ContainsKey(n) && FibDict.ContainsKey(n + 1)) return (FibDict[n], FibDict[n + 1]);

            var (a, b) = Fibonacci2(n / 2);
            var c = a * (b * 2 - a);
            var d = a * a + b * b;

            if (n % 2 == 0)
            {
                if (!FibDict.ContainsKey(n)) FibDict.Add(n, c);
                if (!FibDict.ContainsKey(n + 1)) FibDict.Add(n + 1, d);

                return (c, d);
            }
            else
            {
                if (!FibDict.ContainsKey(n)) FibDict.Add(n, d);
                if (!FibDict.ContainsKey(n + 1)) FibDict.Add(n + 1, c + d);
                return (d, c + d);
            }
        }

        public static bool IsPanDigital(this BigInteger n)
        {
            return IsPanDigital(n.ToString());
        }

        public static bool IsPanDigital(this string n)
        {
            var nCharArray = n.ToCharArray();
            return nCharArray.Length == 9 && !nCharArray.Contains('0') && nCharArray.Distinct().Count() == 9;
        }

        public static bool IsPanDigital(this string n, int digit)
        {
            var nCharArray = n.ToCharArray();
            return nCharArray.Length == digit && !nCharArray.Contains('0') 
                && nCharArray.Select(x => Convert.ToInt32(x.ToString()))
                    .Intersect(Utility.SeqFrom(1).Take(digit).Select(x => (int)x)).Count() == digit;
        }
    }

}
