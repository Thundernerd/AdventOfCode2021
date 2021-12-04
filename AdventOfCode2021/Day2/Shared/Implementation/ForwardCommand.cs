using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared.Implementation
{
    public class ForwardCommand : ICommand
    {
        private readonly int amount;
        
        public ForwardCommand(int amount)
        {
            this.amount = amount;
        }

        /// <inheritdoc />
        public void Execute(ISubmarine submarine)
        {
            submarine.ApplyForward(amount);
        }
    }
}