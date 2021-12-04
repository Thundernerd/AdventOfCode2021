using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2021
{
    public interface ICustomServiceBuilder
    {
        void Build(IServiceCollection services);
    }
}