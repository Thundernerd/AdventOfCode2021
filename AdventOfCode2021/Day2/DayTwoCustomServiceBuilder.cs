using AdventOfCode2021.Day2.Shared;
using AdventOfCode2021.Day2.Shared.Abstraction;
using AdventOfCode2021.Day2.Shared.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2021.Day2
{
    public class DayTwoCustomServiceBuilder : ICustomServiceBuilder
    {
        /// <inheritdoc />
        public void Build(IServiceCollection services)
        {
            services
                .AddTransient<CommandParser>()
                .AddSingleton<ICommandFactory, ForwardCommandFactory>()
                .AddSingleton<ICommandFactory, UpCommandFactory>()
                .AddSingleton<ICommandFactory, DownCommandFactory>();
        }
    }
}