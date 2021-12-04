using AdventOfCode2021.Day2.Shared;

namespace AdventOfCode2021.Day2.PartOne
{
    public class PartOneSubmarine : ISubmarine
    {
        private int depth;
        private int horizontalPosition;

        public int Depth => depth;

        public int HorizontalPosition => horizontalPosition;

        public void ApplyForward(int amount)
        {
            horizontalPosition += amount;
        }

        public void ApplyUp(int amount)
        {
            depth -= amount;
        }

        public void ApplyDown(int amount)
        {
            depth += amount;
        }
    }
}