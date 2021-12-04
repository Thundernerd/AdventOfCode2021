using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Day2.Shared.Abstraction;

namespace AdventOfCode2021.Day2.Shared
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> factories;

        public CommandParser(IEnumerable<ICommandFactory> factories)
        {
            this.factories = factories;
        }

        public IEnumerable<ICommand> ParseInput(string input)
        {
            List<ICommand> commands = new List<ICommand>();
            string[] splits = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string split in splits)
            {
                List<ICommandFactory> commandFactories = factories.Where(x => x.CanProcess(split))
                    .ToList();

                if (commandFactories.Count == 0)
                {
                    throw new Exception("No available command parser");
                }

                if (commandFactories.Count > 1)
                {
                    throw new Exception("Too many command parsers available!");
                }

                ICommand command = commandFactories.First().Create(split);
                commands.Add(command);
            }

            return commands;
        }
    }
}