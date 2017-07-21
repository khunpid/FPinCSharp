using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProblemSolving
{
    public static class Utility
    {
        public static (Func<IEnumerable<BigInteger>>, Func<IEnumerable<BigInteger>>) Span(Func<BigInteger, bool> pred, IEnumerable<BigInteger> aList)
        {
            return (() => aList.TakeWhile(pred), () => aList.SkipWhile(pred));
        }
        public static IEnumerable<BigInteger> SeqFromTo(BigInteger from, BigInteger to, BigInteger step)
        {
            return SeqFrom(from, step).TakeWhile(x =>
            {
                return step > 0 ? x <= to : x >= to;
            });
        }
            public static IEnumerable<BigInteger> SeqFromTo(BigInteger from, BigInteger to)
        {
            return SeqFromTo(from, to, BigInteger.One);
        }

        public static IEnumerable<BigInteger> SeqFrom(BigInteger v)
        {
            return SeqFrom(v, BigInteger.One);
        }

        public static IEnumerable<BigInteger> SeqFrom(BigInteger v, BigInteger step)
        {
            for (BigInteger i = v; ; i += step)
            {
                yield return i;
            }
        }

        public static IEnumerable<BigInteger> OddFrom(BigInteger v)
        {
            return SeqFrom(v % 2 != BigInteger.Zero ? v : v + 1, 2);
        }
        public static IEnumerable<BigInteger> EvenFrom(BigInteger v)
        {
            return SeqFrom(v % 2 == BigInteger.Zero ? v : v + 1, 2);
        }

        public static void Print<T>(this IEnumerable<T> list, string description)
        {
            Console.WriteLine($"{description}");
            Console.WriteLine($"[{list.JoinToStringWith(",")}]");
            Console.WriteLine();
        }
        public static void Print<T>(this T number, string description)
        {
            Console.WriteLine($"{description}");
            Console.WriteLine($"{number}");
            Console.WriteLine();
        }

        public static string JoinToStringWith<T>(this IEnumerable<T> list, string separator)
        {
            return list.Select(e => e.ToString()).JoinToStringWith(",");
        }

        public static string JoinToStringWith(this IEnumerable<string> list, string separator)
        {
            return string.Join(separator, list);
        }

        /// <summary>
        /// This is from 
        /// https://fuqua.io/blog/2014/03/haskells-elegant-fibonacci-in-csharp/
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<T> LazyConcat<T>(
            this Func<IEnumerable<T>> first,
            Func<IEnumerable<T>> second)
        {
            foreach (var item in first())
                yield return item;
            foreach (var item in second())
                yield return item;
        }
    }
}
