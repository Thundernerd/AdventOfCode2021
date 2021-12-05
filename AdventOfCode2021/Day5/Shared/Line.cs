using System.Drawing;

namespace AdventOfCode2021.Day5.Shared
{
    public class Line
    {
        public Point Start { get; }
        public Point End { get; }

        public bool IsHorizontal => Start.X == End.X;
        public bool IsVertical => Start.Y == End.Y;
        public bool IsDiagonal => !IsHorizontal && !IsVertical;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}