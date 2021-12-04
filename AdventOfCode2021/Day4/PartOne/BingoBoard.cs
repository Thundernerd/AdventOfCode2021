using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day4.Shared;

namespace AdventOfCode2021.Day4.PartOne
{
    public class BingoBoard
    {
        private BingoSquare[,] grid;

        public BingoBoard(int width, int height)
        {
            grid = new BingoSquare[width, height];
        }

        public void SetNumber(int x, int y, int number)
        {
            grid[x, y] = new BingoSquare(number);
        }

        public void MarkNumber(int number)
        {
            foreach (BingoSquare bingoSquare in grid)
            {
                if (bingoSquare.Number == number)
                    bingoSquare.Mark();
            }
        }

        public bool HasBingo()
        {
            return HasHorizontalBingo() || HasVerticalBingo();
        }

        private bool HasHorizontalBingo()
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                BingoSquare[] slice = grid.Slice(x, 0);
                if (slice.All(square => square.IsMarked))
                    return true;
            }

            return false;
        }

        private bool HasVerticalBingo()
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                BingoSquare[] slice = grid.Slice(y, 1);
                if (slice.All(square => square.IsMarked))
                    return true;
            }

            return false;
        }

        public List<int> GetUnmarkedNumbers()
        {
            List<int> numbers = new();

            foreach (BingoSquare square in grid)
            {
                if (!square.IsMarked)
                    numbers.Add(square.Number);
            }

            return numbers;
        }
    }
}