using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class UpCommandFactory : ICommandFactory
    {
        /// <inheritdoc />
        public bool CanProcess(string input) => input.StartsWith("up");

        /// <inheritdoc />
        public ICommand Create(string input)
        {
            input = input.Replace("up", string.Empty).Trim();
            return new UpCommand(int.Parse(input));
        }
    }
}