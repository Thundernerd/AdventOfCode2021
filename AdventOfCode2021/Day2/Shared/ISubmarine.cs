namespace AdventOfCode2021.Day2.Shared
{
    public interface ISubmarine
    {
        int Depth { get; }
        int HorizontalPosition { get; }
        void ApplyForward(int amount);
        void ApplyUp(int amount);
        void ApplyDown(int amount);
    }
}