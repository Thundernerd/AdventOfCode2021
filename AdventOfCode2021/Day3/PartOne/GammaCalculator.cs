using System;
using AdventOfCode2021.Day3.Shared;

namespace AdventOfCode2021.Day3.PartOne
{
    public class GammaCalculator
    {
        public int Calculate(DiagnosticReport report)
        {
            string binaryString = "";
            
            for (int i = 0; i < report.AmountOfBitsPerEntry; i++)
            {
                binaryString += report.GetMostCommonBitAtIndex(i).ToString();
            }

            return Convert.ToInt32(binaryString, 2);
        }
    }
}