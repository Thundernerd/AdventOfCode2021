using AdventOfCode2021.Day2.Shared;

namespace AdventOfCode2021.Day2.PartTwo
{
    public class PartTwoSubmarine : ISubmarine
    {
        private int aim;
        private int depth;
        private int horizontalPosition;

        /// <inheritdoc />
        public int Depth => depth;

        /// <inheritdoc />
        public int HorizontalPosition => horizontalPosition;

        /// <inheritdoc />
        public void ApplyForward(int amount)
        {
            horizontalPosition += amount;
            depth += aim * amount;
        }

        /// <inheritdoc />
        public void ApplyUp(int amount)
        {
            aim -= amount;
        }

        /// <inheritdoc />
        public void ApplyDown(int amount)
        {
            aim += amount;
        }
    }
}