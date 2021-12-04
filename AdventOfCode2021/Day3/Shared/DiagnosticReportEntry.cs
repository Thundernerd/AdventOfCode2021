using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day3.Shared
{
    public class DiagnosticReportEntry
    {
        private readonly List<int> bits = new();
        private readonly int decimalValue;

        public DiagnosticReportEntry(string input)
        {
            decimalValue = Convert.ToInt32(input, 2);

            foreach (char c in input)
            {
                int bit = int.Parse(c.ToString());
                bits.Add(bit);
            }
        }

        public int GetBitAtIndex(int index)
        {
            return bits[index];
        }

        public int GetAsDecimal()
        {
            return decimalValue;
        }
    }
}