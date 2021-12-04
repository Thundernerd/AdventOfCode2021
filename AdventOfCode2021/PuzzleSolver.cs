using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021
{
    public class PuzzleSolver
    {
        private readonly ILogger<PuzzleSolver> logger;
        private readonly IEnumerable<IPuzzle> puzzles;

        public PuzzleSolver(ILogger<PuzzleSolver> logger, IEnumerable<IPuzzle> puzzles)
        {
            this.logger = logger;
            this.puzzles = puzzles;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            IOrderedEnumerable<IPuzzle> orderedPuzzles = puzzles
                .OrderByDescending(x => x.Day)
                .ThenByDescending(x => x.Part);

            foreach (IPuzzle puzzle in orderedPuzzles)
            {
                string solution = await puzzle.Run(cancellationToken);
                logger.LogWarning("Solution to puzzle {day}:{part} is {solution}",
                    puzzle.Day, puzzle.Part, solution);
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}