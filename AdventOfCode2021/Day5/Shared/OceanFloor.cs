using System;
using System.Drawing;

namespace AdventOfCode2021.Day5.Shared
{
    public class OceanFloor
    {
        private readonly int[,] grid;
        private readonly int width;
        private readonly int height;

        public OceanFloor(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new int[width, height];
        }

        public void PlotHydrothermalVentLine(Line line)
        {
            Point position = line.Start;
            int xSign = Math.Sign(line.End.X - line.Start.X);
            int ySign = Math.Sign(line.End.Y - line.Start.Y);

            while (position != line.End)
            {
                grid[position.X, position.Y] += 1;
                position.X += xSign;
                position.Y += ySign;
            }

            grid[line.End.X, line.End.Y] += 1;
        }

        public int AmountOfPointsWithNumberOfOverlaps(int minimumAmountOfOverlap)
        {
            int amount = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y] >= minimumAmountOfOverlap)
                        amount++;
                }
            }

            return amount;
        }

        public void Print()
        {
            for (int y = 0; y < height; y++)
            {
                string line = "";
                for (int x = 0; x < width; x++)
                {
                    line += grid[x, y];
                }

                Console.WriteLine(line);
            }
        }
    }
}