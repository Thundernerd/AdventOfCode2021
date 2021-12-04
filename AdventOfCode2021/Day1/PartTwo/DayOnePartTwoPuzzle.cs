using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day1.PartTwo
{
    public class DayOnePartTwoPuzzle : Puzzle
    {
        /// <inheritdoc />
        public override int Day => 1;

        /// <inheritdoc />
        public override int Part => 2;


        /// <inheritdoc />
        public DayOnePartTwoPuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger) : base(puzzleDownloader,
            logger)
        {
        }

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            List<int> splits = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<IMeasurement> measurements = new();
            for (int i = 0; i < splits.Count - 2; i++)
            {
                int first = splits[i];
                int second = splits[i + 1];
                int third = splits[i + 2];
                measurements.Add(new ThreeIntMeasurement(first, second, third));
            }
            
            DepthMeasurementIncrementCounter counter = new();
            int increments = counter.Calculate(measurements);
            return Task.FromResult(increments.ToString());
        }
    }
}