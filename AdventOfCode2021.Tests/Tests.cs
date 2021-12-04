using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day1;
using AdventOfCode2021.Day1.PartOne;
using AdventOfCode2021.Day1.PartTwo;
using AdventOfCode2021.Day2.PartOne;
using AdventOfCode2021.Day2.PartTwo;
using AdventOfCode2021.Day2.Shared;
using AdventOfCode2021.Day2.Shared.Abstraction;
using AdventOfCode2021.Day2.Shared.Implementation;
using AdventOfCode2021.Day3.PartOne;
using AdventOfCode2021.Day3.PartTwo;
using AdventOfCode2021.Day3.Shared;
using AdventOfCode2021.Day4.PartOne;
using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    public class Tests
    {
        [Test]
        public void Day1Part1()
        {
            DepthMeasurementIncrementCounter counter = new();

            List<IMeasurement> measurements = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }
                .Select(x => new SingleIntMeasurement(x))
                .Cast<IMeasurement>()
                .ToList();

            int result = counter.Calculate(measurements);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Day1Part2()
        {
            DepthMeasurementIncrementCounter counter = new();

            int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            List<IMeasurement> measurements = new();

            for (int i = 0; i < input.Length - 2; i++)
            {
                int first = input[i];
                int second = input[i + 1];
                int third = input[i + 2];

                measurements.Add(new ThreeIntMeasurement(first, second, third));
            }

            int result = counter.Calculate(measurements);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Day2Part1()
        {
            List<ICommandFactory> factories = new()
            {
                new DownCommandFactory(),
                new ForwardCommandFactory(),
                new UpCommandFactory()
            };

            CommandParser commandParser = new(factories);

            string input = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            IEnumerable<ICommand> commands = commandParser.ParseInput(input);

            PartOneSubmarine submarine = new();
            foreach (ICommand command in commands)
            {
                command.Execute(submarine);
            }

            Assert.AreEqual(150, submarine.Depth * submarine.HorizontalPosition);
        }

        [Test]
        public void Day2Part2()
        {
            List<ICommandFactory> factories = new()
            {
                new DownCommandFactory(),
                new ForwardCommandFactory(),
                new UpCommandFactory()
            };

            CommandParser commandParser = new(factories);

            string input = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            IEnumerable<ICommand> commands = commandParser.ParseInput(input);

            PartTwoSubmarine submarine = new();
            foreach (ICommand command in commands)
            {
                command.Execute(submarine);
            }

            Assert.AreEqual(900, submarine.Depth * submarine.HorizontalPosition);
        }

        [Test]
        public void Day3Part1()
        {
            string input = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";

            DiagnosticReport diagnosticReport = new();
            diagnosticReport.Parse(input);

            Assert.AreEqual(22, new GammaCalculator().Calculate(diagnosticReport));
            Assert.AreEqual(9, new EpsilonCalculator().Calculate(diagnosticReport));
            Assert.AreEqual(198, new PowerConsumptionCalculator().Calculate(diagnosticReport));
        }

        [Test]
        public void Day3Part2()
        {
            string input = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";

            DiagnosticReport diagnosticReport = new();
            diagnosticReport.Parse(input);

            Assert.AreEqual(23, new OxygenGeneratorRatingCalculator().Calculate(diagnosticReport));
            Assert.AreEqual(10, new Co2ScrubberRatingCalculator().Calculate(diagnosticReport));
            Assert.AreEqual(230, new LifeSupportRatingCalculator().Calculate(diagnosticReport));
        }

        [Test]
        public void Day4Part1()
        {
            string input =
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\n\n22 13 17 11  0\n 8  2 23  4 24\n21  9 14 16  7\n 6 10  3 18  5\n 1 12 20 15 19\n\n 3 15  0  2 22\n 9 18 13 17  5\n19  8  7 25 23\n20 11 10 24  4\n14 21 16 12  6\n\n14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7";

            NumberParser numberParser = new();
            List<int> numbers = numberParser.Parse(input);
            Assert.IsTrue(numbers.Count == 27);

            BoardParser boardParser = new();
            List<BingoBoard> boards = boardParser.Parse(input);
            Assert.IsTrue(boards.Count == 3);

            BingoBoard winningBoard = null;
            int lastNumber = -1;

            foreach (int number in numbers)
            {
                foreach (BingoBoard board in boards)
                {
                    board.MarkNumber(number);
                    if (board.HasBingo())
                    {
                        winningBoard = board;
                        break;
                    }
                }

                if (winningBoard != null)
                {
                    lastNumber = number;
                    break;
                }
            }

            List<int> unmarkedNumbers = winningBoard.GetUnmarkedNumbers();

            Assert.AreEqual(24, lastNumber);
            Assert.AreEqual(188, unmarkedNumbers.Sum());
            Assert.AreEqual(4512, unmarkedNumbers.Sum() * lastNumber);
        }
    }
}