﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    public static class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HigherOrderFunctions.DemoHigherOrderFunctions();
            Imperative.DemoImperative();


            Honesty.HonestyDemo();

            OpenJaw.OpenJawDemo("MEL-BKK-KUL", "SIN-LON-BKK-MEL");
            OpenJaw.OpenJawDemo("MEL-BKK-KUL", "SIN-LON-PAR-NYC-MEL");
            OpenJaw.OpenJawDemo("MEL-BKK-SYD");
            OpenJaw.OpenJawDemo("MEL-SYD-BKK-SYD");

            TestAndAdjustData();
            Immutability.AddAndStore(5);
            Immutability.AddAndStore(5);
            Immutability.AddAndStore(5);

            /// What should this print?
            Console.WriteLine("Print Current = {0}", Immutability.accumulated);

        }

        private static void TestAndAdjustData()
        {
            Console.WriteLine("Testing Data = {0}", Immutability.accumulated);
            Immutability.accumulated = 11;
        }
    }
}