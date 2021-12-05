using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day5.Shared;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day5.PartTwo
{
    public class DayFivePartTwoPuzzle : Puzzle
    {
        /// <inheritdoc />
        public DayFivePartTwoPuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger) : base(puzzleDownloader, logger)
        {
        }

        /// <inheritdoc />
        public override int Day => 5;

        /// <inheritdoc />
        public override int Part => 2;

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            D5P2InputParser inputParser = new();
            IEnumerable<Line> lines = inputParser.Parse(input);

            OceanFloorSizeCalculator oceanFloorSizeCalculator = new();
            Point size = oceanFloorSizeCalculator.CalculateSize(lines);

            OceanFloor oceanFloor = new(size.X, size.Y);
            foreach (Line line in lines)
            {
                oceanFloor.PlotHydrothermalVentLine(line);
            }

            return Task.FromResult(oceanFloor.AmountOfPointsWithNumberOfOverlaps(2).ToString());
        }
    }
}