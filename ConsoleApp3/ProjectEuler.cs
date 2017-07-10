using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class ProjectEuler
    {
        public static BigInteger P1()
        {
            var notOver = 1000;
            var result = MyClass.MultipliesOf(3).Union(MyClass.MultipliesOf(5)).TakeWhile(n => n < notOver).Aggregate((x, y) => x + y);
            Console.WriteLine("P1 sum = {0}", result);

            return result;
        }
        public static BigInteger P2()
        {
            var fibNotOver = 4000000;
            var fibs = MyClass.Fibo().TakeWhile(x => x < fibNotOver).Where(x => x % 2 == 0);
            var sumEvenFibs = fibs.Aggregate((x, y) => x + y);
            Console.WriteLine("P2 sum even Fibs (not over {1}) [{0}]", sumEvenFibs, fibNotOver);
            return sumEvenFibs;
        }

        public static BigInteger P7()
        {
            var theValue = MyClass.Primes().ElementAt(10000);
            Console.WriteLine("P7 10001st primes is {0}", theValue);
            return theValue;
        }

        public static BigInteger P10()
        {
            var notOver = 2000000;
            var theValue = MyClass.Primes().TakeWhile(x => x < notOver).Aggregate((x, y) => x + y);
            Console.WriteLine("P10 sum of primes under {1} is {0}", theValue, notOver);
            return theValue;
        }

        public static BigInteger P25()
        {
            var limit = MyClass.Power(10, 999);
            var theValue = MyClass.IndexFibo().Where(x => x.value > limit).First().index;
            Console.WriteLine("P25 the first Fibs over 1000 digit is {0}", theValue);
            return theValue;
        }

        private static string[] lines;
        public static int P18()
        {
            lines = File.ReadAllLines("p018_triangle.txt");

            var max = SumMax(0, 0);

            return max;
        }

        private static int Triangle(int i, int j)
        {
            if (i >= lines.Count() || j >= lines.Count() || i < 0 || j < 0) return 0;

            var lineCount = lines.Count();
            return Convert.ToInt32(lines[i].Split(' ')[j].ToString());
        }

        private static int SumMax(int i, int j)
        {
            if (i >= lines.Count() || j >= lines.Count()) return 0;
            return Triangle(i, j) + Math.Max(SumMax(i + 1, j), SumMax(i + 1, j + 1));
        }

        public static int P67()
        {
            lines = File.ReadAllLines("p067_triangle.txt");

            var x = SumMaxUp(lines.Length - 1, lines.Length - 1);

            return 0;
        }

        private static int SumMaxUp(int i, int j)
        {
            if (i <= 0 || j <= 0) return 0;
            var lineInts = lines[i].Split(' ').Select(x => Convert.ToInt32(x.ToString())).Select(x => x + Math.Max(Triangle(i - 1, j), Triangle(i - 1, j - 1)));

            lineInts.ToList().ForEach(x => Console.WriteLine("--{x},"));

            return lineInts.Max();
        }

        public static BigInteger P104()
        {
            var tenToNine = MyClass.Power(10, 9);
            var theValue = MyClass.IndexFibo()
                .AsParallel()
                .Where(x => x.value > MyClass.Power(10, 10))
                .Where(x =>
                {
                    var xString = x.value.ToString();
                    var last = xString.Substring(xString.Length - 9).ToCharArray();
                    var isPanDigitalLast = !last.Contains('0') && last.Distinct().Count() == 9;

                    if (isPanDigitalLast)
                    {
                        Console.WriteLine("[{1,5}]: last 9 = {0}", x, Task.CurrentId);

                        var first = xString.Substring(0, 9).ToCharArray();
                        var isPanDigitalFirst = !first.Contains('0') && first.Distinct().Count() == 9;
                        return isPanDigitalFirst;
                    }

                    return false;
                }).First();

            Console.WriteLine("P104 = {0}", theValue);

            return theValue.index;
        }

        public static BigInteger P104_2()
        {
            //var theValue = MyClass.IndexFibo2()
            //   .TakeWhile(x => x.value < MyClass.Power(10, 2));


            var tenToNine = MyClass.Power(10, 9);
            var theValue = MyClass.IndexFibo2()
                .AsParallel()
                .Where(x => x.value > MyClass.Power(10, 10))
                .Where(x =>
                {
                    var xString = x.value.ToString();

                    var lastString = xString.Substring(xString.Length - 9);
                    var last = lastString.ToCharArray();
                    var isPanDigitalLast = !last.Contains('0') && last.Distinct().Count() == 9;

                    if (isPanDigitalLast)
                    {
                        var firstString = xString.Substring(0, 9);
                        var first = firstString.ToCharArray();
                        var isPanDigitalFirst = !first.Contains('0') && first.Distinct().Count() == 9;
                        Console.WriteLine("[{3,5}]:{0,10} - {1}....{2}", x.index, firstString, lastString, Task.CurrentId);
                        return isPanDigitalFirst;
                    }

                    return false;
                }).First();

            Console.WriteLine("P104 = {0}", theValue);

            return theValue.index;
        }
    }
}
