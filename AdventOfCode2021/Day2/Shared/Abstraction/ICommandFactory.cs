namespace AdventOfCode2021.Day2.Shared.Abstraction
{
    public interface ICommandFactory
    {
        bool CanProcess(string input);
        ICommand Create(string input);
    }
}