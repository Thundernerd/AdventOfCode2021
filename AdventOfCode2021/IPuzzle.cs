using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public interface IPuzzle
    {
        int Day { get; }
        int Part { get; }
        Task<string> Run(CancellationToken cancellationToken);
    }
}