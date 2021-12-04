using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2021.Day4.Shared
{
    public class Day4CustomServiceBuilder : ICustomServiceBuilder
    {
        /// <inheritdoc />
        public void Build(IServiceCollection services)
        {
            services
                .AddSingleton<BoardSolver>()
                .AddSingleton<NumberParser>()
                .AddSingleton<BoardParser>();
        }
    }
}