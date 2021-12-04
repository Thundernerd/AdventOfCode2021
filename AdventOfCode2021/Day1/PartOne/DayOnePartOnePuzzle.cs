using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day1.PartOne
{
    public class DayOnePartOnePuzzle : Puzzle
    {
        /// <inheritdoc />
        public override int Day => 1;

        /// <inheritdoc />
        public override int Part => 1;

        /// <inheritdoc />
        public DayOnePartOnePuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger)
            : base(puzzleDownloader, logger)
        {
        }

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            string[] splits = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            SingleIntMeasurement[] measurements = splits
                .Select(x => new SingleIntMeasurement(int.Parse(x)))
                .ToArray();

            DepthMeasurementIncrementCounter counter = new();
            int increments = counter.Calculate(measurements);
            return Task.FromResult(increments.ToString());
        }
    }
}