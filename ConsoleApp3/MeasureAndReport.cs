using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace ProblemSolving
{
    public static class MeasureAndReport
    {
        public static (Stopwatch, BigInteger) MeasureRunTime(Func<BigInteger> f)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var value = f();
            stopwatch.Stop();
            return (stopwatch, value);
        }

        public static string ReportTime(this (Stopwatch stopWatch, BigInteger value) report)
        {
            var result = $"result = {report.value}";
            var resultAll = string.Format("{0}{1}{2}", result, Environment.NewLine, report.stopWatch.Elapsed.ToString());
            Console.WriteLine(resultAll);
            return resultAll;
        }
    }
}
