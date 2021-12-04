using System;

namespace AdventOfCode2021.Day1.PartTwo
{
    public class ThreeIntMeasurement : IMeasurement
    {
        private readonly int value;

        public ThreeIntMeasurement(int first, int second, int third)
        {
            value = first + second + third;
        }

        /// <inheritdoc />
        public bool IsGreaterThan(IMeasurement other)
        {
            if (other is not ThreeIntMeasurement measurement)
                throw new Exception("Unable to compare because of a type mismatch");

            return value > measurement.value;
        }
    }
}