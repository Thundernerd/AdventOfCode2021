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
    }
}