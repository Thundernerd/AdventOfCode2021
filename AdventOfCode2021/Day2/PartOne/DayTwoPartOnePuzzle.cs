using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day2.Shared;
using AdventOfCode2021.Day2.Shared.Abstraction;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021.Day2.PartOne
{
    public class DayTwoPartOnePuzzle : Puzzle
    {
        /// <inheritdoc />
        public override int Day => 2;

        /// <inheritdoc />
        public override int Part => 1;

        private readonly CommandParser commandParser;

        /// <inheritdoc />
        public DayTwoPartOnePuzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger, CommandParser commandParser)
            : base(puzzleDownloader, logger)
        {
            this.commandParser = commandParser;
        }

        /// <inheritdoc />
        protected override Task<string> Run(string input, CancellationToken cancellationToken)
        {
            ISubmarine submarine = new PartOneSubmarine();
            
            IEnumerable<ICommand> commands = commandParser.ParseInput(input);
            foreach (ICommand command in commands)
            {
                command.Execute(submarine);
            }

            return Task.FromResult((submarine.Depth * submarine.HorizontalPosition).ToString());
        }
    }
}