using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

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
            var fibs = MyClass.Fibs().TakeWhile(x => x < fibNotOver).Where(x => x % 2 == 0);
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
            var limit = MyClass.Power(10, 8);
            var theValue = MyClass.Fibs().Where(x => x > limit).First();
            Console.WriteLine("P25 the first Fibs over 1000 digit is {0}", theValue);
            return theValue;
        }
    }
}
