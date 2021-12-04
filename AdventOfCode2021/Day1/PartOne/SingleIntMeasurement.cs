using System;

namespace AdventOfCode2021.Day1.PartOne
{
    public class SingleIntMeasurement : IMeasurement
    {
        private readonly int value;

        public SingleIntMeasurement(int value)
        {
            this.value = value;
        }

        /// <inheritdoc />
        public bool IsGreaterThan(IMeasurement other)
        {
            if (other is not SingleIntMeasurement measurement)
                throw new Exception("Unable to compare because of a type mismatch");

            return value > measurement.value;
        }
    }
}