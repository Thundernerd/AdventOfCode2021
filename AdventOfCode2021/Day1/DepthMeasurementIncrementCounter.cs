using System.Collections.Generic;
using JetBrains.Annotations;

namespace AdventOfCode2021.Day1
{
    [PublicAPI]
    public class DepthMeasurementIncrementCounter
    {
        public int Calculate(IList<IMeasurement> measurements)
        {
            int increments = 0;

            for (int i = 1; i < measurements.Count; i++)
            {
                IMeasurement current = measurements[i];
                IMeasurement previous = measurements[i - 1];

                if (current.IsGreaterThan(previous))
                    increments++;
            }

            return increments;
        }
    }
}