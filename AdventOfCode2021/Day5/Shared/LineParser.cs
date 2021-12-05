using System;
using System.Drawing;

namespace AdventOfCode2021.Day5.Shared
{
    public class LineParser
    {
        public Line Parse(string line)
        {
            string[] splits = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
            return new Line(ConvertToPoint(splits[0]), ConvertToPoint(splits[1]));
        }

        private Point ConvertToPoint(string split)
        {
            string[] splits = split.Split(',');
            return new Point(int.Parse(splits[0]), int.Parse(splits[1]));
        }
    }
}