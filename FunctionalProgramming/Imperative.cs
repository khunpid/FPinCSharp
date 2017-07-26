using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FunctionalProgramming
{
    public class Imperative
    {

        private static BigInteger from = 0;
        private static BigInteger to = 1000;

        private static BigInteger two = 2;
        private static BigInteger hundred = 100;

        public static void DemoImperative()
        {
            Console.WriteLine();
            Console.WriteLine("Take 20: ");
            //var itemList = new List<BigInteger>();
            //for (int i = 0; i < 20; i++)
            //{
            //    itemList.Add(i);
            //}
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Where > 920 && Take 20: ");
            for (int i = 0 + 920; i <= 20 + 920; i++)
            {
                if (i == 20 + 920)
                {
                    Console.Write("{0}]", i);
                }
                else if (i == 920)
                {
                    Console.Write("[{0},", i);
                }
                else
                {
                    Console.Write("{0},", i);
                }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("take first 20 elements of number Divisible by 2, 3, 5");
            var take = 0;
            var itemList = new List<BigInteger>();
            for (int i = 0; i < to && itemList.Count < 20; i++)
            {
                if (i % 2 == 0 
                    && i % 3 == 0 
                    && i % 5 == 0)
                {
                    itemList.Add(i);
                }
            }

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Sum of the list from 0 to 1000");
            BigInteger sum = 0;
            for (var i = from; i <= to; i++)
            {
                sum += i;
            }
            Console.WriteLine("{0}", sum);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Zip x and y to (x, y)");
            var toTake = 0;
            var tupleList = new List<(BigInteger, BigInteger)>();
            for (BigInteger i = from, j = to; i <= to; i++, j--)
            {
                if (toTake < 10)
                {
                    tupleList.Add((i, j));
                }

                toTake++;
            }
            Console.WriteLine();
            Console.WriteLine();

            //twoToHundred.Join(twoToHundred, x => true, y => true, (x, y) => Power(x, y))
            //            .Distinct()
            //            .Count()
            //            .Print("Project Euler #29");

            //twoToHundred.Select(x => twoToHundred.Select(y => Power(x, y)))
            //            .Aggregate((x, y) => x.Union(y))
            //            .Count()
            //            .Print("Project Euler #29 Alternative");
        }
    }
}
