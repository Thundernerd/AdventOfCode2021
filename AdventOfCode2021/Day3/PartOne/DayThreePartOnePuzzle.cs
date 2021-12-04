using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day3.Shared;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day3.PartOne
{
    public class DayThreePartOnePuzzle : Puzzle
    {
        /// <inheritdoc />
        public DayThreePartOnePuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger) 
            : base(puzzleDownloader, logger)
        {
        }

        /// <inheritdoc />
        public override int Day => 3;

        /// <inheritdoc />
        public override int Part => 1;

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            DiagnosticReport diagnosticReport = new();
            diagnosticReport.Parse(input);

            PowerConsumptionCalculator powerConsumptionCalculator = new();
            return Task.FromResult(powerConsumptionCalculator.Calculate(diagnosticReport).ToString());
        }
    }
}