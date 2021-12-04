namespace AdventOfCode2021.Day2.Shared.Abstraction
{
    public interface ICommand
    {
        void Execute(ISubmarine submarine);
    }
}