using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day3.Shared
{
    public class DiagnosticReport
    {
        private readonly IList<DiagnosticReportEntry> entries = new List<DiagnosticReportEntry>();
        private int? amountOfBitsPerEntry;

        public int? AmountOfBitsPerEntry => amountOfBitsPerEntry;

        public IList<DiagnosticReportEntry> Entries => new List<DiagnosticReportEntry>(entries);

        public void Parse(string input)
        {
            string[] splits = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (string split in splits)
            {
                entries.Add(new DiagnosticReportEntry(split));

                if (!amountOfBitsPerEntry.HasValue)
                {
                    amountOfBitsPerEntry = split.Length;
                }
            }
        }

        public int GetMostCommonBitAtIndex(IEnumerable<DiagnosticReportEntry> entries, int index)
        {
            List<IGrouping<int, DiagnosticReportEntry>> groupings = entries
                .GroupBy(x => x.GetBitAtIndex(index))
                .OrderByDescending(x => x.Count())
                .ToList();

            int count = groupings.First().Count();
            if (groupings.TrueForAll(x => x.Count() == count))
            {
                return 1;
            }

            return groupings.First().Key;
        }

        public int GetMostCommonBitAtIndex(int index)
        {
            return GetMostCommonBitAtIndex(entries, index);
        }

        public int GetLeastCommonBitAtIndex(IEnumerable<DiagnosticReportEntry> entries, int index)
        {
            List<IGrouping<int, DiagnosticReportEntry>> grouping = entries
                .GroupBy(x => x.GetBitAtIndex(index))
                .OrderBy(x => x.Count())
                .ToList();

            int count = grouping.First().Count();
            if (grouping.TrueForAll(x => x.Count() == count))
            {
                return 0;
            }

            return grouping.First().Key;
        }

        public int GetLeastCommonBitAtIndex(int index)
        {
            return GetLeastCommonBitAtIndex(entries, index);
        }
    }
}