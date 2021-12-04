using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day4.Shared;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day4.PartTwo
{
    public class DayFourPartTwoPuzzle : Puzzle
    {
        /// <inheritdoc />
        public DayFourPartTwoPuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger, BoardSolver boardSolver) : base(puzzleDownloader, logger)
        {
            this.boardSolver = boardSolver;
        }

        /// <inheritdoc />
        public override int Day => 4;

        /// <inheritdoc />
        public override int Part => 2;

        private readonly BoardSolver boardSolver;

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            BingoBoard losingBoard = boardSolver.GetLosingBoard(input, out int lastNumber);
            return Task.FromResult((losingBoard.GetUnmarkedNumbers().Sum() * lastNumber).ToString());
        }
    }
}