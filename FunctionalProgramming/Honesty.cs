using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FunctionalProgramming
{
    public static class Honesty
    {
        public static TimeSpan CalculateAge1(DateTime dateToCheck)
        {
            var now = DateTime.Now;
            return now - dateToCheck;
        }

        public static TimeSpan CalculateAge2(DateTime dateToCheck, DateTime toDate)
        {
            return toDate - dateToCheck;
        }

        public static double Reciprocal(this BigInteger number)
        {
            return 1.0 / (double)number;
        }

        public static Nullable<double> Reciprocal2(this BigInteger number)
        {
            if (number == 0) return null;
            return 1.0 / (double)number;
        }

        public static double Reciprocal3(this BigInteger number)
        {
            if (number == 0) throw new ArgumentException("Number must not be 0");
            return 1.0 / (double)number;
        }
        public static void HonestyDemo()
        {
            Console.WriteLine("Age1 {0}", Honesty.CalculateAge1(new DateTime(2017, 1, 1)));
            Console.WriteLine("Age1 {0}", Honesty.CalculateAge1(new DateTime(2017, 1, 1)));
            Console.WriteLine("Age2 {0}", Honesty.CalculateAge2(new DateTime(2017, 1, 1), new DateTime(2017, 7, 21)));
            Console.WriteLine("Age2 {0}", Honesty.CalculateAge2(new DateTime(2017, 1, 1), new DateTime(2017, 7, 21)));
            Console.WriteLine("Age2 {0}", Honesty.CalculateAge2(new DateTime(2017, 1, 1), new DateTime(2017, 7, 21)));
            Console.WriteLine("Age1 {0}", Honesty.CalculateAge1(new DateTime(2017, 1, 1)));

            Utility.SeqFromTo(10, 0, -1).Select(elem => elem.Reciprocal()).Print("The Reciprocal: ");
            Utility.SeqFromTo(10, 0, -1).Select(elem => elem.Reciprocal2()).Print("The Reciprocal: ");
            Utility.SeqFromTo(10, 0, -1).Select(elem =>
            { try { return elem.Reciprocal3(); } catch { return default(double); } }).Print("The Reciprocal: ");
            Utility.SeqFromTo(10, 0, -1).Print("Teest");
            BigInteger x = 100;
            Console.WriteLine(x.Reciprocal2());

            /*
            for (BigInteger i = 10; i >= 0; i--)
            {

                var result = i.Reciprocal();
                var str = string.Format($"{result:0.000000}");
                Console.WriteLine($"1/{i} = {result:0.000000}");
            }

            for (BigInteger i = 10; i >= 0; i--)
            {
                var result = i.Reciprocal2();
                if (result != null)
                {
                    Console.WriteLine($"1/{i} = {result:0.000000}");
                }
            }


            for (BigInteger i = 10; i >= 0; i--)
            {
                try
                {
                    var result = i.Reciprocal3();
                    Console.WriteLine($"1/{i} = {result:0.000000}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                }
            }
            */
        }
    }
}
