using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day4.PartOne
{
    public class BoardParser
    {
        public List<BingoBoard> Parse(string input)
        {
            List<BingoBoard> boards = new();
            string[] splits = input.Split('\n');

            List<string> lines = new();
            for (int i = 2; i < splits.Length; i++)
            {
                string line = splits[i];
                if (string.IsNullOrEmpty(line))
                {
                    boards.Add(ParseLines(lines));
                    lines.Clear();
                }
                else
                {
                    lines.Add(line);
                }
            }

            if (lines.Count > 0)
            {
                boards.Add(ParseLines(lines));
                lines.Clear();
            }

            return boards;
        }

        private BingoBoard ParseLines(List<string> lines)
        {
            BingoBoard board = new(5, 5);

            for (int y = 0; y < lines.Count; y++)
            {
                string line = lines[y];
                MatchCollection matches = Regex.Matches(line, @"\d+");
                for (int x = 0; x < matches.Count; x++)
                {
                    Match match = matches[x];
                    board.SetNumber(x, y, int.Parse(match.Value));
                }
            }

            return board;
        }
    }
}