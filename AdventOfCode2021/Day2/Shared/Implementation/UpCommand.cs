using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class UpCommand : ICommand
    {
        private readonly int amount;
        
        public UpCommand(int amount)
        {
            this.amount = amount;
        }

        /// <inheritdoc />
        public void Execute(ISubmarine submarine)
        {
            submarine.ApplyUp(amount);
        }
    }
}