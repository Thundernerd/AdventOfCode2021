using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day4.Shared;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day4.PartOne
{
    public class DayOnePartOnePuzzle : Puzzle
    {
        /// <inheritdoc />
        public DayOnePartOnePuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger, BoardSolver boardSolver) :
            base(puzzleDownloader,
                logger)
        {
            this.boardSolver = boardSolver;
        }

        /// <inheritdoc />
        public override int Day => 4;

        /// <inheritdoc />
        public override int Part => 1;

        private readonly BoardSolver boardSolver;

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            BingoBoard winningBoard = boardSolver.GetWinningBoard(input, out int lastNumber);

            // NumberParser numberParser = new();
            // List<int> numbers = numberParser.Parse(input);
            //
            // BoardParser boardParser = new();
            // List<BingoBoard> boards = boardParser.Parse(input);
            //
            // BingoBoard winningBoard = null;
            // int lastNumber = -1;
            //
            // foreach (int number in numbers)
            // {
            //     lastNumber = number;
            //
            //     foreach (BingoBoard board in boards)
            //     {
            //         board.MarkNumber(number);
            //         if (board.HasBingo())
            //         {
            //             winningBoard = board;
            //             break;
            //         }
            //     }
            //
            //     if (winningBoard != null)
            //         break;
            // }

            List<int> unmarkedNumbers = winningBoard.GetUnmarkedNumbers();
            return Task.FromResult((lastNumber * unmarkedNumbers.Sum()).ToString());
        }
    }
}