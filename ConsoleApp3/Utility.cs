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

        public static IEnumerable<BigInteger> OddFrom(BigInteger v)
        {
            for (BigInteger i = v % 2 != 0 ? v : v + 1; ; i += 2)
            {
                yield return i;
            }
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
