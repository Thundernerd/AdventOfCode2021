using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AdventOfCode2021
{
    public abstract class Puzzle : IPuzzle
    {
        private readonly PuzzleDownloader puzzleDownloader;
        protected readonly ILogger<Puzzle> Logger;

        /// <inheritdoc />
        public abstract int Day { get; }

        /// <inheritdoc />
        public abstract int Part { get; }

        protected Puzzle(PuzzleDownloader puzzleDownloader, ILogger<Puzzle> logger)
        {
            this.puzzleDownloader = puzzleDownloader;
            Logger = logger;
        }

        public async Task<string> Run(CancellationToken cancellationToken)
        {
            string input = await puzzleDownloader.DownloadInput(Day, cancellationToken);
            return await Run(input, cancellationToken);
        }

        protected abstract Task<string> Run(string input, CancellationToken cancellationToken);
    }
}