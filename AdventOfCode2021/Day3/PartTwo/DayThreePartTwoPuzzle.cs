using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day3.Shared;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day3.PartTwo
{
    public class DayThreePartTwoPuzzle : Puzzle
    {
        /// <inheritdoc />
        public DayThreePartTwoPuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger)
            : base(puzzleDownloader, logger)
        {
        }

        /// <inheritdoc />
        public override int Day => 3;

        /// <inheritdoc />
        public override int Part => 2;

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            DiagnosticReport diagnosticReport = new();
            diagnosticReport.Parse(input);

            LifeSupportRatingCalculator lifeSupportRatingCalculator = new();
            return Task.FromResult(lifeSupportRatingCalculator.Calculate(diagnosticReport).ToString());
        }
    }
}