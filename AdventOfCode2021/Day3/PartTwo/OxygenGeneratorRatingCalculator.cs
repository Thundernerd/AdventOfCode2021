using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day3.Shared;

namespace AdventOfCode2021.Day3.PartTwo
{
    public class OxygenGeneratorRatingCalculator
    {
        public int Calculate(DiagnosticReport diagnosticReport)
        {
            IList<DiagnosticReportEntry> entries = diagnosticReport.Entries;

            for (int i = 0; i < diagnosticReport.AmountOfBitsPerEntry; i++)
            {
                if (entries.Count == 1)
                    break;
                
                int mostCommonBit = diagnosticReport.GetMostCommonBitAtIndex(entries, i);
                entries = entries.Where(x => x.GetBitAtIndex(i) == mostCommonBit).ToList();
            }

            if (entries.Count == 1)
            {
                return entries.First().GetAsDecimal();
            }

            throw new Exception("Still have more than one entry left!");
        }
    }
}