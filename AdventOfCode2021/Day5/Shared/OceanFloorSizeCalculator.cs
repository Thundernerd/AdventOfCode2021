using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode2021.Day5.Shared
{
    public class OceanFloorSizeCalculator
    {
        public Point CalculateSize(IEnumerable<Line> lines)
        {
            int width = -1;
            int height = -1;

            foreach (Line line in lines)
            {
                if (line.Start.X > width)
                    width = line.Start.X;
                if (line.Start.Y > height)
                    height = line.Start.Y;
                if (line.End.X > width)
                    width = line.End.X;
                if (line.End.Y > height)
                    height = line.End.Y;
            }

            return new Point(width + 1, height + 1);
        }
    }
}