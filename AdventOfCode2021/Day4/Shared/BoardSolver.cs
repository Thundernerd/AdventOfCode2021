using System.Collections.Generic;

namespace AdventOfCode2021.Day4.Shared
{
    public class BoardSolver
    {
        private readonly NumberParser numberParser;
        private readonly BoardParser boardParser;

        public BoardSolver(NumberParser numberParser, BoardParser boardParser)
        {
            this.numberParser = numberParser;
            this.boardParser = boardParser;
        }

        public BingoBoard GetWinningBoard(string input, out int lastNumber)
        {
            List<int> numbers = numberParser.Parse(input);
            List<BingoBoard> boards = boardParser.Parse(input);

            foreach (int number in numbers)
            {
                lastNumber = number;

                foreach (BingoBoard board in boards)
                {
                    board.MarkNumber(number);
                    if (board.HasBingo())
                    {
                        return board;
                    }
                }
            }

            lastNumber = -1;
            return null;
        }
    }
}