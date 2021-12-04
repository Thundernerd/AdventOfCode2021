using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4.PartOne
{
    public class NumberParser
    {
        public List<int> Parse(string input)
        {
            string[] splits = input.Split('\n');
            return splits.First().Split(',').Select(int.Parse).ToList();
        }
    }
}