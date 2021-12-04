using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class DownCommand : ICommand
    {
        private readonly int amount;
        
        public DownCommand(int amount)
        {
            this.amount = amount;
        }

        /// <inheritdoc />
        public void Execute(ISubmarine submarine)
        {
            submarine.ApplyDown(amount);
        }
    }
}