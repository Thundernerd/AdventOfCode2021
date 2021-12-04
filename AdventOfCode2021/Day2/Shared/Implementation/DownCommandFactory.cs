using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class DownCommandFactory : ICommandFactory

    {
        /// <inheritdoc />
        public bool CanProcess(string input) => input.StartsWith("down");

        /// <inheritdoc />
        public ICommand Create(string input)
        {
            input = input.Replace("down", string.Empty).Trim();
            return new DownCommand(int.Parse(input));
        }
    }
}