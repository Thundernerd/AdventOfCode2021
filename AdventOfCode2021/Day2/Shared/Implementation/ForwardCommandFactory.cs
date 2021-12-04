using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class ForwardCommandFactory : ICommandFactory
    {
        /// <inheritdoc />
        public bool CanProcess(string input) => input.StartsWith("forward");

        /// <inheritdoc />
        public ICommand Create(string input)
        {
            input = input.Replace("forward", string.Empty).Trim();
            return new ForwardCommand(int.Parse(input));
        }
    }
}