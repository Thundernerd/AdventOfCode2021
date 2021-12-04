namespace AdventOfCode2021.Day4.PartOne
{
    public class BingoSquare
    {
        public int Number { get; }
        public bool IsMarked { get; private set; }
        
        public BingoSquare(int number)
        {
            Number = number;
        }

        public void Mark()
        {
            IsMarked = true;
        }
    }
}