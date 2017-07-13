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
            if (i >= lines.Count() || j >= lines.Count() - 1 || i < 0 || j < 0) return 0;

            var lineCount = lines.Count();
            return Convert.ToInt32(lines[i].Split(' ')[j].ToString());
        }

        private static int SumMax(int i, int j)
        {
            if (i >= lines.Count() || j >= lines.Count()) return 0;

            Func<int> left = () => SumMax(i + 1, j);
            Func<int> right = () => SumMax(i + 1, j + 1);

            //Parallel.Invoke(() => SumMax(i + 1, j), () => SumMax(i + 1, j + 1));

            return Triangle(i, j) + Math.Max(left(), right());
        }

        public static int P67()
        {
            lines = File.ReadAllLines("p067_triangle.txt");

            var max = SumMax(0, 0);

            return max;
        }

        //private static int SumMaxUp(int i, int j)
        //{
        //    if (i <= 90 || j <= 98) return 0;
        //    var lineInts = lines[i].Split(' ').Select(x => Convert.ToInt32(x.ToString())).Select(x => 
        //    {
        //        Console.WriteLine($"[{Task.CurrentId}]:{i},{j}");
        //        return x + Math.Max(SumMaxUp(i - 1, j), SumMaxUp(i - 1, j - 1));
        //    });

        //    //lineInts.ToList().ForEach(x => Console.Write($"--{x},"));

        //    return lineInts.Max();
        //}

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
            var theValue = MyClass.IndexFibo2().AsParallel()
                .SkipWhile(x => x.value < MyClass.Power(10, 10))
                //.TakeWhile(x => x.index < 100)
                //.Where(x => x.value > MyClass.Power(10, 10))
                //var theValue = new[] { (index: 329468, value: MyClass.Fibonacci2(329468).current) } 
                .AsParallel()                
                .Where(x =>
                {
                    var xString = x.value.ToString();

                    var lastString = xString.Substring(xString.Length - 9);
                    var isPanDigitalLast = MyClass.IsPanDigital(lastString);

                    if (isPanDigitalLast)
                    {
                        var firstString = xString.Substring(0, 9);
                        var isPanDigitalFirst = MyClass.IsPanDigital(firstString);
                        Console.WriteLine("[{3,5}]:{0,10} - {1,9}....{2,9}, digits = {4,6} [{5}]", x.index, firstString, lastString, Task.CurrentId, xString.Length, isPanDigitalLast);
                        return isPanDigitalFirst;
                    }

                    Console.WriteLine("[{3,5}]:{0,10} - {1,9}....{2,9}, digits = {4,6} [{5}]", x.index, "---------", "---------", Task.CurrentId, xString.Length, false);
                    return xString.Length > MyClass.Power(10, 100);
                }).Take(1);

            Console.WriteLine("P104 = {0}", theValue.Count());

            //return theValue.index;
            return theValue.Count();
        }

        public static BigInteger P19()
        {
            var firstDate = new DateTime(1900, 1, 1);
            var startDate = new DateTime(1901, 1, 1);
            var endDate = new DateTime(2000, 12, 31);
            
            var sundayFirstCount = DateSeqFromTo(startDate, endDate).Where(x => x.day == 1 && x.dow == DayOfWeek.Sunday).Count();
            Console.WriteLine($"P19: {sundayFirstCount}");

            return sundayFirstCount;
        }

        private static IEnumerable<(int year, int month, int day, DayOfWeek dow)> DateSeqFrom(DateTime start)
        {
            var date = start;
            do
            {
                yield return (date.Year, date.Month, date.Day, date.DayOfWeek);
                date.AddDays(1);
            } while (true) ;
        }

        private static IEnumerable<(int year, int month, int day, DayOfWeek dow)> DateSeqFromTo(DateTime start, DateTime end)
        {
            var date = start;
            do
            {
                yield return (date.Year, date.Month, date.Day, date.DayOfWeek);
            } while ((date = date.AddDays(1)) < end);
        }

        //public BigInteger P41()
        //{
        //    MyClass.Primes2().TakeWhile(x => x < MyClass.Power(10, 10)).
        //}
    }
}
