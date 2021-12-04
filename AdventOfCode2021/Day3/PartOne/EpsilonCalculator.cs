using System;
using AdventOfCode2021.Day3.Shared;

namespace AdventOfCode2021.Day3.PartOne
{
    public class EpsilonCalculator
    {
        public int Calculate(DiagnosticReport report)
        {
            string binaryString = "";
            
            for (int i = 0; i < report.AmountOfBitsPerEntry; i++)
            {
                binaryString += report.GetLeastCommonBitAtIndex(i).ToString();
            }

            return Convert.ToInt32(binaryString, 2);
        }
    }
}