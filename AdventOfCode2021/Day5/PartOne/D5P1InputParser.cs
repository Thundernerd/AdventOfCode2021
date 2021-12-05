using System;
using System.Collections.Generic;
using AdventOfCode2021.Day5.Shared;

namespace AdventOfCode2021.Day5.PartOne
{
    public class D5P1InputParser
    {
        public IEnumerable<Line> Parse(string input)
        {
            List<Line> lines = new();
            LineParser lineParser = new();
            string[] splits = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string split in splits)
            {
                Line line = lineParser.Parse(split);
                if (line.IsDiagonal)
                    continue;
                lines.Add(line);
            }

            return lines;
        }
    }
}