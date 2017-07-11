using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace ProblemSolving
{
    static class Program
    {
        static void Main(string[] args)
        {
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P1()).ReportTime();        // 166833
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P2()).ReportTime();        // 4613732
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P7()).ReportTime();        // 104743
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P10()).ReportTime();       // 142913828922
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P18()).ReportTime();         // 1074
            MeasureAndReport.MeasureRunTime(() => ProjectEuler.P19()).ReportTime();         // 
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P25()).ReportTime();       // 4782
            //MeasureAndReport.MeasureRunTime(() => ProjectEuler.P67()).ReportTime();         // 
            MeasureAndReport.MeasureRunTime(() => ProjectEuler.P104_2()).ReportTime();    // 329468 - 245681739....352786941
            //Console.ReadLine();
        }

    }
}