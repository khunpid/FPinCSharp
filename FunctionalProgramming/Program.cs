using System;
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

            OpenJaw.OpenJawDemo("MEL-BKK-KUL", "SIN-LON-BKK-MEL");
            OpenJaw.OpenJawDemo("MEL-BKK-KUL", "SIN-LON-PAR-NYC-MEL");


        }

    }
}